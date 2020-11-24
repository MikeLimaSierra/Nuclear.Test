using System;
using System.Collections.Generic;
using System.Diagnostics;

using log4net;

using Nuclear.Exceptions;
using Nuclear.Extensions;
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

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Remote<TConfiguration>));

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

        #region event handlers

        private void OnClientConnected(Object sender, EventArgs e) {
            _log.Debug(nameof(OnClientConnected));

            Link.ClientConnected -= OnClientConnected;
            RaiseClientConnected();

            if(Link.Connect()) {
                _log.Info("Connecting to client.");

                SendSetup();
                Link.MessageReceived += OnResultsReceived;
                Link.MessageReceived += OnFinishedReceived;
                SendExecute();

            } else {
                _log.Error("Failed to connect to client.");
            }
        }

        private void OnResultsReceived(Object sender, MessageReceivedEventArgs e) {
            _log.Debug(nameof(OnResultsReceived));

            if(e.Message.Command == Commands.Results) {
                _log.Info("Results message received.");

                // TODO: handle results
            }
        }

        private void OnFinishedReceived(Object sender, MessageReceivedEventArgs e) {
            _log.Debug(nameof(OnFinishedReceived));

            if(e.Message.Command == Commands.Finished) {
                _log.Info("Finished message received.");

                Link.MessageReceived -= OnResultsReceived;
                Link.MessageReceived -= OnFinishedReceived;
                RaiseRemotingFinished();
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        public void Execute() {
            _log.Debug(nameof(Execute));

            Link.ClientConnected += OnClientConnected;

            if(Configuration.Executable != null && Configuration.Executable.Exists) {
                StartProcess();

            } else {
                _log.Error("Failed to start the client process.");
            }
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Gets the message containing setup data for the attached client.
        /// </summary>
        /// <param name="message">The message for the client.</param>
        /// <returns>A message object containing setup data.</returns>
        protected virtual IMessage GetSetupMessage(IMessage message) {
            _log.Debug(nameof(GetSetupMessage));

            Throw.If.Object.IsNull(message, nameof(message));

            return message;
        }

        /// <summary>
        /// Raises the event <see cref="ClientConnected"/>.
        /// </summary>
        protected internal void RaiseClientConnected() {
            _log.Debug(nameof(RaiseClientConnected));

            ClientConnected?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Raises the event <see cref="ConnectionLost"/>.
        /// </summary>
        protected internal void RaiseConnectionLost() {
            _log.Debug(nameof(RaiseConnectionLost));

            ConnectionLost?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Raises the event <see cref="ResultsReceived"/> with the given <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The raw bytes that were received.</param>
        protected internal void RaiseResultsReceived(Byte[] data) {
            _log.Debug(nameof(RaiseResultsReceived));

            ResultsReceived?.Invoke(this, new ResultsReceivedEventArgs(data));
        }

        /// <summary>
        /// Raises the event <see cref="ResultsAvailable"/> with the given <paramref name="resultCollection"/>.
        /// </summary>
        /// <param name="resultCollection">The results that were received and deserialized.</param>
        protected internal void RaiseResultsAvailable(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> resultCollection) {
            _log.Debug(nameof(RaiseResultsAvailable));

            ResultsAvailable?.Invoke(this, new ResultsAvailableEventArgs(resultCollection));
        }

        /// <summary>
        /// Raises the event <see cref="RemotingFinished"/>.
        /// </summary>
        protected internal void RaiseRemotingFinished() {
            _log.Debug(nameof(RaiseRemotingFinished));

            RemotingFinished?.Invoke(this, new EventArgs());
        }

        #endregion

        #region private methods

        /// <summary>
        /// Initializes the process that will be remote controlled.
        /// </summary>
        private void StartProcess() {
            _log.Debug(nameof(StartProcess));

            using(Process process = new Process()) {
                process.StartInfo.FileName = Configuration.Executable.FullName;
                process.StartInfo.Arguments = Link.PipeID;
                process.StartInfo.UseShellExecute = Configuration.StartClientVisible;
                process.StartInfo.CreateNoWindow = !Configuration.StartClientVisible;

                _log.Info($"Starting process {Configuration.Executable.FullName.Format()} {Link.PipeID.Format()} ...");

                process.Start();
            }
        }

        /// <summary>
        /// Sends the <see cref="Commands.Setup"/> message to the attached client.
        /// </summary>
        private void SendSetup() {
            _log.Debug(nameof(SendSetup));

            Link.Send(GetSetupMessage(new Message(Commands.Setup)));
        }

        /// <summary>
        /// Sends the <see cref="Commands.Execute"/> message to the attached client.
        /// </summary>
        private void SendExecute() {
            _log.Debug(nameof(SendExecute));

            Link.Send(new Message(Commands.Execute));
        }

        #endregion

    }
}
