using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;

using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Extensions;
using Nuclear.Test.Output;
using Nuclear.Test.Results;

namespace Nuclear.Test.TestExecution {

    /// <summary>
    /// Implements the base functionality of any remote control for test clients using named pipes for ipc.
    /// </summary>
    public class PipedTestExecutorRemote : Remote {

        #region fields

        private readonly String _pipeName;

        #endregion

        #region properties

        /// <summary>
        /// Configuration values for test execution.
        /// </summary>
        public TestConfiguration TestConfiguration { get; } = new TestConfiguration();

        /// <summary>
        /// Configuration values for output and logging.
        /// </summary>
        public OutputConfiguration OutputConfiguration { get; } = new OutputConfiguration();

        /// <summary>
        /// Gets the <see cref="NamedPipeServerStream"/> that is used for communication.
        /// </summary>
        protected NamedPipeServerStream PipeStream { get; private set; }

        /// <summary>
        /// Gets the <see cref="FileInfo"/> of the executable on disk.
        /// </summary>
        protected FileInfo Executable { get; private set; }

        /// <summary>
        /// Gets the <see cref="FileInfo"/> of the test assembly on disk.
        /// </summary>
        protected FileInfo File { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="PipedTestExecutorRemote"/>.
        /// </summary>
        /// <param name="executable">The test client executable to start.</param>
        /// <param name="file">The test assembly file.</param>
        /// <param name="testConfig">The test configuration.</param>
        /// <param name="outputConfig">The output configuration.</param>
        public PipedTestExecutorRemote(FileInfo executable, FileInfo file, TestConfiguration testConfig, OutputConfiguration outputConfig) {
            Throw.If.Object.IsNull(executable, nameof(executable));
            Throw.If.Object.IsNull(file, nameof(file));
            Throw.If.Object.IsNull(testConfig, nameof(testConfig));
            Throw.If.Object.IsNull(outputConfig, nameof(outputConfig));

            Executable = executable;
            File = file;
            TestConfiguration = testConfig;
            OutputConfiguration = outputConfig;
            _pipeName = Guid.NewGuid().ToString();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Creates the process, thread and pipe required to remote control the test client.
        /// </summary>
        public override void Execute() {
            if(Executable != null && Executable.Exists) {
                Thread pipeThread = new Thread(StartThread);
                pipeThread.Start();

                StartProcess(Executable, _pipeName);

                if(TestConfiguration.ForceAsmSequential) {
                    pipeThread.Join();
                }

            } else {
                DiagnosticOutput.LogError("Unable to find file at '{0}'", Executable != null ? Executable.FullName : "null");
                RaiseRemotingFinished();
            }
        }

        #endregion

        #region private methods

        private void StartProcess(FileInfo executable, String pipeName) {
            using(Process process = new Process()) {
                process.StartInfo.FileName = executable.FullName;
                process.StartInfo.Arguments = pipeName;
                process.StartInfo.UseShellExecute = OutputConfiguration.ShowClients;
                process.StartInfo.CreateNoWindow = !OutputConfiguration.ShowClients;
                DiagnosticOutput.Log(OutputConfiguration, "Starting process '{0} {1}' ...", executable.FullName, pipeName);
                process.Start();
            }
        }

        private void StartThread() {
            NamedPipeServerStream pipeStream = null;

            try {
                pipeStream = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1);
                DiagnosticOutput.Log(OutputConfiguration, "Pipe [{0}]: waiting for client ...", _pipeName);
                pipeStream.WaitForConnection();
                DiagnosticOutput.Log(OutputConfiguration, "Pipe [{0}]: client connected ... sending assembly path '{1}'", _pipeName, File.FullName);

                pipeStream.Write(OutputConfiguration);
                pipeStream.Write(TestConfiguration);
                pipeStream.Write(TestConfiguration.FILE_PATH);
                pipeStream.Write(File.FullName);
                pipeStream.WaitForPipeDrain();

                while(pipeStream.ReadString() == TestConfiguration.TEST_RESULTS) {
                    if(TryReceiveResultData(pipeStream, out Byte[] data)) {
                        RaiseResultsReceived(data);

                        if(ResultSerializer.TryDeserialize(data, out ITestResultEndPoint results)) {
                            IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> resultCollection = results.GetKeyedResults();
                            RaiseResultsAvailable(resultCollection);
                        }
                    }
                }

                RaiseRemotingFinished();

            } catch(Exception ex) {
                DiagnosticOutput.LogError("An exception was thrown while running tests in '{0}': {1}", File.FullName, ex);

            } finally {
                try {
                    DiagnosticOutput.Log(OutputConfiguration, "Pipe [{0}] closing ...", _pipeName);
                    pipeStream.Close();
                } catch(Exception ex) {
                    DiagnosticOutput.LogError("An exception was thrown while closing the pipe for '{0}': {1}", File.FullName, ex);
                } finally {
                    RaiseRemotingFinished();
                }
            }
        }

        private Boolean TryReceiveResultData(PipeStream pipe, out Byte[] data) {
            data = null;

            try {
                data = pipe.ReadLarge();

            } catch(Exception ex) {
                // this should work flawlessly
                DiagnosticOutput.LogError("Receiving of results failed with exception: {0}.", ex);
            }

            return data != null && data.Length > 0;
        }

        #endregion

    }
}
