using System;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IRemote"/>.
    /// </summary>
    public interface IRemoteConfiguration {

        /// <summary>
        /// Gets or sets if client processes should be started in visible windows.
        /// </summary>
        Boolean ShowClients { get; set; }

    }
}
