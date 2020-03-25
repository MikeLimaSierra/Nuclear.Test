
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class MethodWithFailingTests {

        [TestMethod]
        void HasFailingTest() {

            TestX.Note("Note 1");
            TestX.If.Value.IsTrue(false);
            TestX.If.Value.IsTrue(true);
            TestX.Note("Note 2");
            TestX.If.Value.IsTrue(false);
            TestX.If.Value.IsTrue(true);

        }

    }
}
