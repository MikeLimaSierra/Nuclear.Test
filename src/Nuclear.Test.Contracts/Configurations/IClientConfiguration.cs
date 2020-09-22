﻿using System;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IClient"/>.
    /// </summary>
    public interface IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets if client window will remain open after test execution.
        ///     If set to true, the client will automatically shut down.
        ///     If set to false, the client will will wait for console input.
        /// </summary>
        Boolean AutoShutdown { get; set; }

        #endregion

    }
}
