using System;

namespace Nuclear.Test.Configurations {
    public class OutputConfiguration {

        #region constants

        public const String VERBOSITY = "Output.Verbosity";

        public const String SHOW_WORKERS = "Output.ShowWorkers";

        public const String WORKERS_AWAIT_INPUT = "Output.WorkersAwaitInput";

        public const String DIAGNOSTIC_OUTPUT = "Output.DiagnosticOutput";

        #endregion

        #region properties

        public Verbosity Verbosity { get; set; }

        public Boolean ShowWorkers { get; set; }

        public Boolean WorkersAwaitInput { get; set; }

        public Boolean DiagnosticOutput { get; set; }

        #endregion

    }
}
