using System;
using System.ComponentModel;

namespace Nuclear.TestSite.TestSuites.Base {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TestSuite {

        #region methods

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Boolean Equals(Object obj) => throw new MethodAccessException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Int32 GetHashCode() => throw new MethodAccessException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override String ToString() => throw new MethodAccessException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() => throw new MethodAccessException("This method is currently out of order.");

        #endregion

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
