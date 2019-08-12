﻿using System;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Security.Principal;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Extensions;
using Nuclear.Test.NetVersions;
using Nuclear.Test.Output;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.TestExecution {

    /// <summary>
    /// Base implementation of <see cref="TestExecutor"/> using named pipes for IPC.
    /// </summary>
    public abstract class PipedTestExecutor : TestExecutor {

        #region properties

        /// <summary>
        /// Gets the <see cref="NamedPipeClientStream"/> that is used for communication.
        /// </summary>
        protected NamedPipeClientStream PipeStream { get; private set; }

        /// <summary>
        /// Gets the <see cref="FileInfo"/> of the test assembly on disk.
        /// </summary>
        protected FileInfo File { get; private set; }

        /// <summary>
        /// Gets the instance of the test <see cref="Assembly"/>.
        /// </summary>
        protected Assembly TestAssembly { get; private set; }

        /// <summary>
        /// Gets the <see cref="AssemblyName"/> of the test <see cref="Assembly"/>.
        /// </summary>
        protected AssemblyName TestAssemblyName { get; private set; }

        /// <summary>
        /// Gets the target runtime of the test <see cref="Assembly"/>.
        /// </summary>
        protected (NetPlatforms platform, Version version) TestAssemblyTargetRuntime { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="PipedTestExecutor"/>.
        /// </summary>
        /// <param name="results">The test results sink to use.</param>
        /// <param name="pipeName">The pipe name to use.</param>
        protected PipedTestExecutor(ITestResultsEndPoint results, String pipeName) : base(results) {
            Throw.If.NullOrWhiteSpace(pipeName, "pipeName");

            PipeStream = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.None);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Execute tests.
        /// </summary>
        /// <returns>The collective results of all executed tests.</returns>
        public override TestResultMap Execute() {
            base.Execute();

            try {
                PipeStream.Connect();

                if(TryLoadConfiguration(PipeStream, out FileInfo file)) {
                    File = file;
                    DiagnosticOutput.Log(OutputConfiguration, "Received assembly path: {0}", File.FullName);
                    Console.Title += String.Format(": {0}", File.Name);

                    if(File.Exists && TryLoadAssembly(File, out Assembly assembly, out AssemblyName assemblyName, out (NetPlatforms platform, Version version) assemblyTargetRuntime)) {
                        TestAssembly = assembly;
                        TestAssemblyName = assemblyName;
                        TestAssemblyTargetRuntime = assemblyTargetRuntime;

                        PrintAssemblyInfo(TestAssemblyName, TestAssemblyTargetRuntime);

                        ExecuteInternal();
                    }
                }

            } catch(Exception ex) {
                HandleException(ex);
            } finally {
                CloseClientPipe(PipeStream);
            }

            return Results.ResultMap;
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Implements client specific mechanics of running tests within the specific scope.
        /// </summary>
        protected abstract void ExecuteInternal();

        /// <summary>
        /// Is called in case an exception is thrown during test execution.
        ///     Override this in subclasses if necessary.
        /// </summary>
        /// <param name="ex">The unhandled exception that is thrown.</param>
        protected virtual void HandleException(Exception ex) => DiagnosticOutput.LogError("An exception was thrown while running tests: {0}", ex);

        /// <summary>
        /// Sends <see cref="TestConfiguration.TEST_FINISHED"/> to every member of the pipe and then closes the stream.
        /// </summary>
        /// <param name="pipeStream">The <see cref="PipeStream"/> that will be closed.</param>
        protected virtual void CloseClientPipe(PipeStream pipeStream) {
            pipeStream.Write(TestConfiguration.TEST_FINISHED);
            DiagnosticOutput.Log(OutputConfiguration, "Closing pipe stream.");
            pipeStream.Close();
        }

        #endregion

        #region load methods

        /// <summary>
        /// Loads configuration values from <see cref="PipeStream"/> that are sent by the server.
        ///     Loading finishes once <see cref="TestConfiguration.FILE_PATH"/> is received.
        /// </summary>
        /// <param name="pipeStream">The <see cref="PipeStream"/> used for communication.</param>
        /// <param name="file">The <see cref="FileInfo"/> of the test assembly on disk.</param>
        /// <returns>True if <paramref name="file"/> is not null.</returns>
        protected Boolean TryLoadConfiguration(PipeStream pipeStream, out FileInfo file) {
            file = null;

            String command = null;
            do {
                command = pipeStream.ReadString();
                String value = String.Empty;

                if(pipeStream.ReadConfiguration(command, TestConfiguration, out value) ||
                    pipeStream.ReadConfiguration(command, OutputConfiguration, out value)) {

                    DiagnosticOutput.Log(OutputConfiguration, "Received configuration: '{0}' => '{1}'", command, value);
                }

            } while(command != TestConfiguration.FILE_PATH);

            file = pipeStream.ReadFileInfo();

            return file != null;
        }

        /// <summary>
        /// Loads an assembly from file and provides additional information about it.
        /// </summary>
        /// <param name="file">The <see cref="FileInfo"/> that points to the assembly file on disk.</param>
        /// <param name="assembly">The loaded <see cref="Assembly"/> instance.</param>
        /// <param name="assemblyName">The <see cref="AssemblyName"/> of <paramref name="assembly"/>.</param>
        /// <param name="assemblyTargetRuntime">The targeted runtime of <paramref name="assembly"/>.</param>
        /// <returns>True if loading was successful or false if not.</returns>
        protected Boolean TryLoadAssembly(FileInfo file, out Assembly assembly, out AssemblyName assemblyName, out (NetPlatforms platform, Version version) assemblyTargetRuntime) {
            assembly = null;
            assemblyName = null;
            assemblyTargetRuntime = (NetPlatforms.Unknown, new Version());

            try {
                assembly = Assembly.LoadFrom(file.FullName);
                assemblyName = assembly.GetName();
                assemblyTargetRuntime = NetVersionTree.GetTargetRuntimeFromAssembly(assembly);

            } catch(FileNotFoundException) {
                DiagnosticOutput.LogError("File not found: '{0}'", file.FullName);

            } catch(FileLoadException) {
                DiagnosticOutput.LogError("File not loaded: '{0}'", file.FullName);

            } catch(BadImageFormatException) {
                DiagnosticOutput.LogError("File is invalid: '{0}'", file.FullName);

            } catch(PathTooLongException) {
                DiagnosticOutput.LogError("File path is too long: '{0}'", file.FullName);
            }

            return assembly != null && assemblyName != null && assemblyTargetRuntime.platform != NetPlatforms.Unknown;
        }

        #endregion

        #region result methods

        /// <summary>
        /// Sends the results as the given <see cref="Byte"/> <see cref="Array"/>.
        ///     Message is tagged with <see cref="TestConfiguration.TEST_RESULTS"/>.
        /// </summary>
        /// <param name="pipe"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected Boolean TrySendResultData(PipeStream pipe, Byte[] data) {
            try {
                DiagnosticOutput.Log(OutputConfiguration, "Sending {0} ({1} Bytes) results back to server.", Results.ResultMap.ResultsTotal, data.Length);
                pipe.Write(TestConfiguration.TEST_RESULTS);
                pipe.WriteLarge(data);

            } catch(Exception ex) {
                // this should work flawlessly
                DiagnosticOutput.LogError("Sending of results failed with exception: {0}.", ex);
                return false;
            }

            return true;
        }

        #endregion

    }
}