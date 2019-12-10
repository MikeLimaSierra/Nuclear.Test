using System;
using Nuclear.TestSite;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class TestDataAvailableEventArgs_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.IsSubClass<RawTestDataReceivedEventArgs, EventArgs>();

        }

        [TestMethod]
        void Ctor() {

            RawTestDataReceivedEventArgs e = null;

            TestX.IfNot.Action.ThrowsException(() => e = new RawTestDataReceivedEventArgs(null), out Exception ex);
            TestX.If.Object.IsNull(e.Data);

            TestX.IfNot.Action.ThrowsException(() => e = new RawTestDataReceivedEventArgs(new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 }), out ex);
            TestX.If.Enumerable.MatchesExactly(e.Data, new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 });

        }

    }
}
