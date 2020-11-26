using Nuclear.Test.Configurations;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of a remote controlled proxy client.
    /// </summary>
    public interface IProxyClient : IClient<IProxyClientConfiguration> { }
}
