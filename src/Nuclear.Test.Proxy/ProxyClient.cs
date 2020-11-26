using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using log4net;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Helpers;
using Nuclear.Test.Link;

namespace Nuclear.Test.Proxy {
    internal class ProxyClient : Client<IProxyClientConfiguration>, IProxyClient {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(ProxyClient));

        private readonly IFactory _factory;

        private readonly CountdownEvent _remotesFinishedEvent = new CountdownEvent(0);

        #endregion

        #region ctors

        public ProxyClient(IClientLink link, IFactory factory)
            : base(link) {

            Throw.If.Object.IsNull(factory, nameof(factory));

            _factory = factory;

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

            if(sender is WorkerRemote remote) {
                remote.ResultsReceived -= OnResultsReceived;
                _log.Debug($"Failed to cast {nameof(sender)} to {nameof(WorkerRemote)}.");
            }

            SendResults(e);
        }

        private void OnResultsAvailable(Object sender, ResultsAvailableEventArgs e) {
            _log.Debug(nameof(OnResultsAvailable));

            if(sender is WorkerRemote remote) {
                remote.ResultsAvailable -= OnResultsAvailable;
                _log.Debug($"Failed to cast {nameof(sender)} to {nameof(WorkerRemote)}.");
            }

            Results.Add(e.Results);
        }

        private void OnRemotingFinished(Object sender, EventArgs e) {
            _log.Debug(nameof(OnRemotingFinished));

            if(sender is WorkerRemote remote) {
                remote.RemotingFinished -= OnRemotingFinished;
                _log.Debug($"Failed to cast {nameof(sender)} to {nameof(WorkerRemote)}.");
            }

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

            IEnumerable<RemoteInfo> remoteInfos = CreateRemoteInfos();
            ConsoleHelper.PrintWorkerRemotesInfo(remoteInfos.Select(r => (r.Runtime, r.HasExecutable, r.IsSelected)));
            IEnumerable<WorkerRemote> remotes = CreateRemotes(remoteInfos);

            foreach(WorkerRemote remote in remotes) {
                _remotesFinishedEvent.AddCount();

                remote.Execute();

                if(Configuration.AssembliesInSequence) {
                    _remotesFinishedEvent.Wait();
                }
            }

            _remotesFinishedEvent.Wait();

            SendFinished();
            Link.WaitForOutputFlush();
            RaiseExecutionFinished();
        }

        #endregion

        #region private methods

        private IEnumerable<RemoteInfo> CreateRemoteInfos() {
            _log.Debug(nameof(CreateRemoteInfos));

            if(RuntimesHelper.TryGetMatchingRuntimes(TestAssemblyRuntime, out IEnumerable<RuntimeInfo> matchingRuntimes)) {
                IEnumerable<RemoteInfo> remotes = matchingRuntimes.Select(r => new RemoteInfo(Configuration, r));

                Func<IEnumerable<Version>, Version> filter = Configuration.SelectedRuntimes == SelectedExecutionRuntimes.Highest ? Enumerable.Max : Enumerable.Min;

                IDictionary<FrameworkIdentifiers, Version> versionfilter = matchingRuntimes
                    .GroupBy(r => r.Framework)
                    .ToDictionary(g => g.Key, g => filter(g.Select(r => r.Version)));

                remotes.Foreach(r => r.IsSelected = r.HasExecutable && (Configuration.SelectedRuntimes == SelectedExecutionRuntimes.All || r.Runtime.Version == versionfilter[r.Runtime.Framework]));

                return remotes;
            }

            _log.Info($"Could not find matching runtimes for {TestAssemblyRuntime.Format()}.");

            return Enumerable.Empty<RemoteInfo>();
        }

        private IEnumerable<WorkerRemote> CreateRemotes(IEnumerable<RemoteInfo> remoteInfos) {
            _log.Debug(nameof(CreateRemotes));

            IList<WorkerRemote> remotes = new List<WorkerRemote>();

            foreach(RemoteInfo remoteInfo in remoteInfos.Where(r => r.IsSelected)) {
                _factory.Create(out IServerLink link);
                WorkerRemote remote = new WorkerRemote(Configuration.WorkerRemoteConfiguration, Configuration.WorkerClientConfiguration, link);
                remote.RemotingFinished += OnRemotingFinished;
                remote.ResultsReceived += OnResultsReceived;
                remote.ResultsAvailable += OnResultsAvailable;

                _log.Debug($"Remote created: {remoteInfo.Format()}");

                remotes.Add(remote);
            }

            _log.Info($"Created {remotes.Count} workers.");

            return remotes;
        }

        #endregion

    }
}
