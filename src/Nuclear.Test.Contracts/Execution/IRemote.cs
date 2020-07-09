using System;
using System.Collections.Generic;
using System.Text;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of remote control for test clients.
    /// </summary>
    public interface IRemote {

        #region events

        /// <summary>
        /// Is raised when raw test data is received from the attached test client.
        /// </summary>
        public event ResultsReceivedEventHandler ResultsReceived;

        /// <summary>
        /// Is raised when test results are deserialized and added to the results.
        /// </summary>
        public event ResultsAvailableEventHandler ResultsAvailable;

        /// <summary>
        /// Is raised when all test results have been sent.
        /// </summary>
        public event EventHandler Finished;

        #endregion

    }
}
