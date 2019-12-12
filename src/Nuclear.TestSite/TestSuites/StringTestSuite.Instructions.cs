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
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.StartsWith(someString, '.');
        /// </code>
        /// </example>
        public void StartsWith(String @string, Char value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) => StartsWith(@string, value, StringComparison.CurrentCulture, _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> starts with a specific <see cref="Char"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="Char"/> to check for.</param>
        /// <param name="comparisonType">The value defining how strings are compared.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.StartsWith(someString, '.', StringComparison.CurrentCultureIgnoreCase);
        /// </code>
        /// </example>
        public void StartsWith(String @string, Char value, StringComparison comparisonType,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            if(!Enum.IsDefined(typeof(StringComparison), comparisonType)) {
                FailTest("Parameter 'comparisonType' is out of bounds.", _file, _method);
                return;
            }

            String message = null;
            if(comparisonType == StringComparison.CurrentCulture) {
                message = $"[String = {@string.Format()}; Value = {value.Format()}]";
            } else {
                message = $"[String = {@string.Format()}; Value = {value.Format()}; ComparisonType = {comparisonType.Format()}]";
            }

            InternalTest(@string.StartsWith(value, comparisonType), message,
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
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) => StartsWith(@string, value, StringComparison.CurrentCulture, _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> starts with a specific <see cref="String"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        /// <param name="comparisonType">The value defining how strings are compared.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.StartsWith(someString, "https://", StringComparison.CurrentCultureIgnoreCase);
        /// </code>
        /// </example>
        public void StartsWith(String @string, String value, StringComparison comparisonType,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            if(!Enum.IsDefined(typeof(StringComparison), comparisonType)) {
                FailTest("Parameter 'comparisonType' is out of bounds.", _file, _method);
                return;
            }

            String message = null;
            if(comparisonType == StringComparison.CurrentCulture) {
                message = $"[String = {@string.Format()}; Value = {value.Format()}]";
            } else {
                message = $"[String = {@string.Format()}; Value = {value.Format()}; ComparisonType = {comparisonType.Format()}]";
            }

            InternalTest(@string.StartsWith(value, comparisonType), message,
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
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) => EndsWith(@string, value, StringComparison.CurrentCulture, _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> ends with a specific <see cref="Char"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="Char"/> to check for.</param>
        /// <param name="comparisonType">The value defining how strings are compared.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.EndsWith(someString, '/');
        /// </code>
        /// </example>
        public void EndsWith(String @string, Char value, StringComparison comparisonType,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            if(!Enum.IsDefined(typeof(StringComparison), comparisonType)) {
                FailTest("Parameter 'comparisonType' is out of bounds.", _file, _method);
                return;
            }

            String message = null;
            if(comparisonType == StringComparison.CurrentCulture) {
                message = $"[String = {@string.Format()}; Value = {value.Format()}]";
            } else {
                message = $"[String = {@string.Format()}; Value = {value.Format()}; ComparisonType = {comparisonType.Format()}]";
            }

            InternalTest(@string.EndsWith(value, comparisonType), message,
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
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) => EndsWith(@string, value, StringComparison.CurrentCulture, _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> ends with a specific <see cref="String"/>.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        /// <param name="comparisonType">The value defining how strings are compared.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.String.EndsWith(someString, ".xml");
        /// </code>
        /// </example>
        public void EndsWith(String @string, String value, StringComparison comparisonType,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(@string == null) {
                FailTest("Parameter 'string' is null.", _file, _method);
                return;
            }

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            if(!Enum.IsDefined(typeof(StringComparison), comparisonType)) {
                FailTest("Parameter 'comparisonType' is out of bounds.", _file, _method);
                return;
            }

            String message = null;
            if(comparisonType == StringComparison.CurrentCulture) {
                message = $"[String = {@string.Format()}; Value = {value.Format()}]";
            } else {
                message = $"[String = {@string.Format()}; Value = {value.Format()}; ComparisonType = {comparisonType.Format()}]";
            }

            InternalTest(@string.EndsWith(value, comparisonType), message,
                _file, _method);
        }

        #endregion

        #region Null

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
            => InternalTest(String.IsNullOrEmpty(@string), $"[String = {@string.Format()}]",
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
            => InternalTest(String.IsNullOrWhiteSpace(@string), $"[String = {@string.Format()}]",
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

            InternalTest(@string.Contains(value), $"[String = {@string.Format()}; Value = {value.Format()}]",
                _file, _method);
        }

        #endregion

    }
}
