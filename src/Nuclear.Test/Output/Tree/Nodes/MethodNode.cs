using System;
using System.Collections.Generic;
using Nuclear.Test.ConsolePrinter.Tree.Leafs;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Nodes {
    internal class MethodNode : TreeNode {

        #region properties

        internal override Int32 Padding => 10;

        internal override String Title => Key.MethodName;

        internal ITestMethodResult Results { get; private set; }

        internal List<TreeLeaf> Leafs { get; } = new List<TreeLeaf>();

        #endregion

        #region ctors

        internal MethodNode(PrintVerbosity verbosity, ITestResultKey key, ITestResultSource results)
            : base(key, results) {

            Results = results.GetResult(key);
            Int32 index = 1;

            if(verbosity > PrintVerbosity.MethodName || Results.Failed) {
                foreach(ITestInstructionResult result in Results.InstructionResults) {
                    if(result.Result.HasValue) {
                        Leafs.Add(new ResultLeaf(result, index++));
                    } else {
                        Leafs.Add(new NoteLeaf(result));
                    }
                }
            }
        }

        #endregion

        #region methods

        internal override void PrintResults() {
            PrintTitle();
            PrintResult(!Failed);
            PrintDetails(Total, Successes, Fails);

            if(Results.HasFailMessage) {
                Write(": ");
                Write(ConsoleColor.Red, Results.FailMessage);
            }

            WriteEOL();

            Leafs.ForEach(leaf => leaf.PrintResults());
        }

        #endregion

    }
}
