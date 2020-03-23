using TestMethodX = Nuclear.TestSite.TestMethodAttribute;

namespace Nuclear.Test {
    class EmptyMethod {

        [TestMethodX]
        void HasNoTests() {

        }

    }
}
