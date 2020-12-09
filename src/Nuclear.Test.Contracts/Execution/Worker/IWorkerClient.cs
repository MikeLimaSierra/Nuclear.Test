using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Execution.Worker {

    /// <summary>
    /// Defines the base functionality of a remote controlled worker client.
    /// </summary>
    public interface IWorkerClient : IClient<IWorkerClientConfiguration> { }
}
