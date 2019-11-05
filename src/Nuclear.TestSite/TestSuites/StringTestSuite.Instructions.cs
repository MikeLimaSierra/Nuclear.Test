using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    public partial class StringTestSuite {

        #region StartsWith

        /// <summary>
        /// Tests if a <see cref="String"/> starts with a specific <see cref="Char"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="Char"/> to check for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.StartsWith(someString, '.');
        /// </code>
        /// </example>
        public void StartsWith(String @string, Char value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

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
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.StartsWith(someString, "https://");
        /// </code>
        /// </example>
        public void StartsWith(String @string, String value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

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
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.EndsWith(someString, '/');
        /// </code>
        /// </example>
        public void EndsWith(String @string, Char value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

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
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.EndsWith(someString, ".xml");
        /// </code>
        /// </example>
        public void EndsWith(String @string, String value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

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
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.IsNullOrEmpty(someString);
        /// </code>
        /// </example>
        public void IsNullOrEmpty(String @string,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(String.IsNullOrEmpty(@string), $"[String = {@string.Print()}]",
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> is null or white spaces.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.IsNullOrWhiteSpace(someString);
        /// </code>
        /// </example>
        public void IsNullOrWhiteSpace(String @string,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(String.IsNullOrWhiteSpace(@string), $"[String = {@string.Print()}]",
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> contains a specific <see cref="String"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.Contains(someString, "John Doe");
        /// </code>
        /// </example>
        public void Contains(String @string, String value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

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
