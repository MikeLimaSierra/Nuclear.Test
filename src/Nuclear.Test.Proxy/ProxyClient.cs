using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;

namespace Nuclear.Test.Proxy {
    internal class ProxyClient : Client {

        #region fields

        private CountdownEvent _remotesFinishedEvent = null;

        private IProxyConfiguration _proxyConfig;

        private IWorkerConfiguration _workerConfig;

        #endregion

        #region ctors

        public ProxyClient(IClientLink link)
            : base(link) {

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

        #region methods

        protected override void Setup(IMessage message) {
            base.Setup(message);

            message.TryGetData(out _proxyConfig);
            message.TryGetData(out _workerConfig);
        }

        protected override void Execute() {
            base.Execute();

            IEnumerable<RemoteInfo> remoteInfos = CreateRemoteInfos();
            PrintRemotesInfo(remoteInfos);
            IEnumerable<WorkerRemote> remotes = CreateRemotes(remoteInfos);
            // todo

            _remotesFinishedEvent.Wait();
            SendFinished();
            Link.WaitForOutputFlush();
            RaiseExecutionFinished();
        }

        #endregion

        #region private methods

        private IEnumerable<RemoteInfo> CreateRemoteInfos() {
            List<RemoteInfo> remotes = new List<RemoteInfo>();

            if(RuntimesHelper.TryGetMatchingRuntimes(TestAssemblyRuntime, out IEnumerable<RuntimeInfo> matchingRuntimes)) {
                // todo
            }

            return remotes;
        }

        private void PrintRemotesInfo(IEnumerable<RemoteInfo> remoteInfos) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine(@"║                       Matching Target Runtimes                       ║");
            sb.AppendLine(@"╠══════════════════════════════════════════════════════════════════════╣");
            Console.Write(sb);

            foreach(RemoteInfo remoteInfo in remoteInfos) {
                Console.Write("║    ");
                Console.ForegroundColor = (remoteInfo.HasExecutable) ? (remoteInfo.IsSelected ? ConsoleColor.Green : ConsoleColor.DarkYellow) : ConsoleColor.DarkGray;
                Console.Write("[{0}]", (remoteInfo.HasExecutable) ? (remoteInfo.IsSelected ? "Y" : "N") : "?");
                Console.ResetColor();
                Console.WriteLine(" {0}    ║", remoteInfo.Runtime.ToString().PadRight(58, ' '));
            }

            sb.Clear();
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        private IEnumerable<WorkerRemote> CreateRemotes(IEnumerable<RemoteInfo> remoteInfos) {
            List<WorkerRemote> remotes = new List<WorkerRemote>();

            // todo

            return remotes;
        }

        #endregion

    }
}
