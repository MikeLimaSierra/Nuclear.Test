using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {

    [TestClass("For another reason.")]
    class IgnoredClass {

        [TestMethod]
        void IsIgnoredByClass() {

            TestX.Note("Note 1");

        }

    }
}
