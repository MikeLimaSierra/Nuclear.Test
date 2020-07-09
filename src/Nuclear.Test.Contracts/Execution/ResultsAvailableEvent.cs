using System;
using System.Collections.Generic;

using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// An event handler delegate to handle <see cref="ResultsAvailableEventArgs"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    public delegate void ResultsAvailableEventHandler(Object sender, ResultsAvailableEventArgs e);

    /// <summary>
    /// An event holding a collection of test results.
    /// </summary>
    public class ResultsAvailableEventArgs : EventArgs {

        #region properties

        /// <summary>
        /// Gets the collection of test results.
        /// </summary>
        public IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> Results { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates an instance of <see cref="ResultsAvailableEventArgs"/>.
        /// </summary>
        /// <param name="results">The collection of test results.</param>
        public ResultsAvailableEventArgs(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results) {
            Results = results;
        }

        #endregion

    }
}
