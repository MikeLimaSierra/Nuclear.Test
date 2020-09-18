using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines the basic communication link.
    /// </summary>
    public interface ILink : IDisposable {

        #region events

        /// <summary>
        /// Is raised when an <see cref="IMessage"/> is received through the input channel.
        /// </summary>
        event MessageReceivedEventHandler MessageReceived;

        #endregion

        #region methods

        /// <summary>
        /// Starts the output channel.
        /// </summary>
        /// <returns>True if successful.</returns>
        Boolean Start();

        /// <summary>
        /// Connects to another <see cref="ILink"/>.
        /// </summary>
        /// <returns>True if successful.</returns>
        Boolean Connect();

        /// <summary>
        /// Disconnects from the input channel and stops the output channel.
        /// </summary>
        void Stop();

        /// <summary>
        /// Sends an <see cref="IMessage"/> through the output channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Boolean Send(IMessage message);

        #endregion

    }
}
