using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IProxyRemote"/>.
    /// </summary>
    internal class ProxyRemoteConfiguration : RemoteConfiguration<IProxyClientConfiguration>, IProxyRemoteConfiguration { }
}
