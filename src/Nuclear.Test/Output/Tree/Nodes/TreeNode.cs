using System;
using System.Collections.Generic;

using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal abstract class TreeNode : TreeElement {

        #region properties

        internal ITestResultKey Key { get; private set; }

        internal Int32 ResultsTotal { get; private set; }

        internal Int32 ResultsSuccessful { get; private set; }

        internal Int32 ResultsFailed { get; private set; }

        internal Boolean HasFails { get; private set; }

        internal Boolean HasIgnores { get; private set; }

        internal Boolean HasBlanks { get; private set; }

        internal List<TreeElement> Children { get; } = new List<TreeElement>();

        #endregion

        #region ctors

        internal TreeNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity) {

            Key = key;

            IEnumerable<ITestMethodResult> _results = results.GetResults(Key);
            ResultsTotal = _results.CountResults();
            ResultsSuccessful = _results.CountResultsOk();
            ResultsFailed = _results.CountResultsFailed();
            HasFails = _results.HasFails();
            HasIgnores = _results.HasIgnores();
            HasBlanks = _results.HasBlanks();
        }

        #endregion

        #region methods

        internal override void Print(Int32 padding) {
            base.Print(padding);

            PrintChildren(padding + 2);
        }

        protected override void PrintResult() => Write(HasFails ? ResultTree.ColorScheme.StateFailed : ResultTree.ColorScheme.StateOk, HasFails ? "Failed" : "Ok");

        protected override void PrintDetails() {
            Write($" [Total: {ResultsTotal}; Ok: ");
            Write(ResultTree.ColorScheme.ResultsOk, $"{ResultsSuccessful}");
            Write("; Failed: ");

            if(ResultsFailed > 0) {
                Write(ResultTree.ColorScheme.ResultsFailed, $"{ResultsFailed}");
            } else {
                Write($"{ResultsFailed}");
            }

            Write("]");
        }

        protected virtual void PrintChildren(Int32 padding) => Children.ForEach(child => child.Print(padding));

        #endregion

    }
}
