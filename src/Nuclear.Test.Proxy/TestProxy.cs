using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.TestExecution;

namespace Nuclear.Test.Proxy {

    internal class TestProxy : PipedTestExecutor {

        #region fields

        private CountdownEvent _exitEvent = null;

        #endregion

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

        private void OnTestDataReceived(Object sender, RawTestDataReceivedEventArgs e) => TrySendResultData(PipeStream, e.Data);

        private void OnResultsAvailable(Object sender, TestResultsAvailableEventArgs e) => Results.Add(e.Results);

        private void OnFinished(Object sender, EventArgs e) {
            if(sender is PipedTestExecutorRemote remote) {
                remote.ResultsReceived -= OnTestDataReceived;
                remote.ResultsAvailable -= OnResultsAvailable;
                remote.Finished -= OnFinished;
                _exitEvent.Signal();
            }
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
                    remote.ResultsReceived += OnTestDataReceived;
                    remote.ResultsAvailable += OnResultsAvailable;
                    remote.Finished += OnFinished;
                    remotes.Add(remote);
                }
            }

            _exitEvent = new CountdownEvent(remotes.Count);

            remotes.ForEach(remote => remote.Execute());
            _exitEvent.Wait();
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
                Console.WriteLine(" {0}    ║", runtimeInfo.TargetRuntime.ToString().PadRight(58, ' '));
            }

            sb.Clear();
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        private List<WorkerInfo> GetWorkerInfos(RuntimeInfo targetRuntime, AssemblyName asmName) {
            List<WorkerInfo> workerInfos = new List<WorkerInfo>();
            IEnumerable<RuntimeInfo> matchingRuntimes = RuntimesHelper.TryGetMatchingRuntimes(targetRuntime, out IEnumerable<RuntimeInfo> runtimes) ? runtimes : Enumerable.Empty<RuntimeInfo>();

            matchingRuntimes.Foreach(_runtime => workerInfos.Add(new WorkerInfo(TestConfiguration.WorkerBaseDir, _runtime, RuntimeArchitecure)));

            List<FrameworkIdentifiers> platforms = matchingRuntimes.GroupBy(_runtime => _runtime.Framework).Select(_group => _group.Key).ToList();
            Dictionary<FrameworkIdentifiers, Version> maxVersions = new Dictionary<FrameworkIdentifiers, Version>();

            if(TestConfiguration.TestAllVersions) {
                platforms.ForEach(_platform => maxVersions.Add(_platform, matchingRuntimes
                    .Where(_runtime => _runtime.Framework == _platform)
                    .Select(_runtime => _runtime.Version)
                    .Max()));
            } else {
                platforms.ForEach(_platform => maxVersions.Add(_platform, matchingRuntimes
                    .Where(_runtime => _runtime.Framework == _platform)
                    .Select(_runtime => _runtime.Version)
                    .Min()));
            }

            foreach(WorkerInfo workerInfo in workerInfos.ToArray()) {
                workerInfo.ExecutionRequired = workerInfo.TargetRuntime.Version <= maxVersions[workerInfo.TargetRuntime.Framework];
            }

            return workerInfos;
        }

        #endregion

    }
}
