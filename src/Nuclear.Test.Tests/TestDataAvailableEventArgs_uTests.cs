using System;

using Nuclear.Test.Execution;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class TestDataAvailableEventArgs_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.IsSubClass<ResultsReceivedEventArgs, EventArgs>();

        }

        [TestMethod]
        void Ctor() {

            ResultsReceivedEventArgs e = null;

            TestX.IfNot.Action.ThrowsException(() => e = new ResultsReceivedEventArgs(null), out Exception ex);
            TestX.If.Object.IsNull(e.Data);

            TestX.IfNot.Action.ThrowsException(() => e = new ResultsReceivedEventArgs(new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 }), out ex);
            TestX.If.Enumerable.MatchesExactly(e.Data, new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 });

        }

    }
}
