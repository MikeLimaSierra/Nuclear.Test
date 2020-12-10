using System;

namespace Nuclear.Test.Printer.Leafs {
    internal class InvokationLeaf : TreeLeaf {

        #region properties

        internal override String Title => "Parameter Invokation";

        internal String Message { get; private set; }

        #endregion

        #region ctors

        internal InvokationLeaf(Verbosity verbosity, String message) : base(verbosity) {
            Message = message;
        }

        #endregion

        #region methods

        protected override void PrintResult() { }

        protected override void PrintDetails() => Write(ResultTree.ColorScheme.InvokationMessage, $"'{Message}'");

        #endregion

    }
}
