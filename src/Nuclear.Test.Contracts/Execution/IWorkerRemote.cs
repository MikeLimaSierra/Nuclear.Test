using Nuclear.Test.Configurations;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of a remote control for worker clients.
    /// </summary>
    public interface IWorkerRemote : IRemote<IWorkerRemoteConfiguration, IWorkerClientConfiguration> { }
}
