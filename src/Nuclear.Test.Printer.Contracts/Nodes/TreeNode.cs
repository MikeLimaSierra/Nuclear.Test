using System;
using System.Collections.Generic;

using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Nodes {
    internal abstract class TreeNode : TreeElement {

        #region properties

        internal ITestResultKey Key { get; private set; }

        internal Int32 ResultsTotal { get; private set; }

        internal Int32 ResultsSuccessful { get; private set; }

        internal Int32 ResultsFailed { get; private set; }

        internal Int32 Errors { get; private set; }

        internal Boolean HasFails { get; private set; }

        internal Boolean HasIgnores { get; private set; }

        internal Boolean HasBlanks { get; private set; }

        internal List<TreeElement> Children { get; } = new List<TreeElement>();

        #endregion

        #region ctors

        internal TreeNode(Verbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity) {

            Key = key;

            IEnumerable<ITestMethodResult> _results = results.GetResults(Key);
            ResultsTotal = _results.CountRelevantEntries();
            ResultsSuccessful = _results.CountResultsOk();
            ResultsFailed = _results.CountResultsFailed();
            Errors = _results.CountErrors();
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

            if(HasFails) {
                Write(ResultTree.ColorScheme.ResultsFailed, $"{ResultsFailed + Errors}");
            } else {
                Write("0");
            }

            Write("]");
        }

        protected virtual void PrintChildren(Int32 padding) => Children.ForEach(child => child.Print(padding));

        #endregion

    }
}
