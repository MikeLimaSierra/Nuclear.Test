using System;

using log4net;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements the server side communication link.
    /// </summary>
    internal class ServerLink : Link, IServerLink {

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

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(ServerLink));

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
        internal ServerLink(String pipeID) : base(pipeID) { }

        #endregion

        #region ILink methods

        /// <summary>
        /// Waits for a connecting <see cref="ILink"/> on the output channel.
        /// </summary>
        /// <returns>True if a connection was established.</returns>
        public override Boolean WaitForConnection() {
            _log.Debug(nameof(WaitForConnection));

            if(base.WaitForConnection()) {
                RaiseClientConnected();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Connects to the output channel another <see cref="ILink"/>.
        /// </summary>
        /// <returns>True if successful.</returns>
        public override Boolean ConnectInput() {
            _log.Debug(nameof(ConnectInput));

            if(base.ConnectInput()) {
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
        protected internal void RaiseClientConnected() {
            _log.Debug(nameof(RaiseClientConnected));

            ClientConnected?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the event <see cref="ConnectedToClient"/>.
        /// </summary>
        protected internal void RaiseConnectedToClient() {
            _log.Debug(nameof(RaiseConnectedToClient));

            ConnectedToClient?.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }
}
