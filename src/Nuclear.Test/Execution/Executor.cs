using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

using log4net;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Execution.Proxy;
using Nuclear.Test.Helpers;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {
    internal class Executor : IExecutor {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Executor));

        private readonly List<String> _headerContent = new List<String>();

        private CountdownEvent _remotesFinishedEvent;

        #endregion

        #region properties

        /// <summary>
        /// Gets the client configuration object.
        /// </summary>
        public IExecutorConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        public ITestResultEndPoint Results { get; }

        #endregion

        #region ctors

        public Executor(IExecutorConfiguration configuration) {
            Throw.If.Object.IsNull(configuration, nameof(configuration));

            Configuration = configuration;

            Factory.Instance.Create(out ITestResultEndPoint results);
            Results = results;

            _headerContent.Add(@" _   _               _                    _____           _   ");
            _headerContent.Add(@"| \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_ ");
            _headerContent.Add(@"|  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|");
            _headerContent.Add(@"| |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_ ");
            _headerContent.Add(@"|_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|");
            _headerContent.Add(@"  ____                           _                            ");
            _headerContent.Add(@" / ___| ___   _ __   ___   ___  | |  ___                      ");
            _headerContent.Add(@"| |    / _ \ | '_ \ / __| / _ \ | | / _ \                     ");
            _headerContent.Add(@"| |___| (_) || | | |\__ \| (_) || ||  __/                     ");
            _headerContent.Add(@" \____|\___/ |_| |_||___/ \___/ |_| \___|                     ");
            _headerContent.Add(@"                                                              ");
        }

        #endregion

        #region event handlers

        private void OnResultsAvailable(Object sender, ResultsAvailableEventArgs e) {
            _log.Debug(nameof(OnResultsAvailable));

            if(sender is IProxyRemote remote) {
                remote.ResultsAvailable -= OnResultsAvailable;

            } else { _log.Error($"Failed to cast {nameof(sender)} to {nameof(IProxyRemote)}."); }

            Results.Add(e.Results);
        }

        private void OnRemotingFinished(Object sender, EventArgs e) {
            _log.Debug(nameof(OnRemotingFinished));

            if(sender is IProxyRemote remote) {
                remote.RemotingFinished -= OnRemotingFinished;
                remote.Dispose();

            } else { _log.Error($"Failed to cast {nameof(sender)} to {nameof(IProxyRemote)}."); }

            _remotesFinishedEvent.Signal();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Commands to execute.
        /// </summary>
        public void Execute() {
            _log.Debug(nameof(Execute));
            RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo currentRuntime);

            ConsoleHelper.SetConsoleTitle(currentRuntime);
            ConsoleHelper.PrintProcessInfo(currentRuntime, _headerContent);

            IEnumerable<IProxyRemoteInfo> remoteInfos = CreateRemoteInfos(Configuration.Assemblies);
            IEnumerable<IProxyRemote> remotes = CreateRemotes(remoteInfos);
            ExecuteRemotes(remotes);
        }

        #endregion

        #region private methods

        private IEnumerable<IProxyRemoteInfo> CreateRemoteInfos(IEnumerable<FileInfo> assemblies) {
            _log.Debug(nameof(CreateRemoteInfos));

            IList<IProxyRemoteInfo> infos = new List<IProxyRemoteInfo>();

            foreach(FileInfo assembly in assemblies.Where(a => a.Exists)) {
                if(AssemblyHelper.TryGetAssemblyName(assembly, out AssemblyName assemblyName)) {

                    foreach(ProcessorArchitecture architecture in GetArchitectures(assemblyName.ProcessorArchitecture)) {
                        String executablePath = Path.Combine(Environment.ExpandEnvironmentVariables(Configuration.ProxyDirectory.FullName),
                            architecture.ToString(),
                            Configuration.ProxyExecutableName);

                        Factory.Instance.Copy(out IProxyRemoteConfiguration proxyRemoteConfiguration, Configuration.ProxyRemoteConfiguration);
                        proxyRemoteConfiguration.ClientConfiguration.WorkerRemoteConfiguration.ClientConfiguration.TestAssembly = assembly;
                        proxyRemoteConfiguration.ClientConfiguration.WorkerRemoteConfiguration.Executable = assembly; // dummy, will be corrected on proxy level
                        proxyRemoteConfiguration.ClientConfiguration.TestAssembly = assembly;
                        proxyRemoteConfiguration.Executable = new FileInfo(executablePath);

                        Factory.Instance.Create(out IProxyRemoteInfo info, proxyRemoteConfiguration);

                        _log.Debug($"Defined proxy remote: {info.Format()}");

                        infos.Add(info);
                    }

                } else { _log.Error($"Could not load assembly name for {assembly.FullName.Format()}."); }
            }

            if(infos.Count > 0) {
                _log.Info($"Defined {infos.Count.Format()} proxy remotes.");

            } else { _log.Info("No remotes defined."); }

            return infos;
        }

        private IEnumerable<ProcessorArchitecture> GetArchitectures(ProcessorArchitecture architecture) {
            _log.Debug(nameof(GetArchitectures));

            IList<ProcessorArchitecture> architectures = new List<ProcessorArchitecture>();

            switch(architecture) {
                case ProcessorArchitecture.X86:
                case ProcessorArchitecture.Amd64:
                    architectures.Add(architecture);
                    break;

                case ProcessorArchitecture.MSIL:
                    architectures.Add(ProcessorArchitecture.X86);
                    architectures.Add(ProcessorArchitecture.Amd64);
                    break;

                default:
                    break;
            }

            _log.Info($"Chose {architectures.Count.Format()} architectures ({architectures.Format()}) to execute tests in assembly ({architecture.Format()})");

            return architectures;
        }

        private IEnumerable<IProxyRemote> CreateRemotes(IEnumerable<IProxyRemoteInfo> infos) {
            _log.Debug(nameof(CreateRemotes));

            IList<IProxyRemote> remotes = new List<IProxyRemote>();

            foreach(IProxyRemoteInfo info in infos) {
                Factory.Instance.Create(out IServerLink link);
                Factory.Instance.Create(out IProxyRemote remote, info.Configuration, link);

                remote.RemotingFinished += OnRemotingFinished;
                remote.ResultsAvailable += OnResultsAvailable;

                _log.Debug($"Created proxy remote: {info.Format()}");

                remotes.Add(remote);
            }

            if(remotes.Count > 0) {
                _log.Info($"Created {remotes.Count.Format()} proxy remotes.");

            } else { _log.Info("No remotes created."); }

            return remotes;
        }

        private void ExecuteRemotes(IEnumerable<IProxyRemote> remotes) {
            _log.Debug(nameof(ExecuteRemotes));
            _log.Info($"Execute {remotes.Count().Format()} {(Configuration.ProxyRemoteConfiguration.ClientConfiguration.AssembliesInSequence ? "sequential" : "parallel")} proxy remotes.");

            if(!Configuration.ProxyRemoteConfiguration.ClientConfiguration.AssembliesInSequence) {
                _remotesFinishedEvent = new CountdownEvent(remotes.Where(r => r.Configuration.HasExecutable).Count());
            }

            foreach(IProxyRemote remote in remotes) {
                if(!remote.Configuration.HasExecutable) {
                    _log.Info($"Skipping {remote.Format()} with missing executable.");

                    continue;
                }

                if(Configuration.ProxyRemoteConfiguration.ClientConfiguration.AssembliesInSequence) {
                    _remotesFinishedEvent = new CountdownEvent(1);
                }

                _log.Info($"Executing proxy remote {remote.Format()}.");

                remote.Execute();

                if(Configuration.ProxyRemoteConfiguration.ClientConfiguration.AssembliesInSequence) {
                    _log.Info($"Waiting for proxy remote {remote.Format()} to finish.");

                    _remotesFinishedEvent.Wait();
                }
            }

            if(!Configuration.ProxyRemoteConfiguration.ClientConfiguration.AssembliesInSequence) {
                _remotesFinishedEvent.Wait();
            }
        }

        #endregion

    }
}
