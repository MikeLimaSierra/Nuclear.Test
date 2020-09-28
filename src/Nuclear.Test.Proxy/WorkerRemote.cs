
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;

namespace Nuclear.Test.Proxy {
    class WorkerRemote : Remote {

        #region ctors

        public WorkerRemote(IRemoteConfiguration remoteConfig, IClientConfiguration clientConfig, IServerLink link)
            : base(remoteConfig, clientConfig, link) {

        }

        #endregion

        #region methods

        public override void Execute() {
            throw new System.NotImplementedException();
        }

        protected override IMessage GetSetupMessage(IMessage message) {
            message = base.GetSetupMessage(message);

            return message;
        }

        #endregion

    }
}
