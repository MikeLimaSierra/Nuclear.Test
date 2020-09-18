using System;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IClient"/>.
    /// </summary>
    public interface IClientConfiguration {

        #region constants

        /// <summary>
        /// Configuration values for <see cref="AutoShutdown"/>.
        /// </summary>
        public String AUTO_SHUTDOWN { get; }

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
