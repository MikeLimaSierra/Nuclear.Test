using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IWorkerRemote"/>.
    /// </summary>
    internal class WorkerRemoteConfiguration : RemoteConfiguration<IWorkerClientConfiguration>, IWorkerRemoteConfiguration { }
}
