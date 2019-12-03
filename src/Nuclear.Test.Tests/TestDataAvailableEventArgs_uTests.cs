using System;
using Nuclear.TestSite;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class TestDataAvailableEventArgs_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.IsSubClass<TestDataAvailableEventArgs, EventArgs>();

        }

        [TestMethod]
        void Ctor() {

            TestDataAvailableEventArgs e = null;

            TestX.IfNot.Action.ThrowsException(() => e = new TestDataAvailableEventArgs(null), out Exception ex);
            TestX.If.Object.IsNull(e.Data);

            TestX.IfNot.Action.ThrowsException(() => e = new TestDataAvailableEventArgs(new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 }), out ex);
            TestX.If.Enumerable.MatchesExactly(e.Data, new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 });

        }

    }
}
