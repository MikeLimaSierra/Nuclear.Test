using Nuclear.Test.Configurations;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of a remote control for proxy clients.
    /// </summary>
    public interface IProxyRemote : IRemote<IProxyRemoteConfiguration, IProxyClientConfiguration> { }
}
