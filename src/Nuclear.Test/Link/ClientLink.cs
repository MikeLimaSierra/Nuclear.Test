using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements the client side communication link.
    /// </summary>
    internal class ClientLink : Link, IClientLink {

        #region events

        /// <summary>
        /// Is raised when the server has made connection to the output channel.
        /// </summary>
        public event EventHandler ServerConnected;

        /// <summary>
        /// Is raised when connected to the output channel of an <see cref="IServerLink"/>.
        /// </summary>
        public event EventHandler ConnectedToServer;

        #endregion

        #region properties

        /// <summary>
        /// Gets the ID of the outbound pipe.
        /// </summary>
        public override String PipeIDOut => $"{PipeID}-Client";

        /// <summary>
        /// Gets the ID of the inbound pipe.
        /// </summary>
        public override String PipeIDIn => $"{PipeID}-Server";

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClientLink"/>.
        /// </summary>
        /// <param name="pipeID">The ID that both inbound and outbound pipe IDs are based on.</param>
        internal ClientLink(String pipeID) : base(pipeID) { }

        #endregion

        #region ILink methods

        /// <summary>
        /// Starts the output channel.
        /// </summary>
        /// <returns>True if successful.</returns>
        public override Boolean Start() {
            if(base.Start()) {
                RaiseServerConnected();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Connects to another <see cref="ILink"/>.
        /// </summary>
        /// <returns>True if successful.</returns>
        public override Boolean Connect() {
            if(base.Connect()) {
                RaiseConnectedToServer();
                return true;
            }

            return false;
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Raises the event <see cref="ServerConnected"/>.
        /// </summary>
        protected internal void RaiseServerConnected() => ServerConnected?.Invoke(this, new EventArgs());

        /// <summary>
        /// Raises the event <see cref="ConnectedToServer"/>.
        /// </summary>
        protected internal void RaiseConnectedToServer() => ConnectedToServer?.Invoke(this, new EventArgs());

        #endregion
    }
}
