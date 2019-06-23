using System;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.Tests {
    public partial class ConditionalTest {

        /// <summary>
        /// Tests if <paramref name="obj"/> is null.
        /// </summary>
        /// <param name="obj">The object to be checked.</param>
        public void Null(Object obj,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(obj == null, String.Format("[Object: {0}null]", obj == null ? "" : "not "),
                _file, _method);

        /// <summary>
        /// Tests if references <paramref name="obj"/> and <paramref name="_other"/> are equal.
        /// </summary>
        /// <param name="obj">The object to be checked against <paramref name="_other"/>.</param>
        /// <param name="_other">The object to be checked against <paramref name="obj"/>.</param>
        public void ReferencesEqual(Object obj, Object _other,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(ReferenceEquals(obj, _other), String.Format("References {0}equal.", ReferenceEquals(obj, _other) ? "" : "don't "),
                _file, _method);

    }
}
