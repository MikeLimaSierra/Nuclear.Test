using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
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
        public ITestResultEndPoint Results { get; } = new TestResultEndPoint();

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

            Link.ServerConnected += OnServerConnected;
            Link.Start();
            Link.MessageReceived += OnSetupReceived;
            Link.MessageReceived += OnExecuteReceived;
            Link.Connect();
        }

        #endregion

        #region event handlers

        private void OnSetupReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Setup) {
                Link.MessageReceived -= OnSetupReceived;
                Setup(e.Message);
            }
        }

        private void OnExecuteReceived(Object sender, MessageReceivedEventArgs e) {
            if(e.Message.Command == Commands.Execute) {
                Link.MessageReceived -= OnExecuteReceived;
                Execute();
            }
        }

        private void OnServerConnected(Object sender, EventArgs e) {
            Link.ServerConnected -= OnServerConnected;
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
            ConsoleHelper.SetConsoleTitle(_currentRuntime);
            ConsoleHelper.PrintProcessInfo(_currentRuntime, HeaderContent);
            ConsoleHelper.PrintTestAssemblyInfo(TestAssemblyName, TestAssemblyRuntime);
        }

        /// <summary>
        /// Sends test results back to the attached <see cref="IRemote"/>.
        /// </summary>
        /// <param name="results">The test result collection that will be sent.</param>
        protected void SendResults(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results) {
            IMessage message = new Message(Commands.Results);
            message.Append(results);
            Link.Send(message);
        }

        /// <summary>
        /// Sends the <see cref="Commands.Finished"/> message to the attached <see cref="IRemote"/>.
        /// </summary>
        protected void SendFinished() => Link.Send(new Message(Commands.Finished));

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

    }
}
