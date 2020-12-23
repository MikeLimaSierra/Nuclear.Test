using System;

using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Leafs {
    internal class NoteLeaf : TreeLeaf {

        #region ctors

        internal NoteLeaf(String name, ITestEntry result) : base(name, result) { }

        #endregion

        #region methods

        protected override void WriteDetails() => ConsoleAdapter.Write(Writer.Colors.NoteMessage, $"'{Result.Message}'");

        #endregion

    }
}
