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
        protected IClientConfiguration Configuration { get; private set; }

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
        /// Creates a new instance of <see cref="Client"/>.
        /// </summary>
        /// <param name="link">The link object used to communicate with the remote.</param>
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

        private void OnSetupReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Setup) {
                _link.MessageReceived -= OnSetupReceived;
                Setup(e.Message);
            }
        }

        private void OnExecuteReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Execute) {
                _link.MessageReceived -= OnExecuteReceived;
                Execute();
            }
        }

        private void OnServerConnected(Object sender, EventArgs e) {
            _link.ServerConnected -= OnServerConnected;
            RaiseRemoteConnected();
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Loads setup data from <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message containing the setup.</param>
        protected virtual void Setup(IMessage message) {
            if(message.Command == Commands.Setup && message.TryGetData(out IClientConfiguration config)) {
                Configuration = config;

                if(AssemblyHelper.TryLoadFrom(Configuration.File, out Assembly testAssembly)) {
                    TestAssembly = testAssembly;

                    if(AssemblyHelper.TryGetAssemblyName(Configuration.File, out AssemblyName testAssemblyName)) {
                        TestAssemblyName = testAssemblyName;
                    }

                    if(AssemblyHelper.TryGetRuntime(TestAssembly, out RuntimeInfo testAssemblyRuntime)) {
                        TestAssemblyRuntime = testAssemblyRuntime;
                    }
                }
            }
        }

        /// <summary>
        /// Commands the client to execute its task.
        /// </summary>
        protected virtual void Execute() {
            SetConsoleTitle();
            PrintProcessInfo();
            PrintAssemblyInfo();
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

        private void PrintProcessInfo() {

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

        private void PrintAssemblyInfo() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine("║                             Test Assembly                            ║");
            sb.AppendLine("╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat("║            Name: {1}    ║{0}", Environment.NewLine, TestAssemblyName.Name.PadRight(48, ' '));
            sb.AppendFormat("║        Platform: {1}    ║{0}", Environment.NewLine, TestAssemblyRuntime.Framework.ToString().PadRight(48, ' '));
            sb.AppendFormat("║         Version: {1}    ║{0}", Environment.NewLine, TestAssemblyRuntime.Version.ToString().PadRight(48, ' '));
            sb.AppendFormat("║    Architecture: {1}    ║{0}", Environment.NewLine, TestAssemblyName.ProcessorArchitecture.ToString().PadRight(48, ' '));
            sb.AppendLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        #endregion

    }
}
