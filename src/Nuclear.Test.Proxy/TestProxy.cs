using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Nuclear.Test.Configurations;
using Nuclear.Test.TestExecution;
using Nuclear.TestSite;

namespace Nuclear.Test.Proxy {

    internal class TestProxy : PipedTestExecutor {

        #region ctors

        internal TestProxy(String pipeName)
            : base(pipeName) {

            HeaderContent.Add(@" _   _               _                    _____           _   ");
            HeaderContent.Add(@"| \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_ ");
            HeaderContent.Add(@"|  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|");
            HeaderContent.Add(@"| |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_ ");
            HeaderContent.Add(@"|_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|");
            HeaderContent.Add(@" ____                                                         ");
            HeaderContent.Add(@"|  _ \  _ __  ___ __  __ _   _                                ");
            HeaderContent.Add(@"| |_) || '__|/ _ \\ \/ /| | | |                               ");
            HeaderContent.Add(@"|  __/ | |  | (_) |>  < | |_| |                               ");
            HeaderContent.Add(@"|_|    |_|   \___//_/\_\ \__, |                               ");
            HeaderContent.Add(@"                         |___/                                ");
            HeaderContent.Add(@"                                                              ");
        }

        #endregion

        #region eventhandlers

        private void OnTestDataAvailable(Object sender, TestDataAvailableEventArgs e) {
            TrySendResultData(PipeStream, e.Data);
            (sender as PipedTestExecutorRemote).TestDataAvailable -= OnTestDataAvailable;
        }

        #endregion

        #region protected methods

        protected override void ExecuteInternal() {
            List<WorkerInfo> workerInfos = GetWorkerInfos(TestAssemblyTargetRuntime, TestAssemblyName);
            List<PipedTestExecutorRemote> remotes = new List<PipedTestExecutorRemote>();

            PrintRuntimesInfo(workerInfos);

            foreach(WorkerInfo workerInfo in workerInfos) {
                if(workerInfo.ExecutionRequired && workerInfo.HasExecutable && workerInfo.Executable.Exists) {
                    PipedTestExecutorRemote remote = new PipedTestExecutorRemote(workerInfo.Executable, File, TestConfiguration, OutputConfiguration);
                    remote.TestDataAvailable += OnTestDataAvailable;
                    remotes.Add(remote);
                }
            }

            remotes.ForEach(remote => Results.Add(remote.Execute().Values));
            remotes.ForEach(remote => remote.WaitToExit());
        }

        #endregion

        #region private methods

        private void PrintRuntimesInfo(List<WorkerInfo> runtimeInfos) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine(@"║                       Matching Target Runtimes                       ║");
            sb.AppendLine(@"╠══════════════════════════════════════════════════════════════════════╣");
            Console.Write(sb);

            foreach(WorkerInfo runtimeInfo in runtimeInfos) {
                Console.Write("║    ");
                Console.ForegroundColor = (runtimeInfo.HasExecutable && runtimeInfo.Executable.Exists) ? (runtimeInfo.ExecutionRequired ? ConsoleColor.Green : ConsoleColor.DarkYellow) : ConsoleColor.DarkGray;
                Console.Write("[{0}]", (runtimeInfo.HasExecutable && runtimeInfo.Executable.Exists) ? (runtimeInfo.ExecutionRequired ? "Y" : "N") : "?");
                Console.ResetColor();
                Console.WriteLine(" {0}    ║", String.Format("{0} {1}", runtimeInfo.Platform, runtimeInfo.Version).PadRight(58, ' '));
            }

            sb.Clear();
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        private Boolean TryGetWorker((FrameworkIdentifiers platform, Version version) framework, ProcessorArchitecture architecture, out FileInfo worker) {
            worker = null;

            switch(architecture) {
                case ProcessorArchitecture.None:
                    break;
                default:
                    worker = new FileInfo(Path.Combine(TestConfiguration.WorkerBaseDir.FullName, architecture.ToString(), framework.platform.ToString() + framework.version.ToString(), "Nuclear.Test.Worker.exe"));
                    break;
            }

            return worker != null;
        }

        private List<WorkerInfo> GetWorkerInfos((FrameworkIdentifiers platform, Version version) targetRuntime, AssemblyName asmName) {
            List<WorkerInfo> workerInfos = new List<WorkerInfo>();
            List<(FrameworkIdentifiers platform, Version version)> matchingRuntimes = NetVersionTree.GetMatchingTargetRuntimes(targetRuntime);

            matchingRuntimes.ForEach(_runtime => {
                if(TryGetWorker(_runtime, asmName.ProcessorArchitecture, out FileInfo worker)) {
                    workerInfos.Add(new WorkerInfo(_runtime, worker));
                }
            });

            List<FrameworkIdentifiers> platforms = matchingRuntimes.GroupBy(_runtime => _runtime.platform).Select(_group => _group.Key).ToList();
            Dictionary<FrameworkIdentifiers, Version> maxVersions = new Dictionary<FrameworkIdentifiers, Version>();

            if(TestConfiguration.TestAllVersions) {
                platforms.ForEach(_platform => maxVersions.Add(_platform, matchingRuntimes.Where(_runtime => _runtime.platform == _platform).Select(_runtime => _runtime.version).Max()));
            } else {
                platforms.ForEach(_platform => maxVersions.Add(_platform, matchingRuntimes.Where(_runtime => _runtime.platform == _platform).Select(_runtime => _runtime.version).Min()));
            }

            foreach(WorkerInfo workerInfo in workerInfos.ToArray()) {
                workerInfo.ExecutionRequired = workerInfo.Version <= maxVersions[workerInfo.Platform];
            }

            return workerInfos;
        }

        #endregion

    }
}
