using System;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for a proxy <see cref="IClient"/>.
    /// </summary>
    public class ProxyConfiguration : IProxyConfiguration {

        #region constants

        /// <summary>
        /// Configuration values for <see cref="AssembliesInSequence"/>.
        /// </summary>
        public const String ASSEMBLIES_IN_SEQUENCE = "Proxy.AssembliesInSequence";

        /// <summary>
        /// Configuration values for <see cref="SelectedRuntimes"/>.
        /// </summary>
        public const String SELECTED_RUNTIMES = "Proxy.SelectedRuntimes";

        #endregion

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

        #endregion

    }
}
