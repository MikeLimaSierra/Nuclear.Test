using System;

using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class MethodWithException {

        [TestMethodX]
        void FailsWithException() {

            TestX.Note("Note 1");
            TestX.If.Value.IsTrue(true);

            throw new NotImplementedException();
        }

    }
}
