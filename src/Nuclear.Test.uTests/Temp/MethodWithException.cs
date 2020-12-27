using System;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class MethodWithException {

        [TestMethod]
        void FailsWithException() {

            TestX.Note("Note 1");
            TestX.If.Value.IsTrue(true);

            throw new NotImplementedException();
        }

    }
}
