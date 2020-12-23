using System;
using System.IO;

using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations {
    internal abstract class RemoteConfiguration<TClientConfiguration> : IRemoteConfiguration<TClientConfiguration>
        where TClientConfiguration : IClientConfiguration {

        #region properties

        public FileInfo Executable { get; set; }

        public Boolean HasExecutable => Executable != null && Executable.Exists;

        public Boolean StartClientVisible { get; set; }

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
