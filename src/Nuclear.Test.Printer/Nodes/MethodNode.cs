using System;

using Nuclear.Test.Printer.Leafs;
using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Nodes {
    internal class MethodNode : TreeNode {

        #region properties

        internal override String Title => Key.MethodName;

        internal ITestMethodResult Results { get; private set; }

        #endregion

        #region ctors

        internal MethodNode(Verbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(verbosity, key, results) {

            Results = results.GetResult(Key);
            Int32 index = 1;

            if(Verbosity > Verbosity.MethodName || HasFails) {
                foreach(ITestEntry result in Results.TestEntries) {
                    if(result.EntryType == EntryTypes.Error) {
                        Children.Add(new ErrorLeaf(Verbosity, result.Message));

                    } else if(result.EntryType == EntryTypes.Note) {
                        Children.Add(new NoteLeaf(Verbosity, result.Message));

                    } else if(result.EntryType == EntryTypes.Injection) {
                        Children.Add(new InjectionLeaf(Verbosity, result.Message));

                    } else {
                        Children.Add(new ResultLeaf(Verbosity, result, index++));
                    }
                }
            }
        }

        #endregion

        #region methods

        protected override void PrintResult() {
            if(Results.IsIgnored) {
                Write(ResultTree.ColorScheme.IgnoreMessage, Results.IgnoreReason);

            } else if(Results.IsEmpty && !Results.IsFailed) {
                Write(ResultTree.ColorScheme.StateEmpty, "Method has no test instructions!");

            } else if(Results.IsFailed) {
                Write(ResultTree.ColorScheme.StateFailed, "Failed");

            } else {
                Write(ResultTree.ColorScheme.StateOk, "Ok");
            }
        }

        protected override void PrintDetails() {
            if(!Results.IsEmpty) {
                base.PrintDetails();
            }
        }

        #endregion

    }
}
