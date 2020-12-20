using System;
using System.IO;

using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations {
    internal abstract class ClientConfiguration : IClientConfiguration {

        #region properties

        public FileInfo TestAssembly { get; set; }

        public Boolean AutoShutdown { get; set; }

        public Boolean WriteJsonResultFile { get; set; }

        #endregion

        #region ctors

        internal ClientConfiguration() { }

        internal ClientConfiguration(IClientConfiguration original) {
            Throw.If.Object.IsNull(original, nameof(original));

            TestAssembly = original.TestAssembly;
            AutoShutdown = original.AutoShutdown;
        }

        #endregion

    }
}
