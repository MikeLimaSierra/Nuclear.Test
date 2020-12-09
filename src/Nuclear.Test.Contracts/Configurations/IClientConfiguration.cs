using System;
using System.IO;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IClient{TConfiguration}"/>.
    /// </summary>
    public interface IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the file path of the test assembly.
        /// </summary>
        FileInfo TestAssembly { get; set; }

        /// <summary>
        /// Gets or sets if client window will remain open after test execution.
        ///     If set to true, the client will automatically shut down.
        ///     If set to false, the client will will wait for console input.
        /// </summary>
        Boolean AutoShutdown { get; set; }

        #endregion

    }
}
