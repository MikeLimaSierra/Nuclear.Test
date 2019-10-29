using System;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class ObjectTestSuit_uTests {

        #region IsNull

        [TestMethod]
        void TestNull() {

            DDTestIsNull(null, (1, true, "[Object: null]"));
            DDTestIsNull(new Object(), (2, false, "[Object: not null]"));

        }

        void DDTestIsNull(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsNull({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Object.IsNull(input, _file, _method),
                expected, "Test.If.Object.IsNull", _file, _method);

        }

        [TestMethod]
        void TestNotIsNull() {

            DDTestNotIsNull(null, (1, false, "[Object: null]"));
            DDTestNotIsNull(new Object(), (2, true, "[Object: not null]"));

        }

        void DDTestNotIsNull(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsNull({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Object.IsNull(input, _file, _method),
                expected, "Test.IfNot.Object.IsNull", _file, _method);

        }

        #endregion

        #region IsOfType

        [TestMethod]
        void TestIsOfType() {

            DDTestIsOfType((null, null), (1, false, "Parameter 'object' is null."));
            DDTestIsOfType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTestIsOfType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTestIsOfType((new Zero(), typeof(Zero)), (4, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfType((new DerivesFromZero(), typeof(Zero)), (5, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfType((new Two(), typeof(Zero)), (6, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTestIsOfType((new Two(), typeof(ITwo)), (7, true, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTestIsOfType((new Two(), typeof(IZero)), (8, false, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTestIsOfType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfType({input.@object.PrintType()}, {input.type.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Object.IsOfType(input.@object, input.type, _file, _method),
                expected, "Test.If.Object.IsOfType", _file, _method);

        }

        [TestMethod]
        void TestNotIsOfType() {

            DDTestNotIsOfType((null, null), (1, false, "Parameter 'object' is null."));
            DDTestNotIsOfType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTestNotIsOfType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTestNotIsOfType((new Zero(), typeof(Zero)), (4, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfType((new DerivesFromZero(), typeof(Zero)), (5, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfType((new Two(), typeof(Zero)), (6, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfType((new Two(), typeof(ITwo)), (7, false, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTestNotIsOfType((new Two(), typeof(IZero)), (8, true, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTestNotIsOfType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfType({input.@object.PrintType()}, {input.type.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Object.IsOfType(input.@object, input.type, _file, _method),
                expected, "Test.IfNot.Object.IsOfType", _file, _method);

        }

        [TestMethod]
        void TestIsOfTypeGeneric() {

            DDTestIsOfTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTestIsOfTypeGeneric<Zero>(new Zero(), (2, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfTypeGeneric<Zero>(new DerivesFromZero(), (3, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfTypeGeneric<Zero>(new Two(), (4, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTestIsOfTypeGeneric<ITwo>(new Two(), (5, true, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTestIsOfTypeGeneric<IZero>(new Two(), (6, false, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTestIsOfTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfType<{typeof(TType).Print()}>({input.PrintType()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Object.IsOfType<TType>(input, _file, _method),
                expected, "Test.If.Object.IsOfType", _file, _method);

        }

        [TestMethod]
        void TestNotIsOfTypeGeneric() {

            DDTestNotIsOfTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTestNotIsOfTypeGeneric<Zero>(new Zero(), (2, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfTypeGeneric<Zero>(new DerivesFromZero(), (3, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfTypeGeneric<Zero>(new Two(), (4, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfTypeGeneric<ITwo>(new Two(), (5, false, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTestNotIsOfTypeGeneric<IZero>(new Two(), (6, true, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTestNotIsOfTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfType<{typeof(TType).Print()}>({input.PrintType()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Object.IsOfType<TType>(input, _file, _method),
                expected, "Test.IfNot.Object.IsOfType", _file, _method);

        }

        #endregion

        #region IsOfExactType

        [TestMethod]
        void TestIsOfExactType() {

            DDTestIsOfExactType((null, null), (1, false, "Parameter 'object' is null."));
            DDTestIsOfExactType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTestIsOfExactType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTestIsOfExactType((new Zero(), typeof(Zero)), (4, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfExactType((new DerivesFromZero(), typeof(Zero)), (5, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfExactType((new Two(), typeof(Zero)), (6, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTestIsOfExactType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfExactType({input.@object.PrintType()}, {input.type.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Object.IsOfExactType(input.@object, input.type, _file, _method),
                expected, "Test.If.Object.IsOfExactType", _file, _method);

        }

        [TestMethod]
        void TestNotIsOfExactType() {

            DDTestNotIsOfExactType((null, null), (1, false, "Parameter 'object' is null."));
            DDTestNotIsOfExactType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTestNotIsOfExactType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTestNotIsOfExactType((new Zero(), typeof(Zero)), (4, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfExactType((new DerivesFromZero(), typeof(Zero)), (5, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfExactType((new Two(), typeof(Zero)), (6, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTestNotIsOfExactType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfExactType({input.@object.PrintType()}, {input.type.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Object.IsOfExactType(input.@object, input.type, _file, _method),
                expected, "Test.IfNot.Object.IsOfExactType", _file, _method);

        }

        [TestMethod]
        void TestIsOfExactTypeGeneric() {

            DDTestIsOfExactTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTestIsOfExactTypeGeneric<Zero>(new Zero(), (2, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfExactTypeGeneric<Zero>(new DerivesFromZero(), (3, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestIsOfExactTypeGeneric<Zero>(new Two(), (4, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTestIsOfExactTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfExactType<{typeof(TType).Print()}>({input.PrintType()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Object.IsOfExactType<TType>(input, _file, _method),
                expected, "Test.If.Object.IsOfExactType", _file, _method);

        }

        [TestMethod]
        void TestNotIsOfExactTypeGeneric() {

            DDTestNotIsOfExactTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTestNotIsOfExactTypeGeneric<Zero>(new Zero(), (2, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfExactTypeGeneric<Zero>(new DerivesFromZero(), (3, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTestNotIsOfExactTypeGeneric<Zero>(new Two(), (4, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTestNotIsOfExactTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfExactType<{typeof(TType).Print()}>({input.PrintType()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Object.IsOfExactType<TType>(input, _file, _method),
                expected, "Test.IfNot.Object.IsOfExactType", _file, _method);

        }

        #endregion

    }
}
