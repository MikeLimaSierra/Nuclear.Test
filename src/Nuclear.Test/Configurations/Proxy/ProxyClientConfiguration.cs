using System;
using System.IO;

using Nuclear.Exceptions;
using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Configurations.Proxy {
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

        #endregion

        #region ctors

        internal ProxyClientConfiguration() : base() { }

        internal ProxyClientConfiguration(IProxyClientConfiguration original) : base(original) {
            Throw.If.Object.IsNull(original, nameof(original));

            AssembliesInSequence = original.AssembliesInSequence;
            SelectedRuntimes = original.SelectedRuntimes;
            WorkerDirectory = original.WorkerDirectory;
            WorkerExecutableName = original.WorkerExecutableName;
            Factory.Instance.Copy(out IWorkerRemoteConfiguration remoteConfig, original.WorkerRemoteConfiguration);
            WorkerRemoteConfiguration = remoteConfig;
        }

        #endregion

    }
}
