using System;
using System.IO;
using System.Reflection;
using Nuclear.Arguments;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Server.Servers;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Server.Console {
    static class Program {

        #region fields

        private static IArgumentCollector _arguments = new ArgumentCollector();

        private static Configuration _config = new Configuration();

        #endregion

        #region public methods

        public static void Main(String[] args) {
            CreateConfig(args);

            if(_arguments.TryGetSwitch("h", out IArgument arg) || _arguments.TryGetSwitch("help", out arg) || _arguments.Arguments.Count == 0) {
                PrintHelp();
                return;
            }

            PipedTestServer server = new PipedTestServer(TestResults.Instance, _config);
            server.RunTests();
        }

        #endregion

        #region private methods

        private static void CreateConfig(String[] args) {
            _arguments.Collect(args);
            IArgument arg = null;

            if((_arguments.TryGetSwitch("d", out arg) || _arguments.TryGetSwitch("search-dir", out arg)) && arg.HasValue && Directory.Exists(arg.Value)) {
                _config.AssemblyLocatorConfiguration.SearchDir = new DirectoryInfo(arg.Value);
            } else {
                _config.AssemblyLocatorConfiguration.SearchDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory;
            }

            if((_arguments.TryGetSwitch("r", out arg) || _arguments.TryGetSwitch("search-recursion", out arg)) && arg.HasValue && Int32.TryParse(arg.Value, out Int32 depth)) {
                _config.AssemblyLocatorConfiguration.SearchDepth = depth;
            } else {
                _config.AssemblyLocatorConfiguration.SearchDepth = 0;
            }

            if((_arguments.TryGetSwitch("p", out arg) || _arguments.TryGetSwitch("search-pattern", out arg)) && arg.HasValue) {
                _config.AssemblyLocatorConfiguration.SearchPattern = arg.Value;
            } else {
                _config.AssemblyLocatorConfiguration.SearchPattern = "*Tests.dll";
            }

            if((_arguments.TryGetSwitch("i", out arg) || _arguments.TryGetSwitch("ignore-dir", out arg)) && arg.HasValue) {
                _config.AssemblyLocatorConfiguration.IgnoredDirNames.AddRange(_arguments.GetSeparatedValues(arg));
            }

            _config.TestConfiguration.ForceSequential = _arguments.TryGetSwitch("force-sequential", out arg);

            _config.TestConfiguration.ForceAsmSequential = _arguments.TryGetSwitch("force-asm-sequential", out arg);

            if(_arguments.TryGetSwitch("worker-base-dir", out arg) && arg.HasValue && Directory.Exists(arg.Value)) {
                _config.TestConfiguration.WorkerBaseDir = new DirectoryInfo(arg.Value);
            } else {
                _config.TestConfiguration.WorkerBaseDir = new DirectoryInfo("./Nuclear.Test.Client.Worker/");
            }

            _config.OutputConfiguration.ShowWorkers = _arguments.TryGetSwitch("show-workers", out arg);

            _config.OutputConfiguration.WorkersAwaitInput = _arguments.TryGetSwitch("workers-await-input", out arg);

            _config.OutputConfiguration.DiagnosticOutput = _arguments.TryGetSwitch("diagnostic-output", out arg);

            if((_arguments.TryGetSwitch("v", out arg) || _arguments.TryGetSwitch("verbosity", out arg)) && arg.HasValue && Int32.TryParse(arg.Value, out Int32 vLevel)) {
                switch(vLevel) {
                    case 1:
                        _config.OutputConfiguration.Verbosity = Verbosity.Assembly;
                        break;
                    case 2:
                        _config.OutputConfiguration.Verbosity = Verbosity.Architecture;
                        break;
                    case 3:
                        _config.OutputConfiguration.Verbosity = Verbosity.Class;
                        break;
                    case 4:
                        _config.OutputConfiguration.Verbosity = Verbosity.Method;
                        break;
                    case 5:
                        _config.OutputConfiguration.Verbosity = Verbosity.Instruction;
                        break;
                    case 0:
                    default:
                        _config.OutputConfiguration.Verbosity = Verbosity.Collapsed;
                        break;
                }
            }
        }

        private static void PrintHelp() {

            Int32 colWidth = 40;

            System.Console.WriteLine("Usage: {0}.exe [OPTIONS]", Assembly.GetEntryAssembly().GetName().Name);

            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-h".ToLength(colWidth, ' '), "Display this help context.");
            System.Console.WriteLine("  {0} {1}", "--help".ToLength(colWidth, ' '), "Same as -h.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-d path".ToLength(colWidth, ' '), "The directory to search for test assemblies in.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 2, ' '), "Defaults to the current location.");
            System.Console.WriteLine("  {0} {1}", "--search-dir path".ToLength(colWidth, ' '), "Same as -d path");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-r num".ToLength(colWidth, ' '), "The depth of recursion to use for sub level directories.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 2, ' '), "Defaults to -r 0");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use 0 to search all available sub directories recursively.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use positive value to search the first <num> levels of directories.");
            System.Console.WriteLine("  {0} {1}", "--search-recursion num".ToLength(colWidth, ' '), "Same as -r num");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-p pattern".ToLength(colWidth, ' '), "The search pattern to find files with.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 2, ' '), "Defaults to -p *Tests.dll");
            System.Console.WriteLine("  {0} {1}", "--search-pattern pattern".ToLength(colWidth, ' '), "Same as -p pattern");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-i name1;name2;...".ToLength(colWidth, ' '), "Ignore directories with these names separated by ; .");
            System.Console.WriteLine("  {0} {1}", "--ignore-dir name1;name2;...".ToLength(colWidth, ' '), "Same as -i name1;name2;...");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--force-sequential".ToLength(colWidth, ' '), "Execute one test at a time for each assembly.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--force-asm-sequential".ToLength(colWidth, ' '), "Execute one assembly at a time.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--worker-base-dir path".ToLength(colWidth, ' '), "The directory containing all worker executables.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 2, ' '), "Defaults to --worker-base-dir ./Nuclear.Test.Client.Worker/");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--show-workers".ToLength(colWidth, ' '), "Start worker process as visible windows.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--workers-await-input".ToLength(colWidth, ' '), "Let worker process await key input before exit.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--diagnostic-output".ToLength(colWidth, ' '), "Show diagnostic output.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-v num".ToLength(colWidth, ' '), "Set the minimum verbosity level for a 100% success case. Failing tests will unfold the relevant test tree nodes.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 2, ' '), "Defaults to -v 0");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use 0 to print all results combined.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use 1 to print results for individual architectures.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use 2 to print results for individual test assemblies.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use 3 to print results for individual test classes.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use 4 to print results for individual test methods.");
            System.Console.WriteLine("  {0} {1}", String.Empty.ToLength(colWidth + 4, ' '), "Use 5 to print results for individual test instructions.");
            System.Console.WriteLine("  {0} {1}", "--verbose num".ToLength(colWidth, ' '), "Same as -v num");

        }

        #endregion

    }
}
