﻿using System;
using System.IO;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for a remote.
    /// </summary>
    internal abstract class RemoteConfiguration : IRemoteConfiguration {

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
