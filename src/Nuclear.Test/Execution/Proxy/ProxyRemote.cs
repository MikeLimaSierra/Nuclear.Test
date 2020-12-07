using log4net;

using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Link;

namespace Nuclear.Test.Execution.Proxy {
    internal class ProxyRemote : Remote<IProxyRemoteConfiguration, IProxyClientConfiguration>, IProxyRemote {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(ProxyRemote));

        #endregion

        #region ctors

        public ProxyRemote(IProxyRemoteConfiguration configuration, IServerLink link)
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
