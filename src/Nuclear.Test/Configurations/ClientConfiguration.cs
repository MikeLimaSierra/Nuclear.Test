using System;
using System.IO;

using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations {
    internal abstract class ClientConfiguration : IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the file path of the test assembly.
        /// </summary>
        public FileInfo TestAssembly { get; set; }

        /// <summary>
        /// Gets or sets if client window will remain open after test execution.
        ///     If set to true, the client will automatically shut down.
        ///     If set to false, the client will will wait for console input.
        /// </summary>
        public Boolean AutoShutdown { get; set; }

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
