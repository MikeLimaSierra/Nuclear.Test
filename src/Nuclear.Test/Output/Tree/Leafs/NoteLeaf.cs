using System;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Leafs {
    internal class NoteLeaf : TreeLeaf {

        #region properties

        internal override String Title => "Note";

        #endregion

        #region ctors

        internal NoteLeaf(PrintVerbosity verbosity, ITestInstructionResult result) : base(verbosity, result) { }

        #endregion

        #region methods

        internal override void Print() {
            PrintTitle();
            Print(ConsoleColor.Yellow, $"'{Result.Message}'");
            PrintEOL();
        }

        #endregion

    }
}
