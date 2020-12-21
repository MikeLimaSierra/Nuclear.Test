using System;

using Nuclear.Exceptions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Console.Data.Leafs {
    internal abstract class TreeLeaf : TreeElement {

        #region properties

        internal ITestEntry Result { get; private set; }

        #endregion

        #region ctors

        internal TreeLeaf(String name, ITestEntry result) : base(name) {
            Throw.If.Object.IsNull(result, nameof(result));

            Result = result;
        }

        #endregion

    }
}
