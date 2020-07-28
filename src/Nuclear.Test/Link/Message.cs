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

        #endregion

        #region methods

        public override String ToString() => $"{typeof(Message).Format()} ({Command.Format()} => {Payload.Length.Format()} Bytes)";

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

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

        #endregion

        #region static methods

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Boolean payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Byte payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, SByte payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Char payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Int16 payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, UInt16 payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Int32 payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, UInt32 payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Int64 payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, UInt64 payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Single payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Double payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Decimal payload) {
            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, String payload) {
            Throw.If.Object.IsNull(payload, nameof(payload));

            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Byte[] payload) {
            Throw.If.Object.IsNull(payload, nameof(payload));

            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="payload">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage FromData(String command, Char[] payload) {
            Throw.If.Object.IsNull(payload, nameof(payload));

            MemoryStream ms = new MemoryStream();

            using(BinaryWriter bw = new BinaryWriter(ms)) {
                bw.Write(payload);
            }

            return new Message(command, ms);
        }

        #endregion

    }
}
