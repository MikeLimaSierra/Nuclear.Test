using System;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IClient"/>.
    /// </summary>
    public class ClientConfiguration : IClientConfiguration {

        #region constants

        /// <summary>
        /// Configuration values for <see cref="AutoShutdown"/>.
        /// </summary>
        public const String AUTO_SHUTDOWN = "Client.AutoShutdown";

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets if client window will remain open after test execution.
        ///     If set to true, the client will automatically shut down.
        ///     If set to false, the client will will wait for console input.
        /// </summary>
        public Boolean AutoShutdown { get; set; }

        #endregion

    }
}
