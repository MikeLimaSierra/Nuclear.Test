using System;
using System.Collections.Generic;
using Nuclear.Exceptions;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines methods to support the comparison of <see cref="ITestResultKey"/> for equality.
    /// </summary>
    public class TestResultKeyEqualityComparer : IEqualityComparer<ITestResultKey> {

        #region methods

        /// <summary>
        /// Determines whether the specified keys are equal.
        /// </summary>
        /// <param name="x">The first <see cref="ITestResultKey"/>.</param>
        /// <param name="y">The second <see cref="ITestResultKey"/>.</param>
        /// <returns>true if the specified keys are equal; otherwise, false.</returns>
        public Boolean Equals(ITestResultKey x, ITestResultKey y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : x.Equals(y);
        }

        /// <summary>
        /// Returns a hash code for the specified key.
        /// </summary>
        /// <param name="obj">The <see cref="ITestResultKey"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified key.</returns>
        public Int32 GetHashCode(ITestResultKey obj) {
            Throw.If.Null(obj, "obj");

            return obj.GetHashCode();
        }

        #endregion

    }
}
