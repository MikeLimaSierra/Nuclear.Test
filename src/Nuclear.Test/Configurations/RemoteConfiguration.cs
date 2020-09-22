using System;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IRemote"/>.
    /// </summary>
    public class RemoteConfiguration : IRemoteConfiguration {

        #region constants

        /// <summary>
        /// Configuration values for <see cref="StartClientVisible"/>.
        /// </summary>
        public const String START_CLIENT_VISIBLE = "Remote.StartClientVisible";

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets if client process should be started in a visible window.
        /// </summary>
        public Boolean StartClientVisible { get; set; }

        #endregion

    }
}
