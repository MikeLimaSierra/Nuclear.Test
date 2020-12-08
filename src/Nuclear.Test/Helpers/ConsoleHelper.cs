using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;

namespace Nuclear.Test.Helpers {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class ConsoleHelper {

        public static void SetConsoleTitle(RuntimeInfo current) {
            Throw.If.Object.IsNull(current, nameof(current));

            Console.Title = $"{current} - {(Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86)} - {Assembly.GetEntryAssembly().GetName().Name}";
        }

        public static void PrintProcessInfo(RuntimeInfo current, List<String> headerContent) {
            Throw.If.Object.IsNull(current, nameof(current));
            Throw.If.Object.IsNull(headerContent, nameof(headerContent));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");

            foreach(String line in headerContent) {
                sb.AppendFormat("║    {1}    ║{0}", Environment.NewLine, line.PadRight(60, ' '));
            }

            sb.AppendLine("╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat("║        Platform: {1}    ║{0}", Environment.NewLine, current.Framework.ToString().PadRight(48, ' '));
            sb.AppendFormat("║         Version: {1}    ║{0}", Environment.NewLine, current.Version.ToString().PadRight(48, ' '));
            sb.AppendFormat("║    Architecture: {1}    ║{0}", Environment.NewLine, (Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86).ToString().PadRight(48, ' '));
            sb.AppendLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        public static void PrintTestAssemblyInfo(AssemblyName asmName, RuntimeInfo asmRuntime) {
            Throw.If.Object.IsNull(asmName, nameof(asmName));
            Throw.If.Object.IsNull(asmRuntime, nameof(asmRuntime));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine("║                             Test Assembly                            ║");
            sb.AppendLine("╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat("║            Name: {1}    ║{0}", Environment.NewLine, asmName.Name.PadRight(48, ' '));
            sb.AppendFormat("║        Platform: {1}    ║{0}", Environment.NewLine, asmRuntime.Framework.ToString().PadRight(48, ' '));
            sb.AppendFormat("║         Version: {1}    ║{0}", Environment.NewLine, asmRuntime.Version.ToString().PadRight(48, ' '));
            sb.AppendFormat("║    Architecture: {1}    ║{0}", Environment.NewLine, asmName.ProcessorArchitecture.ToString().PadRight(48, ' '));
            sb.AppendLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        public static void PrintWorkerRemotesInfo(IEnumerable<(RuntimeInfo runtime, Boolean hasExecutable, Boolean isSelected)> remoteInfos) {
            Throw.If.Object.IsNull(remoteInfos, nameof(remoteInfos));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine(@"║                       Matching Target Runtimes                       ║");
            sb.AppendLine(@"╠══════════════════════════════════════════════════════════════════════╣");
            Console.Write(sb);

            foreach((RuntimeInfo runtime, Boolean hasExecutable, Boolean isSelected) in remoteInfos) {
                Console.Write("║    ");
                Console.ForegroundColor = (hasExecutable) ? (isSelected ? ConsoleColor.Green : ConsoleColor.DarkYellow) : ConsoleColor.DarkGray;
                Console.Write("[{0}]", (hasExecutable) ? (isSelected ? "Y" : "N") : "?");
                Console.ResetColor();
                Console.WriteLine(" {0}    ║", runtime.ToString().PadRight(58, ' '));
            }

            sb.Clear();
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
