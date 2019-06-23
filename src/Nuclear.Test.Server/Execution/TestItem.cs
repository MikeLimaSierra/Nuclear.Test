using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Threading;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Extensions;
using Nuclear.Test.Output;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Server.Execution {
    public class TestItem {

        #region events

        public event TestCompletedEventHandler TestsCompleted;

        #endregion

        #region fields

        private readonly Configuration _config;

        private FileInfo _file;

        private readonly String _pipeName;

        private NamedPipeServerStream _serverStream;

        private Thread _serverThread;

        private Boolean _workerStarted = false;

        #endregion

        #region properties

        public Boolean IsCompleted { get; private set; }

        #endregion

        #region ctors

        public TestItem(FileInfo file, Configuration config) {
            Throw.If.Null(file, "file");
            Throw.If.False(file.Exists, "file");
            Throw.If.Null(config, "config");

            _file = file;
            _config = config;
            _pipeName = Guid.NewGuid().ToString();
        }

        #endregion

        #region public methods

        public void Run() {
            ProcessorArchitecture architecture = AssemblyName.GetAssemblyName(_file.FullName).ProcessorArchitecture;
            String archDir = String.Empty;

            switch(architecture) {
                case ProcessorArchitecture.MSIL:
                case ProcessorArchitecture.X86:
                    archDir = ProcessorArchitecture.X86.ToString();
                    break;
                case ProcessorArchitecture.Amd64:
                    archDir = architecture.ToString();
                    break;
                default:
                    return;
            }

            String executionPath = Path.Combine(_config.TestConfiguration.WorkerBaseDir.FullName, archDir, "netcore", "Nuclear.Test.Client.Worker.exe");

            if(!File.Exists(executionPath)) {
                DiagnosticOutput.LogError("Worker executable does not exist at '{0}'", executionPath);
                return;
            }

            if(!_workerStarted) {
                _workerStarted = true;
                _serverThread = new Thread(ServerThread);
                _serverThread.Start();

                StartWorker(executionPath);

                if(_config.TestConfiguration.ForceAsmSequential) {
                    _serverThread.Join();
                }
            }
        }

        #endregion

        #region private methods

        private void StartWorker(String executionPath) {
            using(Process worker = new Process()) {
                worker.StartInfo.FileName = executionPath;
                worker.StartInfo.Arguments = _pipeName;
                worker.StartInfo.UseShellExecute = _config.OutputConfiguration.ShowWorkers;
                worker.StartInfo.CreateNoWindow = !_config.OutputConfiguration.ShowWorkers;
                DiagnosticOutput.Log(_config, "Starting Worker '{0}' ...", executionPath);
                worker.Start();
            }
        }

        private void ServerThread() {
            TestResultMap remoteResults = null;

            try {
                _serverStream = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1);
                DiagnosticOutput.Log(_config, "Pipe [{0}]: waiting for client ...", _pipeName);
                _serverStream.WaitForConnection();
                DiagnosticOutput.Log(_config, "Pipe [{0}]: client connected ... sending assembly path '{1}'", _pipeName, _file.FullName);

                _serverStream.Write(OutputConfiguration.DIAGNOSTIC_OUTPUT);
                _serverStream.Write(_config.OutputConfiguration.DiagnosticOutput);

                _serverStream.Write(OutputConfiguration.VERBOSITY);
                _serverStream.Write((Int32) _config.OutputConfiguration.Verbosity);

                _serverStream.Write(OutputConfiguration.SHOW_WORKERS);
                _serverStream.Write(_config.OutputConfiguration.ShowWorkers);

                _serverStream.Write(OutputConfiguration.WORKERS_AWAIT_INPUT);
                _serverStream.Write(_config.OutputConfiguration.WorkersAwaitInput);

                _serverStream.Write(TestConfiguration.FORCE_SEQUENTIAL);
                _serverStream.Write(_config.TestConfiguration.ForceSequential);

                _serverStream.Write(TestConfiguration.FILE_PATH);
                _serverStream.Write(_file.FullName);

                Byte[] buffer = _serverStream.ReadLarge();
                remoteResults = ResultSerializer.Deserialize(buffer);
                DiagnosticOutput.Log(_config, "Pipe [{0}]: received {1} ({2} Bytes) results from worker: '{3}'", _pipeName, remoteResults.ResultsTotal, buffer.Length, _file.FullName);

            } catch(Exception ex) {
                DiagnosticOutput.LogError("An exception was thrown while running tests in '{0}': {1}", _file.FullName, ex);

            } finally {
                DiagnosticOutput.Log(_config, "Pipe [{0}] closing ...", _pipeName);
                _serverStream.Close();

                DiagnosticOutput.Log(_config, "TestsCompleted: '{0}'", _file.FullName);
                IsCompleted = true;
                TestsCompleted?.Invoke(this, new TestCompletedEventArgs(remoteResults, _file));
            }
        }

        #endregion

    }
}
