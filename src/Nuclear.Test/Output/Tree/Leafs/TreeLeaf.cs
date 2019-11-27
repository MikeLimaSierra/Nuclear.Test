using System;
using Nuclear.Test.Results;

namespace Nuclear.Test.ConsolePrinter.Tree.Leafs {
    internal abstract class TreeLeaf : TreeElement {

        #region properties

        internal ITestInstructionResult Result { get; private set; }

        internal override Int32 Padding => 12;

        #endregion

        #region ctors

        internal TreeLeaf(PrintVerbosity verbosity, ITestInstructionResult result)
            : base(verbosity) {

            Result = result;
        }

        #endregion

    }
}
