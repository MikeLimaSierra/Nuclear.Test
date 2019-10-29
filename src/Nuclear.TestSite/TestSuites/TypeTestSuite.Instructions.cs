using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    public partial class TypeTestSuite {

        #region Implements

        /// <summary>
        /// Tests if <typeparamref name="TType"/> implements <typeparamref name="TInterface"/>.
        /// </summary>
        /// <typeparam name="TType">The type to be checked.</typeparam>
        /// <typeparam name="TInterface">The interface to be implemented.</typeparam>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
        public void Implements<TType, TInterface>([CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => Implements(typeof(TType), typeof(TInterface), _file, _method);

        /// <summary>
        /// Tests if <paramref name="type"/> implements <paramref name="interface"/>.
        /// </summary>
        /// <param name="type">The type to be checked.</param>
        /// <param name="interface">The interface to be implemented.</param>
        public void Implements(Type type, Type @interface,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(type == null) {
                FailTest("Parameter 'type' is null.", _file, _method);
                return;
            }

            if(@interface == null) {
                FailTest("Parameter 'interface' is null.", _file, _method);
                return;
            }

            if(!@interface.IsInterface) {
                FailTest($"Type {@interface.Print()} is not an interface.",
                    _file, _method);
                return;
            }

            Boolean result = type.GetInterfaces().Where(_interface => _interface.Equals(@interface)).Count() > 0;
            InternalTest(result, String.Format("Type {0} {1} interface {2}.", type.Print(), result ? "implements" : "doesn't implement", @interface.Print()),
                _file, _method);
        }

        #endregion

        #region IsSubClass

        /// <summary>
        /// Tests if <typeparamref name="TType"/> inherits from <typeparamref name="TBase"/>.
        /// </summary>
        /// <typeparam name="TType">The type to be checked.</typeparam>
        /// <typeparam name="TBase">The base class to be inherited from.</typeparam>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
        public void IsSubClass<TType, TBase>([CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
         => IsSubClass(typeof(TType), typeof(TBase), _file, _method);

        /// <summary>
        /// Tests if <paramref name="type"/> inherits from <paramref name="baseType"/>.
        /// </summary>
        /// <param name="type">The type to be checked.</param>
        /// <param name="baseType">The base class to be inherited from.</param>
        public void IsSubClass(Type type, Type baseType,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

            if(type == null) {
                FailTest("Parameter 'type' is null.", _file, _method);
                return;
            }

            if(baseType == null) {
                FailTest("Parameter 'baseType' is null.", _file, _method);
                return;
            }

            if(!type.IsClass) {
                FailTest($"Type {type.Print()} is not a class.",
                    _file, _method);
                return;
            }

            if(!baseType.IsClass) {
                FailTest($"Type {baseType.Print()} is not a class.",
                    _file, _method);
                return;
            }

            Boolean result = type.IsSubclassOf(baseType);
            InternalTest(result, String.Format("Type {0} is {1}subclass of {2}.", type.Print(), result ? "" : "no ", baseType.Print()),
                _file, _method);
        }

        #endregion

    }
}
