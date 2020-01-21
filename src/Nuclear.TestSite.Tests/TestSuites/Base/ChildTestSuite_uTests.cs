using System;

namespace Nuclear.TestSite.TestSuites.Base {
    class ChildTestSuite_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<ChildTestSuite, TestSuite>();

        }

        [TestMethod]
        void Ctor() {

            ChildTestSuite suite = null;
            TestSuiteCollection suites = new TestSuiteCollection(DummyTestResults.Instance);

            Test.If.Action.ThrowsException(() => suite = new ChildTestSuite(null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "parent");

            Test.IfNot.Action.ThrowsException(() => suite = new ChildTestSuite(suites), out Exception ex2);
            Test.If.Reference.IsEqual(suites, suite.Parent);

        }

    }
}
