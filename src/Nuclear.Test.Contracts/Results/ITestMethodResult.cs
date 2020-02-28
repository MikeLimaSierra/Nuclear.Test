using System;
using System.Collections.Generic;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Represents the results of a number of executed test instructions (e.g. executed test method).
    /// </summary>
    public interface ITestMethodResult {

        #region properties

        /// <summary>
        /// Gets the list of <see cref="ITestInstructionResult"/> for the corresponding test method.
        /// </summary>
        IList<ITestInstructionResult> InstructionResults { get; }

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        Int32 CountResults { get; }

        /// <summary>
        /// Gets the number of successful results.
        /// </summary>
        Int32 CountSuccesses { get; }

        /// <summary>
        /// Gets the number of failed results.
        /// </summary>
        Int32 CountFails { get; }

        /// <summary>
        /// Gets the message of the <see cref="Exception"/> that was thrown during execution.
        /// </summary>
        String FailMessage { get; }

        /// <summary>
        /// Gets the reason why the test method is being ignored.
        /// </summary>
        String IgnoreReason { get; }


        /// <summary>
        /// Gets if the collection contains failed results.
        /// </summary>
        Boolean HasFails { get; }

        /// <summary>
        /// Gets if an exceptional fail message has been recorded.
        /// </summary>
        Boolean HasFailMessage { get; }

        /// <summary>
        /// Gets if the method is considered failed due to exceptions or negative test results.
        /// </summary>
        Boolean Failed { get; }

        /// <summary>
        /// Gets if the test method was ignored.
        /// </summary>
        Boolean IsIgnored { get; }

        #endregion

        #region methods

        /// <summary>
        /// Sets the results to failed by setting an exception message.
        /// </summary>
        /// <param name="message">The message of the caught exception.</param>
        void Fail(String message);

        /// <summary>
        /// Sets the results to ignored.
        /// </summary>
        /// <param name="message">The reason why the testmethod is being ignored.</param>
        void Ignore(String message);

        #endregion

    }
}
