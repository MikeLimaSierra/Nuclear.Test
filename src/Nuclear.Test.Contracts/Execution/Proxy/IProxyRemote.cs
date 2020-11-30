using Nuclear.Test.Configurations.Proxy;

namespace Nuclear.Test.Execution.Proxy {

    /// <summary>
    /// Defines the base functionality of a remote control for proxy clients.
    /// </summary>
    public interface IProxyRemote : IRemote<IProxyRemoteConfiguration, IProxyClientConfiguration> { }
}
