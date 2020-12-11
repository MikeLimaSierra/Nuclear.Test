using System;

namespace Nuclear.Test.Printer.Leafs {
    internal class InjectionLeaf : TreeLeaf {

        #region properties

        internal override String Title => "Parameter Injection";

        internal String Message { get; private set; }

        #endregion

        #region ctors

        internal InjectionLeaf(Verbosity verbosity, String message) : base(verbosity) {
            Message = message;
        }

        #endregion

        #region methods

        protected override void PrintResult() { }

        protected override void PrintDetails() => Write(ResultTree.ColorScheme.InjectionMessage, $"'{Message}'");

        #endregion

    }
}
