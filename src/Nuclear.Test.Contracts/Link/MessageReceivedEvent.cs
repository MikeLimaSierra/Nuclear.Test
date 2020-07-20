using System;

using Nuclear.Exceptions;

namespace Nuclear.Test.Link {

    /// <summary>
    /// An event handler delegate to handle <see cref="MessageReceivedEventArgs"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    public delegate void MessageReceivedEventHandler(Object sender, MessageReceivedEventArgs e);

    /// <summary>
    /// An event holding a message that was received.
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs {

        #region properties

        /// <summary>
        /// Gets the message that was received.
        /// </summary>
        public IMessage Message { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates an instance of <see cref="MessageReceivedEventArgs"/>.
        /// </summary>
        /// <param name="message">The message that was received.</param>
        public MessageReceivedEventArgs(IMessage message) {
            Throw.If.Object.IsNull(message, nameof(message));

            Message = message;
        }

        #endregion

    }
}
