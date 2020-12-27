using System;
using System.IO;
using System.Reflection;
using System.Threading;

using log4net;
using log4net.Config;

using Nuclear.Extensions;
using Nuclear.Test.Execution;
using Nuclear.Test.Execution.Proxy;
using Nuclear.Test.Extensions;
using Nuclear.Test.Link;
using Nuclear.Test.Results;
using Nuclear.Test.Writer.Console;
using Nuclear.Test.Writer.Json;

namespace Nuclear.Test.Proxy {
    internal static class Program {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        private static readonly ManualResetEventSlim _executionFinishedEvent = new ManualResetEventSlim(false);

        private static IProxyClient _client;

        #endregion

        #region event handlers

        private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e) => _log.Fatal($"Unhandled exception thrown: {e.ExceptionObject.Format()}");

        #endregion

        #region methods

        internal static void Main(String[] args) {
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("log4net.config"));

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            Factory.Instance.Create(out IClientLink link, args[0]);
            Factory.Instance.Create(out _client, link);
            _client.ExecutionFinished += OnClientExecutionFinished;

            _executionFinishedEvent.Wait();

            ITestResultEndPoint results = _client.Results;

            Factory.Instance.Create(out IConsoleWriter writer, Verbosity.ExecutionFrameworkVersion, ColorScheme.Default);
            writer.Load(results);
            writer.Write();

            if(_client.Configuration.WriteReport) {
                Factory.Instance.Create(out IJsonWriter jsonWriter, new FileInfo($"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}_{_client.Configuration.TestAssembly.Name}.json"));
                jsonWriter.Load(results);
                jsonWriter.Write();
            }

            if(!_client.Configuration.AutoShutdown) {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }

            Environment.ExitCode = (Int32) (results.GetResults().HasFails() ? ExitCode.Fail : ExitCode.OK);
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
