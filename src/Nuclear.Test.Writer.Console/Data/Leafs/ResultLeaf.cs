using System;

using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Leafs {
    internal class ResultLeaf : TreeLeaf {

        #region ctors

        internal ResultLeaf(String name, ITestEntry result) : base(name, result) { }

        #endregion

        #region methods

        protected override void WriteResult()
            => ConsoleAdapter.Write(Result.EntryType == EntryTypes.ResultOk ? Writer.Colors.StateOk : Writer.Colors.StateFailed,
                Result.EntryType == EntryTypes.ResultOk ? "Ok" : "Failed");

        protected override void WriteDetails() {
            if(Result.EntryType == EntryTypes.ResultFail) {
                ConsoleAdapter.Write(": ");
                ConsoleAdapter.Write(Writer.Colors.ResultFailMessage, Result.Message);
            }
        }

        #endregion

    }
}
