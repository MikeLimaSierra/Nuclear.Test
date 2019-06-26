using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Represents the results of a number of executed test instructions (e.g. executed test method).
    /// </summary>
    [Serializable]
    public class TestResultCollection : List<TestResult>, IResultAggregation {

        #region properties

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        public Int32 ResultsTotal => Count;

        /// <summary>
        /// Gets the number of successful results.
        /// </summary>
        public Int32 ResultsOk => this.Where(result => result.Result).Count();

        /// <summary>
        /// Gets the number of failed results.
        /// </summary>
        public Int32 ResultsFailed => this.Where(result => !result.Result).Count();

        /// <summary>
        /// Gets if the collection contains failed results.
        /// </summary>
        public Boolean HasFails => Exception != null || ResultsFailed > 0;

        /// <summary>
        /// Gets or sets the <see cref="Exception"/> that was thrown during execution.
        /// </summary>
        public Exception Exception { get; set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestResultCollection"/>.
        /// </summary>
        public TestResultCollection() : base() { }

        /// <summary>
        /// Creates a new instance of <see cref="TestResultCollection"/>.
        /// </summary>
        /// <param name="capacity">The initial capacity.</param>
        public TestResultCollection(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Creates a new instance of <see cref="TestResultCollection"/>.
        /// </summary>
        /// <param name="collection">The initial collection of <see cref="TestResult"/>.</param>
        public TestResultCollection(IEnumerable<TestResult> collection) : base(collection) { }

        #endregion

    }
}
