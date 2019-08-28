using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class TestResultsTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<TestResults, ITestResultsEndPoint>();

            ITestResultsEndPoint results1 = TestResults.Instance;
            ITestResultsEndPoint results2 = TestResults.Instance;

            Test.IfNot.Null(results1);
            Test.IfNot.Null(results2);
            Test.If.ReferencesEqual(results1, results2);

        }

        [TestMethod]
        void TestAssemblyNameProperty() {

            Test.If.ThrowsException(() => TestResults.Instance.AssemblyName = null, out ArgumentNullException argNullEx);
            Test.IfNot.Null(argNullEx);
            Test.If.ValuesEqual(argNullEx.ParamName, "value");

            Test.If.ThrowsException(() => TestResults.Instance.AssemblyName = String.Empty, out ArgumentException argEx);
            Test.IfNot.Null(argEx);
            Test.If.ValuesEqual(argEx.ParamName, "value");

        }

        [TestMethod]
        void TestTargetRuntimeProperty() {

            Test.If.ThrowsException(() => TestResults.Instance.TargetRuntime = null, out ArgumentNullException argNullEx);
            Test.IfNot.Null(argNullEx);
            Test.If.ValuesEqual(argNullEx.ParamName, "value");

            Test.If.ThrowsException(() => TestResults.Instance.TargetRuntime = String.Empty, out ArgumentException argEx);
            Test.IfNot.Null(argEx);
            Test.If.ValuesEqual(argEx.ParamName, "value");

        }

        [TestMethod]
        void TestExecutionRuntimeProperty() {

            Test.If.ThrowsException(() => TestResults.Instance.ExecutionRuntime = null, out ArgumentNullException argNullEx);
            Test.IfNot.Null(argNullEx);
            Test.If.ValuesEqual(argNullEx.ParamName, "value");

            Test.If.ThrowsException(() => TestResults.Instance.ExecutionRuntime = String.Empty, out ArgumentException argEx);
            Test.IfNot.Null(argEx);
            Test.If.ValuesEqual(argEx.ParamName, "value");

        }

    }
}
