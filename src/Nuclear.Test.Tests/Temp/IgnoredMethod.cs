using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class IgnoredMethod {

        [TestMethod("For Some Reason")]
        void IsIgnored() {

            TestX.Note("Note 1");

        }

    }
}
