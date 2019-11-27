using System;
using System.Collections.Generic;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal abstract class TreeNode : TreeElement {

        #region properties

        internal TestResultKey Key { get; private set; }

        internal Int32 Total { get; private set; }

        internal Int32 Successes { get; private set; }

        internal Int32 Fails { get; private set; }

        internal Boolean Failed { get; private set; }

        #endregion

        #region ctors

        internal TreeNode(PrintVerbosity verbosity, TestResultKey key, ITestResultsSource results)
            : base(verbosity) {

            Key = key;

            IEnumerable<TestMethodResult> _results = results.GetResults(Key);
            Total = _results.CountResults();
            Successes = _results.CountSuccesses();
            Fails = _results.CountFails();
            Failed = _results.Failed();
        }

        #endregion

        #region methods

        protected void PrintDetails(Int32 total, Int32 succeeded, Int32 failed) {
            Print($" [Total: {total}; Ok: ");
            Print(ConsoleColor.Green, $"{succeeded}");
            Print("; Failed: ");

            if(failed > 0) {
                Print(ConsoleColor.Red, $"{failed}");
            } else {
                Print($"{failed}");
            }

            Print("]");
        }

        #endregion

    }
}
