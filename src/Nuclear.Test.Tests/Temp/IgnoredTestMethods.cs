
using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class IgnoredTestMethods {

        [TestMethodX("For Some Reason")]
        void MethodIsIgnored() {

            TestX.Note("Note 1");

        }

    }
}
