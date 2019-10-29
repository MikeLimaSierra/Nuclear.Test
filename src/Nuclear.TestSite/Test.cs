using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Results;
using Nuclear.TestSite.TestSuites;

namespace Nuclear.TestSite {

    /// <summary>
    /// Supplies conditional test implementation.
    /// </summary>
    public static class Test {

        #region fields

        private static ITestResultsEndPoint _results;

        private static String _assemblyName;

        private static String _targetRuntime;

        private static ProcessorArchitecture _architecture;

        private static String _executionRuntime;

        #endregion

        #region properties

        /// <summary>
        /// Gets conditional test functionality.
        /// </summary>
        public static TestSuiteCollection If { get; private set; } = new TestSuiteCollection();

        /// <summary>
        /// Gets conditional test functionality with inverted results.
        /// </summary>
        public static TestSuiteCollection IfNot { get; private set; } = new TestSuiteCollection(invert: true);

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
        public static void Note(String note,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            TestResult result = new TestResult(note);
            _results.CollectResult(result, Path.GetFileNameWithoutExtension(_file), _method);
        }

        /// <summary>
        /// Sets the name and <see cref="ProcessorArchitecture"/> of the targeted assembly. Should only ever be used by test client implementations.
        /// </summary>
        /// <param name="assemblyName">The assembly name.</param>
        /// <param name="targetRuntime">The target runtime.</param>
        /// <param name="architecture">The processor architecture.</param>
        /// <param name="executionRuntime">The execution runtime.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="assemblyName"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="targetRuntime"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="executionRuntime"/> is null.</exception>
        /// <exception cref="ArgumentException">Throws if <paramref name="assemblyName"/> is empty of white space.</exception>
        /// <exception cref="ArgumentException">Throws if <paramref name="targetRuntime"/> is empty of white space.</exception>
        /// <exception cref="ArgumentException">Throws if <paramref name="executionRuntime"/> is empty of white space.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetAssemblyInfo(String assemblyName, String targetRuntime, ProcessorArchitecture architecture, String executionRuntime) {
            _assemblyName = assemblyName;
            _targetRuntime = targetRuntime;
            _architecture = architecture;
            _executionRuntime = executionRuntime;

            _results.AssemblyName = _assemblyName;
            _results.TargetRuntime = _targetRuntime;
            _results.Architecture = _architecture;
            _results.ExecutionRuntime = _executionRuntime;
        }

        /// <summary>
        /// Sets the test result sink to a specific <see cref="ITestResultsEndPoint"/>. Should only ever be used by test client implementations.
        /// </summary>
        /// <param name="results"></param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="results"/> is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetTestResultsEndPoint(ITestResultsEndPoint results) {
            _results = results;
            If.Results = _results;
            IfNot.Results = _results;
        }

        #endregion

    }
}
