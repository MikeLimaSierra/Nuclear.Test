﻿using System;
using System.IO;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for a remote.
    /// </summary>
    public interface IRemoteConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the executable that the remote will start as a client.
        /// </summary>
        FileInfo Executable { get; set; }

        /// <summary>
        /// Gets or sets if client process should be started in a visible window.
        /// </summary>
        Boolean StartClientVisible { get; set; }

        #endregion

    }
}
