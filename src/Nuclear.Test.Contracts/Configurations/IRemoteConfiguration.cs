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
        Boolean ClientIsVisible { get; set; }

        /// <summary>
        /// Gets or sets if client window will remain open after test execution.
        ///     If set to true, visible worker will wait for input before exit.
        /// </summary>
        public Boolean ClientStaysOpen { get; set; }

    }
}
