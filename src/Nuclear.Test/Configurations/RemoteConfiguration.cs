using System;
using System.IO;

using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations {
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

        #region ctors

        internal RemoteConfiguration() { }

        internal RemoteConfiguration(IRemoteConfiguration<TClientConfiguration> original) {
            Throw.If.Object.IsNull(original, nameof(original));

            Executable = original.Executable;
            StartClientVisible = original.StartClientVisible;
        }

        #endregion

    }
}
