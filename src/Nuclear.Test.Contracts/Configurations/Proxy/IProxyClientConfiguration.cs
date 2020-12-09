using System;
using System.IO;

using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Execution.Proxy;

namespace Nuclear.Test.Configurations.Proxy {

    /// <summary>
    /// Defines configuration values for an <see cref="IProxyClient"/>.
    /// </summary>
    public interface IProxyClientConfiguration : IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets if assemblies should all be executed in a sequence.
        ///     If set to true, there will only be one worker running at a time.
        ///     If set to false, all proxies and workers will start immediately.
        /// </summary>
        Boolean AssembliesInSequence { get; set; }

        /// <summary>
        /// Gets or sets the selected runtimes that are used to execute tests.
        /// </summary>
        SelectedExecutionRuntimes SelectedRuntimes { get; set; }

        /// <summary>
        /// Gets or sets the directory that contains all workers.
        /// </summary>
        DirectoryInfo WorkerDirectory { get; set; }

        /// <summary>
        /// Gets or sets the name of any worker executable.
        /// </summary>
        String WorkerExecutableName { get; set; }

        /// <summary>
        /// Gets or sets the worker remote configuration object.
        /// </summary>
        IWorkerRemoteConfiguration WorkerRemoteConfiguration { get; set; }

        #endregion

    }
}
