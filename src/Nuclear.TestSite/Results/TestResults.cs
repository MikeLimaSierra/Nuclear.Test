using System;
using System.Reflection;
using Nuclear.Exceptions;

namespace Nuclear.TestSite.Results {
    public class TestResults : ITestResultsEndPoint {

        #region properties

        /// <summary>
        /// Gets the instance of <see cref="TestResults"/>.
        /// </summary>
        public static ITestResultsEndPoint Instance { get; } = new TestResults();

        /// <summary>
        /// Gets the collection of results.
        /// </summary>
        public TestResultMap ResultMap { get; } = new TestResultMap();

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
        /// <param name="_architecture">The <see cref="ProcessorArchitecture"/>.</param>
        /// <param name="_assembly">The assembly name.</param>
        /// <param name="_class">The test class name (actually the filename of the test method source).</param>
        /// <param name="_method">The test method name.</param>
        public void CollectResult(TestResult result, ProcessorArchitecture _architecture, String _assembly, String _class, String _method) {
            Tuple<ProcessorArchitecture, String, String, String> key = Tuple.Create(_architecture, _assembly, _class, _method);

            ResultMap.GetOrAdd(key, new TestResultCollection()).Add(result);
        }

        /// <summary>
        /// Sets an entire test method to failed with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="_method">The <see cref="MethodInfo"/> that was invoked when the <see cref="Exception"/> was thrown.</param>
        /// <param name="ex">The <see cref="Exception"/> that was thrown.</param>
        public void FailTestMethod(MethodInfo _method, Exception ex) {
            Tuple<ProcessorArchitecture, String, String, String> key =
                Tuple.Create(_method.DeclaringType.Assembly.GetName().ProcessorArchitecture, _method.DeclaringType.Assembly.GetName().Name, _method.DeclaringType.Name, _method.Name);

            ResultMap.GetOrAdd(key, new TestResultCollection()).Exception = ex;
        }

        #endregion

    }
}
