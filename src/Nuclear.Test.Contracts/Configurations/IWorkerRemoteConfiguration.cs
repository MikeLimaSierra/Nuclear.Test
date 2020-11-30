using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IWorkerRemote"/>.
    /// </summary>
    public interface IWorkerRemoteConfiguration : IRemoteConfiguration<IWorkerClientConfiguration> { }
}
