using System;
using System.Reflection;
using Nuclear.Exceptions;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// A test results sink implementation.
    /// </summary>
    public class TestResults : ITestResultsEndPoint {

        #region fields

        private String _assemblyName;

        private String _targetRuntime;

        private String _executionRuntime;

        #endregion

        #region properties

        /// <summary>
        /// Gets the instance of <see cref="TestResults"/>.
        /// </summary>
        public static ITestResultsEndPoint Instance { get; } = new TestResults();

        /// <summary>
        /// Gets the collection of results.
        /// </summary>
        public TestResultMap ResultMap { get; } = new TestResultMap();

        /// <summary>
        /// Gets or sets the assembly name.
        /// </summary>
        public String AssemblyName {
            get => _assemblyName;
            set {
                Throw.If.NullOrWhiteSpace(value, "value");
                _assemblyName = value;
            }
        }

        /// <summary>
        /// Gets or sets the targeted runtime.
        /// </summary>
        public String TargetRuntime {
            get => _targetRuntime;
            set {
                Throw.If.NullOrWhiteSpace(value, "value");
                _targetRuntime = value;
            }
        }

        /// <summary>
        /// Gets or sets the processor architecture.
        /// </summary>
        public ProcessorArchitecture Architecture { get; set; }

        /// <summary>
        /// Gets or sets the executed runtime.
        /// </summary>
        public String ExecutionRuntime {
            get => _executionRuntime;
            set {
                Throw.If.NullOrWhiteSpace(value, "value");
                _executionRuntime = value;
            }
        }

        #endregion

        #region ctors

        private TestResults() {
            Throw.IfNot.Null(Instance, "Instance", "Constructor must not be called twice.");
        }

        #endregion

        #region methods

        /// <summary>
        /// Clears all results.
        /// </summary>
        public void Clear() => ResultMap.Clear();

        /// <summary>
        /// Collects a given <see cref="TestResult"/> and maps that to the combination of architecture, assembly, class and method.
        /// </summary>
        /// <param name="result">The <see cref="TestResult"/> to collect.</param>
        /// <param name="_file">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        public void CollectResult(TestResult result, String _file, String _method)
            => ResultMap.GetOrAdd(new ResultKeyMethodLevel(AssemblyName, TargetRuntime, Architecture, ExecutionRuntime, _file, _method),
                new TestResultCollection()).Add(result);

        /// <summary>
        /// Sets an entire test method to failed with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        /// <param name="ex">The <see cref="Exception"/> that was thrown.</param>
        public void FailTestMethod(MethodInfo _method, Exception ex)
            => ResultMap.GetOrAdd(new ResultKeyMethodLevel(AssemblyName, TargetRuntime, Architecture, ExecutionRuntime, _method.DeclaringType.Name, _method.Name),
                new TestResultCollection()).Exception = ex.ToString();

        #endregion

    }
}
