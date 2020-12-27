using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class EmptyMethodWithNote {

        [TestMethod]
        void HasNoTests() {

            TestX.Note("Note 1");

        }

    }
}
