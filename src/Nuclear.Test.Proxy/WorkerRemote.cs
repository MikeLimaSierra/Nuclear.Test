using log4net;

using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;

namespace Nuclear.Test.Proxy {
    internal class WorkerRemote : Remote<IWorkerRemoteConfiguration, IWorkerClientConfiguration> {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(WorkerRemote));

        #endregion

        #region ctors

        internal WorkerRemote(IWorkerRemoteConfiguration remoteConfig, IWorkerClientConfiguration clientConfiguration, IServerLink link)
            : base(remoteConfig, clientConfiguration, link) { }

        #endregion

        #region methods

        protected override IMessage GetSetupMessage() {
            _log.Debug(nameof(GetSetupMessage));

            return base.GetSetupMessage().Append(ClientConfiguration);
        }

        #endregion

    }
}
