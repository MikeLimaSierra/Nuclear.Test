using System;

using Nuclear.Exceptions;
using Nuclear.Test.Link;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Implements the base functionality of a remote controlled test client.
    /// </summary>
    public abstract class Client : IClient {

        #region events

        /// <summary>
        /// Is raised when the remote connects.
        /// </summary>
        public event EventHandler RemoteConnected;

        /// <summary>
        /// Is raised when the connection to the remote was lost.
        /// </summary>
        public event EventHandler ConnectionLost;

        /// <summary>
        /// Is raised when the client has finished processing and all results have been transfered.
        /// </summary>
        public event EventHandler ExecutionFinished;

        #endregion

        #region fields

        private readonly IClientLink _link;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Client"/>.
        /// </summary>
        /// <param name="link">The link object used to communicate with the remote.</param>
        public Client(IClientLink link) {
            Throw.If.Object.IsNull(link, nameof(link));

            _link = link;
            _link.ServerConnected += OnServerConnected;
            _link.Start();
            _link.MessageReceived += OnSetupReceived;
            _link.MessageReceived += OnExecuteReceived;
            _link.Connect();
        }

        private void OnSetupReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Setup) {
                _link.MessageReceived -= OnSetupReceived;
                // TODO: load setup data
            }
        }

        private void OnExecuteReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Execute) {
                _link.MessageReceived -= OnExecuteReceived;
                Execute();
            }
        }

        #endregion

        #region event handlers

        private void OnServerConnected(Object sender, EventArgs e) {
            _link.ServerConnected -= OnServerConnected;
            RaiseRemoteConnected();
        }

        #endregion

        #region methods

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        public void Execute() => throw new NotImplementedException();

        #endregion

        #region protected methods

        /// <summary>
        /// Raises the event <see cref="RemoteConnected"/>.
        /// </summary>
        protected internal void RaiseRemoteConnected() => RemoteConnected?.Invoke(this, new EventArgs());

        /// <summary>
        /// Raises the event <see cref="ConnectionLost"/>.
        /// </summary>
        protected internal void RaiseConnectionLost() => ConnectionLost?.Invoke(this, new EventArgs());

        /// <summary>
        /// Raises the event <see cref="ExecutionFinished"/>.
        /// </summary>
        protected internal void RaiseExecutionFinished() => ExecutionFinished?.Invoke(this, new EventArgs());

        #endregion

    }
}
