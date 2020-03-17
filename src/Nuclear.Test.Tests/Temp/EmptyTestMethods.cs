
using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class EmptyTestMethods {

        [TestMethodX]
        void MethodHasNoTests() {

            TestX.Note("Note 1");

        }

    }
}
