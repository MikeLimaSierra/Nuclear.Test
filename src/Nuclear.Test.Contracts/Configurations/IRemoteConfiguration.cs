using System;
using System.IO;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IRemote{TRemoteConfiguration, TClientConfiguration}"/>.
    /// </summary>
    /// <typeparam name="TClientConfiguration">The client configuration type.</typeparam>
    public interface IRemoteConfiguration<TClientConfiguration>
        where TClientConfiguration : IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the executable that the remote will start as a client.
        /// </summary>
        FileInfo Executable { get; set; }

        /// <summary>
        /// Gets or sets if client process should be started in a visible window.
        /// </summary>
        Boolean StartClientVisible { get; set; }

        /// <summary>
        /// Gets or sets the client configuration object.
        /// </summary>
        TClientConfiguration ClientConfiguration { get; set; }

        #endregion

    }
}
