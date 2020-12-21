using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Exceptions;
using Nuclear.Test.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Nodes {
    internal abstract class TreeNode : TreeElement {

        #region properties

        internal IResultKey Key { get; private set; }

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

        internal TreeNode(String name, Verbosity verbosity, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results)
            : base(name) {

            Throw.IfNot.Enum.IsDefined<Verbosity>(verbosity, nameof(verbosity));
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Value.IsFalse(results.Count() > 0, nameof(results));

            IEnumerable<ITestMethodResult> _results = results.Select(kvp => kvp.Value);

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

        internal override void Write(Int32 padding) {
            base.Write(padding);

            Children.ForEach(child => child.Write(padding + 2));
        }

        protected override void WriteResult() => ConsoleAdapter.Write(HasFails ? Writer.Colors.StateFailed : Writer.Colors.StateOk, HasFails ? "Failed" : "Ok");

        protected override void WriteDetails() {
            ConsoleAdapter.Write($" [Total: {ResultsTotal}; Ok: ");
            ConsoleAdapter.Write(Writer.Colors.ResultsOk, $"{ResultsSuccessful}");
            ConsoleAdapter.Write("; Failed: ");

            if(HasFails) {
                ConsoleAdapter.Write(Writer.Colors.ResultsFailed, $"{ResultsFailed + Errors}");
            } else {
                ConsoleAdapter.Write("0");
            }

            ConsoleAdapter.Write("]");
        }

        #endregion

    }
}
