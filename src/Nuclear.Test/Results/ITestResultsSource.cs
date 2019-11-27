using System.Collections.Generic;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines a result source.
    /// </summary>
    public interface ITestResultsSource {

        #region properties

        /// <summary>
        /// Gets all contained results and their corresponding keys.
        /// </summary>
        IEnumerable<KeyValuePair<TestResultKey, TestMethodResult>> Values { get; }

        /// <summary>
        /// Gets all available keys.
        /// </summary>
        IEnumerable<TestResultKey> Keys { get; }

        /// <summary>
        /// Gets all available results.
        /// </summary>
        IEnumerable<TestMethodResult> Results { get; }

        /// <summary>
        /// Gets the <see cref="TestMethodResult"/> to a specific <see cref="TestResultKey"/>.
        /// </summary>
        /// <param name="key">The given key that identifies results.</param>
        /// <returns>The results or an empty result collection if the key was not found.</returns>
        TestMethodResult this[TestResultKey key] { get; }

        #endregion

    }
}
