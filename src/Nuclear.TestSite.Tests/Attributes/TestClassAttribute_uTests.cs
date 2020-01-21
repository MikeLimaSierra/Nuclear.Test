using System;

namespace Nuclear.TestSite {
    class TestClassAttribute_uTests {

        [TestMethod]
        void Ctor() {

            TestClassAttribute attr = null;

            Test.IfNot.Action.ThrowsException(() => attr = new TestClassAttribute(), out Exception ex);
            Test.IfNot.Object.IsNull(attr);
            Test.If.Value.IsEqual(attr.TestMode, TestMode.Parallel);

            Test.IfNot.Action.ThrowsException(() => attr = new TestClassAttribute(TestMode.Parallel), out ex);
            Test.IfNot.Object.IsNull(attr);
            Test.If.Value.IsEqual(attr.TestMode, TestMode.Parallel);

            Test.IfNot.Action.ThrowsException(() => attr = new TestClassAttribute(TestMode.Sequential), out ex);
            Test.IfNot.Object.IsNull(attr);
            Test.If.Value.IsEqual(attr.TestMode, TestMode.Sequential);

        }

    }
}
