using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Execution.Proxy;

namespace Nuclear.Test.Configurations.Proxy {

    /// <summary>
    /// Defines configuration values for an <see cref="IProxyClient"/>.
    /// </summary>
    public interface IProxyClientConfiguration : IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets how assemblies should be executed.
        /// </summary>
        TestModeOverrides AssemblyModeOverride { get; set; }

        /// <summary>
        /// Gets or sets the runtimes that can be used.
        /// </summary>
        IEnumerable<RuntimeInfo> AvailableRuntimes { get; set; }

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
