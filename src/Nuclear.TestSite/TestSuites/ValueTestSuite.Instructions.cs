using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    public partial class ValueTestSuite {

        #region IsTrue

        /// <summary>
        /// Tests if <paramref name="value"/> is true.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void IsTrue(Boolean value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(value, $"[Value = {value.Print()}]",
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="value"/> is true.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void IsTrue(Boolean? value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(!value.HasValue) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.Value, $"[Value = {value.Print()}]",
                _file, _method);
        }

        #endregion

        #region IsFalse

        /// <summary>
        /// Tests if <paramref name="value"/> is false.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void IsFalse(Boolean value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(!value, $"[Value = {value.Print()}]",
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="value"/> is false.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        public void IsFalse(Boolean? value,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(!value.HasValue) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(!value.Value, $"[Value = {value.Print()}]",
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
        public void IsClamped<TType>(TType value, TType min, TType max,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            where TType : IComparable {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClamped(min, max), $"[Value = {value.Print()}; Min = {min.Print()}; Max = {max.Print()}]",
                _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="value"/> is clamped in a given inclusive range.
        /// </summary>
        /// <typeparam name="TType">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="value">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="value"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="value"/> if null.</param>
        public void IsClampedT<TType>(TType value, TType min, TType max,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            where TType : IComparable<TType> {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClamped(min, max), $"[Value = {value.Print()}; Min = {min.Print()}; Max = {max.Print()}]",
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
        public void IsClampedExclusive<TType>(TType value, TType min, TType max,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            where TType : IComparable {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClampedExclusive(min, max), $"[Value = {value.Print()}; Min = {min.Print()}; Max = {max.Print()}]",
                _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="value"/> is clamped in a given exclusive range.
        /// </summary>
        /// <typeparam name="TType">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="value">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="value"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="value"/> if null.</param>
        public void IsClampedExclusiveT<TType>(TType value, TType min, TType max,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            where TType : IComparable<TType> {

            if(value == null) {
                FailTest("Parameter 'value' is null.", _file, _method);
                return;
            }

            InternalTest(value.IsClampedExclusive(min, max), $"[Value = {value.Print()}; Min = {min.Print()}; Max = {max.Print()}]",
                _file, _method);
        }

        #endregion

    }
}
