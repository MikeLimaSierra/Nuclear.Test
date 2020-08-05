using System;
using System.Collections.Generic;

using Nuclear.Exceptions;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Implements the base functionality of a remote control for test clients.
    /// </summary>
    public abstract class Remote : IRemote {

        #region events

        /// <summary>
        /// Is raised when the client connects.
        /// </summary>
        public event EventHandler ClientConnected;

        /// <summary>
        /// Is raised when the connection to the client was lost.
        /// </summary>
        public event EventHandler ConnectionLost;

        /// <summary>
        /// Is raised when raw test data is received from the attached test client.
        /// </summary>
        public event ResultsReceivedEventHandler ResultsReceived;

        /// <summary>
        /// Is raised when test results are deserialized and added to the results.
        /// </summary>
        public event ResultsAvailableEventHandler ResultsAvailable;

        /// <summary>
        /// Is raised when the client has finished processing and all results have been transfered.
        /// </summary>
        public event EventHandler RemotingFinished;

        #endregion

        #region fields

        private readonly IServerLink _link;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Remote"/>.
        /// </summary>
        /// <param name="link">The link object used to communicate with clients.</param>
        public Remote(IServerLink link) {
            Throw.If.Object.IsNull(link, nameof(link));

            _link = link;
            _link.ClientConnected += OnClientConnected;
            _link.Start();
        }

        #endregion

        #region event handlers

        private void OnClientConnected(Object sender, EventArgs e) {
            _link.ClientConnected -= OnClientConnected;
            RaiseClientConnected();
            _link.ConnectedToClient += OnConnectedToClient;
            _link.Connect();
        }

        private void OnConnectedToClient(Object sender, EventArgs e) {
            _link.ConnectedToClient -= OnConnectedToClient;
            SetupClient();
            _link.MessageReceived += OnResultsReceived;
            _link.MessageReceived += OnExecutionFinished;
            ExecuteClient();
        }

        private void OnResultsReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Results) {
                RaiseResultsReceived(e.Message.Payload.ToArray());

                if(e.Message.TryGetData(out IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results)) {
                    RaiseResultsAvailable(results);
                }
            }
        }

        private void OnExecutionFinished(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Finished) {
                _link.MessageReceived -= OnResultsReceived;
                _link.MessageReceived -= OnExecutionFinished;
                RaiseRemotingFinished();
            }
        }

        #endregion

        #region abstract methods

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Sends configuration and test information to the client.
        /// </summary>
        protected abstract void SetupClient();

        /// <summary>
        /// Commands the client to execute.
        /// </summary>
        protected abstract void ExecuteClient();

        #endregion

        #region protected methods

        /// <summary>
        /// Raises the event <see cref="ClientConnected"/>.
        /// </summary>
        protected internal void RaiseClientConnected() => ClientConnected?.Invoke(this, new EventArgs());

        /// <summary>
        /// Raises the event <see cref="ConnectionLost"/>.
        /// </summary>
        protected internal void RaiseConnectionLost() => ConnectionLost?.Invoke(this, new EventArgs());

        /// <summary>
        /// Raises the event <see cref="ResultsReceived"/> with the given <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The raw bytes that were received.</param>
        protected internal void RaiseResultsReceived(Byte[] data) => ResultsReceived?.Invoke(this, new ResultsReceivedEventArgs(data));

        /// <summary>
        /// Raises the event <see cref="ResultsAvailable"/> with the given <paramref name="resultCollection"/>.
        /// </summary>
        /// <param name="resultCollection">The results that were received and deserialized.</param>
        protected internal void RaiseResultsAvailable(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> resultCollection)
            => ResultsAvailable?.Invoke(this, new ResultsAvailableEventArgs(resultCollection));

        /// <summary>
        /// Raises the event <see cref="RemotingFinished"/>.
        /// </summary>
        protected internal void RaiseRemotingFinished() => RemotingFinished?.Invoke(this, new EventArgs());

        #endregion

    }
}
