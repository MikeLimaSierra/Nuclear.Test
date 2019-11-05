using System;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Results {
    class TestResults_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<TestResults, ITestResultsEndPoint>();

            ITestResultsEndPoint results1 = TestResults.Instance;
            ITestResultsEndPoint results2 = TestResults.Instance;

            Test.IfNot.Object.IsNull(results1);
            Test.IfNot.Object.IsNull(results2);
            Test.If.ReferencesEqual(results1, results2);

        }

        [TestMethod]
        void TestAssemblyNameProperty() {

            Test.If.Action.ThrowsException(() => TestResults.Instance.AssemblyName = null, out ArgumentNullException argNullEx);
            Test.IfNot.Object.IsNull(argNullEx);
            Test.If.Value.Equals(argNullEx.ParamName, "value");

            Test.If.Action.ThrowsException(() => TestResults.Instance.AssemblyName = String.Empty, out ArgumentException argEx);
            Test.IfNot.Object.IsNull(argEx);
            Test.If.Value.Equals(argEx.ParamName, "value");

        }

        [TestMethod]
        void TestTargetRuntimeProperty() {

            Test.If.Action.ThrowsException(() => TestResults.Instance.TargetRuntime = null, out ArgumentNullException argNullEx);
            Test.IfNot.Object.IsNull(argNullEx);
            Test.If.Value.Equals(argNullEx.ParamName, "value");

            Test.If.Action.ThrowsException(() => TestResults.Instance.TargetRuntime = String.Empty, out ArgumentException argEx);
            Test.IfNot.Object.IsNull(argEx);
            Test.If.Value.Equals(argEx.ParamName, "value");

        }

        [TestMethod]
        void TestExecutionRuntimeProperty() {

            Test.If.Action.ThrowsException(() => TestResults.Instance.ExecutionRuntime = null, out ArgumentNullException argNullEx);
            Test.IfNot.Object.IsNull(argNullEx);
            Test.If.Value.Equals(argNullEx.ParamName, "value");

            Test.If.Action.ThrowsException(() => TestResults.Instance.ExecutionRuntime = String.Empty, out ArgumentException argEx);
            Test.IfNot.Object.IsNull(argEx);
            Test.If.Value.Equals(argEx.ParamName, "value");

        }

    }
}
