using System;

using Nuclear.Test.Results;

namespace Nuclear.Test {

    /// <summary>
    /// Defines a basic printer type to make test results human readable.
    /// </summary>
    public interface IPrinter {

        #region methods

        /// <summary>
        /// Loads all results from <paramref name="results"/>.
        /// </summary>
        /// <param name="results">The result source that is being loaded.</param>
        /// <returns>True if successfull, false if not.</returns>
        Boolean Load(ITestResultSource results);

        /// <summary>
        /// Prints all results.
        /// </summary>
        void Print();

        #endregion

    }
}
