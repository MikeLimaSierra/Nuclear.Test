using System;

namespace Nuclear.Test.Link {

    public interface IMessage {

        #region properties

        String Command { get; }

        Byte[] Payload { get; }

        #endregion

    }
}
