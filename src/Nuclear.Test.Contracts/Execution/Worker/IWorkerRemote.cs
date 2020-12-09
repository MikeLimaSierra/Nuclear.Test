using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Execution.Worker {

    /// <summary>
    /// Defines the base functionality of a remote control for worker clients.
    /// </summary>
    public interface IWorkerRemote : IRemote<IWorkerRemoteConfiguration, IWorkerClientConfiguration> { }
}
