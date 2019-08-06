using System;
using System.Reflection;
using System.Runtime.Versioning;
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
            If.Runtime = Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName;
            IfNot.Architecture = asmName.ProcessorArchitecture;
            IfNot.AssemblyName = asmName.Name;
            IfNot.Runtime = Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName;
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

        public void CollectResult(TestResult result, String _assembly, ProcessorArchitecture _architecture, String _runtime, String _file, String _method)
            => ResultMap.GetOrAdd(new ResultKeyMethodLevel(_assembly, _architecture, _runtime, _file, _method), new TestResultCollection()).Add(result);

        public void FailTestMethod(MethodInfo _method, Exception ex) {
            ResultKeyMethodLevel key = new ResultKeyMethodLevel(
                _method.DeclaringType.Assembly.GetName().Name,
                _method.DeclaringType.Assembly.GetName().ProcessorArchitecture,
                Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName,
                _method.DeclaringType.Name,
                _method.Name);

            ResultMap.GetOrAdd(key, new TestResultCollection()).Exception = ex.ToString();
        }

        #endregion

    }
}
