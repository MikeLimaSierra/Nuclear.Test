﻿using System;

namespace Nuclear.Test.ConsolePrinter.Tree.Leafs {
    internal class ExceptionLeaf : TreeLeaf {

        #region properties

        internal override String Title => "Exception";

        internal String Message { get; private set; }

        #endregion

        #region ctors

        internal ExceptionLeaf(PrintVerbosity verbosity, String message) : base(verbosity) {
            Message = message;
        }

        #endregion

        #region methods

        protected override void PrintResult() { }

        protected override void PrintDetails() => Write(ResultTree.ColorScheme.ExceptionDetails, $"'{Message}'");

        #endregion

    }
}
