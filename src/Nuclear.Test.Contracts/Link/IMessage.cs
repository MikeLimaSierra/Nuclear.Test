using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public interface IMessage : IEquatable<IMessage>, IComparable<IMessage>, IComparable {

        #region properties

        /// <summary>
        /// Gets the command.
        /// </summary>
        String Command { get; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        Byte[] Payload { get; }

        #endregion

    }
}
