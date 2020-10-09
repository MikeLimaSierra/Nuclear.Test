using System;
using System.IO;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IRemote{TConfiguration}"/>.
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
        /// Gets or sets the executable that the remote will start as a client.
        /// </summary>
        public FileInfo Executable { get; set; }

        /// <summary>
        /// Gets or sets if client process should be started in a visible window.
        /// </summary>
        public Boolean StartClientVisible { get; set; }

        #endregion

    }
}
