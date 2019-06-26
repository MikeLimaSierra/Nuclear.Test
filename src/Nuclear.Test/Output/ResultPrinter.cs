using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Output {
    public class ResultPrinter {

        #region properties

        public OutputConfiguration Configuration { get; private set; }

        #endregion

        #region ctors

        public ResultPrinter(OutputConfiguration configuration) {
            Throw.If.Null(configuration, "configuration");

            Configuration = configuration;
        }

        #endregion

        #region public methods

        // total
        public void PrintResults(TestResultMap results) {
            Console.Write("Test Run Summary: [{0}/{1}] ", results.ResultsOk, results.ResultsTotal);
            PrintColoredState(!results.HasFails);

            if(results.HasFails || Configuration.Verbosity > Verbosity.Collapsed) {
                List<String> keys = results.Keys
                    .GroupBy(_key => _key.Item1)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_architecure => PrintResults(results, Tuple.Create(_architecure)));

            }
        }

        #endregion

        #region private methods

        // architecture
        private void PrintResults(TestResultMap results, Tuple<String> key) {
            Console.Write("{0}: [{1}/{2}] ", key.Item1, results.GetResultsOk(key), results.GetResultsTotal(key));
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);
            PrintColoredState(!hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.Assembly) {
                List<ProcessorArchitecture> keys = results.Keys
                    .Where(_key => _key.Item1 == key.Item1)
                    .GroupBy(_key => _key.Item2)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_assembly => PrintResults(results, Tuple.Create(key.Item1, _assembly)));
            }
        }

        // Test assemblies
        private void PrintResults(TestResultMap results, Tuple<String, ProcessorArchitecture> key) {
            Console.Write("  {0}: [{1}/{2}] ", key.Item2, results.GetResultsOk(key), results.GetResultsTotal(key));
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);
            PrintColoredState(!hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.Architecture) {
                List<String> keys = results.Keys
                    .Where(_key => _key.Item1 == key.Item1 && _key.Item2 == key.Item2)
                    .GroupBy(_key => _key.Item3)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_class => PrintResults(results, Tuple.Create(key.Item1, key.Item2, _class)));
            }
        }

        // Test classes
        private void PrintResults(TestResultMap results, Tuple<String, ProcessorArchitecture, String> key) {
            Console.Write("    {0}: [{1}/{2}] ", key.Item3, results.GetResultsOk(key), results.GetResultsTotal(key));
            Boolean hasFails = results.GetResultsFailed(key) > 0 || results.HasFailedTests(key);
            PrintColoredState(!hasFails);

            if(hasFails || Configuration.Verbosity > Verbosity.Class) {
                List<String> keys = results.Keys
                    .Where(_key => _key.Item1 == key.Item1 && _key.Item2 == key.Item2 && _key.Item3 == key.Item3)
                    .GroupBy(_key => _key.Item4)
                    .Select(_group => _group.Key)
                    .ToList();
                keys.Sort();
                keys.ForEach(_method => PrintResults(results, Tuple.Create(key.Item1, key.Item2, key.Item3, _method)));
            }
        }

        // Test methods
        private void PrintResults(TestResultMap results, Tuple<String, ProcessorArchitecture, String, String> key) {
            TestResultCollection result = results[key];

            Console.Write("      {0}: [{1}/{2}] ", key.Item4, result.ResultsOk, result.ResultsTotal);
            PrintColoredState(!result.HasFails, result.Exception?.ToString());

            if(result.HasFails || Configuration.Verbosity > Verbosity.Method) {
                for(Int32 i = 0; i < result.Count; i++) {
                    PrintResults(result[i], i);
                }
            }
        }

        // Test statements
        private void PrintResults(TestResult result, Int32 index) {
            Console.Write("        #{0}: {1} => ", ++index, result.TestInstruction);
            PrintColoredState(result.Result, result.Message);
        }

        private void PrintColoredState(Boolean ok, String errorMessage = null) {
            if(ok) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ok");
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("failed{0}{1}", errorMessage != null ? ": " : String.Empty, errorMessage ?? String.Empty);
            }

            Console.ResetColor();
        }

        #endregion

    }
}
