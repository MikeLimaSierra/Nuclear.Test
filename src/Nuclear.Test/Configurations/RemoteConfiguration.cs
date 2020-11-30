using System;
using System.IO;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IRemote{TRemoteConfiguration, TClientConfiguration}"/>.
    /// </summary>
    /// <typeparam name="TClientConfiguration">The client configuration type.</typeparam>
    internal abstract class RemoteConfiguration<TClientConfiguration> : IRemoteConfiguration<TClientConfiguration>
        where TClientConfiguration : IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the executable that the remote will start as a client.
        /// </summary>
        public FileInfo Executable { get; set; }

        /// <summary>
        /// Gets if the executable is set and if it exists.
        /// </summary>
        public Boolean HasExecutable => Executable != null && Executable.Exists;

        /// <summary>
        /// Gets or sets if client process should be started in a visible window.
        /// </summary>
        public Boolean StartClientVisible { get; set; }

        /// <summary>
        /// Gets or sets the client configuration object.
        /// </summary>
        public TClientConfiguration ClientConfiguration { get; set; }

        #endregion

    }
}
