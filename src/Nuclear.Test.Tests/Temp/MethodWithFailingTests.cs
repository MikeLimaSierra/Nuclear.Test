
using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class MethodWithFailingTests {

        [TestMethodX]
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
