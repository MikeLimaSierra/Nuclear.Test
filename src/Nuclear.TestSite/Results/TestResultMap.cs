using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Implements a threadsafe collection of <see cref="TestResultCollection"/> that maps to <see cref="ProcessorArchitecture"/>, assembly name, class name and method name.
    /// </summary>
    [Serializable]
    public class TestResultMap : ConcurrentDictionary<Tuple<ProcessorArchitecture, String, String, String>, TestResultCollection>, IResultAggregation {

        #region properties

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        public Int32 ResultsTotal => Values.Sum(results => results.ResultsTotal);

        /// <summary>
        /// Gets the number of successful results.
        /// </summary>
        public Int32 ResultsOk => Values.Sum(results => results.ResultsOk);

        /// <summary>
        /// Gets the number of failed results.
        /// </summary>
        public Int32 ResultsFailed => Values.Sum(results => results.ResultsFailed);

        /// <summary>
        /// Gets if the collection contains failed results.
        /// </summary>
        public Boolean HasFails => Values.Where(results => results.Exception != null).Count() > 0 || ResultsFailed > 0;

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
        public TestResultMap(IEnumerable<KeyValuePair<Tuple<ProcessorArchitecture, String, String, String>, TestResultCollection>> collection) : base(collection) { }

        #endregion

        #region methods

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(Tuple<ProcessorArchitecture> key) => GetResultsTotal(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, null, null, null));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(Tuple<ProcessorArchitecture, String> key) => GetResultsTotal(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, null, null));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(Tuple<ProcessorArchitecture, String, String> key) => GetResultsTotal(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, key.Item3, null));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(Tuple<ProcessorArchitecture, String, String, String> key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsTotal);


        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(Tuple<ProcessorArchitecture> key) => GetResultsOk(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, null, null, null));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(Tuple<ProcessorArchitecture, String> key) => GetResultsOk(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, null, null));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(Tuple<ProcessorArchitecture, String, String> key) => GetResultsOk(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, key.Item3, null));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(Tuple<ProcessorArchitecture, String, String, String> key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsOk);


        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(Tuple<ProcessorArchitecture> key) => GetResultsFailed(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, null, null, null));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(Tuple<ProcessorArchitecture, String> key) => GetResultsFailed(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, null, null));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(Tuple<ProcessorArchitecture, String, String> key) => GetResultsFailed(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, key.Item3, null));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(Tuple<ProcessorArchitecture, String, String, String> key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsFailed);


        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(Tuple<ProcessorArchitecture> key) => HasFailedTests(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, null, null, null));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(Tuple<ProcessorArchitecture, String> key) => HasFailedTests(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, null, null));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(Tuple<ProcessorArchitecture, String, String> key) => HasFailedTests(Tuple.Create<ProcessorArchitecture, String, String, String>(key.Item1, key.Item2, key.Item3, null));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(Tuple<ProcessorArchitecture, String, String, String> key) => FilterResults(key).Where(kvp => kvp.Value.Exception != null).Count() > 0;


        private IEnumerable<KeyValuePair<Tuple<ProcessorArchitecture, String, String, String>, TestResultCollection>> FilterResults(Tuple<ProcessorArchitecture, String, String, String> key)
            => this.Where(kvp => kvp.Key.Item1 == key.Item1).Where(kvp => key.Item2 == null || kvp.Key.Item2 == key.Item2)
            .Where(kvp => key.Item3 == null || kvp.Key.Item3 == key.Item3).Where(kvp => key.Item4 == null || kvp.Key.Item4 == key.Item4);

        #endregion

    }
}
