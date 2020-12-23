using System;

using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Leafs {
    internal class ErrorLeaf : TreeLeaf {

        #region ctors

        internal ErrorLeaf(String name, ITestEntry result) : base(name, result) { }

        #endregion

        #region methods

        protected override void WriteDetails() => ConsoleAdapter.Write(Writer.Colors.ErrorDetails, $"'{Result.Message}'");

        #endregion

    }
}
