using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    public partial class ObjectTestSuite {

        #region null

        /// <summary>
        /// Tests if <paramref name="object"/> is null.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Object.IsNull(obj);
        /// </code>
        /// </example>
        public void IsNull(Object @object,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => InternalTest(@object == null, String.Format("[Object: {0}null]", @object == null ? "" : "not "),
                _file, _method);

        #endregion

        #region type

        /// <summary>
        /// Tests if <paramref name="object"/> can be casted to <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TType">The type to be checked for.</typeparam>
        /// <param name="object">The object to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Object.IsOfType&lt;MyClass&gt;(obj);
        /// </code>
        /// </example>
        public void IsOfType<TType>(Object @object,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => IsOfType(@object, typeof(TType), _file, _method);

        /// <summary>
        /// Tests if <paramref name="object"/> can be casted to <paramref name="type"/>.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Object.IsOfType(obj, typeof(MyClass));
        /// </code>
        /// </example>
        public void IsOfType(Object @object, Type type,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(@object == null) {
                FailTest("Parameter 'object' is null.", _file, _method);
                return;
            }

            if(type == null) {
                FailTest("Parameter 'type' is null.", _file, _method);
                return;
            }

            InternalTest(type.IsAssignableFrom(@object.GetType()), $"Object is {@object.FormatType()}. Given type is {type.Format()}.",
                _file, _method);
        }

        #endregion

        #region exact type

        /// <summary>
        /// Tests if <paramref name="object"/> is exactly of type <typeparamref name="TType"/> and not just assignable.
        /// </summary>
        /// <typeparam name="TType">The type to be checked for.</typeparam>
        /// <param name="object">The object to be checked.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Object.IsOfExactType&lt;MyClass&gt;(obj);
        /// </code>
        /// </example>
        public void IsOfExactType<TType>(Object @object,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => IsOfExactType(@object, typeof(TType), _file, _method);

        /// <summary>
        /// Tests if <paramref name="object"/> is exactly of type <paramref name="type"/> and not just assignable.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        /// <param name="_file">The file name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <param name="_method">The name of the caller. Do not use in methods decorated with <see cref="TestMethodAttribute"/>!</param>
        /// <example>
        /// <code>
        /// Test.If.Object.IsOfExactType(obj, typeof(MyClass));
        /// </code>
        /// </example>
        public void IsOfExactType(Object @object, Type type,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            if(@object == null) {
                FailTest("Parameter 'object' is null.", _file, _method);
                return;
            }

            if(type == null) {
                FailTest("Parameter 'type' is null.", _file, _method);
                return;
            }

            InternalTest(@object.GetType().Equals(type), $"Object is {@object.FormatType()}. Given type is {type.Format()}.",
                _file, _method);
        }

        #endregion

    }
}
