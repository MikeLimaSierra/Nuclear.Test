using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    public partial class EnumerationTestSuite {

        #region Contains

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains <paramref name="element"/>.
        /// </summary>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="element">The <see cref="Object"/> to search for.</param>
        public void Contains(IEnumerable enumeration, Object element,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            foreach(Object _element in enumeration) {
                result |= (_element == null && element == null) || Equals(_element, element);

                if(result) { break; }
            }

            InternalTest(result, String.Format("Enumeration {0} element {1}.", result ? "contains" : "doesn't contain", element.Print()),
                _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="element"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable{T}"/> that is checked.</param>
        /// <param name="element">The element of type <typeparamref name="TType"/> to search for.</param>
        public void Contains<TType>(IEnumerable<TType> enumeration, TType element,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(enumeration == null) {
                FailTest("Parameter 'enumeration' is null.", _file, _method);
                return;
            }

            Boolean result = false;

            foreach(TType _element in enumeration) {
                result |= (_element == null && element == null) || EqualityComparer<TType>.Default.Equals(_element, element);

                if(result) { break; }
            }

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
        public void ContainsRange(IEnumerable enumeration, IEnumerable elements,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

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

            foreach(Object element in elements) {
                elementsCount++;

                foreach(Object _element in enumeration) {
                    if((_element == null && element == null) || Equals(_element, element)) {
                        elementsFound++;
                        break;
                    }
                }
            }

            InternalTest(elementsCount == elementsFound, $"Enumeration contains {elementsFound} of {elementsCount} elements.",
                _file, _method);
        }

        /// <summary>
        /// Tests if <paramref name="enumeration"/> contains a range of <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="elements"/>.</typeparam>
        /// <param name="enumeration">The <see cref="IEnumerable"/> that is checked.</param>
        /// <param name="elements">The range of <see cref="Object"/> to search for.</param>
        public void ContainsRange<TType>(IEnumerable<TType> enumeration, IEnumerable elements,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

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

                foreach(TType _element in enumeration) {
                    if((_element == null && element == null) || EqualityComparer<TType>.Default.Equals(_element, element)) {
                        elementsFound++;
                        break;
                    }
                }
            }

            InternalTest(elementsCount == elementsFound, $"Enumeration contains {elementsFound} of {elementsCount} elements.",
                _file, _method);
        }

        #endregion

    }
}
