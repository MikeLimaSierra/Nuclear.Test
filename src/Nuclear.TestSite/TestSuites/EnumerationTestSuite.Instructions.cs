using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    public partial class EnumerationTestSuite {

        #region IsEmpty

        /// <summary>
        /// Tests if <paramref name="enumeration"/> is empty.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void IsEmpty(IEnumerable enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            IsEmpty(enumeration.Cast<Object>(), _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> is empty.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void IsEmpty<TType>(IEnumerable<TType> enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = enumeration.Count() == 0;

            InternalTest(result, String.Format("Enumeration is {0}empty.", result ? String.Empty : "not "),
                _file, _method);
        }

        #endregion

        #region ContainsNull

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a null element.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void ContainsNull(IEnumerable enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            ContainsNull(enumeration.Cast<Object>(), _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a null element.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void ContainsNull<TType>(IEnumerable<TType> enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            foreach(TType element in enumeration) {
                if(element == null) {
                    result = true;
                    break;
                }
            }

            InternalTest(result, String.Format("Enumeration {0} null.", result ? "contains" : "doesn't contain"),
                _file, _method);
        }

        #endregion

        #region ContainsNonNull

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a non null element.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void ContainsNonNull(IEnumerable enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            ContainsNonNull(enumeration.Cast<Object>(), _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a non null element.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void ContainsNonNull<TType>(IEnumerable<TType> enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            foreach(TType element in enumeration) {
                if(element != null) {
                    result = true;
                    break;
                }
            }

            InternalTest(result, String.Format("Enumeration {0} a non null value.", result ? "contains" : "doesn't contain"),
                _file, _method);
        }

        #endregion

        #region Contains

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains <paramref name="element"/>.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="element">The <see cref="Object"/> to search for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, someObject);
        /// </code>
        /// </example>
        public void Contains(IEnumerable enumeration, Object element,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Contains(enumeration.Cast<Object>(), element, _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="element">The element of type <typeparamref name="TType"/> to search for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, someObject);
        /// </code>
        /// </example>
        public void Contains<TType>(IEnumerable<TType> enumeration, TType element,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = enumeration.Contains(element);

            InternalTest(result, String.Format("Enumeration {0} element {1}.", result ? "contains" : "doesn't contain", element.Print()),
                _file, _method);
        }

        #endregion

        #region ContainsRange

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a range of <paramref name="elements"/>.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="elements">The range of <see cref="Object"/> to search for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.ContainsRange(someEnumeration, someCollection);
        /// </code>
        /// </example>
        public void ContainsRange(IEnumerable enumeration, IEnumerable elements,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(elements == null) {
                FailTest("Parameter 'elements' is null.", _file, _method);
                return;
            }

            ContainsRange(enumeration.Cast<Object>(), elements.Cast<Object>(), _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a range of <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="elements">The range of <see cref="Object"/> to search for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.ContainsRange(someEnumeration, someCollection);
        /// </code>
        /// </example>
        public void ContainsRange<TType>(IEnumerable<TType> enumeration, IEnumerable elements,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(elements == null) {
                FailTest("Parameter 'elements' is null.", _file, _method);
                return;
            }

            Int32 elementsCount = 0;
            Int32 elementsFound = 0;

            foreach(TType element in elements) {
                elementsCount++;

                if(enumeration.Contains(element)) {
                    elementsFound++;
                }
            }

            InternalTest(elementsCount == elementsFound, $"Enumeration contains {elementsFound} of {elementsCount} elements.",
                _file, _method);
        }

        #endregion

        #region Matches

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> ignoring order.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable"/> that is checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Matches(someEnumeration, someOtherEnumeration);
        /// </code>
        /// </example>
        public void Matches(IEnumerable enumeration, IEnumerable other,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            Matches(enumeration.Cast<Object>(), other.Cast<Object>(), _file, _method);
        }

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> ignoring order.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Matches(someEnumeration, someOtherEnumeration);
        /// </code>
        /// </example>
        public void Matches<TType>(IEnumerable<TType> enumeration, IEnumerable<TType> other,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            Int32 count1 = enumeration.Count();
            Int32 count2 = other.Count();
            Boolean result = count1 == 0 && count2 == 0;

            if(!result && count1 == count2) {
                result = true;
                List<TType> otherAsList = other.ToList();

                foreach(TType element in enumeration) {
                    if(otherAsList.Contains(element)) {
                        otherAsList.Remove(element);
                    } else {
                        result = false;
                        break;
                    }
                }
            }

            InternalTest(result, String.Format("Enumerations {0}.", result ? "match" : "don't match"),
                _file, _method);
        }

        #endregion

        #region MatchesExactly

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> respecting order.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable"/> that is checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.MatchesExactly(someEnumeration, someOtherEnumeration);
        /// </code>
        /// </example>
        public void MatchesExactly(IEnumerable enumeration, IEnumerable other,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            MatchesExactly(enumeration.Cast<Object>(), other.Cast<Object>(), _file, _method);
        }

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> respecting order.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.MatchesExactly(someEnumeration, someOtherEnumeration);
        /// </code>
        /// </example>
        public void MatchesExactly<TType>(IEnumerable<TType> enumeration, IEnumerable<TType> other,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            Int32 count1 = enumeration.Count();
            Int32 count2 = other.Count();
            Boolean result = count1 == 0 && count2 == 0;

            if(!result && count1 == count2) {
                result = true;

                using(IEnumerator<TType> enum1 = enumeration.GetEnumerator()) {
                    using(IEnumerator<TType> enum2 = other.GetEnumerator()) {

                        do {
                            TType element1 = enum1.Current;
                            TType element2 = enum2.Current;

                            if(!element1.IsEqual(element2)) {
                                result = false;
                                break;
                            }

                        } while(enum1.MoveNext() && enum2.MoveNext());
                    }
                }
            }

            InternalTest(result, String.Format("Enumerations {0}.", result ? "match" : "don't match"),
                _file, _method);
        }

        #endregion

    }
}
