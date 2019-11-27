using System.Collections.Generic;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines a result source.
    /// </summary>
    public interface ITestResultsSource {

        #region properties

        /// <summary>
        /// Gets all contained results and their corresponding keys.
        /// </summary>
        IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> Values { get; }

        /// <summary>
        /// Gets all available keys.
        /// </summary>
        IEnumerable<ITestResultKey> Keys { get; }

        /// <summary>
        /// Gets all available results.
        /// </summary>
        IEnumerable<ITestMethodResult> Results { get; }

        /// <summary>
        /// Gets the <see cref="ITestMethodResult"/> to a specific <see cref="ITestResultKey"/>.
        /// </summary>
        /// <param name="key">The given key that identifies results.</param>
        /// <returns>The results or an empty result collection if the key was not found.</returns>
        ITestMethodResult this[ITestResultKey key] { get; }

        #endregion

    }
}
