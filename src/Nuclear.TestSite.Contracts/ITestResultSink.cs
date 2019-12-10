using System;

namespace Nuclear.TestSite {

    /// <summary>
    /// Defines a result sink.
    /// </summary>
    public interface ITestResultSink {

        #region methods

        /// <summary>
        /// Adds a given test result.
        /// </summary>
        /// <param name="result">The success state.</param>
        /// <param name="testInstruction">The test instruction.</param>
        /// <param name="message">The message.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        void AddResult(Boolean result, String testInstruction, String message, String _file, String _method);

        /// <summary>
        /// Adds a given test note.
        /// </summary>
        /// <param name="message">The message that is to be displayed as note.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        void AddNote(String message, String _file, String _method);

        #endregion

    }
}
