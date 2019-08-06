using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Implements a threadsafe collection of <see cref="TestResultCollection"/> that maps to assembly name, <see cref="ProcessorArchitecture"/>, runtime version, class name and method name.
    /// </summary>
    public class TestResultMap : ConcurrentDictionary<ResultKeyMethodLevel, TestResultCollection>, IResultAggregation {

        #region properties

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        public Int32 ResultsTotal => GetResultsTotal(ResultKeyMethodLevel.Empty);

        /// <summary>
        /// Gets the number of successful results.
        /// </summary>
        public Int32 ResultsOk => GetResultsOk(ResultKeyMethodLevel.Empty);

        /// <summary>
        /// Gets the number of failed results.
        /// </summary>
        public Int32 ResultsFailed => GetResultsFailed(ResultKeyMethodLevel.Empty);

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
        public TestResultMap(IEnumerable<KeyValuePair<ResultKeyMethodLevel, TestResultCollection>> collection) : base(collection) { }

        #endregion

        #region methods

        public void AddRange(TestResultMap results) {
            foreach(KeyValuePair<ResultKeyMethodLevel, TestResultCollection> result in results) {
                AddOrUpdate(result.Key, result.Value, (ResultKeyMethodLevel key, TestResultCollection value) => result.Value);
            }
        }

        #endregion

        #region filter methods

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyAssemblyLevel key) => GetResultsTotal(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyArchitectureLevel key) => GetResultsTotal(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyRuntimeLevel key) => GetResultsTotal(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyFileLevel key) => GetResultsTotal(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyMethodLevel key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsTotal);


        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyAssemblyLevel key) => GetResultsOk(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyArchitectureLevel key) => GetResultsOk(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyRuntimeLevel key) => GetResultsOk(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyFileLevel key) => GetResultsOk(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyMethodLevel key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsOk);


        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyAssemblyLevel key) => GetResultsFailed(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyArchitectureLevel key) => GetResultsFailed(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyRuntimeLevel key) => GetResultsFailed(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyFileLevel key) => GetResultsFailed(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyMethodLevel key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsFailed);


        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyAssemblyLevel key) => HasFailedTests(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyArchitectureLevel key) => HasFailedTests(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyRuntimeLevel key) => HasFailedTests(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyFileLevel key) => HasFailedTests(new ResultKeyMethodLevel(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyMethodLevel key) => FilterResults(key).Where(kvp => !String.IsNullOrWhiteSpace(kvp.Value.Exception)).Count() > 0;


        private IEnumerable<KeyValuePair<ResultKeyMethodLevel, TestResultCollection>> FilterResults(ResultKeyMethodLevel key)
            => this.Where(kvp => key.Assembly == null || kvp.Key.Assembly == key.Assembly)
                   .Where(kvp => key.Architecture == ProcessorArchitecture.None || kvp.Key.Architecture == key.Architecture)
                   .Where(kvp => key.Runtime == null || kvp.Key.Runtime == key.Runtime)
                   .Where(kvp => key.File == null || kvp.Key.File == key.File)
                   .Where(kvp => key.Method == null || kvp.Key.Method == key.Method);

        #endregion

    }
}
