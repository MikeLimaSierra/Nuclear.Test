using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.Tests {
    public partial class ConditionalTest {

        /// <summary>
        /// Tests if <paramref name="_object"/> can be casted to <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TType">The type to be checked for.</typeparam>
        /// <param name="_object">The object to be checked.</param>
        public void OfType<TType>(Object _object,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(_object != null && _object is TType,
                String.Format("Object is '{0}'. Given type is '{1}'.", _object != null ? _object.GetType().FullName : "null", typeof(TType).FullName),
                _file, _method);

        /// <summary>
        /// Tests if <paramref name="_object"/> is exactly of type <typeparamref name="TType"/> and not just assignable.
        /// </summary>
        /// <typeparam name="TType">The type to be checked for.</typeparam>
        /// <param name="_object">The object to be checked.</param>
        public void OfExactType<TType>(Object _object,
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
            => InternalTest(_object != null && _object.GetType().Equals(typeof(TType)),
                String.Format("Object is '{0}'. Given type is '{1}'.", _object != null ? _object.GetType().FullName : "null", typeof(TType).FullName),
                _file, _method);

        /// <summary>
        /// Tests if type <typeparamref name="TType"/> implements interface <typeparamref name="TInterface"/>.
        /// </summary>
        /// <typeparam name="TType">The type to be checked.</typeparam>
        /// <typeparam name="TInterface">The interface to be implemented.</typeparam>
        public void TypeImplements<TType, TInterface>([CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
            Type _type = typeof(TType);
            Type _interface = typeof(TInterface);

            if(!_interface.IsInterface) {
                InternalTest(false, String.Format("Type '{0}' is not an interface.", _interface.FullName),
                    _file, _method);
            } else {
                Boolean result = _type.GetInterfaces().Where(type => type.Equals(_interface)).Count() > 0;
                InternalTest(result, String.Format("Type '{0}' {1}interface '{2}'.", _type, result ? "implements " : "doesn't implement ", _interface.FullName),
                    _file, _method);
            }
        }

        /// <summary>
        /// Tests if type <typeparamref name="TType"/> inherits from class <typeparamref name="TBase"/>.
        /// </summary>
        /// <typeparam name="TType">The type to be checked.</typeparam>
        /// <typeparam name="TBase">The base class to be inherited from.</typeparam>
        public void TypeIsSubClass<TType, TBase>([CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {
            Type _type = typeof(TType);
            Type _base = typeof(TBase);

            if(!_type.IsClass) {
                InternalTest(false, String.Format("Type '{0}' is not a class.", _type.FullName),
                    _file, _method);
            } else if(!_base.IsClass) {
                InternalTest(false, String.Format("Type '{0}' is not a class.", _base.FullName),
                    _file, _method);
            } else {
                Boolean result = _type.IsSubclassOf(_base);
                InternalTest(result, String.Format("Type '{0}' is {1}subclass of '{2}'.", _type.FullName, result ? "" : "no ", _base.FullName),
                    _file, _method);
            }
        }
    }
}
