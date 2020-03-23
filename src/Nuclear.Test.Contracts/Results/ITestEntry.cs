using System;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Represents a test entry.
    /// </summary>
    public interface ITestEntry {

        #region properties

        /// <summary>
        /// Gets the type of the test entry.
        /// </summary>
        EntryTypes EntryType { get; }

        /// <summary>
        /// Gets the name of the corresponding test instruction.
        /// </summary>
        String Instruction { get; }

        /// <summary>
        /// Gets the message of the corresponding test instruction.
        /// </summary>
        String Message { get; }

        #endregion
    }
}
