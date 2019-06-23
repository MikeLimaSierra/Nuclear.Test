using System;
using System.ComponentModel;
using System.Reflection;
using Nuclear.TestSite.Results;

namespace Nuclear.TestSite.Tests {

    /// <summary>
    /// Supplies conditional test implementation.
    /// </summary>
    public static class Test {

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
        /// Sets the name and <see cref="ProcessorArchitecture"/> of the targeted assembly. Should only ever be used by test client implementations.
        /// </summary>
        /// <param name="architecture">The processor architecture.</param>
        /// <param name="assemblyName">The assembly name.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="assemblyName"/> is null.</exception>
        /// <exception cref="ArgumentException">Throws if <paramref name="assemblyName"/> is empty of white space.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetAssemblyInfo(ProcessorArchitecture architecture, String assemblyName) {
            If.Architecture = architecture;
            If.AssemblyName = assemblyName;
            IfNot.Architecture = architecture;
            IfNot.AssemblyName = assemblyName;
        }

        /// <summary>
        /// Sets the test result sink to a specific <see cref="ITestResultsEndPoint"/>. Should only ever be used by test client implementations.
        /// </summary>
        /// <param name="results"></param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="results"/> is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetTestResultsEndPoint(ITestResultsEndPoint results) {
            If.Results = results;
            IfNot.Results = results;
        }

        #endregion

    }
}
