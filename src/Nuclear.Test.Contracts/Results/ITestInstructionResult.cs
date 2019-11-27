using System;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Represents the result of one exectued test instruction.
    /// </summary>
    public interface ITestInstructionResult {

        #region properties

        /// <summary>
        /// Gets if the corresponding test instruction was successful or not.
        ///    Null if the result entry is a note.
        /// </summary>
        Boolean? Result { get; }

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
