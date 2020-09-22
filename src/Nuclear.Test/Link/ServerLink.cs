using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements the server side communication link.
    /// </summary>
    public class ServerLink : Link, IServerLink {

        #region events

        /// <summary>
        /// Is raised when the client has made connection to the output channel.
        /// </summary>
        public event EventHandler ClientConnected;

        /// <summary>
        /// Is raised when connected to the output channel of an <see cref="IClientLink"/>.
        /// </summary>
        public event EventHandler ConnectedToClient;

        #endregion

        #region properties

        /// <summary>
        /// Gets the ID of the outbound pipe.
        /// </summary>
        public override String PipeIDOut => $"{PipeID}-Server";

        /// <summary>
        /// Gets the ID of the inbound pipe.
        /// </summary>
        public override String PipeIDIn => $"{PipeID}-Client";

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ServerLink"/>.
        /// </summary>
        /// <param name="pipeID">The ID that both inbound and outbound pipe IDs are based on.</param>
        public ServerLink(String pipeID) : base(pipeID) { }

        #endregion

        #region ILink methods

        /// <summary>
        /// Starts the output channel.
        /// </summary>
        /// <returns>True if successful.</returns>
        public override Boolean Start() {
            if(base.Start()) {
                RaiseClientConnected();
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
                RaiseConnectedToClient();
                return true;
            }

            return false;
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Raises the event <see cref="ClientConnected"/>.
        /// </summary>
        protected internal void RaiseClientConnected() => ClientConnected?.Invoke(this, new EventArgs());

        /// <summary>
        /// Raises the event <see cref="ConnectedToClient"/>.
        /// </summary>
        protected internal void RaiseConnectedToClient() => ConnectedToClient?.Invoke(this, new EventArgs());

        #endregion

    }
}
