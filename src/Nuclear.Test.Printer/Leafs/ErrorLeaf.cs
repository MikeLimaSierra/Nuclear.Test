using System;

namespace Nuclear.Test.Printer.Leafs {
    internal class ErrorLeaf : TreeLeaf {

        #region properties

        internal override String Title => "Error";

        internal String Message { get; private set; }

        #endregion

        #region ctors

        internal ErrorLeaf(Verbosity verbosity, String message) : base(verbosity) {
            Message = message;
        }

        #endregion

        #region methods

        protected override void PrintResult() { }

        protected override void PrintDetails() => Write(ResultTree.ColorScheme.ErrorDetails, $"'{Message}'");

        #endregion

    }
}
