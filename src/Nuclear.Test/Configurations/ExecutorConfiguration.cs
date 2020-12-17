using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Test.Configurations.Proxy;

namespace Nuclear.Test.Configurations {
    internal class ExecutorConfiguration : IExecutorConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the test assemblies that should be executed.
        /// </summary>
        public IEnumerable<FileInfo> Assemblies { get; set; }

        /// <summary>
        /// Gets or sets the processor architectures that can be used.
        /// </summary>
        public IEnumerable<ProcessorArchitecture> AvailableArchitectures { get; set; }

        /// <summary>
        /// Gets or sets the directory that contains all workers.
        /// </summary>
        public DirectoryInfo ProxyDirectory { get; set; }

        /// <summary>
        /// Gets or sets the name of any worker executable.
        /// </summary>
        public String ProxyExecutableName { get; set; }

        /// <summary>
        /// Gets or sets the worker remote configuration object.
        /// </summary>
        public IProxyRemoteConfiguration ProxyRemoteConfiguration { get; set; }

        #endregion

    }
}
