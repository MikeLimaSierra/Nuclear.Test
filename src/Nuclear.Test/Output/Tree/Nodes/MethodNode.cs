using System;
using System.Collections.Generic;
using Nuclear.Test.ConsolePrinter.Tree.Leafs;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class MethodNode : TreeNode {

        #region properties

        internal override Int32 Padding => 10;

        internal override String Title => Key.MethodName;

        internal TestMethodResult Results { get; private set; }

        internal List<TreeLeaf> Leafs { get; } = new List<TreeLeaf>();

        #endregion

        #region ctors

        internal MethodNode(PrintVerbosity verbosity, TestResultKey key, ITestResultsSource results)
            : base(verbosity, key, results) {

            Results = results[key];
            Int32 index = 1;

            if(Verbosity > PrintVerbosity.MethodName || Results.Failed) {
                foreach(TestInstructionResult result in Results.InstructionResults) {
                    if(result.Result.HasValue) {
                        Leafs.Add(new ResultLeaf(Verbosity, result, index++));
                    } else {
                        Leafs.Add(new NoteLeaf(Verbosity, result));
                    }
                }
            }
        }

        #endregion

        #region methods

        internal override void Print() {
            PrintTitle();
            PrintResult(!Failed);
            PrintDetails(Total, Successes, Fails);

            if(Results.HasFailMessage) {
                Print(": ");
                Print(ConsoleColor.Red, Results.FailMessage);
            }

            PrintEOL();

            Leafs.ForEach(leaf => leaf.Print());
        }

        #endregion

    }
}
