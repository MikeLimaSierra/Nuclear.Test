using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations.Proxy {
    internal class ProxyRemoteConfiguration : RemoteConfiguration<IProxyClientConfiguration>, IProxyRemoteConfiguration {

        #region ctors

        internal ProxyRemoteConfiguration() : base() { }

        internal ProxyRemoteConfiguration(IProxyRemoteConfiguration original) : base(original) {
            Throw.If.Object.IsNull(original, nameof(original));

            Factory.Instance.Copy(out IProxyClientConfiguration clientConfig, original.ClientConfiguration);
            ClientConfiguration = clientConfig;
        }

        #endregion

    }
}
