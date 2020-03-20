using System;

using Nuclear.Test.Output;
using Nuclear.Test.Printer;
using Nuclear.Test.Results;
using Nuclear.Test.TestExecution;

namespace Nuclear.Test.Proxy {
    static class Program {

        #region methods

        static void Main(String[] args) {
            TestExecutor process = new TestProxy(args[0]);
            ITestResultSource results = process.Execute();

            DiagnosticOutput.Log(process.OutputConfiguration, "=========================");
            new ResultTree(process.OutputConfiguration.Verbosity, TestResultKey.Empty, results).Print();
            DiagnosticOutput.Log(process.OutputConfiguration, "=========================");

            if(process.OutputConfiguration.ClientsAwaitInput && process.OutputConfiguration.ShowClients) {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
        }

        #endregion

    }
}
