using System;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.Tests {
    public partial class ConditionalTest {

        /// <summary>
        /// Tests if <paramref name="obj"/> is null.
        /// </summary>
        /// <param name="obj">The object to be checked.</param>
        public void Null(Object obj,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(obj == null, String.Format("[Object: {0}null]", obj == null ? "" : "not "),
                _file, _method);

        /// <summary>
        /// Tests if references <paramref name="obj"/> and <paramref name="_other"/> are equal.
        /// </summary>
        /// <param name="obj">The object to be checked against <paramref name="_other"/>.</param>
        /// <param name="_other">The object to be checked against <paramref name="obj"/>.</param>
        public void ReferencesEqual(Object obj, Object _other,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(ReferenceEquals(obj, _other), String.Format("References {0}equal.", ReferenceEquals(obj, _other) ? "" : "don't "),
                _file, _method);

    }
}
