using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Implements a threadsafe collection of <see cref="TestResultCollection"/> that maps to assembly name, <see cref="ProcessorArchitecture"/>, runtime version, class name and method name.
    /// </summary>
    public class TestResultMap : ConcurrentDictionary<ResultKey, TestResultCollection>, IResultAggregation {

        #region properties

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        public Int32 ResultsTotal => GetResultsTotal(ResultKey.Empty);

        /// <summary>
        /// Gets the number of successful results.
        /// </summary>
        public Int32 ResultsOk => GetResultsOk(ResultKey.Empty);

        /// <summary>
        /// Gets the number of failed results.
        /// </summary>
        public Int32 ResultsFailed => GetResultsFailed(ResultKey.Empty);

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
        public TestResultMap(IEnumerable<KeyValuePair<ResultKey, TestResultCollection>> collection) : base(collection) { }

        #endregion

        #region methods

        /// <summary>
        /// Adds the contents of another <see cref="TestResultMap"/> to this collection.
        /// </summary>
        /// <param name="results">The other <see cref="TestResultMap"/>.</param>
        public void AddRange(TestResultMap results) {
            foreach(KeyValuePair<ResultKey, TestResultCollection> result in results) {
                AddOrUpdate(result.Key, result.Value, (ResultKey key, TestResultCollection value) => result.Value);
            }
        }

        private IEnumerable<KeyValuePair<ResultKey, TestResultCollection>> FilterResults(ResultKey key)
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
        public Int32 GetResultsTotal(ResultKeyAssemblyNameLevel key) => GetResultsTotal(new ResultKey(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyTargetRuntimeLevel key) => GetResultsTotal(new ResultKey(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyArchitectureLevel key) => GetResultsTotal(new ResultKey(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyExecutionRuntimeLevel key) => GetResultsTotal(new ResultKey(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKeyFileLevel key) => GetResultsTotal(new ResultKey(key));

        /// <summary>
        /// Gets the total number of results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsTotal(ResultKey key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsTotal);


        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyAssemblyNameLevel key) => GetResultsOk(new ResultKey(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyTargetRuntimeLevel key) => GetResultsOk(new ResultKey(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyArchitectureLevel key) => GetResultsOk(new ResultKey(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyExecutionRuntimeLevel key) => GetResultsOk(new ResultKey(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKeyFileLevel key) => GetResultsOk(new ResultKey(key));

        /// <summary>
        /// Gets the number of successful results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsOk(ResultKey key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsOk);


        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyAssemblyNameLevel key) => GetResultsFailed(new ResultKey(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyTargetRuntimeLevel key) => GetResultsFailed(new ResultKey(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyArchitectureLevel key) => GetResultsFailed(new ResultKey(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyExecutionRuntimeLevel key) => GetResultsFailed(new ResultKey(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKeyFileLevel key) => GetResultsFailed(new ResultKey(key));

        /// <summary>
        /// Gets the number of failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Int32 GetResultsFailed(ResultKey key) => FilterResults(key).Sum(kvp => kvp.Value.ResultsFailed);


        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyAssemblyNameLevel key) => HasFailedTests(new ResultKey(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyTargetRuntimeLevel key) => HasFailedTests(new ResultKey(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyArchitectureLevel key) => HasFailedTests(new ResultKey(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyExecutionRuntimeLevel key) => HasFailedTests(new ResultKey(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKeyFileLevel key) => HasFailedTests(new ResultKey(key));

        /// <summary>
        /// Gets if the collection contains failed results for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to filter by.</param>
        public Boolean HasFailedTests(ResultKey key) => FilterResults(key).Where(kvp => !String.IsNullOrWhiteSpace(kvp.Value.Exception)).Count() > 0;

        #endregion

    }
}
