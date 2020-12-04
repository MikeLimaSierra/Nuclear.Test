using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using log4net;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Execution.Worker;
using Nuclear.Test.Helpers;
using Nuclear.Test.Link;

namespace Nuclear.Test.Execution.Proxy {
    internal class ProxyClient : Client<IProxyClientConfiguration>, IProxyClient {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(ProxyClient));

        private CountdownEvent _remotesFinishedEvent = new CountdownEvent(0);

        #endregion

        #region ctors

        public ProxyClient(IClientLink link)
            : base(link) {

            HeaderContent.Add(@" _   _               _                    _____           _   ");
            HeaderContent.Add(@"| \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_ ");
            HeaderContent.Add(@"|  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|");
            HeaderContent.Add(@"| |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_ ");
            HeaderContent.Add(@"|_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|");
            HeaderContent.Add(@" ____                                                         ");
            HeaderContent.Add(@"|  _ \  _ __  ___ __  __ _   _                                ");
            HeaderContent.Add(@"| |_) || '__|/ _ \\ \/ /| | | |                               ");
            HeaderContent.Add(@"|  __/ | |  | (_) |>  < | |_| |                               ");
            HeaderContent.Add(@"|_|    |_|   \___//_/\_\ \__, |                               ");
            HeaderContent.Add(@"                         |___/                                ");
        }

        #endregion

        #region event handlers

        private void OnResultsReceived(Object sender, ResultsReceivedEventArgs e) {
            _log.Debug(nameof(OnResultsReceived));

            if(sender is IWorkerRemote remote) {
                remote.ResultsReceived -= OnResultsReceived;

            } else { _log.Error($"Failed to cast {nameof(sender)} to {nameof(IWorkerRemote)}."); }

            SendResults(e);
        }

        private void OnResultsAvailable(Object sender, ResultsAvailableEventArgs e) {
            _log.Debug(nameof(OnResultsAvailable));

            if(sender is IWorkerRemote remote) {
                remote.ResultsAvailable -= OnResultsAvailable;

            } else { _log.Error($"Failed to cast {nameof(sender)} to {nameof(IWorkerRemote)}."); }

            Results.Add(e.Results);
        }

        private void OnRemotingFinished(Object sender, EventArgs e) {
            _log.Debug(nameof(OnRemotingFinished));

            if(sender is IWorkerRemote remote) {
                remote.RemotingFinished -= OnRemotingFinished;

            } else { _log.Error($"Failed to cast {nameof(sender)} to {nameof(IWorkerRemote)}."); }

            _remotesFinishedEvent.Signal();
        }

        #endregion

        #region methods

        protected override IProxyClientConfiguration LoadConfiguration(IMessage message) {
            _log.Debug(nameof(LoadConfiguration));

            if(message == null) {
                _log.Error($"{nameof(message)} is null.");
                return null;
            }

            if(message.TryGetData(out IProxyClientConfiguration config)) {
                return config;

            } else {
                _log.Error($"{nameof(message)} doesn't contain a configuration object.");

                return null;
            }
        }

        protected override void Execute() {
            _log.Debug(nameof(Execute));

            base.Execute();

            IEnumerable<IWorkerRemoteInfo> remoteInfos = CreateRemoteInfos();
            ConsoleHelper.PrintWorkerRemotesInfo(remoteInfos.Select(r => (r.Runtime, r.Configuration.HasExecutable, r.IsSelected)));
            IEnumerable<IWorkerRemote> remotes = CreateRemotes(remoteInfos);
            ExecuteRemotes(remotes);

            SendFinished();
            Link.WaitForOutputFlush();
            RaiseExecutionFinished();
        }

        #endregion

        #region private methods

        private IEnumerable<IWorkerRemoteInfo> CreateRemoteInfos() {
            _log.Debug(nameof(CreateRemoteInfos));

            IList<IWorkerRemoteInfo> infos = new List<IWorkerRemoteInfo>();

            if(RuntimesHelper.TryGetMatchingRuntimes(TestAssemblyRuntime, out IEnumerable<RuntimeInfo> matchingRuntimes)) {

                Func<IEnumerable<Version>, Version> filter = Configuration.SelectedRuntimes == SelectedExecutionRuntimes.Highest ? Enumerable.Max : Enumerable.Min;
                IDictionary<FrameworkIdentifiers, Version> versionfilter = matchingRuntimes
                    .GroupBy(r => r.Framework)
                    .ToDictionary(g => g.Key, g => filter(g.Select(r => r.Version)));

                _log.Debug($"Selected versions are {versionfilter.Format()}.");

                foreach(RuntimeInfo runtime in matchingRuntimes) {
                    Factory.Instance.Create(out IWorkerRemoteInfo info, Configuration, runtime);
                    info.IsSelected = info.Configuration.HasExecutable && (Configuration.SelectedRuntimes == SelectedExecutionRuntimes.All || info.Runtime.Version == versionfilter[info.Runtime.Framework]);

                    _log.Debug($"Created worker remote: {info.Format()}");

                    infos.Add(info);
                }
            }

            if(infos.Count > 0) {
                _log.Info($"Defined {infos.Count.Format()} worker remotes.");

            } else { _log.Info("No remotes defined."); }

            return infos;
        }

        private IEnumerable<IWorkerRemote> CreateRemotes(IEnumerable<IWorkerRemoteInfo> infos) {
            _log.Debug(nameof(CreateRemotes));

            IList<IWorkerRemote> remotes = new List<IWorkerRemote>();

            foreach(IWorkerRemoteInfo info in infos.Where(r => r.IsSelected)) {
                Factory.Instance.Create(out IServerLink link);
                Factory.Instance.Create(out IWorkerRemote remote, info.Configuration, link);

                remote.RemotingFinished += OnRemotingFinished;
                remote.ResultsReceived += OnResultsReceived;
                remote.ResultsAvailable += OnResultsAvailable;

                _log.Debug($"Remote created: {info.Format()}");

                remotes.Add(remote);
            }

            _log.Info($"Created {remotes.Count} remotes.");

            return remotes;
        }

        private void ExecuteRemotes(IEnumerable<IWorkerRemote> remotes) {
            _log.Debug(nameof(ExecuteRemotes));
            _log.Info($"Execute {remotes.Count().Format()} {(Configuration.AssembliesInSequence ? "sequential" : "parallel")} worker remotes.");

            if(!Configuration.AssembliesInSequence) {
                _remotesFinishedEvent = new CountdownEvent(remotes.Where(r => r.Configuration.HasExecutable).Count());
            }

            foreach(IWorkerRemote remote in remotes) {
                if(!remote.Configuration.HasExecutable) {
                    _log.Info($"Skipping {remote.Format()} with missing executable.");

                    continue;
                }

                if(Configuration.AssembliesInSequence) {
                    _remotesFinishedEvent = new CountdownEvent(1);
                }

                _log.Info($"Executing worker remote {remote.Format()}.");

                remote.Execute();

                if(Configuration.AssembliesInSequence) {
                    _log.Info($"Waiting for worker remote {remote.Format()} to finish.");

                    _remotesFinishedEvent.Wait();
                }
            }

            if(!Configuration.AssembliesInSequence) {
                _remotesFinishedEvent.Wait();
            }
        }

        #endregion

    }
}
