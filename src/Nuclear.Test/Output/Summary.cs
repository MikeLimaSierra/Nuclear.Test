using System;
using System.Collections.Generic;
using System.Text;
using Nuclear.Test.ConsolePrinter.Tree;
using Nuclear.Test.Results;
using Nuclear.Test.Extensions;
using System.Linq;

namespace Nuclear.Test.Output {
    public class Summary {

        #region properties

        internal ITestResultSource Results { get; private set; }

        #endregion

        #region ctors

        public Summary(ITestResultSource results) {
            Results = results;
        }

        #endregion

        #region methods

        public void Print() {
            // Test results: Total, ok, failed
            // Test methods: Total, ok, failed, ignored
            // Test classes: Total, ok, failed, ignored
            // Test assemblies: Total, ok, failed
            // Worker processes: Total, ok, failed

            List<(ConsoleColor, Object)> parts = new List<(ConsoleColor, Object)>();
            ConsoleColor defaultColor = Console.ForegroundColor;

            IEnumerable<ITestMethodResult> _results = Results.GetResults();
            Int32 resultFails = _results.CountFails();

            Print(new List<(ConsoleColor, Object)>() {
                (defaultColor, $"Test results: Total: {_results.CountResults()}; Ok: "),
                (ConsoleColor.Green, _results.CountSuccesses()),
                (defaultColor, "; Failed: "),
                (resultFails > 0 ? ConsoleColor.Red : defaultColor, resultFails)
            });

            Int32 methodFails = _results.Where(r => r.Failed).Count();
            Int32 methodIgnores = _results.Where(r => r.IsIgnored).Count();

            Print(new List<(ConsoleColor, Object)>() {
                (defaultColor, $"Test methods: Total: {_results.Count()}; Ok: "),
                (ConsoleColor.Green, _results.Where(r => !r.Failed && !r.IsIgnored).Count()),
                (defaultColor, "; Failed: "),
                (methodFails > 0 ? ConsoleColor.Red : defaultColor, methodFails),
                (defaultColor, "; Ignored: "),
                (methodIgnores > 0 ? ConsoleColor.DarkYellow : defaultColor, methodIgnores)
            });

            Int32 classFails = _results.Where(r => r.Failed).Count();
            Int32 classIgnores = _results.Where(r => r.IsIgnored).Count();

            Print(new List<(ConsoleColor, Object)>() {
                (defaultColor, $"Test classes: Total: {_results.Count()}; Ok: "),
                (ConsoleColor.Green, _results.Where(r => !r.Failed && !r.IsIgnored).Count()),
                (defaultColor, "; Failed: "),
                (classFails > 0 ? ConsoleColor.Red : defaultColor, classFails),
                (defaultColor, "; Ignored: "),
                (classIgnores > 0 ? ConsoleColor.DarkYellow : defaultColor, classIgnores)
            });

            Int32 asmFails = _results.Where(r => r.Failed).Count();

            Print(new List<(ConsoleColor, Object)>() {
                (defaultColor, $"Test assemblies: Total: {_results.Count()}; Ok: "),
                (ConsoleColor.Green, _results.Where(r => !r.Failed && !r.IsIgnored).Count()),
                (defaultColor, "; Failed: "),
                (asmFails > 0 ? ConsoleColor.Red : defaultColor, asmFails)
            });

            Int32 workerFails = _results.Where(r => r.Failed).Count();

            Print(new List<(ConsoleColor, Object)>() {
                (defaultColor, $"Worker processes: Total: {_results.Count()}; Ok: "),
                (ConsoleColor.Green, _results.Where(r => !r.Failed && !r.IsIgnored).Count()),
                (defaultColor, "; Failed: "),
                (workerFails > 0 ? ConsoleColor.Red : defaultColor, workerFails)
            });
        }

        private void Print(List<(ConsoleColor, Object)> parts) {
            foreach((ConsoleColor color, Object item) in parts) {
                TreeElement.Print(color, item.ToString());
            }

            TreeElement.PrintEOL();
        }

        #endregion

    }
}
