using System;

using Nuclear.Test.Execution;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class ResultsReceivedEventArgs_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.IsSubClass<ResultsReceivedEventArgs, EventArgs>();

        }

        [TestMethod]
        void Ctor() {

            ResultsReceivedEventArgs e = null;

            TestX.If.Action.ThrowsException(() => e = new ResultsReceivedEventArgs(null), out ArgumentException ex);
            TestX.If.Value.IsEqual(ex.ParamName, "data");

            TestX.IfNot.Action.ThrowsException(() => e = new ResultsReceivedEventArgs(new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 }), out Exception ex1);
            TestX.If.Enumerable.MatchesExactly(e.Data, new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 });

        }

    }
}
