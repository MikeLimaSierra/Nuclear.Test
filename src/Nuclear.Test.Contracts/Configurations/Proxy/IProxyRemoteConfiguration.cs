using Nuclear.Test.Execution.Proxy;

namespace Nuclear.Test.Configurations.Proxy {

    /// <summary>
    /// Defines configuration values for an <see cref="IProxyRemote"/>.
    /// </summary>
    public interface IProxyRemoteConfiguration : IRemoteConfiguration<IProxyClientConfiguration> { }
}
