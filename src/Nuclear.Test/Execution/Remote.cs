using System;
using System.Collections.Generic;

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
            _link = link;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Remote"/>.
        /// </summary>
        public Remote() { }

        #endregion

        #region public methods

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        public abstract void Execute();

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
