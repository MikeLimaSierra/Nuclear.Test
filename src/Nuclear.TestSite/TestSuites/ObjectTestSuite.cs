using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.TestSuites.Base;

namespace Nuclear.TestSite.TestSuites {

    /// <summary>
    /// Provides conditional test instructions for objects.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ObjectTestSuite : ChildTestSuite {

        #region ctors

        internal ObjectTestSuite(TestSuiteCollection parent) : base(parent) { }

        #endregion

        #region public methods

        /// <summary>
        /// Forwards to <see cref="TestSuiteCollection"/>.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message.</param>
        /// <param name="file">The file name where the test method is located.</param>
        /// <param name="method">The test method name.</param>
        /// <param name="testInstruction">The test instruction.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InternalTest(Boolean condition, String message, String file, String method, [CallerMemberName] String testInstruction = null)
            => Parent.CreateResult(condition, message, file, method, testInstruction);

        /// <summary>
        /// Fails the calling test.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="file">The file name where the test method is located.</param>
        /// <param name="method">The test method name.</param>
        /// <param name="testInstruction">The test instruction.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void FailTest(String message, String file, String method, [CallerMemberName] String testInstruction = null)
            => Parent.InternalFail(message, file, method, testInstruction);

        #endregion

    }
}
