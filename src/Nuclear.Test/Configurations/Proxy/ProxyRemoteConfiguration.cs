using Nuclear.Test.Execution.Proxy;

namespace Nuclear.Test.Configurations.Proxy {

    /// <summary>
    /// Implements configuration values for an <see cref="IProxyRemote"/>.
    /// </summary>
    internal class ProxyRemoteConfiguration : RemoteConfiguration<IProxyClientConfiguration>, IProxyRemoteConfiguration { }
}
