using System;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines legit exit codes for Nuclear.Test processes
    /// </summary>
    public enum ExitCode : Int32 {

        /// <summary>
        /// All tests succeeded.
        /// </summary>
        OK = 0,

        /// <summary>
        /// One or more tests failed.
        /// </summary>
        Fail = 1,
    }
}
