using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.TestSite;

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
        /// Adds an <see cref="ITestMethodResult"/> and its <see cref="IResultKey"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="results">The test method result.</param>
        void Add(IResultKey key, ITestMethodResult results);

        /// <summary>
        /// Adds a bunch of results with their keys.
        /// </summary>
        /// <param name="results">The results.</param>
        void Add(IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results);


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
        /// Logs an error that occured while invoking a test method.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the error occurred.</param>
        /// <param name="message">The error message.</param>
        void LogError(MethodInfo _method, String message);

        /// <summary>
        /// Logs a test method data injection.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that is invoked.</param>
        /// <param name="message">The detailed invokation message.</param>
        void LogInjection(MethodInfo _method, String message);

        /// <summary>
        /// Set an entire test method to ignored.
        /// </summary>
        /// <param name="_method">The test method to ignore.</param>
        /// <param name="ignoreReason">The reason why it is being ignored.</param>
        void IgnoreTestMethod(MethodInfo _method, String ignoreReason);

        #endregion

    }
}
