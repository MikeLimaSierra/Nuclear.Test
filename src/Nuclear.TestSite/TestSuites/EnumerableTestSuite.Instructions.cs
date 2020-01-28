using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    public partial class EnumerableTestSuite {

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
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void IsEmpty<T>(IEnumerable<T> enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = enumeration.Count() == 0;

            InternalTest(result, String.Format("Enumeration is {0}empty. Enumeration is: {1}", result ? String.Empty : "not ", enumeration.Format()),
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
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void ContainsNull<T>(IEnumerable<T> enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            foreach(T element in enumeration) {
                if(element == null) {
                    result = true;
                    break;
                }
            }

            InternalTest(result, String.Format("Enumeration {0} null. Enumeration is: {1}", result ? "contains" : "doesn't contain", enumeration.Format()),
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
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        public void ContainsNonNull<T>(IEnumerable<T> enumeration,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            foreach(T element in enumeration) {
                if(element != null) {
                    result = true;
                    break;
                }
            }

            InternalTest(result, String.Format("Enumeration {0} a non null value. Enumeration is: {1}", result ? "contains" : "doesn't contain", enumeration.Format()),
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
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="element">The element of type <typeparamref name="T"/> to search for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, someObject);
        /// </code>
        /// </example>
        public void Contains<T>(IEnumerable<T> enumeration, T element,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = enumeration.Contains(element);

            InternalTest(result, String.Format("Enumeration {0} element {1}. Enumeration is: {2}", result ? "contains" : "doesn't contain", element.Format(), enumeration.Format()),
                _file, _method);
        }

        #endregion

        #region ContainsComparer

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="element">The <see cref="Object"/> to search for.</param>
        /// <param name="comparer">The <see cref="EqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, someObject, new MyEqualityComparer());
        /// </code>
        /// </example>
        public void Contains<T>(IEnumerable<T> enumeration, T element, EqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Contains(enumeration, element, comparer as IEqualityComparer<T>, _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains <paramref name="element"/>.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="element">The <see cref="Object"/> to search for.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, someObject, new MyEqualityComparer());
        /// </code>
        /// </example>
        public void Contains(IEnumerable enumeration, Object element, IEqualityComparer comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Contains(enumeration.Cast<Object>(), element, DynamicEqualityComparer.FromComparer<Object>(comparer), _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="element">The element of type <typeparamref name="T"/> to search for.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, someObject, new MyEqualityComparer());
        /// </code>
        /// </example>
        public void Contains<T>(IEnumerable<T> enumeration, T element, IEqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            try {
                result = enumeration.Contains(element, comparer);

            } catch(Exception ex) {
                FailTest($"Comparer threw Exception: {ex.Message.Format()}",
                    _file, _method);
                return;
            }

            InternalTest(result, String.Format("Enumeration {0} element {1}. Enumeration is: {2}", result ? "contains" : "doesn't contain", element.Format(), enumeration.Format()),
                _file, _method);
        }

        #endregion

        #region ContainsPredicate

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains an element matching <paramref name="match"/>.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="match">The <see cref="Predicate{Object}"/> used to filter for matches.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, new Predicate&lt;Object&gt;((element) => element as Int32 > 0));
        /// </code>
        /// </example>
        public void Contains(IEnumerable enumeration, Predicate<Object> match,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(match == null) {
                FailTest("Parameter 'predicate' is null.", _file, _method);
                return;
            }

            Contains(enumeration.Cast<Object>(), match, _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains an element matching <paramref name="match"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="match">The <see cref="Predicate{T}"/> used to filter for matches.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Contains(someEnumeration, new Predicate&lt;Int32&gt;((element) => element > 0));
        /// </code>
        /// </example>
        public void Contains<T>(IEnumerable<T> enumeration, Predicate<T> match,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(match == null) {
                FailTest("Parameter 'predicate' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            try {
                foreach(T element in enumeration) {
                    if(match(element)) {
                        result = true;
                        break;
                    }
                }

            } catch(Exception ex) {
                FailTest($"Predicate threw Exception: {ex.Message.Format()}",
                    _file, _method);
                return;
            }

            InternalTest(result, String.Format("Enumeration {0} a matching element. Enumeration is: {1}", result ? "contains" : "doesn't contain", enumeration.Format()),
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
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="elements">The range of <see cref="Object"/> to search for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.ContainsRange(someEnumeration, someCollection);
        /// </code>
        /// </example>
        public void ContainsRange<T>(IEnumerable<T> enumeration, IEnumerable elements,
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

            foreach(T element in elements) {
                elementsCount++;

                if(enumeration.Contains(element)) {
                    elementsFound++;
                }
            }

            InternalTest(elementsCount == elementsFound, $"Enumeration contains {elementsFound} of {elementsCount} elements. Enumeration is: {enumeration.Format()}; Elements are: {elements.Format()}",
                _file, _method);
        }

        #endregion

        #region ContainsRangeComparer

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a range of <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="elements">The <see cref="IEnumerable{T}"/> to search for.</param>
        /// <param name="comparer">The <see cref="EqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.ContainsRange(someEnumeration, someCollection, new MyEqualityComparer());
        /// </code>
        /// </example>
        public void ContainsRange<T>(IEnumerable<T> enumeration, IEnumerable<T> elements, EqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(elements == null) {
                FailTest("Parameter 'elements' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            ContainsRange(enumeration, elements, comparer as IEqualityComparer<T>, _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a range of <paramref name="elements"/>.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="elements">The <see cref="IEnumerable"/> to search for.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.ContainsRange(someEnumeration, someCollection, new MyEqualityComparer());
        /// </code>
        /// </example>
        public void ContainsRange(IEnumerable enumeration, IEnumerable elements, IEqualityComparer comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(elements == null) {
                FailTest("Parameter 'elements' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            ContainsRange(enumeration.Cast<Object>(), elements.Cast<Object>(), DynamicEqualityComparer.FromComparer<Object>(comparer), _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a range of <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="elements">The <see cref="IEnumerable{T}"/> to search for.</param>
        /// <param name="comparer">´The <see cref="IEqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.ContainsRange(someEnumeration, someCollection, new MyEqualityComparer());
        /// </code>
        /// </example>
        public void ContainsRange<T>(IEnumerable<T> enumeration, IEnumerable<T> elements, IEqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(elements == null) {
                FailTest("Parameter 'elements' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Int32 elementsCount = 0;
            Int32 elementsFound = 0;


            foreach(T element in elements) {
                elementsCount++;
                Boolean contains = false;

                try {
                    contains = enumeration.Contains(element, comparer);

                } catch(Exception ex) {
                    FailTest($"Comparer threw Exception: {ex.Message.Format()}",
                        _file, _method);
                    return;
                }

                if(contains) { elementsFound++; }
            }

            InternalTest(elementsCount == elementsFound, $"Enumeration contains {elementsFound} of {elementsCount} elements. Enumeration is: {enumeration.Format()}; Elements are: {elements.Format()}",
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
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Matches(someEnumeration, someOtherEnumeration);
        /// </code>
        /// </example>
        public void Matches<T>(IEnumerable<T> enumeration, IEnumerable<T> other,
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
                List<T> otherAsList = other.ToList();

                foreach(T element in enumeration) {
                    if(otherAsList.Contains(element)) {
                        otherAsList.Remove(element);
                    } else {
                        result = false;
                        break;
                    }
                }
            }

            InternalTest(result, String.Format("Enumerations {0}. Enumeration is: {1}; Elements are: {2}", result ? "match" : "don't match", enumeration.Format(), other.Format()),
                _file, _method);
        }

        #endregion

        #region MatchesComparer

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> ignoring order.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="comparer">The <see cref="EqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Matches(someEnumeration, someOtherEnumeration, new MyComparer());
        /// </code>
        /// </example>
        public void Matches<T>(IEnumerable<T> enumeration, IEnumerable<T> other, EqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Matches(enumeration, other, comparer as IEqualityComparer<T>, _file, _method);
        }

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> ignoring order.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable"/> that is checked for.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Matches(someEnumeration, someOtherEnumeration, new MyComparer());
        /// </code>
        /// </example>
        public void Matches(IEnumerable enumeration, IEnumerable other, IEqualityComparer comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Matches(enumeration.Cast<Object>(), other.Cast<Object>(), DynamicEqualityComparer.FromComparer<Object>(comparer), _file, _method);
        }

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> ignoring order.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.Matches(someEnumeration, someOtherEnumeration, new MyComparer());
        /// </code>
        /// </example>
        public void Matches<T>(IEnumerable<T> enumeration, IEnumerable<T> other, IEqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Int32 count1 = enumeration.Count();
            Int32 count2 = other.Count();
            Boolean result = count1 == 0 && count2 == 0;

            if(!result && count1 == count2) {
                result = true;
                List<T> otherAsList = other.ToList();

                foreach(T element in enumeration) {
                    Int32 index = -1;

                    try {
                        index = otherAsList.FindIndex(new Predicate<T>((_) => comparer.Equals(_, element)));

                    } catch(Exception ex) {
                        FailTest($"Comparer threw Exception: {ex.Message.Format()}",
                            _file, _method);
                        return;
                    }

                    if(index >= 0) {
                        otherAsList.RemoveAt(index);
                    } else {
                        result = false;
                        break;
                    }
                }
            }

            InternalTest(result, String.Format("Enumerations {0}. Enumeration is: {1}; Elements are: {2}", result ? "match" : "don't match", enumeration.Format(), other.Format()),
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
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.MatchesExactly(someEnumeration, someOtherEnumeration);
        /// </code>
        /// </example>
        public void MatchesExactly<T>(IEnumerable<T> enumeration, IEnumerable<T> other,
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

                using(IEnumerator<T> enum1 = enumeration.GetEnumerator()) {
                    using(IEnumerator<T> enum2 = other.GetEnumerator()) {
                        while(enum1.MoveNext() && enum2.MoveNext()) {
                            T element1 = enum1.Current;
                            T element2 = enum2.Current;

                            if(!element1.IsEqual<T>(element2)) {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }

            InternalTest(result, String.Format("Enumerations {0}. Enumeration is: {1}; Elements are: {2}", result ? "match" : "don't match", enumeration.Format(), other.Format()),
                _file, _method);
        }

        #endregion

        #region MatchesExactlyComparer

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> respecting order.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="comparer">The <see cref="EqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.MatchesExactly(someEnumeration, someOtherEnumeration, new MyComparer());
        /// </code>
        /// </example>
        public void MatchesExactly<T>(IEnumerable<T> enumeration, IEnumerable<T> other, EqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            MatchesExactly(enumeration, other, comparer as IEqualityComparer<T>, _file, _method);
        }

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> respecting order.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable"/> that is checked for.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.MatchesExactly(someEnumeration, someOtherEnumeration, new MyComparer());
        /// </code>
        /// </example>
        public void MatchesExactly(IEnumerable enumeration, IEnumerable other, IEqualityComparer comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            MatchesExactly(enumeration.Cast<Object>(), other.Cast<Object>(), DynamicEqualityComparer.FromComparer<Object>(comparer), _file, _method);
        }

        /// <summary>
        /// Tests if the elements of <paramref name="enumeration"/> match the elements of <paramref name="other"/> respecting order.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="enumeration"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="other">The other <see cref="IEnumerable{T}"/> that is checked for.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> used to determine equality.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Enumeration.MatchesExactly(someEnumeration, someOtherEnumeration, new MyComparer());
        /// </code>
        /// </example>
        public void MatchesExactly<T>(IEnumerable<T> enumeration, IEnumerable<T> other, IEqualityComparer<T> comparer,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            if(other == null) {
                FailTest("Parameter 'other' is null.", _file, _method);
                return;
            }

            if(comparer == null) {
                FailTest("Parameter 'comparer' is null.", _file, _method);
                return;
            }

            Int32 count1 = enumeration.Count();
            Int32 count2 = other.Count();
            Boolean result = count1 == 0 && count2 == 0;

            if(!result && count1 == count2) {
                result = true;

                using(IEnumerator<T> enum1 = enumeration.GetEnumerator()) {
                    using(IEnumerator<T> enum2 = other.GetEnumerator()) {

                        do {
                            T element1 = enum1.Current;
                            T element2 = enum2.Current;
                            Boolean contains = false;

                            try {
                                contains = comparer.Equals(element1, element2);

                            } catch(Exception ex) {
                                FailTest($"Comparer threw Exception: {ex.Message.Format()}",
                                    _file, _method);
                                return;
                            }

                            if(!contains) {
                                result = false;
                                break;
                            }

                        } while(enum1.MoveNext() && enum2.MoveNext());
                    }
                }
            }

            InternalTest(result, String.Format("Enumerations {0}. Enumeration is: {1}; Elements are: {2}", result ? "match" : "don't match", enumeration.Format(), other.Format()),
                _file, _method);
        }

        #endregion

    }
}
