using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Represents the results of a number of executed test instructions (e.g. executed test method).
    /// </summary>
    public class TestMethodResult {

        #region properties

        /// <summary>
        /// Gets the list of <see cref="TestInstructionResult"/> for the corresponding test method.
        /// </summary>
        public IList<TestInstructionResult> InstructionResults { get; } = new List<TestInstructionResult>();

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        public Int32 CountResults => InstructionResults.Where(result => result.Result.HasValue).Count();

        /// <summary>
        /// Gets the number of successful results.
        /// </summary>
        public Int32 CountSuccesses => InstructionResults.Where(result => result.Result.HasValue && result.Result.Value).Count();

        /// <summary>
        /// Gets the number of failed results.
        /// </summary>
        public Int32 CountFails => InstructionResults.Where(result => result.Result.HasValue && !result.Result.Value).Count();

        /// <summary>
        /// Gets the message of the <see cref="Exception"/> that was thrown during execution.
        /// </summary>
        public String FailMessage { get; private set; }


        /// <summary>
        /// Gets if the collection contains failed results.
        /// </summary>
        public Boolean HasFails => CountFails > 0;

        /// <summary>
        /// Gets if an exceptional fail message has been recorded.
        /// </summary>
        public Boolean HasFailMessage => !String.IsNullOrWhiteSpace(FailMessage);

        /// <summary>
        /// Gets if the method is considered failed due to exceptions or negative test results.
        /// </summary>
        public Boolean Failed => HasFails || HasFailMessage;

        #endregion

        #region methods

        /// <summary>
        /// Sets the results to failed by setting an exception message.
        /// </summary>
        /// <param name="message">The message of the caught exception.</param>
        public void Fail(String message) => FailMessage = message;

        #endregion

    }
}
