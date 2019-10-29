using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    public partial class StringTestSuite {

        #region StartsWith

        /// <summary>
        /// Tests if a <see cref="String"/> starts with a specific <see cref="Char"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="Char"/> to check for.</param>
        public void StartsWith(String @string, Char value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            InternalTest(@string.StartsWith(value), $"[String = {@string.Print()}; Value = {value.Print()}]",
                _file, _method);
        }

        /// <summary>
        /// Tests if a <see cref="String"/> starts with a specific <see cref="String"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        public void StartsWith(String @string, String value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(@string.StartsWith(value), $"[String = {@string.Print()}; Value = {value.Print()}]",
                _file, _method);
        }

        #endregion

        #region EndsWith

        /// <summary>
        /// Tests if a <see cref="String"/> ends with a specific <see cref="Char"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="Char"/> to check for.</param>
        public void EndsWith(String @string, Char value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            InternalTest(@string.EndsWith(value), $"[String = {@string.Print()}; Value = {value.Print()}]",
                _file, _method);
        }

        /// <summary>
        /// Tests if a <see cref="String"/> ends with a specific <see cref="String"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        public void EndsWith(String @string, String value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(@string.EndsWith(value), $"[String = {@string.Print()}; Value = {value.Print()}]",
                _file, _method);
        }

        #endregion

        #region

        /// <summary>
        /// Tests if a <see cref="String"/> is null or empty.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        public void IsNullOrEmpty(String @string,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(String.IsNullOrEmpty(@string), $"[String = {@string.Print()}]",
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> is null or white spaces.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        public void IsNullOrWhiteSpace(String @string,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(String.IsNullOrWhiteSpace(@string), $"[String = {@string.Print()}]",
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> contains a specific <see cref="String"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        public void Contains(String @string, String value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(@string.Contains(value), $"[String = {@string.Print()}; Value = {value.Print()}]",
                _file, _method);
        }

        #endregion

    }
}
