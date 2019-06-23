using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Output;
using Nuclear.Test.Server.Execution;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Server.Servers {
    public class PipedTestServer {

        #region fields

        private readonly Configuration _config;

        private readonly ITestResultsEndPoint _results;

        private readonly TestRun _testRun;

        private readonly TestAssemblyLocator _locator;

        private ManualResetEvent _exitEvent = new ManualResetEvent(false);

        #endregion

        #region ctors

        public PipedTestServer(ITestResultsEndPoint results, Configuration config) {
            Throw.If.Null(results, "results");
            Throw.If.Null(config, "config");

            _results = results;
            _config = config;

            _testRun = new TestRun(_results, _config);
            _testRun.TestsFinished += OnTestsFinished;
            _locator = new TestAssemblyLocator(_config.AssemblyLocatorConfiguration);
        }

        #endregion

        #region eventhandlers

        private void OnTestsFinished(Object sender, EventArgs e) => _exitEvent.Set();

        #endregion

        #region public methods

        public void RunTests() {
            PrintConfig();

            IEnumerable<FileInfo> files = _locator.GetAssemblies();
            if(files.Count() == 0) {
                DiagnosticOutput.LogError("No matching files have been found in '{0}'", _config.AssemblyLocatorConfiguration.SearchDir);
            } else {

                _testRun.LoadFiles(files);
                _testRun.Run();

                _exitEvent.WaitOne();

                DiagnosticOutput.Log(_config, "=========================");
                new ResultPrinter(_config.OutputConfiguration).PrintResults(_results.ResultMap);
                DiagnosticOutput.Log(_config, "=========================");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        #endregion

        #region private methods

        private void PrintConfig() {
            DiagnosticOutput.Log(_config, "Configuration begin");

            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", AssemblyLocatorConfiguration.SEARCH_DIR, _config.AssemblyLocatorConfiguration.SearchDir.FullName);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", AssemblyLocatorConfiguration.SEARCH_DEPTH, _config.AssemblyLocatorConfiguration.SearchDepth);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", AssemblyLocatorConfiguration.SEARCH_PATTERN, _config.AssemblyLocatorConfiguration.SearchPattern);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", AssemblyLocatorConfiguration.IGNORED_DIR_NAMES, _config.AssemblyLocatorConfiguration.IgnoredDirNames);

            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", TestConfiguration.WORKER_BASE_DIR, _config.TestConfiguration.WorkerBaseDir.FullName);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", TestConfiguration.FORCE_SEQUENTIAL, _config.TestConfiguration.ForceSequential);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", TestConfiguration.FORCE_ASM_SEQUENTIAL, _config.TestConfiguration.ForceAsmSequential);

            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", OutputConfiguration.SHOW_WORKERS, _config.OutputConfiguration.ShowWorkers);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", OutputConfiguration.WORKERS_AWAIT_INPUT, _config.OutputConfiguration.WorkersAwaitInput);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", OutputConfiguration.DIAGNOSTIC_OUTPUT, _config.OutputConfiguration.DiagnosticOutput);
            DiagnosticOutput.Log(_config, "'{0}' => '{1}'", OutputConfiguration.VERBOSITY, _config.OutputConfiguration.Verbosity);

            DiagnosticOutput.Log(_config, "Configuration end");
        }

        #endregion

    }
}
