using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Results;

namespace Nuclear.TestSite.Tests {

    /// <summary>
    /// Supplies conditional test implementation.
    /// </summary>
    public static class Test {

        #region fields

        private static ITestResultsEndPoint _results;

        private static ProcessorArchitecture _architecture;

        private static String _assemblyName;

        private static String _runtime;

        #endregion

        #region properties

        /// <summary>
        /// Gets conditional test functionality.
        /// </summary>
        public static ConditionalTest If { get; private set; } = new ConditionalTest();

        /// <summary>
        /// Gets conditional test functionality with inverted results.
        /// </summary>
        public static ConditionalTest IfNot { get; private set; } = new ConditionalTest(invert: true);

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
            _results.CollectResult(result, _assemblyName, _architecture, _runtime, Path.GetFileNameWithoutExtension(_file), _method);
        }

        /// <summary>
        /// Sets the name and <see cref="ProcessorArchitecture"/> of the targeted assembly. Should only ever be used by test client implementations.
        /// </summary>
        /// <param name="architecture">The processor architecture.</param>
        /// <param name="assemblyName">The assembly name.</param>
        /// <param name="runtime">The runtime version.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="assemblyName"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="runtime"/> is null.</exception>
        /// <exception cref="ArgumentException">Throws if <paramref name="assemblyName"/> is empty of white space.</exception>
        /// <exception cref="ArgumentException">Throws if <paramref name="runtime"/> is empty of white space.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetAssemblyInfo(ProcessorArchitecture architecture, String assemblyName, String runtime) {
            _architecture = architecture;
            _assemblyName = assemblyName;
            _runtime = runtime;

            If.Architecture = _architecture;
            If.AssemblyName = _assemblyName;
            If.Runtime = _runtime;
            IfNot.Architecture = _architecture;
            IfNot.AssemblyName = _assemblyName;
            IfNot.Runtime = _runtime;
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
