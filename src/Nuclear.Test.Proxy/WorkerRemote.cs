using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;

namespace Nuclear.Test.Proxy {
    class WorkerRemote : Remote<IWorkerRemoteConfiguration> {

        #region fields

        IWorkerClientConfiguration _clientConfig;

        #endregion

        #region ctors

        public WorkerRemote(IWorkerRemoteConfiguration remoteConfig, IWorkerClientConfiguration clientConfig, IServerLink link)
            : base(remoteConfig, link) {

            Throw.If.Object.IsNull(clientConfig, nameof(clientConfig));

            _clientConfig = clientConfig;
        }

        #endregion

        #region methods

        public override void Execute() {
            if(Configuration.Executable != null && Configuration.Executable.Exists) {

                StartProcess();

            }
        }

        protected override IMessage GetSetupMessage(IMessage message) {
            message = base.GetSetupMessage(message);

            return message;
        }

        #endregion

    }
}
