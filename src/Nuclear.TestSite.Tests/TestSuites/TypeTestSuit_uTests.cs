using System;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    class TypeTestSuit_uTests {

        #region Implements

        [TestMethod]
        void ImplementsGeneric() {

            DDTImplements((null, null), (1, false, "Parameter 'type' is null."));
            DDTImplements((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTImplements((typeof(Zero), null), (3, false, "Parameter 'interface' is null."));
            DDTImplements((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is not an interface."));
            DDTImplements((typeof(Two), typeof(ITwo)), (5, true, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTImplements((typeof(Two), typeof(IZero)), (6, false, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTImplements((typeof(Zero), typeof(ITwo)), (7, true, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTImplements((typeof(IZero), typeof(IZero)), (8, false, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTImplements((typeof(IZero), typeof(ITwo)), (9, true, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

            DDTImplements<Zero, Zero>((10, false, "Type 'Ntt.Zero' is not an interface."));
            DDTImplements<Two, ITwo>((11, true, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTImplements<Two, IZero>((12, false, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTImplements<Zero, ITwo>((13, true, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTImplements<IZero, IZero>((14, false, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTImplements<IZero, ITwo>((15, true, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));
        }

        void DDTImplements<TType, TInterface>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.Implements<{typeof(TType).Format()}, {typeof(TInterface).Format()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.Implements<TType, TInterface>(_file, _method),
                expected, "Test.If.Type.Implements", _file, _method);

        }

        void DDTImplements((Type type, Type @interface) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.Implements({input.type.Format()}, {input.@interface.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.Implements(input.type, input.@interface, _file, _method),
                expected, "Test.If.Type.Implements", _file, _method);

        }

        [TestMethod]
        void NotImplementsGeneric() {

            DDTNotImplements((null, null), (1, false, "Parameter 'type' is null."));
            DDTNotImplements((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTNotImplements((typeof(Zero), null), (3, false, "Parameter 'interface' is null."));
            DDTNotImplements((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is not an interface."));
            DDTNotImplements((typeof(Two), typeof(ITwo)), (5, false, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTNotImplements((typeof(Two), typeof(IZero)), (6, true, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplements((typeof(Zero), typeof(ITwo)), (7, false, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTNotImplements((typeof(IZero), typeof(IZero)), (8, true, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplements((typeof(IZero), typeof(ITwo)), (9, false, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

            DDTNotImplements<Zero, Zero>((10, false, "Type 'Ntt.Zero' is not an interface."));
            DDTNotImplements<Two, ITwo>((11, false, "Type 'Ntt.Two' implements interface 'Ntt.ITwo'."));
            DDTNotImplements<Two, IZero>((12, true, "Type 'Ntt.Two' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplements<Zero, ITwo>((13, false, "Type 'Ntt.Zero' implements interface 'Ntt.ITwo'."));
            DDTNotImplements<IZero, IZero>((14, true, "Type 'Ntt.IZero' doesn't implement interface 'Ntt.IZero'."));
            DDTNotImplements<IZero, ITwo>((15, false, "Type 'Ntt.IZero' implements interface 'Ntt.ITwo'."));

        }

        void DDTNotImplements<TType, TInterface>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.Implements<{typeof(TType).Format()}, {typeof(TInterface).Format()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.Implements<TType, TInterface>(_file, _method),
                expected, "Test.IfNot.Type.Implements", _file, _method);

        }

        void DDTNotImplements((Type type, Type @interface) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.Implements({input.type.Format()}, {input.@interface.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.Implements(input.type, input.@interface, _file, _method),
                expected, "Test.IfNot.Type.Implements", _file, _method);

        }

        #endregion

        #region IsSubClass

        [TestMethod]
        void IsSubClassGeneric() {

            DDTIsSubClass((null, null), (1, false, "Parameter 'type' is null."));
            DDTIsSubClass((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTIsSubClass((typeof(Zero), null), (3, false, "Parameter 'baseType' is null."));
            DDTIsSubClass((typeof(Zero), typeof(Zero)), (4, false, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTIsSubClass((typeof(DerivesFromZero), typeof(Zero)), (5, true, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTIsSubClass((typeof(DerivesFromZero), typeof(ITwo)), (6, false, "Type 'Ntt.ITwo' is not a class."));
            DDTIsSubClass((typeof(ITwo), typeof(Zero)), (7, false, "Type 'Ntt.ITwo' is not a class."));

            DDTIsSubClass<Zero, Zero>((8, false, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTIsSubClass<DerivesFromZero, Zero>((9, true, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTIsSubClass<DerivesFromZero, ITwo>((10, false, "Type 'Ntt.ITwo' is not a class."));
            DDTIsSubClass<ITwo, Zero>((11, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTIsSubClass<TType, TBase>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.IsSubClass<{typeof(TType).Format()}, {typeof(TBase).Format()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.IsSubClass<TType, TBase>(_file, _method),
                expected, "Test.If.Type.IsSubClass", _file, _method);

        }

        void DDTIsSubClass((Type type, Type baseType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Type.IsSubClass({input.type.Format()}, {input.baseType.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Type.IsSubClass(input.type, input.baseType, _file, _method),
                expected, "Test.If.Type.IsSubClass", _file, _method);

        }

        [TestMethod]
        void NotIsSubClassGeneric() {

            DDTNotIsSubClass((null, null), (1, false, "Parameter 'type' is null."));
            DDTNotIsSubClass((null, typeof(Zero)), (2, false, "Parameter 'type' is null."));
            DDTNotIsSubClass((typeof(Zero), null), (3, false, "Parameter 'baseType' is null."));
            DDTNotIsSubClass((typeof(Zero), typeof(Zero)), (4, true, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTNotIsSubClass((typeof(DerivesFromZero), typeof(Zero)), (5, false, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTNotIsSubClass((typeof(DerivesFromZero), typeof(ITwo)), (6, false, "Type 'Ntt.ITwo' is not a class."));
            DDTNotIsSubClass((typeof(ITwo), typeof(Zero)), (7, false, "Type 'Ntt.ITwo' is not a class."));

            DDTNotIsSubClass<Zero, Zero>((8, true, "Type 'Ntt.Zero' is no subclass of 'Ntt.Zero'."));
            DDTNotIsSubClass<DerivesFromZero, Zero>((9, false, "Type 'Ntt.DerivesFromZero' is subclass of 'Ntt.Zero'."));
            DDTNotIsSubClass<DerivesFromZero, ITwo>((10, false, "Type 'Ntt.ITwo' is not a class."));
            DDTNotIsSubClass<ITwo, Zero>((11, false, "Type 'Ntt.ITwo' is not a class."));

        }

        void DDTNotIsSubClass<TType, TBase>((Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.IsSubClass<{typeof(TType).Format()}, {typeof(TBase).Format()}>()",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.IsSubClass<TType, TBase>(_file, _method),
                expected, "Test.IfNot.Type.IsSubClass", _file, _method);

        }

        void DDTNotIsSubClass((Type type, Type baseType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Type.IsSubClass({input.type.Format()}, {input.baseType.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Type.IsSubClass(input.type, input.baseType, _file, _method),
                expected, "Test.IfNot.Type.IsSubClass", _file, _method);

        }

        #endregion

    }
}
