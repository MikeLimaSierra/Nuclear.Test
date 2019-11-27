using System;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Defines a result sink.
    /// </summary>
    public interface ITestResultsSink {

        #region properties

        /// <summary>
        /// Gets the current test scenario.
        /// </summary>
        ITestScenario Scenario { get; }

        #endregion

        #region methods

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
        /// Adds a given test result.
        /// </summary>
        /// <param name="result">The success state.</param>
        /// <param name="testInstruction">The test instruction.</param>
        /// <param name="message">The message.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        void Add(Boolean result, String testInstruction, String message, String _file, String _method);

        /// <summary>
        /// Adds a given test note.
        /// </summary>
        /// <param name="message">The message that is to be displayed as note.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        void Add(String message, String _file, String _method);

        /// <summary>
        /// Sets an entire test method to failed with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        /// <param name="ex">The <see cref="Exception"/> that was thrown.</param>
        void FailTestMethod(MethodInfo _method, Exception ex);

        #endregion

        #region methods

        /// <summary>
        /// Initializes the <see cref="ITestResultsSink"/> by giving a <see cref="ITestScenario"/>.
        /// </summary>
        /// <param name="scenario">The <see cref="ITestScenario"/> relevant to the results.</param>
        void Initialize(ITestScenario scenario);

        #endregion

    }
}
