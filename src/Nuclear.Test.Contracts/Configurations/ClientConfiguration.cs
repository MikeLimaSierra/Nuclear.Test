using System;
using System.IO;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Holds configuration values for an <see cref="IClient{TConfiguration}"/>.
    /// </summary>
    public abstract class ClientConfiguration {

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
        public Boolean AutoShutdown { get; set; } = true;

        /// <summary>
        /// Gets or sets if the client will write all results into a detailed report file.
        /// </summary>
        public Boolean WriteReport { get; set; } = false;

        #endregion

    }
}
