using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Output {

    /// <summary>
    /// Implements functionality to print out <see cref="TestResultMap"/> to <see cref="Console"/>.
    /// </summary>
    public class ResultPrinter {

        #region properties

        private OutputConfiguration Configuration { get; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultPrinter"/>.
        /// </summary>
        /// <param name="configuration">The <see cref="OutputConfiguration"/> to use for printing.</param>
        public ResultPrinter(OutputConfiguration configuration) {
            Throw.If.Null(configuration, "configuration");

            Configuration = configuration;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Prints the contents of a <see cref="TestResultMap"/> to console.
        /// </summary>
        /// <param name="results"></param>
        public void PrintResults(TestResultMap results) {
            PrintSummaryLine(Verbosity.Collapsed, "Test Summary", results.ResultsTotal, results.ResultsOk, results.ResultsFailed, results.HasFails);

            if(results.HasFails || Configuration.Verbosity > Verbosity.Collapsed) {
                List<String> keys = results.Keys
                    .GroupBy(_key => _key.Assembly)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_assembly => PrintResults(results, new ResultKeyAssemblyNameLevel(_assembly)));
            }
        }

        #endregion

        #region private methods

        // assembly level
        private void PrintResults(TestResultMap results, ResultKeyAssemblyNameLevel key) {
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);

            if(!hasFails && Configuration.Verbosity < Verbosity.Assembly) { return; }

            PrintSummaryLine(Verbosity.Assembly, key.Assembly, results.GetResultsTotal(key), results.GetResultsOk(key), results.GetResultsFailed(key), hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.Assembly) {
                List<String> keys = results.Keys
                    .Where(_key => _key.Assembly == key.Assembly)
                    .GroupBy(_key => _key.TargetRuntime)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_targetRuntime => PrintResults(results, new ResultKeyTargetRuntimeLevel(key, _targetRuntime)));
            }
        }

        // target runtime level
        private void PrintResults(TestResultMap results, ResultKeyTargetRuntimeLevel key) {
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);

            if(!hasFails && Configuration.Verbosity < Verbosity.TargetRuntime) { return; }

            PrintSummaryLine(Verbosity.TargetRuntime, key.TargetRuntime.Replace(",Version=v", " "), results.GetResultsTotal(key), results.GetResultsOk(key), results.GetResultsFailed(key), hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.TargetRuntime) {
                List<ProcessorArchitecture> keys = results.Keys
                    .Where(_key => _key.Assembly == key.Assembly)
                    .Where(_key => _key.TargetRuntime == key.TargetRuntime)
                    .GroupBy(_key => _key.Architecture)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_architecture => PrintResults(results, new ResultKeyArchitectureLevel(key, _architecture)));
            }
        }

        // architecture level
        private void PrintResults(TestResultMap results, ResultKeyArchitectureLevel key) {
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);

            if(!hasFails && Configuration.Verbosity < Verbosity.Architecture) { return; }

            PrintSummaryLine(Verbosity.Architecture, key.Architecture, results.GetResultsTotal(key), results.GetResultsOk(key), results.GetResultsFailed(key), hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.Architecture) {
                List<String> keys = results.Keys
                    .Where(_key => _key.Assembly == key.Assembly)
                    .Where(_key => _key.TargetRuntime == key.TargetRuntime)
                    .Where(_key => _key.Architecture == key.Architecture)
                    .GroupBy(_key => _key.ExecutionRuntime)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_executionRuntime => PrintResults(results, new ResultKeyExecutionRuntimeLevel(key, _executionRuntime)));
            }
        }

        // execution runtime level
        private void PrintResults(TestResultMap results, ResultKeyExecutionRuntimeLevel key) {
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);

            if(!hasFails && Configuration.Verbosity < Verbosity.ExecutionRuntime) { return; }

            PrintSummaryLine(Verbosity.ExecutionRuntime, key.ExecutionRuntime.Replace(",Version=v", " "), results.GetResultsTotal(key), results.GetResultsOk(key), results.GetResultsFailed(key), hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.ExecutionRuntime) {
                List<String> keys = results.Keys
                    .Where(_key => _key.Assembly == key.Assembly)
                    .Where(_key => _key.TargetRuntime == key.TargetRuntime)
                    .Where(_key => _key.Architecture == key.Architecture)
                    .Where(_key => _key.ExecutionRuntime == key.ExecutionRuntime)
                    .GroupBy(_key => _key.File)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_file => PrintResults(results, new ResultKeyFileLevel(key, _file)));
            }
        }

        // file level
        private void PrintResults(TestResultMap results, ResultKeyFileLevel key) {
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);

            if(!hasFails && Configuration.Verbosity < Verbosity.File) { return; }

            PrintSummaryLine(Verbosity.File, key.File, results.GetResultsTotal(key), results.GetResultsOk(key), results.GetResultsFailed(key), hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.File) {
                List<String> keys = results.Keys
                    .Where(_key => _key.Assembly == key.Assembly)
                    .Where(_key => _key.TargetRuntime == key.TargetRuntime)
                    .Where(_key => _key.Architecture == key.Architecture)
                    .Where(_key => _key.ExecutionRuntime == key.ExecutionRuntime)
                    .Where(_key => _key.File == key.File)
                    .GroupBy(_key => _key.Method)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_method => PrintResults(results, new ResultKeyMethodLevel(key, _method)));
            }
        }

        // method level
        private void PrintResults(TestResultMap results, ResultKeyMethodLevel key) {
            TestResultCollection result = results[key];

            if(!result.HasFails && Configuration.Verbosity < Verbosity.Method) { return; }

            PrintSummaryLine(Verbosity.Method, key.Method, result.ResultsTotal, result.ResultsOk, result.ResultsFailed, result.HasFails, result.Exception);

            if(result.HasFails || Configuration.Verbosity > Verbosity.Method) {
                Int32 iInstruction = 0;

                for(Int32 i = 0; i < result.Count; i++) {
                    PrintResults(result[i], iInstruction);

                    if(result[i].Result.HasValue) {
                        iInstruction++;
                    }
                }
            }
        }

        // Test statements
        private void PrintResults(TestResult result, Int32 index) {
            if(result.Result.HasValue) {
                PrintInstructionLine(String.Format("#{0}: {1}", ++index, result.TestInstruction), !result.Result.Value, result.Message);
            } else {
                PrintNote(result.Message);
            }
        }

        private void PrintSummaryLine(Verbosity verbosityLevel, Object item, Int32 total, Int32 ok, Int32 failed, Boolean hasFails, String message = null) {
            PrintLineHead(verbosityLevel, item, hasFails);
            PrintOutcome(hasFails);

            Console.Write(" [Total: {0}; Ok: ", total);
            WriteColored(ConsoleColor.Green, "{0}", ok);
            Console.Write("; Failed: ");
            if(failed > 0) {
                WriteColored(ConsoleColor.Red, "{0}", failed);
            } else {
                Console.Write(failed);
            }
            Console.Write("]");

            PrintMessage(hasFails, message);

            Console.WriteLine();
        }

        private void PrintInstructionLine(Object item, Boolean hasFails, String message = null) {
            PrintLineHead(Verbosity.Instruction, item, hasFails);
            PrintOutcome(hasFails);
            PrintMessage(hasFails, message);
            Console.WriteLine();
        }

        private void PrintNote(String note) {
            PrintLineHead(Verbosity.Instruction, "Note", false);
            WriteColored(ConsoleColor.Yellow, "'{0}'", note);
            Console.WriteLine();
        }

        private void PrintLineHead(Verbosity verbosityLevel, Object item, Boolean hasFails)
            => Console.Write("{0}{1} => ", String.Empty.PadLeft((Int32) verbosityLevel * 2), item);

        private void PrintOutcome(Boolean hasFails)
            => WriteColored(hasFails ? ConsoleColor.Red : ConsoleColor.Green, hasFails ? "failed" : "ok");

        private void PrintMessage(Boolean hasFails, String message) {
            if(!String.IsNullOrWhiteSpace(message) && hasFails) {
                Console.Write(": ");
                WriteColored(ConsoleColor.Red, "{0}", message);
            }
        }

        private void WriteColored(ConsoleColor color, String format, params Object[] args) {
            Console.ForegroundColor = color;
            Console.Write(format, args);
            Console.ResetColor();
        }

        #endregion

    }
}
