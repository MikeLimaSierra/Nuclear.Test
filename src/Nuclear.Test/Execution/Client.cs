using System;
using System.Collections.Generic;
using System.Reflection;

using log4net;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Helpers;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Implements the base functionality of a remote controlled test client.
    /// </summary>
    public abstract class Client<TConfiguration> : IClient<TConfiguration>
        where TConfiguration : IClientConfiguration {

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

        private static readonly ILog _log = LogManager.GetLogger(typeof(Client<TConfiguration>));

        private readonly RuntimeInfo _currentRuntime;

        #endregion

        #region properties

        /// <summary>
        /// Gets the communication link object.
        /// </summary>
        protected IClientLink Link { get; }

        /// <summary>
        /// Gets the client configuration object.
        /// </summary>
        public TConfiguration Configuration { get; protected set; }

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        public ITestResultEndPoint Results { get; }

        /// <summary>
        /// Gets or sets the header content as a <see cref="List{String}"/>.
        /// </summary>
        protected List<String> HeaderContent { get; } = new List<String>();

        /// <summary>
        /// Gets the runtime architecture.
        /// </summary>
        protected ProcessorArchitecture RuntimeArchitecure => Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86;

        /// <summary>
        /// Gets the loaded test <see cref="Assembly"/> object.
        /// </summary>
        protected Assembly TestAssembly { get; private set; }

        /// <summary>
        /// Gets the <see cref="AssemblyName"/> of the <see cref="TestAssembly"/>.
        /// </summary>
        protected AssemblyName TestAssemblyName { get; private set; }

        /// <summary>
        /// Gets the <see cref="RuntimeInfo"/> of the <see cref="TestAssembly"/>.
        /// </summary>
        protected RuntimeInfo TestAssemblyRuntime { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Client{TConfiguration}"/>.
        /// </summary>
        /// <param name="link">The link object used to communicate with the remote.</param>
        public Client(IClientLink link) {
            Throw.If.Object.IsNull(link, nameof(link));

            Link = link;

            RuntimesHelper.TryGetCurrentRuntime(out _currentRuntime);

            Factory.Instance.Create(out ITestResultEndPoint result);
            Results = result;

            Link.StartOutput();
            Link.MessageReceived += OnSetupReceived;
            Link.MessageReceived += OnExecuteReceived;
            Link.ConnectInput();
            Link.ServerConnected += OnServerConnected;
            Link.WaitForConnection();
        }

        #endregion

        #region event handlers

        private void OnSetupReceived(Object sender, MessageReceivedEventArgs e) {
            _log.Debug(nameof(OnSetupReceived));

            if(e.Message.Command == Commands.Setup) {
                _log.Info("Setup message received.");

                Link.MessageReceived -= OnSetupReceived;

                try {
                    Configuration = LoadConfiguration(e.Message);
                    LoadAssembly();

                } catch(Exception ex) {
                    _log.Fatal("Failed to load configuration and load assembly.", ex);

                    RaiseExecutionFinished();
                }
            }
        }

        private void OnExecuteReceived(Object sender, MessageReceivedEventArgs e) {
            _log.Debug(nameof(OnExecuteReceived));

            if(e.Message.Command == Commands.Execute) {
                _log.Info("Execute message received.");

                Link.MessageReceived -= OnExecuteReceived;

                try {
                    Execute();

                } catch(Exception ex) {
                    _log.Fatal("Failed to execute.", ex);

                    RaiseExecutionFinished();
                }
            }
        }

        private void OnFinishedReceived(Object sender, MessageReceivedEventArgs e) {
            _log.Debug(nameof(OnFinishedReceived));

            if(e.Message.Command == Commands.Finished) {
                _log.Info("Finished message received.");

                Link.MessageReceived -= OnFinishedReceived;
                Link.StopOutput();
            }
        }

        private void OnServerConnected(Object sender, EventArgs e) {
            _log.Debug(nameof(OnServerConnected));

            Link.ServerConnected -= OnServerConnected;
            RaiseRemoteConnected();
        }

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected virtual void Dispose(Boolean disposing) {
            _log.Debug(nameof(Dispose));

            if(!_disposedValue) {
                if(disposing) {
                }

                _disposedValue = true;
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        #region protected methods

        /// <summary>
        /// Loads configuration data from <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message containing the configuration.</param>
        protected abstract TConfiguration LoadConfiguration(IMessage message);

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        protected virtual void Execute() {
            _log.Debug(nameof(Execute));

            ConsoleHelper.SetConsoleTitle(_currentRuntime);
            ConsoleHelper.PrintProcessInfo(_currentRuntime, HeaderContent);
            ConsoleHelper.PrintTestAssemblyInfo(TestAssemblyName, TestAssemblyRuntime);
        }

        /// <summary>
        /// Sends test results back to the attached remote.
        /// </summary>
        /// <param name="results">The test result collection that will be sent.</param>
        protected void SendResults(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results) {
            _log.Debug(nameof(SendResults));

            Factory.Instance.Create(out IMessage message, Commands.Results);
            message.Append(results);
            Link.Send(message);
        }

        /// <summary>
        /// Sends test results back to the attached remote.
        /// </summary>
        /// <param name="e">The <see cref="ResultsReceivedEventArgs"/> containing forwarded serialized test data.</param>
        protected void SendResults(ResultsReceivedEventArgs e) {
            _log.Debug(nameof(SendResults));

            Factory.Instance.Create(out IMessage message, Commands.Results);
            message.Append(e.Data);
            Link.Send(message);
        }

        /// <summary>
        /// Sends the <see cref="Commands.Finished"/> message to the attached remote.
        /// </summary>
        protected void SendFinished() {
            _log.Debug(nameof(SendFinished));

            Link.MessageReceived += OnFinishedReceived;
            Factory.Instance.Create(out IMessage message, Commands.Finished);
            Link.Send(message);
            Link.WaitForOutputFlush();
            Link.StopOutput();
        }

        /// <summary>
        /// Raises the event <see cref="RemoteConnected"/>.
        /// </summary>
        protected internal void RaiseRemoteConnected() {
            _log.Debug(nameof(RaiseRemoteConnected));

            RemoteConnected?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the event <see cref="ConnectionLost"/>.
        /// </summary>
        protected internal void RaiseConnectionLost() {
            _log.Debug(nameof(RaiseConnectionLost));

            ConnectionLost?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the event <see cref="ExecutionFinished"/>.
        /// </summary>
        protected internal void RaiseExecutionFinished() {
            _log.Debug(nameof(RaiseExecutionFinished));

            ExecutionFinished?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region private methods

        private void LoadAssembly() {
            _log.Debug(nameof(LoadAssembly));

            if(AssemblyHelper.TryLoadFrom(Configuration.TestAssembly, out Assembly testAssembly)) {
                _log.Debug($"Assembly loaded from {Configuration.TestAssembly.FullName.Format()}");

                TestAssembly = testAssembly;

                if(AssemblyHelper.TryGetAssemblyName(Configuration.TestAssembly, out AssemblyName testAssemblyName)) {
                    _log.Debug($"TestAssemblyName = {testAssemblyName.FullName.Format()}");

                    TestAssemblyName = testAssemblyName;

                } else { _log.Error($"Failed to get assembly name from {Configuration.TestAssembly.FullName.Format()}."); }

                if(AssemblyHelper.TryGetRuntime(TestAssembly, out RuntimeInfo testAssemblyRuntime)) {
                    _log.Debug($"TestAssemblyRuntime = {testAssemblyRuntime.Format()}");

                    TestAssemblyRuntime = testAssemblyRuntime;

                } else { _log.Error($"Failed to get runtime from {Configuration.TestAssembly.FullName.Format()}."); }

            } else { _log.Error($"Failed to loaded from {Configuration.TestAssembly.FullName.Format()}."); }
        }

        #endregion

    }
}
