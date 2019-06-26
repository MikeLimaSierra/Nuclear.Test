using System;
using Nuclear.Exceptions;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Represents the result of one exectued test instruction.
    /// </summary>
    [Serializable]
    public class TestResult {

        #region fields

#pragma warning disable IDE0032 // Use auto property
        private Boolean _result;

        private String _testInstruction;

        private String _message;
#pragma warning restore IDE0032 // Use auto property

        #endregion

        #region properties

        /// <summary>
        /// Gets if the corresponding test instruction was successful or not.
        /// </summary>
        public Boolean Result { get => _result; private set => _result = value; }

        /// <summary>
        /// Gets the name of the corresponding test instruction.
        /// </summary>
        public String TestInstruction { get => _testInstruction; private set => _testInstruction = value; }

        /// <summary>
        /// Gets the message of the corresponding test instruction.
        /// </summary>
        public String Message { get => _message; private set => _message = value; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestResult"/>.
        /// </summary>
        /// <param name="result">The success state.</param>
        /// <param name="testInstruction">The test instruction.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="testInstruction"/> is null.</exception>
        /// <exception cref="ArgumentException">Throws if <paramref name="testInstruction"/> is empty of white space.</exception>
        public TestResult(Boolean result, String testInstruction, String message) {
            Throw.If.NullOrWhiteSpace(testInstruction, "testInstruction");

            Result = result;
            TestInstruction = testInstruction;
            Message = message;
        }

        #endregion

    }
}
