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
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Execution;
using Nuclear.Test.Execution.Proxy;
using Nuclear.Test.Helpers;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test.Console {
    internal class Executer {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Executer));

        private readonly Configuration _configuration;

        private readonly IFactory _factory;

        private readonly List<String> _headerContent = new List<String>();

        private readonly AssemblyLocator _locator;

        private CountdownEvent _remotesFinishedEvent;

        #endregion

        #region properties

        internal ITestResultEndPoint Results { get; }

        #endregion

        #region ctors

        public Executer(Configuration configuration, IFactory factory) {
            Throw.If.Object.IsNull(configuration, nameof(configuration));
            Throw.If.Object.IsNull(factory, nameof(factory));

            _configuration = configuration;
            _factory = factory;

            _factory.Create(out ITestResultEndPoint results);
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

            _locator = new AssemblyLocator() {
                SearchDirectory = new DirectoryInfo(Environment.ExpandEnvironmentVariables(_configuration.Locator.SearchDirectory)),
                SearchDepth = _configuration.Locator.SearchDepth,
                SearchPattern = _configuration.Locator.SearchPattern,
                IgnoredDirectoryNames = _configuration.Locator.IgnoredDirectoryNames
            };
        }

        #endregion

        #region event handlers

        private void OnResultsAvailable(Object sender, ResultsAvailableEventArgs e) {
            _log.Debug(nameof(OnResultsAvailable));

            if(sender is IProxyRemote remote) {
                remote.ResultsAvailable -= OnResultsAvailable;
                _log.Debug($"Failed to cast {nameof(sender)} to {nameof(IProxyRemote)}.");
            }

            Results.Add(e.Results);
        }

        private void OnRemotingFinished(Object sender, EventArgs e) {
            _log.Debug(nameof(OnRemotingFinished));

            if(sender is IProxyRemote remote) {
                remote.RemotingFinished -= OnRemotingFinished;
                _log.Debug($"Failed to cast {nameof(sender)} to {nameof(IProxyRemote)}.");
            }

            _remotesFinishedEvent.Signal();
        }

        #endregion

        #region methods

        internal void Execute() {
            RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo currentRuntime);

            ConsoleHelper.SetConsoleTitle(currentRuntime);
            ConsoleHelper.PrintProcessInfo(currentRuntime, _headerContent);

            IEnumerable<FileInfo> assemblies = _locator.DiscoverAssemblies();
            IEnumerable<IProxyRemoteInfo> remoteInfos = CreateRemoteInfos(assemblies);
            IEnumerable<IProxyRemote> remotes = CreateRemotes(remoteInfos);

            if(!_configuration.Execution.AssembliesInSequence) {
                _remotesFinishedEvent = new CountdownEvent(remotes.Where(r => r.Configuration.HasExecutable).Count());
            }

            foreach(IProxyRemote remote in remotes.Where(r => r.Configuration.HasExecutable)) {
                if(_configuration.Execution.AssembliesInSequence) {
                    _remotesFinishedEvent = new CountdownEvent(1);
                }

                remote.Execute();

                if(_configuration.Execution.AssembliesInSequence) {
                    _remotesFinishedEvent.Wait();
                }
            }

            _remotesFinishedEvent.Wait();
        }

        private IEnumerable<IProxyRemoteInfo> CreateRemoteInfos(IEnumerable<FileInfo> assemblies) {
            _log.Debug(nameof(CreateRemoteInfos));

            IList<IProxyRemoteInfo> remoteInfos = new List<IProxyRemoteInfo>();

            foreach(FileInfo assembly in assemblies.Where(a => a.Exists)) {
                if(AssemblyHelper.TryGetAssemblyName(assembly, out AssemblyName assemblyName)) {

                    foreach(ProcessorArchitecture architecture in GetArchitectures(assemblyName.ProcessorArchitecture)) {
                        String executablePath = Path.Combine(Environment.ExpandEnvironmentVariables(_configuration.Clients.ProxyDirectory),
                            architecture.ToString(),
                            _configuration.Clients.ProxyExecutableName);

                        _factory.Create(out IWorkerClientConfiguration workerClientConfig);
                        workerClientConfig.AutoShutdown = _configuration.Clients.AutoShutdown;
                        workerClientConfig.TestAssembly = assembly;
                        workerClientConfig.TestsInSequence = _configuration.Execution.TestsInSequence;

                        _factory.Create(out IWorkerRemoteConfiguration workerRemoteConfig);
                        workerRemoteConfig.ClientConfiguration = workerClientConfig;
                        workerRemoteConfig.Executable = null;
                        workerRemoteConfig.StartClientVisible = _configuration.Clients.StartClientVisible;

                        _factory.Create(out IProxyClientConfiguration proxyClientConfiguration);
                        proxyClientConfiguration.WorkerRemoteConfiguration = workerRemoteConfig;
                        proxyClientConfiguration.AssembliesInSequence = _configuration.Execution.AssembliesInSequence;
                        proxyClientConfiguration.AutoShutdown = _configuration.Clients.AutoShutdown;
                        proxyClientConfiguration.SelectedRuntimes = _configuration.Execution.SelectedRuntimes;
                        proxyClientConfiguration.TestAssembly = assembly;
                        proxyClientConfiguration.WorkerDirectory = new DirectoryInfo(Environment.ExpandEnvironmentVariables(_configuration.Clients.WorkerDirectory));
                        proxyClientConfiguration.WorkerExecutableName = _configuration.Clients.WorkerExecutableName;

                        _factory.Create(out IProxyRemoteConfiguration proxyRemoteConfiguration);
                        proxyRemoteConfiguration.ClientConfiguration = proxyClientConfiguration;
                        proxyRemoteConfiguration.Executable = new FileInfo(executablePath);
                        proxyRemoteConfiguration.StartClientVisible = _configuration.Clients.StartClientVisible;

                        _factory.Create(out IProxyRemoteInfo info, proxyRemoteConfiguration);
                        remoteInfos.Add(info);
                    }

                } else { _log.Error($"Could not load assembly name for {assembly.FullName.Format()}."); }
            }

            _log.Info("Could not find existing assemblies.");

            return remoteInfos;
        }

        private IEnumerable<ProcessorArchitecture> GetArchitectures(ProcessorArchitecture architecture) {
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

            return architectures;
        }

        private IEnumerable<IProxyRemote> CreateRemotes(IEnumerable<IProxyRemoteInfo> remoteInfos) {
            _log.Debug(nameof(CreateRemotes));

            IList<IProxyRemote> remotes = new List<IProxyRemote>();

            foreach(IProxyRemoteInfo remoteInfo in remoteInfos) {
                _factory.Create(out IServerLink link);
                _factory.Create(out IProxyRemote remote, remoteInfo.Configuration, link);

                remote.RemotingFinished += OnRemotingFinished;
                remote.ResultsAvailable += OnResultsAvailable;

                _log.Debug($"Remote created: {remoteInfo.Format()}");

                remotes.Add(remote);
            }

            _log.Info($"Created {remotes.Count} remotes.");

            return remotes;
        }

        #endregion

    }
}
