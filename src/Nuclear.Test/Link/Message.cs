using System;
using System.IO;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public partial class Message : IMessage {

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

        /// <summary>
        /// Creates a new empty instance of <see cref="Message"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="command"/> is null or empty.</exception>
        /// <param name="command">The message command.</param>
        public Message(String command) {
            Throw.If.String.IsNullOrWhiteSpace(command, nameof(command));

            Command = command;
            Payload = new MemoryStream();
        }

        #endregion

        #region methods

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override String ToString() => $"{typeof(Message).Format()} ({Command.Format()} => {Payload.Length.Format()} Bytes)";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

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

    }
}
