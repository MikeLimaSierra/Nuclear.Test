using System;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Leafs {
    internal class ResultLeaf : TreeLeaf {

        #region properties

        internal override String Title => $"#{Index}: {Result.Instruction}";

        internal Int32 Index { get; private set; }

        #endregion

        #region ctors

        internal ResultLeaf(PrintVerbosity verbosity, ITestInstructionResult result, Int32 index)
            : base(verbosity, result) {

            Index = index;
        }

        #endregion

        #region methods

        internal override void Print() {
            PrintTitle();
            PrintResult(Result.Result.Value);

            if(!Result.Result.Value) {
                Print(": ");
                Print(ConsoleColor.Red, Result.Message);
            }

            PrintEOL();
        }

        #endregion

    }
}
