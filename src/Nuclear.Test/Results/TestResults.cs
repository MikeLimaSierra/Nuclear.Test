using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using Nuclear.TestSite;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {

    /// <summary>
    /// A test results sink implementation.
    /// </summary>
    public class TestResults : ITestResultsSink, ITestResultsSource {

        #region fields

        private ConcurrentDictionary<TestResultKey, TestMethodResult> _results { get; } = new ConcurrentDictionary<TestResultKey, TestMethodResult>();

        #endregion

        #region properties

        /// <summary>
        /// Gets the current test scenario.
        /// </summary>
        public TestScenario Scenario { get; private set; }

        /// <summary>
        /// Gets all contained results and their corresponding keys.
        /// </summary>
        public IEnumerable<KeyValuePair<TestResultKey, TestMethodResult>> Values => _results;

        /// <summary>
        /// Gets all available keys.
        /// </summary>
        public IEnumerable<TestResultKey> Keys => _results.Keys;

        /// <summary>
        /// Gets all available results.
        /// </summary>
        public IEnumerable<TestMethodResult> Results => _results.Values;

        /// <summary>
        /// Gets the <see cref="TestMethodResult"/> to a specific <see cref="TestResultKey"/>.
        /// </summary>
        /// <param name="key">The given key that identifies results.</param>
        /// <returns>The results or an empty result collection if the key was not found.</returns>
        public TestMethodResult this[TestResultKey key] => _results.GetOrAdd(key, new TestMethodResult());

        #endregion

        #region methods

        public void Add(TestResultKey key, TestMethodResult results)
            => _results.AddOrUpdate(key, results, (_key, value) => results);

        public void Add(IEnumerable<KeyValuePair<TestResultKey, TestMethodResult>> results) {
            foreach(KeyValuePair<TestResultKey, TestMethodResult> result in results) {
                Add(result.Key, result.Value);
            }
        }

        #endregion

        #region ITestResultsSink methods

        /// <summary>
        /// Initializes the <see cref="ITestResultsSource"/> by giving a <see cref="TestScenario"/>.
        /// </summary>
        /// <param name="scenario">The <see cref="TestScenario"/> relevant to the results.</param>
        public void Initialize(TestScenario scenario) => Scenario = scenario;

        /// <summary>
        /// Clears all results.
        /// </summary>
        public void Clear() => _results.Clear();

        /// <summary>
        /// Prepares for test results by creating the result collection.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        public void PrepareResults(MethodInfo _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult());

        /// <summary>
        /// Collects a given test result.
        /// </summary>
        /// <param name="result">The success state.</param>
        /// <param name="testInstruction">The test instruction.</param>
        /// <param name="message">The message.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        public void Add(Boolean result, String testInstruction, String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(result, testInstruction, message));

        /// <summary>
        /// Collects a given test note.
        /// </summary>
        /// <param name="message">The message that is to be displayed as note.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        public void Add(String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(message));

        /// <summary>
        /// Sets an entire test method to failed with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        /// <param name="ex">The <see cref="Exception"/> that was thrown.</param>
        public void FailTestMethod(MethodInfo _method, Exception ex)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult()).Fail(ex.ToString());

        #endregion

    }
}
