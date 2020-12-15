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
    /// <typeparam name="TRemoteConfiguration">The remote configuration type.</typeparam>
    /// <typeparam name="TClientConfiguration">The client configuration type.</typeparam>
    public abstract class Remote<TRemoteConfiguration, TClientConfiguration> : IRemote<TRemoteConfiguration, TClientConfiguration>
        where TRemoteConfiguration : IRemoteConfiguration<TClientConfiguration>
        where TClientConfiguration : IClientConfiguration {

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

        private static readonly ILog _log = LogManager.GetLogger(typeof(Remote<TRemoteConfiguration, TClientConfiguration>));

        #endregion

        #region properties

        /// <summary>
        /// Gets the communication link object.
        /// </summary>
        protected IServerLink Link { get; }

        /// <summary>
        /// Gets the client configuration object.
        /// </summary>
        public TRemoteConfiguration Configuration { get; }

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        public ITestResultEndPoint Results { get; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Remote{TRemoteConfiguration, TClientConfiguration}"/>.
        /// </summary>
        /// <param name="configuration">The remote configuration object.</param>
        /// <param name="link">The link object used to communicate with the client.</param>
        public Remote(TRemoteConfiguration configuration, IServerLink link) {
            Throw.If.Object.IsNull(configuration, nameof(configuration));
            Throw.If.Object.IsNull(link, nameof(link));

            Configuration = configuration;

            if(!Configuration.StartClientVisible) {
                Configuration.ClientConfiguration.AutoShutdown = true;
            }

            Link = link;

            Factory.Instance.Create(out ITestResultEndPoint result);
            Results = result;
        }

        #endregion

        #region event handlers

        private void OnClientConnected(Object sender, EventArgs e) {
            _log.Debug(nameof(OnClientConnected));

            Link.ClientConnected -= OnClientConnected;
            RaiseClientConnected();

            if(Link.ConnectInput()) {
                _log.Info("Connected to client.");

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

                RaiseResultsReceived(e.Message.Payload.ToArray());

                if(e.Message.TryGetData(out IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> resultCollection)) {
                    RaiseResultsAvailable(resultCollection);
                }
            }
        }

        private void OnFinishedReceived(Object sender, MessageReceivedEventArgs e) {
            _log.Debug(nameof(OnFinishedReceived));

            if(e.Message.Command == Commands.Finished) {
                _log.Info("Finished message received.");

                Link.MessageReceived -= OnResultsReceived;
                Link.MessageReceived -= OnFinishedReceived;
                RaiseRemotingFinished();
                SendFinished();
                Link.StopOutput();
            }
        }

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected virtual void Dispose(Boolean disposing) {
            _log.Debug(nameof(Dispose));
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        #region public methods

        /// <summary>
        /// Commands to execute.
        /// </summary>
        public void Execute() {
            _log.Debug(nameof(Execute));

            if(Configuration.Executable != null && Configuration.Executable.Exists) {
                Link.StartOutput();
                StartProcess();
                Link.ClientConnected += OnClientConnected;
                Link.WaitForConnection();

            } else {
                _log.Error("Failed to start the client process.");
            }
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Gets the message containing setup data for the attached client.
        /// </summary>
        /// <returns>A message object containing setup data.</returns>
        protected virtual IMessage GetSetupMessage() {
            _log.Debug(nameof(GetSetupMessage));

            Factory.Instance.Create(out IMessage message, Commands.Setup);
            return message;
        }

        /// <summary>
        /// Raises the event <see cref="ClientConnected"/>.
        /// </summary>
        protected internal void RaiseClientConnected() {
            _log.Debug(nameof(RaiseClientConnected));

            ClientConnected?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the event <see cref="ConnectionLost"/>.
        /// </summary>
        protected internal void RaiseConnectionLost() {
            _log.Debug(nameof(RaiseConnectionLost));

            ConnectionLost?.Invoke(this, EventArgs.Empty);
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

            RemotingFinished?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sends the <see cref="Commands.Finished"/> message to the attached remote.
        /// </summary>
        protected void SendFinished() {
            _log.Debug(nameof(SendFinished));

            Factory.Instance.Create(out IMessage message, Commands.Finished);
            Link.Send(message);
            Link.WaitForOutputFlush();
            Link.StopOutput();
        }

        #endregion

        #region private methods

        private void StartProcess() {
            _log.Debug(nameof(StartProcess));

            using(Process process = new Process()) {
                process.StartInfo.FileName = Configuration.Executable.FullName;
                process.StartInfo.Arguments = Link.PipeID;
                process.StartInfo.UseShellExecute = Configuration.StartClientVisible;
                process.StartInfo.CreateNoWindow = !Configuration.StartClientVisible;
                process.StartInfo.WorkingDirectory = Configuration.Executable.Directory.FullName;

                _log.Info($"Starting process {Configuration.Executable.FullName.Format()} {Link.PipeID.Format()} ...");

                process.Start();
            }
        }

        private void SendSetup() {
            _log.Debug(nameof(SendSetup));

            Link.Send(GetSetupMessage());
        }

        private void SendExecute() {
            _log.Debug(nameof(SendExecute));

            Factory.Instance.Create(out IMessage message, Commands.Execute);
            Link.Send(message);
        }

        #endregion

    }
}
