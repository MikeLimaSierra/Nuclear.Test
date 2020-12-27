using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Configurations.Proxy {
    internal class ProxyClientConfiguration : ClientConfiguration, IProxyClientConfiguration {

        #region properties

        public TestModeOverrides AssemblyModeOverride { get; set; }

        public IEnumerable<RuntimeInfo> AvailableRuntimes { get; set; }

        public SelectedExecutionRuntimes SelectedRuntimes { get; set; }

        public DirectoryInfo WorkerDirectory { get; set; }

        public String WorkerExecutableName { get; set; }

        public IWorkerRemoteConfiguration WorkerRemoteConfiguration { get; set; }

        #endregion

        #region ctors

        internal ProxyClientConfiguration() : base() { }

        internal ProxyClientConfiguration(IProxyClientConfiguration original) : base(original) {
            Throw.If.Object.IsNull(original, nameof(original));

            AssemblyModeOverride = original.AssemblyModeOverride;
            AvailableRuntimes = original.AvailableRuntimes;
            SelectedRuntimes = original.SelectedRuntimes;
            WorkerDirectory = original.WorkerDirectory;
            WorkerExecutableName = original.WorkerExecutableName;
            Factory.Instance.Copy(out IWorkerRemoteConfiguration remoteConfig, original.WorkerRemoteConfiguration);
            WorkerRemoteConfiguration = remoteConfig;
        }

        #endregion

    }
}
