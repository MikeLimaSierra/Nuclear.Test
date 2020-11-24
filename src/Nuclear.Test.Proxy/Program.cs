using System;
using System.Threading;

using log4net;

using Nuclear.Test.Link;
using Nuclear.Test.Printer;
using Nuclear.Test.Results;

namespace Nuclear.Test.Proxy {
    internal static class Program {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        private static readonly ManualResetEventSlim _executionFinishedEvent = new ManualResetEventSlim(false);

        private static ProxyClient _client;

        #endregion

        #region methods

        internal static void Main(String[] args) {
            _client = new ProxyClient(new ClientLink(args[0]));
            _client.ExecutionFinished += OnClientExecutionFinished;

            _executionFinishedEvent.Wait();

            ITestResultEndPoint results = _client.Results;

            _log.Info("=========================");
            new ResultTree(Verbosity.ExecutionArchitecture, TestResultKey.Empty, results).Print();
            _log.Info("=========================");

            if(!_client.Configuration.AutoShutdown) {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
        }

        #endregion

        #region private methods

        private static void OnClientExecutionFinished(Object sender, EventArgs e) {
            _log.Debug(nameof(OnClientExecutionFinished));

            _client.ExecutionFinished -= OnClientExecutionFinished;
            _executionFinishedEvent.Set();
        }

        #endregion

    }
}
