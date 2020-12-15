using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines the basic communication link.
    /// </summary>
    public interface ILink {

        #region events

        /// <summary>
        /// Is raised when an <see cref="IMessage"/> is received through the input channel.
        /// </summary>
        event MessageReceivedEventHandler MessageReceived;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the number of milliseconds to wait for the server to respond before the connection to another <see cref="ILink"/> times out.
        /// </summary>
        Int32 ConnectionTimeout { get; set; }

        /// <summary>
        /// Gets the ID that both inbound and outbound pipe IDs are based on.
        /// </summary>
        String PipeID { get; }

        /// <summary>
        /// Gets the ID of the outbound pipe.
        /// </summary>
        String PipeIDOut { get; }

        /// <summary>
        /// Gets the ID of the inbound pipe.
        /// </summary>
        String PipeIDIn { get; }

        #endregion

        #region methods

        /// <summary>
        /// Starts the output channel.
        /// </summary>
        /// <returns>True if successful.</returns>
        Boolean StartOutput();

        /// <summary>
        /// Stops the output channel.
        /// </summary>
        /// <returns>True if successful.</returns>
        Boolean StopOutput();

        /// <summary>
        /// Waits for a connecting <see cref="ILink"/> on the output channel.
        /// </summary>
        /// <returns>True if a connection was established.</returns>
        Boolean WaitForConnection();

        /// <summary>
        /// Connects to the output channel of another <see cref="ILink"/>.
        /// </summary>
        /// <returns>True if successful.</returns>
        Boolean ConnectInput();

        /// <summary>
        /// Sends an <see cref="IMessage"/> through the output channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        void Send(IMessage message);

        /// <summary>
        /// Waits until the output buffer has been emptied.
        /// </summary>
        void WaitForOutputFlush();

        #endregion

    }
}
