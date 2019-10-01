using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Extensions;

namespace Nuclear.TestSite.Tests {
    public partial class ConditionalTest {

        #region boolean

        /// <summary>
        /// Tests if <paramref name="value"/> is true.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void True(Boolean value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(value, String.Format("[Value = '{0}']", value),
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="value"/> is true.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void True(Boolean? value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(value.HasValue && value.Value, String.Format("[Value = '{0}']", value.HasValue ? value.ToString() : "null"),
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="value"/> is false.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void False(Boolean value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(!value, String.Format("[Value = '{0}']", value),
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="value"/> is false.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void False(Boolean? value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(!value.HasValue || !value.Value, String.Format("[Value = '{0}']", value.HasValue ? value.ToString() : "null"),
                _file, _method);

        #endregion

        #region generic

        /// <summary>
        /// Tests if two objects are equal.
        ///     Equality is determined by checking implementations of (in given order):
        ///     <see cref="IEquatable{T}"/>
        ///     <see cref="IComparable{T}"/>
        ///     <see cref="IComparable"/>
        ///     default <see cref="IEqualityComparer{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of both objects.</typeparam>
        /// <param name="left">The first object.</param>
        /// <param name="right">The second object.</param>
        public void ValuesEqual<T>(T left, T right,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(left == null && right == null) {
                InternalTest(true, String.Format(CultureInfo.InvariantCulture,
                    "[Left = '{0}'; Right = '{1}']", left != null ? left.ToString() : "null", right != null ? right.ToString() : "null"),
                    _file, _method);
                return;
            }

            try {
                if(left is IEquatable<T> eLeft) {
                    InternalTest(eLeft.Equals(right), String.Format(CultureInfo.InvariantCulture,
                        "({2}.IEquatable<T>) [Left = '{0}'; Right = '{1}']", left != null ? left.ToString() : "null", right != null ? right.ToString() : "null", typeof(T).FullName),
                        _file, _method);
                    return;
                }

                if(left is IComparable<T> cTLeft) {
                    InternalTest(cTLeft.CompareTo(right) == 0, String.Format(CultureInfo.InvariantCulture,
                        "({2}.IComparable<T>) [Left = '{0}'; Right = '{1}']", left != null ? left.ToString() : "null", right != null ? right.ToString() : "null", typeof(T).FullName),
                        _file, _method);
                    return;
                }

                if(left is IComparable cLeft) {
                    InternalTest(cLeft.CompareTo(right) == 0, String.Format(CultureInfo.InvariantCulture,
                        "({2}.IComparable) [Left = '{0}'; Right = '{1}']", left != null ? left.ToString() : "null", right != null ? right.ToString() : "null", typeof(T).FullName),
                        _file, _method);
                    return;
                }
            } catch { }

            IEqualityComparer<T> comparer = EqualityComparer<T>.Default;
            InternalTest(comparer != null && comparer.Equals(left, right), String.Format(CultureInfo.InvariantCulture,
                "({2}) [Left = '{0}'; Right = '{1}']", left != null ? left.ToString() : "null", right != null ? right.ToString() : "null", comparer.GetType().Name),
                _file, _method);
        }

        /// <summary>
        /// Tests if two objects are equal by using a supplied <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of both objects.</typeparam>
        /// <param name="left">The first object.</param>
        /// <param name="right">The second object.</param>
        /// <param name="comparer">The comparer to be used to determine equality.</param>
        public void ValuesEqual<T>(T left, T right, IEqualityComparer<T> comparer,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(comparer != null && comparer.Equals(left, right), String.Format(CultureInfo.InvariantCulture,
                "({2}) [Left = '{0}'; Right = '{1}']", left != null ? left.ToString() : "null", right != null ? right.ToString() : "null", comparer.GetType().Name),
                _file, _method);

        #endregion

        #region custom numerics

        /// <summary>
        /// Tests if two <see cref="Single"/> values are equal by a margin of 1e-12.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        public void ValuesEqual(Single left, Single right,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(Math.Abs(left - right) <= 1e-12f, String.Format(CultureInfo.InvariantCulture, "[Left = '{0}'; Right = '{1}']", left, right),
                _file, _method);

        /// <summary>
        /// Tests if two <see cref="Single"/> values are equal by a <paramref name="margin"/>.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="margin">The margin to use as tolerance.</param>
        public void ValuesEqual(Single left, Single right, Single margin,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(Math.Abs(left - right) <= margin, String.Format(CultureInfo.InvariantCulture, "[Left = '{0}'; Right = '{1}']", left, right),
                _file, _method);

        /// <summary>
        /// Tests if two <see cref="Double"/> values are equal by a margin of 1e-12.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        public void ValuesEqual(Double left, Double right,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(Math.Abs(left - right) <= 1e-12, String.Format(CultureInfo.InvariantCulture, "[Left = '{0}'; Right = '{1}']", left, right),
                _file, _method);

        /// <summary>
        /// Tests if two <see cref="Double"/> values are equal by a <paramref name="margin"/>.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="margin">The margin to use as tolerance.</param>
        public void ValuesEqual(Double left, Double right, Double margin,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(Math.Abs(left - right) <= margin, String.Format(CultureInfo.InvariantCulture, "[Left = '{0}'; Right = '{1}']", left, right),
                _file, _method);

        #endregion

        #region string

        /// <summary>
        /// Tests if a <see cref="String"/> is null or empty.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to be checked.</param>
        public void StringIsNullOrEmpty(String _string,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(String.IsNullOrEmpty(_string), String.Format("[String = '{0}']", _string ?? "null"),
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> is null or white spaces.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to be checked.</param>
        public void StringIsNullOrWhiteSpace(String _string,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(String.IsNullOrWhiteSpace(_string), String.Format("[String = '{0}']", _string ?? "null"),
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> contains a specific <see cref="String"/>.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        public void StringContains(String _string, String value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(_string.Contains(value), String.Format("[String = '{0}'; Value = '{1}']", _string ?? "null", value),
                    _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> starts with a specific <see cref="Char"/>.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="Char"/> to check for.</param>
        public void StringStartsWith(String _string, Char value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(_string != null && _string.StartsWith(value), String.Format("[String = '{0}'; Value = '{1}']", _string ?? "null", value),
                    _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> starts with a specific <see cref="String"/>.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        public void StringStartsWith(String _string, String value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(_string != null && value != null && _string.StartsWith(value), String.Format("[String = '{0}'; Value = '{1}']", _string ?? "null", value ?? "null"),
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> ends with a specific <see cref="Char"/>.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="Char"/> to check for.</param>
        public void StringEndsWith(String _string, Char value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(_string != null && _string.EndsWith(value), String.Format("[String = '{0}'; Value = '{1}']", _string ?? "null", value),
                _file, _method);

        /// <summary>
        /// Tests if a <see cref="String"/> ends with a specific <see cref="String"/>.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to be checked.</param>
        /// <param name="value">The <see cref="String"/> to check for.</param>
        public void StringEndsWith(String _string, String value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(_string != null && value != null && _string.EndsWith(value), String.Format("[String = '{0}'; Value = '{1}']", _string ?? "null", value ?? "null"),
                _file, _method);

        #endregion

    }
}
