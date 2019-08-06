using System;
using Nuclear.Test.Output;
using Nuclear.Test.TestExecution;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Worker {
    static class Program {

        #region public methods

        static void Main(String[] args) {
            TestExecutor process = new TestWorker(TestResults.Instance, args[0]);
            TestResultMap results = process.Execute();

            DiagnosticOutput.Log(process.OutputConfiguration, "=========================");
            new ResultPrinter(process.OutputConfiguration).PrintResults(results);
            DiagnosticOutput.Log(process.OutputConfiguration, "=========================");

            if(process.OutputConfiguration.ClientsAwaitInput && process.OutputConfiguration.ShowClients) {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
        }

        #endregion

    }
}
