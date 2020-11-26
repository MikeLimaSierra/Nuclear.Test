using Nuclear.Test.Configurations;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of a remote controlled worker client.
    /// </summary>
    public interface IWorkerClient : IClient<IWorkerClientConfiguration> { }
}
