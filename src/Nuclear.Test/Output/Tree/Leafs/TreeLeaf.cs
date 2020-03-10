using System;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Leafs {
    internal abstract class TreeLeaf : TreeElement {

        #region properties

        internal ITestInstructionResult Result { get; private set; }

        #endregion

        #region ctors

        internal TreeLeaf(ITestInstructionResult result) {
            Result = result;
        }

        #endregion

    }
}
