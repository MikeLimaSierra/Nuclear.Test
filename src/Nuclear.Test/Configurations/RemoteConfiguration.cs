using System;
using System.IO;

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

        internal RemoteConfiguration() : this(null) { }

        internal RemoteConfiguration(IRemoteConfiguration<TClientConfiguration> original) {
            if(original != null) {
                Executable = original.Executable;
                StartClientVisible = original.StartClientVisible;
            }
        }

        #endregion

    }
}
