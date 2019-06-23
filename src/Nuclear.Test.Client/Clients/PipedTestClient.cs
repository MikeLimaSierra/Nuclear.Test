using System;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Security.Principal;
using Nuclear.Exceptions;
using Nuclear.Test.Client.Execution;
using Nuclear.Test.Configurations;
using Nuclear.Test.Extensions;
using Nuclear.Test.Output;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Client.Clients {
    public class PipedTestClient {

        #region fields

        private readonly Configuration _config = new Configuration();

        private readonly ITestResultsEndPoint _results;

        private readonly TestRun _testRun;

        private readonly NamedPipeClientStream _pipeStream;

        #endregion

        #region ctors

        public PipedTestClient(ITestResultsEndPoint results, String pipeName) {
            Throw.If.Null(results, "results");
            Throw.If.NullOrWhiteSpace(pipeName, "pipeName");

            _results = results;
            _testRun = new TestRun(_config, _results);
            _pipeStream = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.None);
        }

        #endregion

        #region methods

        public void RunTests() {
            try {
                _pipeStream.Connect();

                String command = null;
                do {
                    command = _pipeStream.ReadString();
                    String value = String.Empty;

                    switch(command) {
                        case OutputConfiguration.VERBOSITY:
                            _config.OutputConfiguration.Verbosity = (Verbosity) _pipeStream.ReadInt32();
                            value = _config.OutputConfiguration.Verbosity.ToString();
                            break;
                        case OutputConfiguration.SHOW_WORKERS:
                            _config.OutputConfiguration.ShowWorkers = _pipeStream.ReadBoolean();
                            value = _config.OutputConfiguration.ShowWorkers.ToString();
                            break;
                        case OutputConfiguration.WORKERS_AWAIT_INPUT:
                            _config.OutputConfiguration.WorkersAwaitInput = _pipeStream.ReadBoolean();
                            value = _config.OutputConfiguration.WorkersAwaitInput.ToString();
                            break;
                        case OutputConfiguration.DIAGNOSTIC_OUTPUT:
                            _config.OutputConfiguration.DiagnosticOutput = _pipeStream.ReadBoolean();
                            value = _config.OutputConfiguration.DiagnosticOutput.ToString();
                            break;
                        case TestConfiguration.FORCE_SEQUENTIAL:
                            _config.TestConfiguration.ForceSequential = _pipeStream.ReadBoolean();
                            value = _config.TestConfiguration.ForceSequential.ToString();
                            break;
                        default:
                            break;
                    }

                    if(command != TestConfiguration.FILE_PATH) { DiagnosticOutput.Log(_config, "Received configuration: '{0}' => '{1}'", command, value); }

                } while(command != TestConfiguration.FILE_PATH);

                FileInfo file = new FileInfo(_pipeStream.ReadString());

                DiagnosticOutput.Log(_config, "Received assembly path: {0}", file.FullName);
                Console.Title = String.Format("[{0}] Nuclear.Test.Client.Worker: {1}", AssemblyName.GetAssemblyName(file.FullName).ProcessorArchitecture, file.Name);
                _testRun.LoadFile(file);

                DiagnosticOutput.Log(_config, "Run tests.");
                _testRun.Run();

                DiagnosticOutput.Log(_config, "=========================");
                new ResultPrinter(_config.OutputConfiguration).PrintResults(_results.ResultMap);
                DiagnosticOutput.Log(_config, "=========================");

                try {
                    Byte[] data = ResultSerializer.Serialize(_results.ResultMap);
                    DiagnosticOutput.Log(_config, "Sending {0} ({1} Bytes) results back to server.", _results.ResultMap.ResultsTotal, data.Length);
                    _pipeStream.WriteLarge(data);
                } catch(Exception ex) {
                    Console.WriteLine(ex);
                    Console.ReadKey(true);
                }

            } catch(Exception ex) {
                DiagnosticOutput.LogError("An exception was thrown while running tests: {0}", ex);

            } finally {
                DiagnosticOutput.Log(_config, "Closing pipe stream.");
                _pipeStream.Close();

                if(_config.OutputConfiguration.WorkersAwaitInput && _config.OutputConfiguration.ShowWorkers) {
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey(true);
                }
            }
        }

        #endregion

    }
}
