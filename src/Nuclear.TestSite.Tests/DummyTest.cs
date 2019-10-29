using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Exceptions;
using Nuclear.TestSite.Results;
using Nuclear.TestSite.TestSuites;

namespace Nuclear.TestSite {
    static class DummyTest {

        #region properties

        public static TestSuiteCollection If { get; private set; } = new TestSuiteCollection(DummyTestResults.Instance);

        public static TestSuiteCollection IfNot { get; private set; } = new TestSuiteCollection(DummyTestResults.Instance, invert: true);

        #endregion

        #region ctors

        static DummyTest() {
            DummyTestResults.Instance.Architecture = Statics.Architecture;
            DummyTestResults.Instance.TargetRuntime = Statics.TargetRuntime;
            DummyTestResults.Instance.AssemblyName = Statics.AssemblyName;
            DummyTestResults.Instance.ExecutionRuntime = Statics.ExecutionRuntime;
        }

        #endregion

        #region methods

        public static void Note(String note, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
            TestResult result = new TestResult(note);
            DummyTestResults.Instance.CollectResult(result, Path.GetFileNameWithoutExtension(_file), _method);
        }

        #endregion

    }

    class DummyTestResults : ITestResultsEndPoint {

        #region properties

        public static ITestResultsEndPoint Instance { get; } = new DummyTestResults();

        public TestResultMap ResultMap { get; } = new TestResultMap();

        public String AssemblyName { get; set; }

        public String TargetRuntime { get; set; }

        public ProcessorArchitecture Architecture { get; set; }

        public String ExecutionRuntime { get; set; }

        #endregion

        #region ctors

        private DummyTestResults() {
            Throw.IfNot.Null(Instance, "Instance", "Constructor must not be called twice.");
        }

        #endregion

        #region methods

        public void Clear() => ResultMap.Clear();

        public void PrepareResults(MethodInfo _method)
            => ResultMap.GetOrAdd(new ResultKeyMethodLevel(AssemblyName, TargetRuntime, Architecture, ExecutionRuntime, _method.DeclaringType.Name, _method.Name),
                new TestResultCollection());

        public void CollectResult(TestResult result, String _file, String _method)
            => ResultMap.GetOrAdd(new ResultKeyMethodLevel(AssemblyName, TargetRuntime, Architecture, ExecutionRuntime, _file, _method),
                new TestResultCollection()).Add(result);

        public void FailTestMethod(MethodInfo _method, Exception ex)
            => ResultMap.GetOrAdd(new ResultKeyMethodLevel(AssemblyName, TargetRuntime, Architecture, ExecutionRuntime, _method.DeclaringType.Name, _method.Name),
                new TestResultCollection()).Exception = ex.ToString();

        #endregion

    }
}
