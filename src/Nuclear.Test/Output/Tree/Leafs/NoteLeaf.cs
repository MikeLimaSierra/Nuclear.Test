using System;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Leafs {
    internal class NoteLeaf : TreeLeaf {

        #region properties

        internal override String Title => "Note";

        #endregion

        #region ctors

        internal NoteLeaf(ITestInstructionResult result) : base(result) { }

        #endregion

        #region methods

        internal override void PrintResults(Int32 padding) {
            PrintTitle(padding);
            Write(ConsoleColor.Yellow, $"'{Result.Message}'");
            WriteEOL();
        }

        #endregion

    }
}
