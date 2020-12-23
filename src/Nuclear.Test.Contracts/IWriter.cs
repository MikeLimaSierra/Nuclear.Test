using System;

using Nuclear.Test.Results;

namespace Nuclear.Test {

    /// <summary>
    /// Defines a basic writer type to make test results human readable.
    /// </summary>
    public interface IWriter {

        #region methods

        /// <summary>
        /// Loads all results from <paramref name="results"/>.
        /// </summary>
        /// <param name="results">The result source that is being loaded.</param>
        /// <returns>True if successfull, false if not.</returns>
        Boolean Load(ITestResultSource results);

        /// <summary>
        /// Write all results.
        /// </summary>
        void Write();

        #endregion

    }
}
