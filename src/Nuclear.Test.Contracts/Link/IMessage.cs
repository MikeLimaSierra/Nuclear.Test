using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public interface IMessage {

        #region properties

        Int32 Index { get; internal set; }

        String Command { get; }

        Byte[] Payload { get; }

        #endregion

    }
}
