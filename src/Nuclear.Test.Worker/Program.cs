using System;
using System.Threading;

using Nuclear.Test.Link;
using Nuclear.Test.Printer;
using Nuclear.Test.Results;

namespace Nuclear.Test.Worker {
    static class Program {

        #region fields

        private static readonly ManualResetEventSlim _executionFinishedEvent = new ManualResetEventSlim(false);

        private static WorkerClient _client;

        #endregion

        #region public methods

        static void Main(String[] args) {
            _client = new WorkerClient(new ClientLink(args[0]));
            _client.ExecutionFinished += OnClientExecutionFinished;

            _executionFinishedEvent.Wait();

            ITestResultEndPoint results = _client.Results;

            //DiagnosticOutput.Log(process.OutputConfiguration, " =========================");
            new ResultTree(Verbosity.ExecutionArchitecture, TestResultKey.Empty, results).Print();
            //DiagnosticOutput.Log(process.OutputConfiguration, "=========================");

            if(!_client.Configuration.AutoShutdown) {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
        }

        #endregion

        #region private methods

        private static void OnClientExecutionFinished(Object sender, EventArgs e) {
            _client.ExecutionFinished -= OnClientExecutionFinished;
            _executionFinishedEvent.Set();
        }

        #endregion

    }
}
