using Nuclear.Test.Execution.Worker;

namespace Nuclear.Test.Configurations.Worker {

    /// <summary>
    /// Implements configuration values for an <see cref="IWorkerRemote"/>.
    /// </summary>
    internal class WorkerRemoteConfiguration : RemoteConfiguration<IWorkerClientConfiguration>, IWorkerRemoteConfiguration { }
}
