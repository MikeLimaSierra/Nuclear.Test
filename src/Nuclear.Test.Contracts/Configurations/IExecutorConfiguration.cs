using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IExecutor"/>.
    /// </summary>
    public interface IExecutorConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the test assemblies that should be executed.
        /// </summary>
        IEnumerable<FileInfo> Assemblies { get; set; }

        /// <summary>
        /// Gets or sets the directory that contains all workers.
        /// </summary>
        DirectoryInfo ProxyDirectory { get; set; }

        /// <summary>
        /// Gets or sets the name of any worker executable.
        /// </summary>
        String ProxyExecutableName { get; set; }

        /// <summary>
        /// Gets or sets the worker remote configuration object.
        /// </summary>
        IProxyRemoteConfiguration ProxyRemoteConfiguration { get; set; }

        #endregion

    }
}
