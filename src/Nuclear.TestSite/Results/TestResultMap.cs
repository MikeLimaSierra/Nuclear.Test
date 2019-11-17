using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Implements a threadsafe collection of <see cref="TestResultCollection"/> that maps to assembly name, <see cref="ProcessorArchitecture"/>, runtime version, class name and method name.
    /// </summary>
    public class TestResultMap : ConcurrentDictionary<TestResultKey, TestResultCollection>, IResultAggregation {

        #region properties

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        public Int32 ResultsTotal => GetResultsTotal(TestResultKey.Empty);

        /// <summary>
        /// Gets the number of successful results.
        /// </summary>
        public Int32 ResultsOk => GetResultsOk(TestResultKey.Empty);

        /// <summary>
        /// Gets the number of failed results.
        /// </summary>
        public Int32 ResultsFailed => GetResultsFailed(TestResultKey.Empty);

        /// <summary>
        /// Gets if the collection contains failed results.
        /// </summary>
        public Boolean HasFails => Values.Where(results => results.HasFails).Count() > 0;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestResultMap"/>.
        /// </summary>
        public TestResultMap() : base() { }

        /// <summary>
        /// Creates a new instance of <see cref="TestResultMap"/>.
        /// </summary>
        /// <param name="collection">The initial collection.</param>
        public TestResultMap(IEnumerable<KeyValuePair<TestResultKey, TestResultCollection>> collection) : base(collection) { }

        #endregion

        #region methods

        /// <summary>
        /// Adds the contents of another <see cref="TestResultMap"/> to this collection.
        /// </summary>
        /// <param name="results">The other <see cref="TestResultMap"/>.</param>
        public void AddRange(TestResultMap results) {
            foreach(KeyValuePair<TestResultKey, TestResultCollection> result in results) {
                AddOrUpdate(result.Key, result.Value, (TestResultKey key, TestResultCollection value) => result.Value);
            }
        }

        /// <summary>
        /// Gets a set of <see cref="TestResultCollection"/> that matches the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The <see cref="TestResultKey"/> used to filter results.</param>
        /// <returns>A set of <see cref="TestResultCollection"/> and their specific keys.</returns>
        public IEnumerable<KeyValuePair<TestResultKey, TestResultCollection>> FilterResults(TestResultKey key)
            => this.Where(kvp => key.Assembly == null || kvp.Key.Assembly == key.Assembly)
                   .Where(kvp => key.TargetRuntime == null || kvp.Key.TargetRuntime == key.TargetRuntime)
                   .Where(kvp => key.Architecture == ProcessorArchitecture.None || kvp.Key.Architecture == key.Architecture)
                   .Where(kvp => key.ExecutionRuntime == null || kvp.Key.ExecutionRuntime == key.ExecutionRuntime)
                   .Where(kvp => key.File == null || kvp.Key.File == key.File)
                   .Where(kvp => key.Method == null || kvp.Key.Method == key.Method);

        #endregion

        #region filter methods

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(TestResultKey key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsTotal);

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(TestResultKey key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsOk);

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(TestResultKey key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsFailed);

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(TestResultKey key) => FilterResults(key).Where(kvp => !String.IsNullOrWhiteSpace(kvp.Value.Exception)).Count() > 0;

        #endregion

    }
}
