using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class EmptyMethodWithNote {

        [TestMethodX]
        void HasNoTests() {

            TestX.Note("Note 1");

        }

    }
}
