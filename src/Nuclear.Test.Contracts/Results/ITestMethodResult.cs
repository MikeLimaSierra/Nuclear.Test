using System;
using System.Collections.Generic;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Represents the results of a number of executed test instructions (e.g. executed test method).
    /// </summary>
    public interface ITestMethodResult {

        #region properties

        /// <summary>
        /// Gets the list of <see cref="ITestEntry"/> for the corresponding test method.
        /// </summary>
        IList<ITestEntry> TestEntries { get; }

        /// <summary>
        /// Gets the total number of entries.
        /// </summary>
        Int32 CountEntries { get; }

        /// <summary>
        /// Gets the number of positive results.
        /// </summary>
        Int32 CountResultsOk { get; }

        /// <summary>
        /// Gets the number of negative results.
        /// </summary>
        Int32 CountResultsFailed { get; }

        /// <summary>
        /// Gets the reason why the test method is being ignored.
        /// </summary>
        String IgnoreReason { get; }
        

        /// <summary>
        /// Gets if the method is considered failed due to errors or negative test results.
        /// </summary>
        Boolean IsFailed { get; }

        /// <summary>
        /// Gets if the test method was ignored.
        /// </summary>
        Boolean IsIgnored { get; }

        /// <summary>
        /// Gets if the test method has no test results or errors.
        /// </summary>
        Boolean IsEmpty { get; }

        #endregion

        #region methods

        /// <summary>
        /// Sets the method to ignored.
        /// </summary>
        /// <param name="message">The reason why the test method is being ignored.</param>
        void Ignore(String message);

        #endregion

    }
}
