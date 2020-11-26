using log4net;

using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;

namespace Nuclear.Test.Console {
    internal class ProxyRemote : Remote<IProxyRemoteConfiguration, IProxyClientConfiguration> {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(ProxyRemote));

        #endregion

        #region ctors

        public ProxyRemote(IProxyRemoteConfiguration remoteConfig, IProxyClientConfiguration clientConfiguration, IServerLink link)
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
