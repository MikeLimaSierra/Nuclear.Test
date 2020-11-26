using System;
using System.IO;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for a proxy client.
    /// </summary>
    internal class ProxyClientConfiguration : ClientConfiguration, IProxyClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets if assemblies should all be executed in a sequence.
        ///     If set to true, there will only be one worker running at a time.
        ///     If set to false, all proxies and workers will start immediately.
        /// </summary>
        public Boolean AssembliesInSequence { get; set; }

        /// <summary>
        /// Gets or sets the selected runtimes that are used to execute tests.
        /// </summary>
        public SelectedExecutionRuntimes SelectedRuntimes { get; set; }

        /// <summary>
        /// Gets or sets the directory that contains all workers.
        /// </summary>
        public DirectoryInfo WorkerDirectory { get; set; }

        /// <summary>
        /// Gets or sets the name of any worker executable.
        /// </summary>
        public String WorkerExecutableName { get; set; }

        /// <summary>
        /// Gets or sets the worker remote configuration object.
        /// </summary>
        public IWorkerRemoteConfiguration WorkerRemoteConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the worker client configuration object.
        /// </summary>
        public IWorkerClientConfiguration WorkerClientConfiguration { get; set; }

        #endregion

    }
}
