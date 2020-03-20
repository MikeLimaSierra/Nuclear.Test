using TestClassX = Nuclear.TestSite.TestClassAttribute;
using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {

    [TestClassX("For another reason.")]
    class IgnoredTestClass {

        [TestMethodX]
        void ClassIsIgnored() {

            TestX.Note("Note 1");

        }

    }
}
