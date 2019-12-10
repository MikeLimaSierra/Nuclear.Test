using System;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.Extensions;

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

            DDTIsOfType<Zero>(null, (9, false, "Parameter 'object' is null."));
            DDTIsOfType<Zero>(new Zero(), (10, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTIsOfType<Zero>(new DerivesFromZero(), (11, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTIsOfType<Zero>(new Two(), (12, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTIsOfType<ITwo>(new Two(), (13, true, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTIsOfType<IZero>(new Two(), (14, false, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTIsOfType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfType(input.@object, input.type, _file, _method),
                expected, "Test.If.Object.IsOfType", _file, _method);

        }

        void DDTIsOfType<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfType<{typeof(TType).Format()}>({input.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfType<TType>(input, _file, _method),
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

            DDTNotIsOfType<Zero>(null, (9, false, "Parameter 'object' is null."));
            DDTNotIsOfType<Zero>(new Zero(), (10, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfType<Zero>(new DerivesFromZero(), (11, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfType<Zero>(new Two(), (12, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfType<ITwo>(new Two(), (13, false, "Object is 'Ntt.Two'. Given type is 'Ntt.ITwo'."));
            DDTNotIsOfType<IZero>(new Two(), (14, true, "Object is 'Ntt.Two'. Given type is 'Ntt.IZero'."));

        }

        void DDTNotIsOfType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsOfType(input.@object, input.type, _file, _method),
                expected, "Test.IfNot.Object.IsOfType", _file, _method);

        }

        void DDTNotIsOfType<TType>(Object input, (Int32 count, Boolean result, String message) expected,
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

            DDTIsOfExactType<Zero>(null, (7, false, "Parameter 'object' is null."));
            DDTIsOfExactType<Zero>(new Zero(), (8, true, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTIsOfExactType<Zero>(new DerivesFromZero(), (9, false, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTIsOfExactType<Zero>(new Two(), (10, false, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTIsOfExactType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfExactType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfExactType(input.@object, input.type, _file, _method),
                expected, "Test.If.Object.IsOfExactType", _file, _method);

        }

        void DDTIsOfExactType<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Object.IsOfExactType<{typeof(TType).Format()}>({input.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Object.IsOfExactType<TType>(input, _file, _method),
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

            DDTNotIsOfExactType<Zero>(null, (7, false, "Parameter 'object' is null."));
            DDTNotIsOfExactType<Zero>(new Zero(), (8, false, "Object is 'Ntt.Zero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfExactType<Zero>(new DerivesFromZero(), (9, true, "Object is 'Ntt.DerivesFromZero'. Given type is 'Ntt.Zero'."));
            DDTNotIsOfExactType<Zero>(new Two(), (10, true, "Object is 'Ntt.Two'. Given type is 'Ntt.Zero'."));

        }

        void DDTNotIsOfExactType((Object @object, Type type) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfExactType({input.@object.FormatType()}, {input.type.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsOfExactType(input.@object, input.type, _file, _method),
                expected, "Test.IfNot.Object.IsOfExactType", _file, _method);

        }

        void DDTNotIsOfExactType<TType>(Object input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Object.IsOfExactType<{typeof(TType).Format()}>({input.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Object.IsOfExactType<TType>(input, _file, _method),
                expected, "Test.IfNot.Object.IsOfExactType", _file, _method);

        }

        #endregion

    }
}
