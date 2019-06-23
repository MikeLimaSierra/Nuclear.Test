using System;
using System.Reflection;
using Nuclear.Exceptions;
using Nuclear.TestSite.Results;

namespace Nuclear.TestSite.Tests {
    static class DummyTest {

        #region properties

        public static ConditionalTest If { get; private set; } = new ConditionalTest(DummyTestResults.Instance);

        public static ConditionalTest IfNot { get; private set; } = new ConditionalTest(DummyTestResults.Instance, invert: true);

        #endregion

        #region ctors

        static DummyTest() {
            AssemblyName asmName = Assembly.GetAssembly(typeof(DummyTest)).GetName();
            If.Architecture = asmName.ProcessorArchitecture;
            If.AssemblyName = asmName.Name;
            IfNot.Architecture = asmName.ProcessorArchitecture;
            IfNot.AssemblyName = asmName.Name;
        }

        #endregion

    }

    class DummyTestResults : ITestResultsEndPoint {

        #region properties

        public static ITestResultsEndPoint Instance { get; } = new DummyTestResults();

        public TestResultMap ResultMap { get; } = new TestResultMap();

        #endregion

        #region ctors

        private DummyTestResults() {
            Throw.IfNot.Null(Instance, "Instance", "Constructor must not be called twice.");
        }

        #endregion

        #region methods

        public void Clear() => ResultMap.Clear();

        public void CollectResult(TestResult result, ProcessorArchitecture _architecture, String _assembly, String _class, String _method) {
            Tuple<ProcessorArchitecture, String, String, String> key = Tuple.Create(_architecture, _assembly, _class, _method);

            ResultMap.GetOrAdd(key, new TestResultCollection()).Add(result);
        }

        public void FailTestMethod(MethodInfo _method, Exception ex) {
            Tuple<ProcessorArchitecture, String, String, String> key =
                Tuple.Create(_method.DeclaringType.Assembly.GetName().ProcessorArchitecture, _method.DeclaringType.Assembly.GetName().Name, _method.DeclaringType.Name, _method.Name);

            ResultMap.GetOrAdd(key, new TestResultCollection()).Exception = ex;
        }

        #endregion

    }
}
