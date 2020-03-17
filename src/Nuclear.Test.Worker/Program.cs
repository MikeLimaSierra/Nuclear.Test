using System;
using Nuclear.Test.ConsolePrinter.Tree;
using Nuclear.Test.Output;
using Nuclear.Test.Results;
using Nuclear.Test.TestExecution;

namespace Nuclear.Test.Worker {
    static class Program {

        #region public methods

        static void Main(String[] args) {
            TestExecutor process = new TestWorker(args[0]);
            ITestResultSource results = process.Execute();

            DiagnosticOutput.Log(process.OutputConfiguration, " =========================");
            new ResultTree(process.OutputConfiguration.Verbosity, results).PrintResults();
            DiagnosticOutput.Log(process.OutputConfiguration, "=========================");

            if(process.OutputConfiguration.ClientsAwaitInput && process.OutputConfiguration.ShowClients) {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
        }

        #endregion

    }
}
