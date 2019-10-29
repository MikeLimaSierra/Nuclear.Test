using System;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    public partial class TestSuiteCollection {

        /// <summary>
        /// Tests if references <paramref name="obj"/> and <paramref name="_other"/> are equal.
        /// </summary>
        /// <param name="obj">The object to be checked against <paramref name="_other"/>.</param>
        /// <param name="_other">The object to be checked against <paramref name="obj"/>.</param>
        public void ReferencesEqual(Object obj, Object _other,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(ReferenceEquals(obj, _other), System.String.Format("References {0}equal.", ReferenceEquals(obj, _other) ? "" : "don't "),
                _file, _method);

    }
}
