using System;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class TypeTestSuit_uTests {

        #region Implements

        [TestMethod]
        void TestImplementsGeneric() {

            DDTestImplementsGeneric<Zero, Zero>((1, false, "Type 'Ntt.Zero' is not an interface."));
            DDTestImplementsGeneric<Two, ITwo>((2, true, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTestImplementsGeneric<Two, IZero>((3, false, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTestImplementsGeneric<Zero, ITwo>((4, true, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTestImplementsGeneric<IZero, IZero>((5, false, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTestImplementsGeneric<IZero, ITwo>((6, true, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));
        }

        void DDTestImplementsGeneric<TType, TInterface>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.Implements<{typeof(TType).Print()}, {typeof(TInterface).Print()}>()",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Type.Implements<TType, TInterface>(_file, _method),
                expected, "Test.If.Type.Implements", _file, _method);

        }

        [TestMethod]
        void TestNotImplementsGeneric() {

            DDTestNotImplementsGeneric<Zero, Zero>((1, false, "Type 'Ntt.Zero' is not an interface."));
            DDTestNotImplementsGeneric<Two, ITwo>((2, false, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTestNotImplementsGeneric<Two, IZero>((3, true, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTestNotImplementsGeneric<Zero, ITwo>((4, false, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTestNotImplementsGeneric<IZero, IZero>((5, true, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTestNotImplementsGeneric<IZero, ITwo>((6, false, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

        }

        void DDTestNotImplementsGeneric<TType, TInterface>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.Implements<{typeof(TType).Print()}, {typeof(TInterface).Print()}>()",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Type.Implements<TType, TInterface>(_file, _method),
                expected, "Test.IfNot.Type.Implements", _file, _method);

        }

        [TestMethod]
        void TestImplements() {

            DDTestImplements((null, null), (1, false, "Parameter 'type' is null."));
            DDTestImplements((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTestImplements((typeof(Zero), null), (3, false, "Parameter 'interface' is null."));
            DDTestImplements((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is not an interface."));
            DDTestImplements((typeof(Two), typeof(ITwo)), (5, true, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTestImplements((typeof(Two), typeof(IZero)), (6, false, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTestImplements((typeof(Zero), typeof(ITwo)), (7, true, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTestImplements((typeof(IZero), typeof(IZero)), (8, false, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTestImplements((typeof(IZero), typeof(ITwo)), (9, true, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

        }

        void DDTestImplements((Type type, Type @interface) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.Implements({input.type.Print()}, {input.@interface.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Type.Implements(input.type, input.@interface, _file, _method),
                expected, "Test.If.Type.Implements", _file, _method);

        }

        [TestMethod]
        void TestNotImplements() {

            DDTestNotImplements((null, null), (1, false, "Parameter 'type' is null."));
            DDTestNotImplements((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTestNotImplements((typeof(Zero), null), (3, false, "Parameter 'interface' is null."));
            DDTestNotImplements((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is not an interface."));
            DDTestNotImplements((typeof(Two), typeof(ITwo)), (5, false, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTestNotImplements((typeof(Two), typeof(IZero)), (6, true, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTestNotImplements((typeof(Zero), typeof(ITwo)), (7, false, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTestNotImplements((typeof(IZero), typeof(IZero)), (8, true, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTestNotImplements((typeof(IZero), typeof(ITwo)), (9, false, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

        }

        void DDTestNotImplements((Type type, Type @interface) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.Implements({input.type.Print()}, {input.@interface.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Type.Implements(input.type, input.@interface, _file, _method),
                expected, "Test.IfNot.Type.Implements", _file, _method);

        }

        #endregion

        #region IsSubClass

        [TestMethod]
        void TestIsSubClassGeneric() {

            DDTestIsSubClassGeneric<Zero, Zero>((1, false, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTestIsSubClassGeneric<DerivesFromZero, Zero>((2, true, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTestIsSubClassGeneric<DerivesFromZero, ITwo>((3, false, "Type 'Ntt.ITwo' is not a class."));
            DDTestIsSubClassGeneric<ITwo, Zero>((4, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTestIsSubClassGeneric<TType, TBase>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.IsSubClass<{typeof(TType).Print()}, {typeof(TBase).Print()}>()",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Type.IsSubClass<TType, TBase>(_file, _method),
                expected, "Test.If.Type.IsSubClass", _file, _method);

        }

        [TestMethod]
        void TestNotIsSubClassGeneric() {

            DDTestNotIsSubClassGeneric<Zero, Zero>((1, true, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTestNotIsSubClassGeneric<DerivesFromZero, Zero>((2, false, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTestNotIsSubClassGeneric<DerivesFromZero, ITwo>((3, false, "Type 'Ntt.ITwo' is not a class."));
            DDTestNotIsSubClassGeneric<ITwo, Zero>((4, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTestNotIsSubClassGeneric<TType, TBase>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.IsSubClass<{typeof(TType).Print()}, {typeof(TBase).Print()}>()",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Type.IsSubClass<TType, TBase>(_file, _method),
                expected, "Test.IfNot.Type.IsSubClass", _file, _method);

        }

        [TestMethod]
        void TestIsSubClass() {

            DDTestIsSubClass((null, null), (1, false, "Parameter 'type' is null."));
            DDTestIsSubClass((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTestIsSubClass((typeof(Zero), null), (3, false, "Parameter 'baseType' is null."));
            DDTestIsSubClass((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTestIsSubClass((typeof(DerivesFromZero), typeof(Zero)), (5, true, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTestIsSubClass((typeof(DerivesFromZero), typeof(ITwo)), (6, false, "Type 'Ntt.ITwo' is not a class."));
            DDTestIsSubClass((typeof(ITwo), typeof(Zero)), (7, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTestIsSubClass((Type type, Type baseType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.IsSubClass({input.type.Print()}, {input.baseType.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Type.IsSubClass(input.type, input.baseType, _file, _method),
                expected, "Test.If.Type.IsSubClass", _file, _method);

        }

        [TestMethod]
        void TestNotIsSubClass() {

            DDTestNotIsSubClass((null, null), (1, false, "Parameter 'type' is null."));
            DDTestNotIsSubClass((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTestNotIsSubClass((typeof(Zero), null), (3, false, "Parameter 'baseType' is null."));
            DDTestNotIsSubClass((typeof(Zero), typeof(Zero)), (4, true, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTestNotIsSubClass((typeof(DerivesFromZero), typeof(Zero)), (5, false, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTestNotIsSubClass((typeof(DerivesFromZero), typeof(ITwo)), (6, false, "Type 'Ntt.ITwo' is not a class."));
            DDTestNotIsSubClass((typeof(ITwo), typeof(Zero)), (7, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTestNotIsSubClass((Type type, Type baseType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.IsSubClass({input.type.Print()}, {input.baseType.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Type.IsSubClass(input.type, input.baseType, _file, _method),
                expected, "Test.IfNot.Type.IsSubClass", _file, _method);

        }

        #endregion

    }
}
