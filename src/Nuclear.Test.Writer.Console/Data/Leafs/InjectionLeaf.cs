using System;

using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Leafs {
    internal class InjectionLeaf : TreeLeaf {

        #region ctors

        internal InjectionLeaf(String name, ITestEntry result) : base(name, result) { }

        #endregion

        #region methods

        protected override void WriteDetails() => ConsoleAdapter.Write(Writer.Colors.InjectionMessage, $"'{Result.Message}'");

        #endregion

    }
}
