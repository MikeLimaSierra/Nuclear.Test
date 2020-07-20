using System;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public class Message : IMessage {

        #region properties

        /// <summary>
        /// Gets the command.
        /// </summary>
        public String Command { get; internal set; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        public Byte[] Payload { get; internal set; }

        #endregion

        #region ctors

        private Message() { }

        #endregion

        #region methods

        public Int32 CompareTo(Object obj) => throw new NotImplementedException();

        public Int32 CompareTo(IMessage other) => throw new NotImplementedException();

        public override Boolean Equals(Object obj) => obj != null && obj is IMessage other && Equals(other);

        public Boolean Equals(IMessage other) => other != null && other.Command == Command && other.Payload == Payload;

        public override Int32 GetHashCode() => Command.GetHashCode() ^ Payload.GetHashCode();

        public override String ToString() => $"{typeof(Message).Format()} ({Command.Format()} => {Payload.Length.Format()} Bytes)";

        #endregion

        #region static methods

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Byte[] payload) {
            Throw.If.Object.IsNull(command, nameof(command));
            Throw.If.Object.IsNull(payload, nameof(payload));

            return new Message() { Command = command, Payload = payload };
        }

        #endregion

    }
}
