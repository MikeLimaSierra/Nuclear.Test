using System;
using Nuclear.Test.ConsolePrinter;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Holds configuration values for output.
    /// </summary>
    public class OutputConfiguration {

        #region constants

        /// <summary>
        /// Configuration values for Verbosity.
        /// </summary>
        public const String VERBOSITY = "Output.Verbosity";

        /// <summary>
        /// Configuration values for ShowClients.
        /// </summary>
        public const String SHOW_CLIENTS = "Output.ShowClients";

        /// <summary>
        /// Configuration values for ClientsAwaitInput.
        /// </summary>
        public const String CLIENTS_AWAIT_INPUT = "Output.ClientsAwaitInput";

        /// <summary>
        /// Configuration values for DiagnosticOutput.
        /// </summary>
        public const String DIAGNOSTIC_OUTPUT = "Output.DiagnosticOutput";

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the verbosity of the results output.
        /// </summary>
        public PrintVerbosity Verbosity { get; set; }

        /// <summary>
        /// Gets or sets if client processes should be started in visible windows.
        /// </summary>
        public Boolean ShowClients { get; set; }

        /// <summary>
        /// Gets or sets if client windows will remain open after test execution.
        ///     If set to true, visible workers will wait for input to exit.
        /// </summary>
        public Boolean ClientsAwaitInput { get; set; }

        /// <summary>
        /// Gets or sets if diagnostic output should be visible in servers and clients.
        /// </summary>
        public Boolean DiagnosticOutput { get; set; }

        #endregion

    }
}
