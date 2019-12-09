using System;
using System.Collections.Generic;
using System.Reflection;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines a test results endpoint that can act as a sink and a source.
    /// </summary>
    public interface ITestResultEndPoint : ITestResultSink, ITestResultSource {

        #region properties

        /// <summary>
        /// Gets the current test scenario.
        /// </summary>
        ITestScenario Scenario { get; }

        #endregion

        #region methods

        /// <summary>
        /// Initializes the <see cref="ITestResultSink"/> by giving a <see cref="ITestScenario"/>.
        /// </summary>
        /// <param name="scenario">The <see cref="ITestScenario"/> relevant to the results.</param>
        void Initialize(ITestScenario scenario);

        /// <summary>
        /// Clears all results.
        /// </summary>
        void Clear();

        /// <summary>
        /// Prepares for test results by creating the result collection.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        void PrepareResults(MethodInfo _method);

        /// <summary>
        /// Sets an entire test method to failed with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        /// <param name="ex">The <see cref="Exception"/> that was thrown.</param>
        void FailTestMethod(MethodInfo _method, Exception ex);

        /// <summary>
        /// Adds an <see cref="ITestMethodResult"/> and its <see cref="ITestResultKey"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="results">The test method result.</param>
        void Add(ITestResultKey key, ITestMethodResult results);

        /// <summary>
        /// Adds a bunch of results with their keys.
        /// </summary>
        /// <param name="results">The results.</param>
        void Add(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results);

        #endregion

    }
}
