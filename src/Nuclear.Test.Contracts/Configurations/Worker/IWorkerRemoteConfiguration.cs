using Nuclear.Test.Execution.Worker;

namespace Nuclear.Test.Configurations.Worker {

    /// <summary>
    /// Defines configuration values for an <see cref="IWorkerRemote"/>.
    /// </summary>
    public interface IWorkerRemoteConfiguration : IRemoteConfiguration<IWorkerClientConfiguration> { }
}
