using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.TestSuites;

namespace Nuclear.TestSite {

    /// <summary>
    /// Supplies conditional test implementation.
    /// </summary>
    public static class Test {

        #region fields

        private static ITestResultSink _results;

        #endregion

        #region properties

        /// <summary>
        /// Gets conditional test functionality.
        /// </summary>
        public static TestSuiteCollection If { get; } = new TestSuiteCollection(null);

        /// <summary>
        /// Gets conditional test functionality with inverted results.
        /// </summary>
        public static TestSuiteCollection IfNot { get; } = new TestSuiteCollection(null, invert: true);

        internal static ITestResultSink Results {
            get {
                if(_results == null) {
                    _results = ResultProxy.Results;
                }

                return _results;
            }
            set => _results = value;
        }

        #endregion

        #region hidden methods
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new Boolean ReferenceEquals(Object objA, Object objB) => throw new MethodAccessException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new Boolean Equals(Object objA, Object objB) => throw new MethodAccessException("This method is currently out of order.");

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        #endregion

        #region methods

        /// <summary>
        /// Creates an orientation note that will be displayed within the test results.
        /// </summary>
        /// <param name="note">The note that will be displayed.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public static void Note(String note,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => Results.AddNote(note, Path.GetFileNameWithoutExtension(_file), _method);

        #endregion

    }
}
