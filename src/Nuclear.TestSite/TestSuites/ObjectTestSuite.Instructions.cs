using System;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    public partial class ObjectTestSuite {

        #region null

        /// <summary>
        /// Tests if <paramref name="object"/> is null.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        public void IsNull(Object @object,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(@object == null, String.Format("[Object: {0}null]", @object == null ? "" : "not "),
                _file, _method);

        #endregion

        #region type

        /// <summary>
        /// Tests if <paramref name="object"/> can be casted to <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TType">The type to be checked for.</typeparam>
        /// <param name="object">The object to be checked.</param>
        public void IsOfType<TType>(Object @object,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => IsOfType(@object, typeof(TType), _file, _method);

        /// <summary>
        /// Tests if <paramref name="object"/> can be casted to <paramref name="type"/>.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        public void IsOfType(Object @object, Type type,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(@object == null) {
                FailTest("Parameter 'object' is null.", _file, _method);
                return;
            }

            if(type == null) {
                FailTest("Parameter 'type' is null.", _file, _method);
                return;
            }

            InternalTest(type.IsAssignableFrom(@object.GetType()), $"Object is {@object.PrintType()}. Given type is {type.Print()}.",
                _file, _method);
        }

        #endregion

        #region exact type

        /// <summary>
        /// Tests if <paramref name="object"/> is exactly of type <typeparamref name="TType"/> and not just assignable.
        /// </summary>
        /// <typeparam name="TType">The type to be checked for.</typeparam>
        /// <param name="object">The object to be checked.</param>
        public void IsOfExactType<TType>(Object @object,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => IsOfExactType(@object, typeof(TType), _file, _method);

        /// <summary>
        /// Tests if <paramref name="object"/> is exactly of type <paramref name="type"/> and not just assignable.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        public void IsOfExactType(Object @object, Type type,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(@object == null) {
                FailTest("Parameter 'object' is null.", _file, _method);
                return;
            }

            if(type == null) {
                FailTest("Parameter 'type' is null.", _file, _method);
                return;
            }

            InternalTest(@object.GetType().Equals(type), $"Object is {@object.PrintType()}. Given type is {type.Print()}.",
                _file, _method);
        }

        #endregion

    }
}
