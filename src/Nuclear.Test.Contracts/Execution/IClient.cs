using System;

using Nuclear.Test.Configurations;
using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of a remote controlled test client.
    /// </summary>
    public interface IClient<TConfiguration>
        where TConfiguration : IClientConfiguration {

        #region events

        /// <summary>
        /// Is raised when the remote connects.
        /// </summary>
        event EventHandler RemoteConnected;

        /// <summary>
        /// Is raised when the connection to the remote was lost.
        /// </summary>
        event EventHandler ConnectionLost;

        /// <summary>
        /// Is raised when the client has finished processing and all results have been transfered.
        /// </summary>
        event EventHandler ExecutionFinished;

        #endregion

        #region properties

        /// <summary>
        /// Gets the client configuration object.
        /// </summary>
        TConfiguration Configuration { get; }

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        ITestResultEndPoint Results { get; }

        #endregion

    }
}
