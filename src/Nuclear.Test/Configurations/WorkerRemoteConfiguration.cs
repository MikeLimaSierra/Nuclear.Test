using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IWorkerRemote"/>.
    /// </summary>
    internal class WorkerRemoteConfiguration : RemoteConfiguration, IWorkerRemoteConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the client configuration object.
        /// </summary>
        public IWorkerClientConfiguration ClientConfiguration { get; set; }

        #endregion

    }
}
