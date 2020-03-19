using System;

namespace Nuclear.Test.Printer.Leafs {
    internal class NoteLeaf : TreeLeaf {

        #region properties

        internal override String Title => "Note";

        internal String Message { get; private set; }

        #endregion

        #region ctors

        internal NoteLeaf(Verbosity verbosity, String message) : base(verbosity) {
            Message = message;
        }

        #endregion

        #region methods

        protected override void PrintResult() { }

        protected override void PrintDetails() => Write(ResultTree.ColorScheme.NoteMessage, $"'{Message}'");

        #endregion

    }
}
