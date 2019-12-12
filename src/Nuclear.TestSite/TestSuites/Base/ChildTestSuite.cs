using System.ComponentModel;
using Nuclear.Exceptions;

namespace Nuclear.TestSite.TestSuites.Base {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ChildTestSuite : TestSuite {

        #region properties

        internal TestSuiteCollection Parent { get; private set; }

        #endregion

        #region ctors

        internal ChildTestSuite(TestSuiteCollection parent) {
            Throw.If.Object.IsNull(parent, nameof(parent));

            Parent = parent;
        }

        #endregion

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
