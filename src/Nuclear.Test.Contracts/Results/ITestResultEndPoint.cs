using System.Collections.Generic;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines a test results endpoint that can act as a sink and a source.
    /// </summary>
    public interface ITestResultEndPoint : ITestResultsSink, ITestResultsSource {

        #region properties

        /// <summary>
        /// Gets the current test scenario.
        /// </summary>
        ITestScenario Scenario { get; }

        #endregion

        #region methods

        /// <summary>
        /// Initializes the <see cref="ITestResultsSink"/> by giving a <see cref="ITestScenario"/>.
        /// </summary>
        /// <param name="scenario">The <see cref="ITestScenario"/> relevant to the results.</param>
        void Initialize(ITestScenario scenario);

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
