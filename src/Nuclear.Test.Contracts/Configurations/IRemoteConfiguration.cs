using System;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IRemote"/>.
    /// </summary>
    public interface IRemoteConfiguration {

        /// <summary>
        /// Gets or sets if client process should be started in a visible window.
        /// </summary>
        Boolean StartClientVisible { get; set; }

    }
}
