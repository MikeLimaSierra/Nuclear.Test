﻿using System;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Link {
    class MessageReceivedEventArgs_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.IsSubClass<MessageReceivedEventArgs, EventArgs>();

        }

        [TestMethod]
        void Ctor() {

            MessageReceivedEventArgs e = null;
            IMessage msg = new Message("command").Append(new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 });

            TestX.If.Action.ThrowsException(() => e = new MessageReceivedEventArgs(null), out ArgumentException ex);
            TestX.If.Value.IsEqual(ex.ParamName, "message");

            TestX.IfNot.Action.ThrowsException(() => e = new MessageReceivedEventArgs(msg), out Exception ex1);
            TestX.If.Reference.IsEqual(e.Message, msg);
            TestX.If.Value.IsEqual(e.Message.Command, "command");
            TestX.If.Enumerable.MatchesExactly(e.Message.Payload.ToArray(), new Byte[] { 0x01, 0x02, 0x03, 0x04, 0x06 });

        }

    }
}
