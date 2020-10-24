using System;
using System.Collections.Generic;
using System.Diagnostics;

using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Implements the base functionality of a remote control for test clients.
    /// </summary>
    public abstract class Remote<TConfiguration> : IRemote<TConfiguration>
        where TConfiguration : IRemoteConfiguration {

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

        #region properties

        /// <summary>
        /// Gets the communication link object.
        /// </summary>
        protected IServerLink Link { get; }

        /// <summary>
        /// Gets the client configuration object.
        /// </summary>
        public TConfiguration Configuration { get; protected set; }

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        public ITestResultEndPoint Results { get; } = new TestResultEndPoint();

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Remote{TConfiguration}"/>.
        /// </summary>
        /// <param name="configuration">The remote configuration object.</param>
        /// <param name="link">The link object used to communicate with the client.</param>
        public Remote(TConfiguration configuration, IServerLink link) {
            Throw.If.Object.IsNull(configuration, nameof(configuration));
            Throw.If.Object.IsNull(link, nameof(link));

            Configuration = configuration;
            Link = link;
        }

        #endregion

        #region abstract methods

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Sends the <see cref="Commands.Setup"/> message to the attached <see cref="IClient"/>.
        /// </summary>
        private void SendSetup() => Link.Send(GetSetupMessage(new Message(Commands.Setup)));

        /// <summary>
        /// Gets the message containing setup data for the connected client.
        /// </summary>
        /// <param name="message">The message for the client.</param>
        /// <returns></returns>
        protected virtual IMessage GetSetupMessage(IMessage message) {
            Throw.If.Object.IsNull(message, nameof(message));

            message.Append(_clientConfig);

            return message;
        }

        /// <summary>
        /// Sends the <see cref="Commands.Execute"/> message to the attached <see cref="IClient"/>.
        /// </summary>
        protected void SendExecute() => Link.Send(new Message(Commands.Execute));

        #endregion

        #region protected methods

        /// <summary>
        /// Initializes the process that will be remote controlled.
        /// </summary>
        protected void StartProcess() {
            using(Process process = new Process()) {
                process.StartInfo.FileName = Configuration.Executable.FullName;
                process.StartInfo.Arguments = Link.PipeID;
                process.StartInfo.UseShellExecute = Configuration.StartClientVisible;
                process.StartInfo.CreateNoWindow = !Configuration.StartClientVisible;
                //DiagnosticOutput.Log(OutputConfiguration, "Starting process '{0} {1}' ...", executable.FullName, pipeName);
                process.Start();
            }
        }

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
