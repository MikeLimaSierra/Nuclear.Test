using System;
using System.IO;

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
        public String Command { get; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        public MemoryStream Payload { get; private set; }

        #endregion

        #region ctors

        private Message(String command, MemoryStream payload) {
            Throw.If.String.IsNullOrWhiteSpace(command, nameof(command));
            Throw.If.Object.IsNull(payload, nameof(payload));

            Command = command;
            Payload = payload;
        }

        private Message(String command) : this(command, new MemoryStream()) { }

        #endregion

        #region methods

        public override String ToString() => $"{typeof(Message).Format()} ({Command.Format()} => {Payload.Length.Format()} Bytes)";

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected virtual void Dispose(Boolean disposing) {
            if(!_disposedValue) {
                if(disposing) {
                    Payload?.Dispose();
                    Payload = null;
                }

                _disposedValue = true;
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        #region static creation methods

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command) => new Message(command);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Boolean data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Byte data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, SByte data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Char data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int16 data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt16 data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int32 data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt32 data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int64 data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt64 data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Single data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Double data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Decimal data) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, String data) {
            Throw.If.Object.IsNull(data, nameof(data));

            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Byte[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Char[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(data);
            }

            return new Message(command, ms);
        }

        #endregion

    }
}
