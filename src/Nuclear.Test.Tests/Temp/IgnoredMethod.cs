using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class IgnoredMethod {

        [TestMethodX("For Some Reason")]
        void IsIgnored() {

            TestX.Note("Note 1");

        }

    }
}
