using System;
using System.IO;
using System.Reflection;
using System.Threading;

using log4net;
using log4net.Config;

using Nuclear.Test.Execution.Worker;
using Nuclear.Test.Link;
using Nuclear.Test.Printer;
using Nuclear.Test.Results;

namespace Nuclear.Test.Worker {
    internal static class Program {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        private static readonly ManualResetEventSlim _executionFinishedEvent = new ManualResetEventSlim(false);

        private static IWorkerClient _client;

        #endregion

        #region public methods

        internal static void Main(String[] args) {
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("log4net.config"));

            Factory.Instance.Create(out IClientLink link, args[0]);
            Factory.Instance.Create(out _client, link);
            _client.ExecutionFinished += OnClientExecutionFinished;

            _executionFinishedEvent.Wait();

            ITestResultEndPoint results = _client.Results;

            Factory.Instance.CreateEmpty(out ITestResultKey emptyKey);
            new ResultTree(Verbosity.ExecutionArchitecture, emptyKey, results).Print();

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
