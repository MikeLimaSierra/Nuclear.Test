using System;
using System.Collections.Generic;
using Nuclear.Test.Results;

namespace Nuclear.Test {

    /// <summary>
    /// An event handler delegate to handle <see cref="TestResultsAvailableEventArgs"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    public delegate void TestResultsAvailableEventHandler(Object sender, TestResultsAvailableEventArgs e);

    /// <summary>
    /// An event holding a collection of test results.
    /// </summary>
    public class TestResultsAvailableEventArgs : EventArgs {

        #region properties

        /// <summary>
        /// Gets the collection of test results.
        /// </summary>
        public IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> Results { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates an instance of <see cref="TestResultsAvailableEventArgs"/>.
        /// </summary>
        /// <param name="results">The collection of test results.</param>
        public TestResultsAvailableEventArgs(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results) {
            Results = results;
        }

        #endregion

    }
}
