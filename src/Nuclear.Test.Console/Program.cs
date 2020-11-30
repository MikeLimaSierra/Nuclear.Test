using System;
using System.Diagnostics;
using System.Reflection;

using log4net;

using Nuclear.Arguments;
using Nuclear.Extensions;
using Nuclear.Test.Printer;
using Nuclear.Test.Results;
using Nuclear.Test.Extensions;

namespace Nuclear.Test.Console {
    internal static class Program {

        #region constants

        private const String HELP_SWITCH_S = "h";

        private const String HELP_SWITCH_L = "help";

        private const String CONFIG_SWITCH_S = "c";

        private const String CONFIG_SWITCH_L = "config";

        #endregion

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        private static readonly ArgumentCollector _arguments = new ArgumentCollector();

        private static Configuration _configuration;

        private static Executer _executer;

        #endregion

        #region public methods

        internal static void Main(String[] args) {
            _arguments.Collect(args);

            Argument arg;

            if(_arguments.TryGetSwitch(HELP_SWITCH_S, out _) || _arguments.TryGetSwitch(HELP_SWITCH_L, out _)) {
                PrintHelp();
                return;
            }

            if((_arguments.TryGetSwitch(CONFIG_SWITCH_S, out arg) || _arguments.TryGetSwitch(CONFIG_SWITCH_L, out arg)) && arg.HasValue) {
                _log.Info($"Loading configuration from {arg.Value.Format()}.");

                if(Configuration.TryLoad(arg.Value, out _configuration)) {
                    _log.Info($"Configuration loaded from {arg.Value.Format()}.");
                }
            }

            if(_configuration == null) {
                _log.Info($"Loading configuration from {Configuration.DefaultFilePath.Format()}.");

                if(Configuration.TryLoad(out _configuration)) {
                    _log.Info($"Configuration loaded from {Configuration.DefaultFilePath.Format()}.");

                } else {
                    _log.Info("Using default configuration.");
                    _configuration = new Configuration();
                    _configuration.Save();
                }
            }

            _executer = new Executer(_configuration, Factory.Instance);
            _executer.Execute();

            _log.Info("=========================");
            Factory.Instance.CreateEmpty(out ITestResultKey emptyKey);
            new ResultTree(Verbosity.Collapsed, emptyKey, _executer.Results).Print();
            _log.Info("=========================");

            WaitOnDebug();

            Environment.ExitCode = (Int32) (_executer.Results.GetResults().HasFails() ? ExitCode.Fail : ExitCode.OK);

        }

        #endregion

        #region private methods

        [Conditional("DEBUG")]
        private static void WaitOnDebug() {
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey(true);
        }

        private static void PrintHelp() {

            Int32 colWidth = 40;

            System.Console.WriteLine("Usage: {0}.exe [OPTIONS]", Assembly.GetEntryAssembly().GetName().Name);

            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", $"-{HELP_SWITCH_S}".PadRight(colWidth, ' '), "Display this help context.");
            System.Console.WriteLine("  {0} {1}", $"--{HELP_SWITCH_L}".PadRight(colWidth, ' '), $"Same as -{HELP_SWITCH_S}.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", $"-{CONFIG_SWITCH_S} path".PadRight(colWidth, ' '), "The configuration file path.");
            System.Console.WriteLine("  {0} {1}", $"--{CONFIG_SWITCH_L} path".PadRight(colWidth, ' '), $"Same as -{CONFIG_SWITCH_S}.");

        }

        #endregion

    }
}
