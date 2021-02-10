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

        public static void PrintWorkerRemotesInfo(IEnumerable<(RuntimeInfo runtime, Boolean hasExecutable, Boolean? isSelected)> remoteInfos) {
            Throw.If.Object.IsNull(remoteInfos, nameof(remoteInfos));

            Console.WriteLine(@"╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(@"║                          Available Workers                           ║");
            Console.WriteLine(@"╠══════════════════════════════════════════════════════════════════════╣");

            foreach((RuntimeInfo runtime, Boolean hasExecutable, Boolean? isSelected) in remoteInfos) {
                Console.Write("║    ");

                if(!hasExecutable) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("[?]");

                } else if(!isSelected.HasValue) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("[X]");

                } else if(isSelected.Value) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[Y]");

                } else {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("[N]");
                }

                Console.ResetColor();
                Console.WriteLine(" {0}    ║", runtime.ToString().PadRight(58, ' '));
            }

            Console.WriteLine(@"╠══════════════════════════════════════════════════════════════════════╣");

            Console.Write("║    ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[?]");
            Console.ResetColor();
            Console.WriteLine(" {0}    ║", "Missing worker executable".PadRight(58, ' '));

            Console.Write("║    ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[X]");
            Console.ResetColor();
            Console.WriteLine(" {0}    ║", "Ignored by configuration".PadRight(58, ' '));

            Console.Write("║    ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Y]");
            Console.ResetColor();
            Console.WriteLine(" {0}    ║", "Selected for execution".PadRight(58, ' '));

            Console.Write("║    ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[N]");
            Console.ResetColor();
            Console.WriteLine(" {0}    ║", "No match".PadRight(58, ' '));

            Console.WriteLine(@"╚══════════════════════════════════════════════════════════════════════╝");
        }

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
