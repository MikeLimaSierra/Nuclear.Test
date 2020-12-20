using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Test.Configurations.Proxy;

namespace Nuclear.Test.Configurations {
    internal class ExecutorConfiguration : IExecutorConfiguration {

        #region properties

        public IEnumerable<FileInfo> Assemblies { get; set; }

        public IEnumerable<ProcessorArchitecture> AvailableArchitectures { get; set; }

        public DirectoryInfo ProxyDirectory { get; set; }

        public String ProxyExecutableName { get; set; }

        public IProxyRemoteConfiguration ProxyRemoteConfiguration { get; set; }

        public Boolean WriteJsonResultFile { get; set; }

        #endregion

    }
}
