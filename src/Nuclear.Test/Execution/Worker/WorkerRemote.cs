using log4net;

using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Link;

namespace Nuclear.Test.Execution.Worker {
    internal class WorkerRemote : Remote<IWorkerRemoteConfiguration, IWorkerClientConfiguration>, IWorkerRemote {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(WorkerRemote));

        #endregion

        #region ctors

        internal WorkerRemote(IWorkerRemoteConfiguration configuration, IServerLink link)
            : base(configuration, link) { }

        #endregion

        #region methods

        protected override IMessage GetSetupMessage() {
            _log.Debug(nameof(GetSetupMessage));

            return base.GetSetupMessage().Append(Configuration.ClientConfiguration);
        }

        #endregion

    }
}
