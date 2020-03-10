using System;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Leafs {
    internal class ResultLeaf : TreeLeaf {

        #region properties

        internal override String Title => $"#{Index}: {Result.Instruction}";

        internal Int32 Index { get; private set; }

        #endregion

        #region ctors

        internal ResultLeaf(ITestInstructionResult result, Int32 index)
            : base(result) {

            Index = index;
        }

        #endregion

        #region methods

        internal override void PrintResults() {
            PrintTitle();
            PrintResult(Result.Result.Value);

            if(!Result.Result.Value) {
                Write(": ");
                Write(ConsoleColor.Red, Result.Message);
            }

            WriteEOL();
        }

        #endregion

    }
}
