using Nuclear.Test.Configurations.Proxy;

namespace Nuclear.Test.Execution.Proxy {

    /// <summary>
    /// Defines the base functionality of a remote controlled proxy client.
    /// </summary>
    public interface IProxyClient : IClient<IProxyClientConfiguration> { }
}
