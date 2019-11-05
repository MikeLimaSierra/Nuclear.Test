using System;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class TypeTestSuit_uTests {

        #region Implements

        [TestMethod]
        void ImplementsGeneric() {

            DDTImplementsGeneric<Zero, Zero>((1, false, "Type 'Ntt.Zero' is not an interface."));
            DDTImplementsGeneric<Two, ITwo>((2, true, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTImplementsGeneric<Two, IZero>((3, false, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTImplementsGeneric<Zero, ITwo>((4, true, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTImplementsGeneric<IZero, IZero>((5, false, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTImplementsGeneric<IZero, ITwo>((6, true, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));
        }

        void DDTImplementsGeneric<TType, TInterface>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.Implements<{typeof(TType).Print()}, {typeof(TInterface).Print()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.Implements<TType, TInterface>(_file, _method),
                expected, "Test.If.Type.Implements", _file, _method);

        }

        [TestMethod]
        void NotImplementsGeneric() {

            DDTNotImplementsGeneric<Zero, Zero>((1, false, "Type 'Ntt.Zero' is not an interface."));
            DDTNotImplementsGeneric<Two, ITwo>((2, false, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTNotImplementsGeneric<Two, IZero>((3, true, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplementsGeneric<Zero, ITwo>((4, false, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTNotImplementsGeneric<IZero, IZero>((5, true, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplementsGeneric<IZero, ITwo>((6, false, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

        }

        void DDTNotImplementsGeneric<TType, TInterface>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.Implements<{typeof(TType).Print()}, {typeof(TInterface).Print()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.Implements<TType, TInterface>(_file, _method),
                expected, "Test.IfNot.Type.Implements", _file, _method);

        }

        [TestMethod]
        void Implements() {

            DDTImplements((null, null), (1, false, "Parameter 'type' is null."));
            DDTImplements((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTImplements((typeof(Zero), null), (3, false, "Parameter 'interface' is null."));
            DDTImplements((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is not an interface."));
            DDTImplements((typeof(Two), typeof(ITwo)), (5, true, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTImplements((typeof(Two), typeof(IZero)), (6, false, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTImplements((typeof(Zero), typeof(ITwo)), (7, true, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTImplements((typeof(IZero), typeof(IZero)), (8, false, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTImplements((typeof(IZero), typeof(ITwo)), (9, true, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

        }

        void DDTImplements((Type type, Type @interface) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.Implements({input.type.Print()}, {input.@interface.Print()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.Implements(input.type, input.@interface, _file, _method),
                expected, "Test.If.Type.Implements", _file, _method);

        }

        [TestMethod]
        void NotImplements() {

            DDTNotImplements((null, null), (1, false, "Parameter 'type' is null."));
            DDTNotImplements((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTNotImplements((typeof(Zero), null), (3, false, "Parameter 'interface' is null."));
            DDTNotImplements((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is not an interface."));
            DDTNotImplements((typeof(Two), typeof(ITwo)), (5, false, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTNotImplements((typeof(Two), typeof(IZero)), (6, true, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplements((typeof(Zero), typeof(ITwo)), (7, false, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTNotImplements((typeof(IZero), typeof(IZero)), (8, true, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplements((typeof(IZero), typeof(ITwo)), (9, false, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

        }

        void DDTNotImplements((Type type, Type @interface) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.Implements({input.type.Print()}, {input.@interface.Print()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.Implements(input.type, input.@interface, _file, _method),
                expected, "Test.IfNot.Type.Implements", _file, _method);

        }

        #endregion

        #region IsSubClass

        [TestMethod]
        void IsSubClassGeneric() {

            DDTIsSubClassGeneric<Zero, Zero>((1, false, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTIsSubClassGeneric<DerivesFromZero, Zero>((2, true, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTIsSubClassGeneric<DerivesFromZero, ITwo>((3, false, "Type 'Ntt.ITwo' is not a class."));
            DDTIsSubClassGeneric<ITwo, Zero>((4, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTIsSubClassGeneric<TType, TBase>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.IsSubClass<{typeof(TType).Print()}, {typeof(TBase).Print()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.IsSubClass<TType, TBase>(_file, _method),
                expected, "Test.If.Type.IsSubClass", _file, _method);

        }

        [TestMethod]
        void NotIsSubClassGeneric() {

            DDTNotIsSubClassGeneric<Zero, Zero>((1, true, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTNotIsSubClassGeneric<DerivesFromZero, Zero>((2, false, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTNotIsSubClassGeneric<DerivesFromZero, ITwo>((3, false, "Type 'Ntt.ITwo' is not a class."));
            DDTNotIsSubClassGeneric<ITwo, Zero>((4, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTNotIsSubClassGeneric<TType, TBase>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.IsSubClass<{typeof(TType).Print()}, {typeof(TBase).Print()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.IsSubClass<TType, TBase>(_file, _method),
                expected, "Test.IfNot.Type.IsSubClass", _file, _method);

        }

        [TestMethod]
        void IsSubClass() {

            DDTIsSubClass((null, null), (1, false, "Parameter 'type' is null."));
            DDTIsSubClass((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTIsSubClass((typeof(Zero), null), (3, false, "Parameter 'baseType' is null."));
            DDTIsSubClass((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTIsSubClass((typeof(DerivesFromZero), typeof(Zero)), (5, true, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTIsSubClass((typeof(DerivesFromZero), typeof(ITwo)), (6, false, "Type 'Ntt.ITwo' is not a class."));
            DDTIsSubClass((typeof(ITwo), typeof(Zero)), (7, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTIsSubClass((Type type, Type baseType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.IsSubClass({input.type.Print()}, {input.baseType.Print()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.IsSubClass(input.type, input.baseType, _file, _method),
                expected, "Test.If.Type.IsSubClass", _file, _method);

        }

        [TestMethod]
        void NotIsSubClass() {

            DDTNotIsSubClass((null, null), (1, false, "Parameter 'type' is null."));
            DDTNotIsSubClass((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTNotIsSubClass((typeof(Zero), null), (3, false, "Parameter 'baseType' is null."));
            DDTNotIsSubClass((typeof(Zero), typeof(Zero)), (4, true, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTNotIsSubClass((typeof(DerivesFromZero), typeof(Zero)), (5, false, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTNotIsSubClass((typeof(DerivesFromZero), typeof(ITwo)), (6, false, "Type 'Ntt.ITwo' is not a class."));
            DDTNotIsSubClass((typeof(ITwo), typeof(Zero)), (7, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTNotIsSubClass((Type type, Type baseType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.IsSubClass({input.type.Print()}, {input.baseType.Print()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.IsSubClass(input.type, input.baseType, _file, _method),
                expected, "Test.IfNot.Type.IsSubClass", _file, _method);

        }

        #endregion

    }
}
