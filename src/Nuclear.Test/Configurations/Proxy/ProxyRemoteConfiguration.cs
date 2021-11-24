namespace Nuclear.Test.Configurations.Proxy {
    internal class ProxyRemoteConfiguration : RemoteConfiguration<IProxyClientConfiguration>, IProxyRemoteConfiguration {

        #region ctors

        internal ProxyRemoteConfiguration() : this(null) { }

        internal ProxyRemoteConfiguration(IProxyRemoteConfiguration original) : base(original) {
            if(original != null) {
                Factory.Instance.Copy(out IProxyClientConfiguration clientConfig, original.ClientConfiguration);
                ClientConfiguration = clientConfig;
            }
        }

        #endregion

    }
}
