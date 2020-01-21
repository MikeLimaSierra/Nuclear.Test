using System;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    public partial class ReferenceTestSuite {

        #region IsEqual

        /// <summary>
        /// Tests if references <paramref name="obj"/> and <paramref name="_other"/> are equal.
        /// </summary>
        /// <param name="obj">The object to be checked against <paramref name="_other"/>.</param>
        /// <param name="_other">The object to be checked against <paramref name="obj"/>.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.ReferencesEqual(obj1, obj2);
        /// </code>
        /// </example>
        public void IsEqual(Object obj, Object _other,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(ReferenceEquals(obj, _other), String.Format("References {0}equal.", ReferenceEquals(obj, _other) ? "" : "don't "),
                _file, _method);

        #endregion

    }
}
