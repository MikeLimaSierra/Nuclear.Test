using System;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Defines a result sink.
    /// </summary>
    public interface ITestResultsEndPoint {

        #region properties

        /// <summary>
        /// Gets the collection of results.
        /// </summary>
        TestResultMap ResultMap { get; }

        /// <summary>
        /// Gets or sets the assembly name.
        /// </summary>
        String AssemblyName { get; set; }

        /// <summary>
        /// Gets or sets the targeted runtime.
        /// </summary>
        String TargetRuntime { get; set; }

        /// <summary>
        /// Gets or sets the processor architecture.
        /// </summary>
        ProcessorArchitecture Architecture { get; set; }

        /// <summary>
        /// Gets or sets the executed runtime.
        /// </summary>
        String ExecutionRuntime { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Clears all results.
        /// </summary>
        void Clear();

        /// <summary>
        /// Collects a given <see cref="TestResult"/> and maps that to the combination of architecture, assembly, class and method.
        /// </summary>
        /// <param name="result">The <see cref="TestResult"/> to collect.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        void CollectResult(TestResult result, String _file, String _method);

        /// <summary>
        /// Sets an entire test method to failed with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        /// <param name="ex">The <see cref="Exception"/> that was thrown.</param>
        void FailTestMethod(MethodInfo _method, Exception ex);

        #endregion

    }
}
