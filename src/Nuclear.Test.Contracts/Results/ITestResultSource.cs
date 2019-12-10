using System.Collections.Generic;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines a result source.
    /// </summary>
    public interface ITestResultSource {

        #region methods

        /// <summary>
        /// Gets all available keys.
        /// </summary>
        /// <returns>The collection of keys.</returns>
        IEnumerable<ITestResultKey> GetKeys();

        /// <summary>
        /// Gets all available keys matching a given key.
        /// </summary>
        /// <param name="match">The <see cref="ITestResultKey"/> that needs to match.</param>
        /// <returns>The collection of keys.</returns>
        IEnumerable<ITestResultKey> GetKeys(ITestResultKey match);

        /// <summary>
        /// Gets all available keys matching a given key with clipped to a precision.
        /// </summary>
        /// <param name="match">The <see cref="ITestResultKey"/> that needs to match.</param>
        /// <param name="precision">The precision that all returned keys are clipped to.</param>
        /// <returns>The collection of keys.</returns>
        IEnumerable<ITestResultKey> GetKeys(ITestResultKey match, TestResultKeyPrecisions precision);

        /// <summary>
        /// Gets the <see cref="ITestMethodResult"/> to a specific <see cref="ITestResultKey"/>.
        /// </summary>
        /// <param name="key">The given key that identifies results.</param>
        /// <returns>The results or an empty result collection if the key was not found.</returns>
        ITestMethodResult GetResult(ITestResultKey key);

        /// <summary>
        /// Gets all available results.
        /// </summary>
        /// <returns>The collection of results.</returns>
        IEnumerable<ITestMethodResult> GetResults();

        /// <summary>
        /// Gets all available results matching a given key.
        /// </summary>
        /// <param name="match"></param>
        /// <returns>The collection of results.</returns>
        IEnumerable<ITestMethodResult> GetResults(ITestResultKey match);

        /// <summary>
        /// Gets all contained results and their corresponding keys.
        /// </summary>
        /// <returns>The collection of <see cref="KeyValuePair{ITestResultKey, ITestMethodResult}"/>.</returns>
        IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> GetKeyedResults();

        #endregion

    }
}
