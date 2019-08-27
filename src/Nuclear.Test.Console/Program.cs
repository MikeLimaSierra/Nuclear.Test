using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Nuclear.Arguments;
using Nuclear.Test.Configurations;
using Nuclear.Test.Output;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Console {
    static class Program {

        #region fields

        private static ArgumentCollector _arguments = new ArgumentCollector();

        private static AssemblyLocatorConfiguration _assemblyLocatorConfiguration = new AssemblyLocatorConfiguration();

        private static TestConfiguration _testConfiguration = new TestConfiguration();

        private static OutputConfiguration _outputConfiguration = new OutputConfiguration();

        #endregion

        #region public methods

        static void Main(String[] args) {
            CreateConfig(args);

            if(_arguments.TryGetSwitch("h", out Argument arg) || _arguments.TryGetSwitch("help", out arg) || _arguments.Arguments.Count == 0) {
                PrintHelp();
                return;
            }

            TestAssemblyLocator locator = new TestAssemblyLocator(_assemblyLocatorConfiguration);
            TestConsole executor = new TestConsole(TestResults.Instance, _testConfiguration, _outputConfiguration);
            executor.Files.AddRange(locator.GetAssemblies());
            TestResultMap results = executor.Execute();

            DiagnosticOutput.Log(_outputConfiguration, "=========================");
            new ResultPrinter(_outputConfiguration).PrintResults(results);
            DiagnosticOutput.Log(_outputConfiguration, "=========================");

            WaitOnDebug();

            Environment.ExitCode = (Int32) (results.HasFails ? ExitCode.Fail : ExitCode.OK);

        }

        #endregion

        #region private methods

        [Conditional("DEBUG")]
        private static void WaitOnDebug() {
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey(true);
        }

        private static void CreateConfig(String[] args) {
            _arguments.Collect(args);

            if((_arguments.TryGetSwitch("d", out Argument arg) || _arguments.TryGetSwitch("search-dir", out arg)) && arg.HasValue && Directory.Exists(arg.Value)) {
                _assemblyLocatorConfiguration.SearchDir = new DirectoryInfo(arg.Value);
            } else {
                _assemblyLocatorConfiguration.SearchDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory;
            }

            if((_arguments.TryGetSwitch("r", out arg) || _arguments.TryGetSwitch("search-recursion", out arg)) && arg.HasValue && Int32.TryParse(arg.Value, out Int32 depth)) {
                _assemblyLocatorConfiguration.SearchDepth = depth;
            } else {
                _assemblyLocatorConfiguration.SearchDepth = 0;
            }

            if((_arguments.TryGetSwitch("p", out arg) || _arguments.TryGetSwitch("search-pattern", out arg)) && arg.HasValue) {
                _assemblyLocatorConfiguration.SearchPattern = arg.Value;
            } else {
                _assemblyLocatorConfiguration.SearchPattern = "*Tests.dll";
            }

            if((_arguments.TryGetSwitch("i", out arg) || _arguments.TryGetSwitch("ignore-dir", out arg)) && arg.HasValue) {
                _assemblyLocatorConfiguration.IgnoredDirNames.AddRange(_arguments.GetSeparatedValues(arg));
            }

            _testConfiguration.ForceSequential = _arguments.TryGetSwitch("force-sequential", out arg);

            _testConfiguration.ForceAsmSequential = _arguments.TryGetSwitch("force-asm-sequential", out arg);

            _testConfiguration.TestAllVersions = _arguments.TryGetSwitch("test-all-versions", out arg);

            if(_arguments.TryGetSwitch("worker-base-dir", out arg) && arg.HasValue && Directory.Exists(arg.Value)) {
                _testConfiguration.WorkerBaseDir = new DirectoryInfo(arg.Value);
            } else {
                _testConfiguration.WorkerBaseDir = new DirectoryInfo("./Nuclear.Test.Worker/");
            }

            if(_arguments.TryGetSwitch("proxy-base-dir", out arg) && arg.HasValue && Directory.Exists(arg.Value)) {
                _testConfiguration.ProxyBaseDir = new DirectoryInfo(arg.Value);
            } else {
                _testConfiguration.ProxyBaseDir = new DirectoryInfo("./Nuclear.Test.Proxy/");
            }

            _outputConfiguration.ShowClients = _arguments.TryGetSwitch("show-clients", out arg);

            _outputConfiguration.ClientsAwaitInput = _arguments.TryGetSwitch("clients-await-input", out arg);

            _outputConfiguration.DiagnosticOutput = _arguments.TryGetSwitch("diagnostic-output", out arg);

            if((_arguments.TryGetSwitch("v", out arg) || _arguments.TryGetSwitch("verbosity", out arg)) && arg.HasValue && Int32.TryParse(arg.Value, out Int32 vLevel)) {
                Verbosity verbosity = (Verbosity) vLevel;

                switch(verbosity) {
                    case Verbosity.Assembly:
                    case Verbosity.TargetRuntime:
                    case Verbosity.Architecture:
                    case Verbosity.ExecutionRuntime:
                    case Verbosity.File:
                    case Verbosity.Method:
                    case Verbosity.Instruction:
                    case Verbosity.Collapsed:
                        _outputConfiguration.Verbosity = verbosity;
                        break;
                    default:
                        _outputConfiguration.Verbosity = Verbosity.Collapsed;
                        break;
                }
            }
        }

        private static void PrintHelp() {

            Int32 colWidth = 40;

            System.Console.WriteLine("Usage: {0}.exe [OPTIONS]", Assembly.GetEntryAssembly().GetName().Name);

            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-h".PadRight(colWidth, ' '), "Display this help context.");
            System.Console.WriteLine("  {0} {1}", "--help".PadRight(colWidth, ' '), "Same as -h.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-d path".PadRight(colWidth, ' '), "The directory to search for test assemblies in.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 2, ' '), "Defaults to the current location.");
            System.Console.WriteLine("  {0} {1}", "--search-dir path".PadRight(colWidth, ' '), "Same as -d path");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-r num".PadRight(colWidth, ' '), "The depth of recursion to use for sub level directories.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 2, ' '), "Defaults to -r 0");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 0 to search all available sub directories recursively.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use positive value to search the first <num> levels of directories.");
            System.Console.WriteLine("  {0} {1}", "--search-recursion num".PadRight(colWidth, ' '), "Same as -r num");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-p pattern".PadRight(colWidth, ' '), "The search pattern to find files with.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 2, ' '), "Defaults to -p *Tests.dll");
            System.Console.WriteLine("  {0} {1}", "--search-pattern pattern".PadRight(colWidth, ' '), "Same as -p pattern");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-i name1;name2;...".PadRight(colWidth, ' '), "Ignore directories with these names separated by ; .");
            System.Console.WriteLine("  {0} {1}", "--ignore-dir name1;name2;...".PadRight(colWidth, ' '), "Same as -i name1;name2;...");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--force-sequential".PadRight(colWidth, ' '), "Execute one test at a time for each assembly.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--force-asm-sequential".PadRight(colWidth, ' '), "Execute one assembly at a time.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--test-all-versions".PadRight(colWidth, ' '), "Execute tests on all matching runtimes.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--worker-base-dir path".PadRight(colWidth, ' '), "The directory containing all worker executables.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 2, ' '), "Defaults to --worker-base-dir ./Nuclear.Test.Worker/");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--proxy-base-dir path".PadRight(colWidth, ' '), "The directory containing all proxy executables.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 2, ' '), "Defaults to --proxy-base-dir ./Nuclear.Test.Proxy/");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--show-clients".PadRight(colWidth, ' '), "Start client process as visible windows.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--clients-await-input".PadRight(colWidth, ' '), "Let client process await key input before exit.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "--diagnostic-output".PadRight(colWidth, ' '), "Show diagnostic output.");
            System.Console.WriteLine();
            System.Console.WriteLine("  {0} {1}", "-v num".PadRight(colWidth, ' '), "Set the minimum verbosity level for a 100% success case. Failing tests will unfold the relevant test tree nodes.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 2, ' '), "Defaults to -v 0");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 0 to print all results combined.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 1 to print results for individual test assemblies.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 2 to print results for individual target runtime versions.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 3 to print results for individual architectures.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 4 to print results for individual execution runtime versions.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 5 to print results for individual test classes.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 6 to print results for individual test methods.");
            System.Console.WriteLine("  {0} {1}", String.Empty.PadRight(colWidth + 4, ' '), "Use 7 to print results for individual test instructions.");
            System.Console.WriteLine("  {0} {1}", "--verbose num".PadRight(colWidth, ' '), "Same as -v num");

        }

        #endregion

    }
}
