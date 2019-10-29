using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    public partial class ValuesTestSuite {

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
        public void Equal<T>(T left, T right,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(left == null && right == null) {
                InternalTest(true, $"[Left = {left.Print()}; Right = {right.Print()}]",
                    _file, _method);
                return;
            }

            try {
                if(left is IEquatable<T> eLeft) {
                    InternalTest(eLeft.Equals(right), $"({typeof(T).Print()}.IEquatable<T>) [Left = {left.Print()}; Right = {right.Print()}]",
                        _file, _method);
                    return;
                }

                if(left is IComparable<T> cTLeft) {
                    InternalTest(cTLeft.CompareTo(right) == 0, $"({typeof(T).Print()}.IComparable<T>) [Left = {left.Print()}; Right = {right.Print()}]",
                        _file, _method);
                    return;
                }

                if(left is IComparable cLeft) {
                    InternalTest(cLeft.CompareTo(right) == 0, $"({typeof(T).Print()}.IComparable) [Left = {left.Print()}; Right = {right.Print()}]",
                        _file, _method);
                    return;
                }
            } catch { }

            Equal(left, right, EqualityComparer<T>.Default, _file, _method);
        }

        /// <summary>
        /// Tests if two objects are equal by using a supplied <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of both objects.</typeparam>
        /// <param name="left">The first object.</param>
        /// <param name="right">The second object.</param>
        /// <param name="comparer">The comparer to be used to determine equality.</param>
        public void Equal<T>(T left, T right, IEqualityComparer<T> comparer,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

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

            InternalTest(result, $"({comparer.GetType().Name.Print()}) [Left = {left.Print()}; Right = {right.Print()}]",
                _file, _method);
        }

        #endregion

        #region custom numerics

        /// <summary>
        /// Tests if two <see cref="Single"/> values are equal by a margin of 1e-12.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        public void Equal(Single left, Single right,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => Equal(left, right, 1e-12f, _file, _method);

        /// <summary>
        /// Tests if two <see cref="Single"/> values are equal by a <paramref name="margin"/>.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="margin">The margin to use as tolerance.</param>
        public void Equal(Single left, Single right, Single margin,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(Math.Abs(left - right) <= margin, $"[Left = {left.Print()}; Right = {right.Print()}; Margin = {margin.Print()}]",
                _file, _method);

        /// <summary>
        /// Tests if two <see cref="Double"/> values are equal by a margin of 1e-12.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        public void Equal(Double left, Double right,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => Equal(left, right, 1e-12d, _file, _method);

        /// <summary>
        /// Tests if two <see cref="Double"/> values are equal by a <paramref name="margin"/>.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="margin">The margin to use as tolerance.</param>
        public void Equal(Double left, Double right, Double margin,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(Math.Abs(left - right) <= margin, $"[Left = {left.Print()}; Right = {right.Print()}; Margin = {margin.Print()}]",
                _file, _method);

        #endregion

    }
}
