using Nuclear.Extensions;
using Nuclear.TestSite.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    public partial class ValueTestSuite {

        #region generic equality

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
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.Equals(obj1, obj2);
        /// </code>
        /// </example>
        public void Equals<T>(T left, T right,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(left == null && right == null) {
                InternalTest(true, $"[Left = {left.Format()}; Right = {right.Format()}]",
                    _file, _method);
                return;
            }

            if(left is IEquatable<T> eLeft) {
                try {
                    InternalTest(eLeft.Equals(right), $"({typeof(T).Format()}.IEquatable<T>) [Left = {left.Format()}; Right = {right.Format()}]",
                        _file, _method);
                    return;

                } catch { /* advance to next */ }
            }

            if(left is IComparable<T> cTLeft) {
                try {
                    InternalTest(cTLeft.CompareTo(right) == 0, $"({typeof(T).Format()}.IComparable<T>) [Left = {left.Format()}; Right = {right.Format()}]",
                        _file, _method);
                    return;

                } catch { /* advance to next */ }

            }

            if(left is IComparable cLeft) {
                try {
                    InternalTest(cLeft.CompareTo(right) == 0, $"({typeof(T).Format()}.IComparable) [Left = {left.Format()}; Right = {right.Format()}]",
                        _file, _method);
                    return;

                } catch { /* advance to next */ }

            }

            Equals(left, right, EqualityComparer<T>.Default, _file, _method);
        }

        /// <summary>
        /// Tests if two objects are equal by using a supplied <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of both objects.</typeparam>
        /// <param name="left">The first object.</param>
        /// <param name="right">The second object.</param>
        /// <param name="comparer">The comparer to be used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.Equals(obj1, obj2, new MyEqualityComparer());
        /// </code>
        /// </example>
        public void Equals<T>(T left, T right, IEqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            try {
                result = comparer.Equals(left, right);

            } catch(Exception ex) {
                FailTest(String.Format("Comparison threw Exception: {0}", ex.Message),
                    _file, _method);
                return;
            }

            InternalTest(result, $"({comparer.GetType().Name.Format()}) [Left = {left.Format()}; Right = {right.Format()}]",
                _file, _method);
        }

        #endregion

        #region float equality

        /// <summary>
        /// Tests if two <see cref="Single"/> values are equal by a margin of 1e-12.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.Equals(val1, val2);
        /// </code>
        /// </example>
        public void Equals(Single left, Single right,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) => Equals(left, right, 1e-12f, _file, _method);

        /// <summary>
        /// Tests if two <see cref="Single"/> values are equal by a <paramref name="margin"/>.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="margin">The margin to use as tolerance.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.Equals(val1, val2, 1e-28f);
        /// </code>
        /// </example>
        public void Equals(Single left, Single right, Single margin,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(Math.Abs(left - right) <= margin, $"[Left = {left.Format()}; Right = {right.Format()}; Margin = {margin.Format()}]",
                _file, _method);

        /// <summary>
        /// Tests if two <see cref="Double"/> values are equal by a margin of 1e-12.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.Equals(val1, val2);
        /// </code>
        /// </example>
        public void Equals(Double left, Double right,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) => Equals(left, right, 1e-12d, _file, _method);

        /// <summary>
        /// Tests if two <see cref="Double"/> values are equal by a <paramref name="margin"/>.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="margin">The margin to use as tolerance.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.Equals(val1, val2, 1e-28f);
        /// </code>
        /// </example>
        public void Equals(Double left, Double right, Double margin,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(Math.Abs(left - right) <= margin, $"[Left = {left.Format()}; Right = {right.Format()}; Margin = {margin.Format()}]",
                _file, _method);

        #endregion

        #region IsTrue

        /// <summary>
        /// Tests if <paramref name="value"/> is true.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsTrue(1 + 1 == 2);
        /// </code>
        /// </example>
        public void IsTrue(Boolean value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(value, $"[Value = {value.Format()}]",
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="value"/> is true.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsTrue(someNullableBoolean);
        /// </code>
        /// </example>
        public void IsTrue(Boolean? value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(!value.HasValue) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.Value, $"[Value = {value.Format()}]",
                _file, _method);
        }

        #endregion

        #region IsFalse

        /// <summary>
        /// Tests if <paramref name="value"/> is false.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsFalse(1 + 1 != 2);
        /// </code>
        /// </example>
        public void IsFalse(Boolean value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(!value, $"[Value = {value.Format()}]",
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="value"/> is false.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsFalse(someNullableBoolean);
        /// </code>
        /// </example>
        public void IsFalse(Boolean? value,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(!value.HasValue) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(!value.Value, $"[Value = {value.Format()}]",
                _file, _method);
        }

        #endregion

        #region IsClamped

        /// <summary>
        /// Tests if <paramref name="value"/> is clamped in a given inclusive range.
        /// </summary>
        /// <typeparam name="TType">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="value">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="value"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="value"/> if null.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsClamped(someIndex, 0, someList.Count - 1);
        /// </code>
        /// </example>
        public void IsClamped<TType>(TType value, TType min, TType max,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClamped(min, max), $"[Value = {value.Format()}; Min = {min.Format()}; Max = {max.Format()}]",
                _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="value"/> is clamped in a given inclusive range.
        /// </summary>
        /// <typeparam name="TType">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="value">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="value"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="value"/> if null.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsClamped(someIndex, 0, someList.Count - 1);
        /// </code>
        /// </example>
        public void IsClampedT<TType>(TType value, TType min, TType max,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClamped(min, max), $"[Value = {value.Format()}; Min = {min.Format()}; Max = {max.Format()}]",
                _file, _method);
        }

        #endregion

        #region IsClampedExclusive

        /// <summary>
        /// Tests if <paramref name="value"/> is clamped in a given exclusive range.
        /// </summary>
        /// <typeparam name="TType">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="value">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="value"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="value"/> if null.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsClampedExclusive(someIndex, -1, someList.Count);
        /// </code>
        /// </example>
        public void IsClampedExclusive<TType>(TType value, TType min, TType max,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClampedExclusive(min, max), $"[Value = {value.Format()}; Min = {min.Format()}; Max = {max.Format()}]",
                _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="value"/> is clamped in a given exclusive range.
        /// </summary>
        /// <typeparam name="TType">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="value">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="value"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="value"/> if null.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Value.IsClampedExclusive(someIndex, -1, someList.Count);
        /// </code>
        /// </example>
        public void IsClampedExclusiveT<TType>(TType value, TType min, TType max,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClampedExclusive(min, max), $"[Value = {value.Format()}; Min = {min.Format()}; Max = {max.Format()}]",
                _file, _method);
        }

        #endregion

    }
}
