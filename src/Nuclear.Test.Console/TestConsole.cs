﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

using Nuclear.Exceptions;
using Nuclear.Test.Results;
using Nuclear.Test.TestExecution;

namespace Nuclear.Test.Console {

    internal class TestConsole : TestExecutor {

        #region fields

        private CountdownEvent _exitEvent = null;

        #endregion

        #region properties

        internal List<FileInfo> Files { get; } = new List<FileInfo>();

        #endregion

        #region ctors

        internal TestConsole(TestConfiguration testConfiguration, OutputConfiguration outputConfiguration) {
            Throw.If.Object.IsNull(testConfiguration, nameof(testConfiguration));
            Throw.If.Object.IsNull(outputConfiguration, nameof(outputConfiguration));

            TestConfiguration = testConfiguration;
            OutputConfiguration = outputConfiguration;

            HeaderContent.Add(@" _   _               _                    _____           _   ");
            HeaderContent.Add(@"| \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_ ");
            HeaderContent.Add(@"|  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|");
            HeaderContent.Add(@"| |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_ ");
            HeaderContent.Add(@"|_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|");
            HeaderContent.Add(@"  ____                           _                            ");
            HeaderContent.Add(@" / ___| ___   _ __   ___   ___  | |  ___                      ");
            HeaderContent.Add(@"| |    / _ \ | '_ \ / __| / _ \ | | / _ \                     ");
            HeaderContent.Add(@"| |___| (_) || | | |\__ \| (_) || ||  __/                     ");
            HeaderContent.Add(@" \____|\___/ |_| |_||___/ \___/ |_| \___|                     ");
            HeaderContent.Add(@"                                                              ");

        }

        #endregion

        #region eventhandlers

        private void OnResultsAvailable(Object sender, TestResultsAvailableEventArgs e) => Results.Add(e.Results);

        private void OnFinished(Object sender, EventArgs e) {
            if(sender is PipedTestExecutorRemote remote) {
                remote.ResultsAvailable -= OnResultsAvailable;
                remote.Finished -= OnFinished;
                _exitEvent.Signal();
            }
        }

        #endregion

        #region public methods

        public override ITestResultEndPoint Execute() {
            base.Execute();

            List<ProxyInfo> proxyInfos = GetProxyInfos(Files);
            List<PipedTestExecutorRemote> remotes = new List<PipedTestExecutorRemote>();

            foreach(ProxyInfo proxyInfo in proxyInfos) {
                if(proxyInfo.HasExecutable && proxyInfo.Executable.Exists && proxyInfo.HasFile && proxyInfo.File.Exists) {
                    PipedTestExecutorRemote remote = new PipedTestExecutorRemote(proxyInfo.Executable, proxyInfo.File, TestConfiguration, OutputConfiguration);
                    remote.ResultsAvailable += OnResultsAvailable;
                    remotes.Add(remote);
                    remote.Finished += OnFinished;
                }
            }

            _exitEvent = new CountdownEvent(remotes.Count);

            remotes.ForEach(remote => remote.Execute());
            _exitEvent.Wait();

            return Results;
        }

        #endregion

        #region private methods

        private void PrintConfig() {
            DiagnosticOutput.Log(OutputConfiguration, "Configuration begin");

            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", TestConfiguration.WORKER_BASE_DIR, TestConfiguration.WorkerBaseDir.FullName);
            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", TestConfiguration.PROXY_BASE_DIR, TestConfiguration.ProxyBaseDir.FullName);
            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", TestConfiguration.FORCE_SEQUENTIAL, TestConfiguration.ForceSequential);
            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", TestConfiguration.FORCE_ASM_SEQUENTIAL, TestConfiguration.ForceAsmSequential);
            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", TestConfiguration.TEST_ALL_VERSIONS, TestConfiguration.TestAllVersions);

            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", OutputConfiguration.SHOW_CLIENTS, OutputConfiguration.ShowClients);
            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", OutputConfiguration.CLIENTS_AWAIT_INPUT, OutputConfiguration.ClientsAwaitInput);
            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", OutputConfiguration.DIAGNOSTIC_OUTPUT, OutputConfiguration.DiagnosticOutput);
            DiagnosticOutput.Log(OutputConfiguration, "'{0}' => '{1}'", OutputConfiguration.VERBOSITY, OutputConfiguration.Verbosity);

            DiagnosticOutput.Log(OutputConfiguration, "Configuration end");
        }

        private Boolean TryGetProxies(ProcessorArchitecture architecture, out List<FileInfo> proxies) {
            proxies = new List<FileInfo>();

            switch(architecture) {
                case ProcessorArchitecture.None:
                    break;

                case ProcessorArchitecture.MSIL:
                    proxies.Add(new FileInfo(Path.Combine(TestConfiguration.ProxyBaseDir.FullName, ProcessorArchitecture.X86.ToString(), "Nuclear.Test.Proxy.exe")));
                    proxies.Add(new FileInfo(Path.Combine(TestConfiguration.ProxyBaseDir.FullName, ProcessorArchitecture.Amd64.ToString(), "Nuclear.Test.Proxy.exe")));
                    break;

                default:
                    proxies.Add(new FileInfo(Path.Combine(TestConfiguration.ProxyBaseDir.FullName, architecture.ToString(), "Nuclear.Test.Proxy.exe")));
                    break;
            }

            return proxies != null;
        }

        private List<ProxyInfo> GetProxyInfos(List<FileInfo> files) {
            List<ProxyInfo> proxyInfos = new List<ProxyInfo>();

            files.ForEach(file => {
                if(TryGetProxies(AssemblyName.GetAssemblyName(file.FullName).ProcessorArchitecture, out List<FileInfo> proxies)) {
                    proxies.ForEach(proxy => proxyInfos.Add(new ProxyInfo(proxy, file)));
                }
            });

            return proxyInfos;
        }

        #endregion

    }
}
