using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IWorkerRemote"/>.
    /// </summary>
    public interface IWorkerRemoteConfiguration : IRemoteConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the client configuration object.
        /// </summary>
        IWorkerClientConfiguration ClientConfiguration { get; set; }

        #endregion

    }
}
