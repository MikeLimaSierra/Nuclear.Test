using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

using log4net;
using log4net.Config;

using Nuclear.Arguments;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Console.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Extensions;
using Nuclear.Test.Writer.Console;
using Nuclear.Test.Writer.Json;

namespace Nuclear.Test.Console {
    internal static class Program {

        #region constants

        private const String HELP_SWITCH_S = "h";

        private const String HELP_SWITCH_L = "help";

        private const String CONFIG_SWITCH_S = "c";

        private const String CONFIG_SWITCH_L = "config";

        private const String FILE_SWITCH_S = "f";

        private const String FILE_SWITCH_L = "file";

        private const String DIR_SWITCH_S = "d";

        private const String DIR_SWITCH_L = "dir";

        #endregion

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        private static readonly ArgumentCollector _arguments = new ArgumentCollector();

        private static Configuration _configuration;

        private static IEnumerable<FileInfo> _assemblies = Enumerable.Empty<FileInfo>();

        #endregion

        #region event handlers

        private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e) => _log.Fatal($"Unhandled exception thrown: {e.ExceptionObject.Format()}");

        #endregion

        #region methods

        internal static void Main(String[] args) {
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("log4net.config"));

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

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
                    _configuration = Configuration.Default;
                    _configuration.Save();
                }
            }

            if((_arguments.TryGetSwitch(FILE_SWITCH_S, out arg) || _arguments.TryGetSwitch(FILE_SWITCH_L, out arg)) && arg.HasValue) {
                if(File.Exists(arg.Value)) {
                    _assemblies = new FileInfo[] { new FileInfo(arg.Value) };

                } else {
                    _log.Error($"Could not find assembly at path {arg.Value.Format()}");
                }

            } else {
                if((_arguments.TryGetSwitch(DIR_SWITCH_S, out arg) || _arguments.TryGetSwitch(DIR_SWITCH_L, out arg)) && arg.HasValue) {
                    _configuration.Locator.SearchDirectory = arg.Value;
                }

                _assemblies = new AssemblyLocator() {
                    SearchDirectory = new DirectoryInfo(Environment.ExpandEnvironmentVariables(_configuration.Locator.SearchDirectory)),
                    SearchDepth = _configuration.Locator.SearchDepth,
                    SearchPattern = _configuration.Locator.SearchPattern,
                    IgnoredDirectoryNames = _configuration.Locator.IgnoredDirectoryNames
                }.DiscoverAssemblies();
            }

            IExecutorConfiguration configuration = _configuration.Dump();
            configuration.Assemblies = _assemblies;
            Factory.Instance.Create(out IExecutor executor, configuration);
            executor.Execute();

            Factory.Instance.Create(out IConsoleWriter writer, _configuration.Executor.Verbosity, ColorScheme.Default);
            writer.Load(executor.Results);
            writer.Write();

            if(executor.Configuration.WriteReport) {
                Factory.Instance.Create(out IJsonWriter jsonWriter, new FileInfo($"Execution_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.json"));
                jsonWriter.Load(executor.Results);
                jsonWriter.Write();
            }

            WaitOnDebug();

            Environment.ExitCode = (Int32) (executor.Results.GetResults().HasFails() ? ExitCode.Fail : ExitCode.OK);

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
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", $"-{FILE_SWITCH_S} path".PadRight(colWidth, ' '), "Override to specify one specific test assembly.");
            System.Console.WriteLine("  {0} {1}", $"--{FILE_SWITCH_L} path".PadRight(colWidth, ' '), $"Same as -{FILE_SWITCH_S}.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", $"-{DIR_SWITCH_S} path".PadRight(colWidth, ' '), "Override to specify a search directory.");
            System.Console.WriteLine("  {0} {1}", $"--{DIR_SWITCH_L} path".PadRight(colWidth, ' '), $"Same as -{DIR_SWITCH_S}.");

        }

        #endregion

    }
}
