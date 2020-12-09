using System;

using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Leafs {
    internal class ResultLeaf : TreeLeaf {

        #region properties

        internal override String Title => $"#{Index}: {Result.Instruction}";

        internal ITestEntry Result { get; private set; }

        internal Int32 Index { get; private set; }

        #endregion

        #region ctors

        internal ResultLeaf(Verbosity verbosity, ITestEntry result, Int32 index)
            : base(verbosity) {

            Result = result;
            Index = index;
        }

        #endregion

        #region methods

        protected override void PrintResult()
            => Write(Result.EntryType == EntryTypes.ResultOk ? ResultTree.ColorScheme.StateOk : ResultTree.ColorScheme.StateFailed,
                Result.EntryType == EntryTypes.ResultOk ? "Ok" : "Failed");

        protected override void PrintDetails() {
            if(Result.EntryType == EntryTypes.ResultFail) {
                Write(": ");
                Write(ResultTree.ColorScheme.ResultFailMessage, Result.Message);
            }
        }

        #endregion

    }
}
