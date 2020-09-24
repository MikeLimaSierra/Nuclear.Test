using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

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

        private readonly RuntimeInfo _currentRuntime;

        #endregion

        #region properties

        /// <summary>
        /// Gets the client configuration object.
        /// </summary>
        protected IClientConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        protected ITestResultEndPoint Results { get; } = new TestResultEndPoint();

        /// <summary>
        /// Gets or sets the header content as a <see cref="List{String}"/>.
        /// </summary>
        protected List<String> HeaderContent { get; } = new List<String>();

        /// <summary>
        /// Gets the runtime architecture.
        /// </summary>
        protected ProcessorArchitecture RuntimeArchitecure => Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Client"/>.
        /// </summary>
        /// <param name="link">The link object used to communicate with the remote.</param>
        /// <param name="clientConfig">The client configuration object.</param>
        public Client(IClientLink link) {
            Throw.If.Object.IsNull(link, nameof(link));

            _link = link;

            RuntimesHelper.TryGetCurrentRuntime(out _currentRuntime);

            _link.ServerConnected += OnServerConnected;
            _link.Start();
            _link.MessageReceived += OnSetupReceived;
            _link.MessageReceived += OnExecuteReceived;
            _link.Connect();
        }

        #endregion

        #region event handlers

        /// <summary>
        /// Called when a message with <see cref="Commands.Setup"/> is received.
        ///     Loads the <see cref="IClientConfiguration"/> first.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MessageReceivedEventArgs"/>.</param>
        protected virtual void OnSetupReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Setup) {
                _link.MessageReceived -= OnSetupReceived;

                if(e.Message.TryGetData(out IClientConfiguration config)) {
                    Configuration = config;
                }
            }
        }

        private void OnExecuteReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Execute) {
                _link.MessageReceived -= OnExecuteReceived;

                SetConsoleTitle();
                PrintProcessInfo();

                Execute();
            }
        }

        private void OnServerConnected(Object sender, EventArgs e) {
            _link.ServerConnected -= OnServerConnected;
            RaiseRemoteConnected();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        public abstract void Execute();

        #endregion

        #region protected methods

        /// <summary>
        /// Prints an information panel to console that details the currently running executor instance.
        /// </summary>
        protected void PrintProcessInfo() {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");

            foreach(String line in HeaderContent) {
                sb.AppendFormat("║    {1}    ║{0}", Environment.NewLine, line.PadRight(60, ' '));
            }

            sb.AppendLine("╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat("║        Platform: {1}    ║{0}", Environment.NewLine, _currentRuntime.Framework.ToString().PadRight(48, ' '));
            sb.AppendFormat("║         Version: {1}    ║{0}", Environment.NewLine, _currentRuntime.Version.ToString().PadRight(48, ' '));
            sb.AppendFormat("║    Architecture: {1}    ║{0}", Environment.NewLine, RuntimeArchitecure.ToString().PadRight(48, ' '));
            sb.AppendLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        /// <summary>
        /// Prints an information panel to console that details the currently loaded test assembly.
        /// </summary>
        /// <param name="asmName"></param>
        /// <param name="targetRuntime"></param>
        protected void PrintAssemblyInfo(AssemblyName asmName, RuntimeInfo targetRuntime) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine("║                             Test Assembly                            ║");
            sb.AppendLine("╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat("║            Name: {1}    ║{0}", Environment.NewLine, asmName.Name.PadRight(48, ' '));
            sb.AppendFormat("║        Platform: {1}    ║{0}", Environment.NewLine, targetRuntime.Framework.ToString().PadRight(48, ' '));
            sb.AppendFormat("║         Version: {1}    ║{0}", Environment.NewLine, targetRuntime.Version.ToString().PadRight(48, ' '));
            sb.AppendFormat("║    Architecture: {1}    ║{0}", Environment.NewLine, asmName.ProcessorArchitecture.ToString().PadRight(48, ' '));
            sb.AppendLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

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

        #region private methods

        private void SetConsoleTitle() => Console.Title = $"{_currentRuntime} - {RuntimeArchitecure} - {Assembly.GetEntryAssembly().GetName().Name}";

        #endregion

    }
}
