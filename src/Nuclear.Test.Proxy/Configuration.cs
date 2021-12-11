using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;

namespace Nuclear.Test.Proxy {

    /// <summary>
    /// Holds configuration values for an <see cref="IProxyClient"/>.
    /// </summary>
    public sealed class Configuration : ClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets how assemblies should be executed.
        /// </summary>
        public TestModeOverrides AssemblyModeOverride { get; set; } = TestModeOverrides.Auto;

        /// <summary>
        /// Gets or sets the runtimes that can be used.
        /// </summary>
        public IEnumerable<RuntimeInfo> AvailableRuntimes { get; set; }

        /// <summary>
        /// Gets or sets the selected runtimes that are used to execute tests.
        /// </summary>
        public SelectedExecutionRuntimes SelectedRuntimes { get; set; } = SelectedExecutionRuntimes.Reasonable;

        /// <summary>
        /// Gets or sets the directory that contains all workers.
        /// </summary>
        public DirectoryInfo WorkerDirectory { get; set; }

        /// <summary>
        /// Gets or sets the name of any worker executable.
        /// </summary>
        public String WorkerExecutableName { get; set; }

        #endregion

    }
}
