using Ntt;
using Nuclear.Extensions;
using Nuclear.TestSite.Attributes;
using System;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    class ObjectTestSuit_uTests {

        #region IsNull

        [TestMethod]
        void IsNull() {

            DDTIsNull(null, (1, true, "[Object: null]"));
            DDTIsNull(new Object(), (2, false, "[Object: not null]"));

        }

        void DDTIsNull(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsNull({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsNull(input, _file, _method),
                expected, "Test.If.Object.IsNull", _file, _method);

        }

        [TestMethod]
        void NotIsNull() {

            DDTNotIsNull(null, (1, false, "[Object: null]"));
            DDTNotIsNull(new Object(), (2, true, "[Object: not null]"));

        }

        void DDTNotIsNull(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsNull({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsNull(input, _file, _method),
                expected, "Test.IfNot.Object.IsNull", _file, _method);

        }

        #endregion

        #region IsOfType

        [TestMethod]
        void IsOfType() {

            DDTIsOfType((null, null), (1, false, "Parameter 'object' is null."));
            DDTIsOfType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTIsOfType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTIsOfType((new Zero(), typeof(Zero)), (4, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTIsOfType((new DerivesFromZero(), typeof(Zero)), (5, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTIsOfType((new Two(), typeof(Zero)), (6, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTIsOfType((new Two(), typeof(ITwo)), (7, true, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTIsOfType((new Two(), typeof(IZero)), (8, false, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTIsOfType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfType(input.@object, input.type, _file, _method),
                expected, "Test.If.Object.IsOfType", _file, _method);

        }

        [TestMethod]
        void NotIsOfType() {

            DDTNotIsOfType((null, null), (1, false, "Parameter 'object' is null."));
            DDTNotIsOfType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTNotIsOfType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTNotIsOfType((new Zero(), typeof(Zero)), (4, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfType((new DerivesFromZero(), typeof(Zero)), (5, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfType((new Two(), typeof(Zero)), (6, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfType((new Two(), typeof(ITwo)), (7, false, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTNotIsOfType((new Two(), typeof(IZero)), (8, true, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTNotIsOfType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsOfType(input.@object, input.type, _file, _method),
                expected, "Test.IfNot.Object.IsOfType", _file, _method);

        }

        [TestMethod]
        void IsOfTypeGeneric() {

            DDTIsOfTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTIsOfTypeGeneric<Zero>(new Zero(), (2, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTIsOfTypeGeneric<Zero>(new DerivesFromZero(), (3, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTIsOfTypeGeneric<Zero>(new Two(), (4, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTIsOfTypeGeneric<ITwo>(new Two(), (5, true, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTIsOfTypeGeneric<IZero>(new Two(), (6, false, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTIsOfTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfType<{typeof(TType).Format()}>({input.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfType<TType>(input, _file, _method),
                expected, "Test.If.Object.IsOfType", _file, _method);

        }

        [TestMethod]
        void NotIsOfTypeGeneric() {

            DDTNotIsOfTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTNotIsOfTypeGeneric<Zero>(new Zero(), (2, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfTypeGeneric<Zero>(new DerivesFromZero(), (3, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfTypeGeneric<Zero>(new Two(), (4, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfTypeGeneric<ITwo>(new Two(), (5, false, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTNotIsOfTypeGeneric<IZero>(new Two(), (6, true, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTNotIsOfTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfType<{typeof(TType).Format()}>({input.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsOfType<TType>(input, _file, _method),
                expected, "Test.IfNot.Object.IsOfType", _file, _method);

        }

        #endregion

        #region IsOfExactType

        [TestMethod]
        void IsOfExactType() {

            DDTIsOfExactType((null, null), (1, false, "Parameter 'object' is null."));
            DDTIsOfExactType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTIsOfExactType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTIsOfExactType((new Zero(), typeof(Zero)), (4, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTIsOfExactType((new DerivesFromZero(), typeof(Zero)), (5, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTIsOfExactType((new Two(), typeof(Zero)), (6, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTIsOfExactType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfExactType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfExactType(input.@object, input.type, _file, _method),
                expected, "Test.If.Object.IsOfExactType", _file, _method);

        }

        [TestMethod]
        void NotIsOfExactType() {

            DDTNotIsOfExactType((null, null), (1, false, "Parameter 'object' is null."));
            DDTNotIsOfExactType((null, typeof(Zero)), (2, false, "Parameter 'object' is null."));
            DDTNotIsOfExactType((new Zero(), null), (3, false, "Parameter 'type' is null."));
            DDTNotIsOfExactType((new Zero(), typeof(Zero)), (4, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfExactType((new DerivesFromZero(), typeof(Zero)), (5, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfExactType((new Two(), typeof(Zero)), (6, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTNotIsOfExactType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfExactType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsOfExactType(input.@object, input.type, _file, _method),
                expected, "Test.IfNot.Object.IsOfExactType", _file, _method);

        }

        [TestMethod]
        void IsOfExactTypeGeneric() {

            DDTIsOfExactTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTIsOfExactTypeGeneric<Zero>(new Zero(), (2, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTIsOfExactTypeGeneric<Zero>(new DerivesFromZero(), (3, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTIsOfExactTypeGeneric<Zero>(new Two(), (4, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTIsOfExactTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfExactType<{typeof(TType).Format()}>({input.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfExactType<TType>(input, _file, _method),
                expected, "Test.If.Object.IsOfExactType", _file, _method);

        }

        [TestMethod]
        void NotIsOfExactTypeGeneric() {

            DDTNotIsOfExactTypeGeneric<Zero>(null, (1, false, "Parameter 'object' is null."));
            DDTNotIsOfExactTypeGeneric<Zero>(new Zero(), (2, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfExactTypeGeneric<Zero>(new DerivesFromZero(), (3, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfExactTypeGeneric<Zero>(new Two(), (4, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTNotIsOfExactTypeGeneric<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfExactType<{typeof(TType).Format()}>({input.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsOfExactType<TType>(input, _file, _method),
                expected, "Test.IfNot.Object.IsOfExactType", _file, _method);

        }

        #endregion

    }
}
