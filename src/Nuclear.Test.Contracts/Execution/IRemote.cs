using System;

using Nuclear.Test.Configurations;
using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of a remote control for clients.
    /// </summary>
    public interface IRemote {

        #region events

        /// <summary>
        /// Is raised when the client connects.
        /// </summary>
        event EventHandler ClientConnected;

        /// <summary>
        /// Is raised when the connection to the client was lost.
        /// </summary>
        event EventHandler ConnectionLost;

        /// <summary>
        /// Is raised when raw test data is received from the attached test client.
        /// </summary>
        event ResultsReceivedEventHandler ResultsReceived;

        /// <summary>
        /// Is raised when test results are deserialized and added to the results.
        /// </summary>
        event ResultsAvailableEventHandler ResultsAvailable;

        /// <summary>
        /// Is raised when the client has finished processing and all results have been transfered.
        /// </summary>
        event EventHandler RemotingFinished;

        #endregion

        #region properties

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        ITestResultEndPoint Results { get; }

        #endregion

        #region methods

        /// <summary>
        /// Commands to execute.
        /// </summary>
        void Execute();

        #endregion

    }
}
