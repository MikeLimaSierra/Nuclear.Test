using System;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class ValueTestSuit_uTests {

        #region IsTrue

        [TestMethod]
        void TestTrue() {

            DDTestTrue(true, (1, true, "[Value = 'True']"));
            DDTestTrue(false, (2, false, "[Value = 'False']"));

        }

        void DDTestTrue(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsTrue({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsTrue(input, _file, _method),
                expected, "Test.If.Value.IsTrue", _file, _method);

        }

        [TestMethod]
        void TestNotTrue() {

            DDTestNotTrue(true, (1, false, "[Value = 'True']"));
            DDTestNotTrue(false, (2, true, "[Value = 'False']"));

        }

        void DDTestNotTrue(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsTrue({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsTrue(input, _file, _method),
                expected, "Test.IfNot.Value.IsTrue", _file, _method);

        }

        [TestMethod]
        void TestTrueNullable() {

            DDTestTrueNullable(true, (1, true, "[Value = 'True']"));
            DDTestTrueNullable(false, (2, false, "[Value = 'False']"));
            DDTestTrueNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTestTrueNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsTrue({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsTrue(input, _file, _method),
                expected, "Test.If.Value.IsTrue", _file, _method);

        }

        [TestMethod]
        void TestNotTrueNullable() {

            DDTestNotTrueNullable(true, (1, false, "[Value = 'True']"));
            DDTestNotTrueNullable(false, (2, true, "[Value = 'False']"));
            DDTestNotTrueNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTestNotTrueNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsTrue({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsTrue(input, _file, _method),
                expected, "Test.IfNot.Value.IsTrue", _file, _method);

        }

        #endregion

        #region IsFalse

        [TestMethod]
        void TestFalse() {

            DDTestFalse(true, (1, false, "[Value = 'True']"));
            DDTestFalse(false, (2, true, "[Value = 'False']"));

        }

        void DDTestFalse(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsFalse({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsFalse(input, _file, _method),
                expected, "Test.If.Value.IsFalse", _file, _method);

        }

        [TestMethod]
        void TestNotFalse() {

            DDTestNotFalse(true, (1, true, "[Value = 'True']"));
            DDTestNotFalse(false, (2, false, "[Value = 'False']"));

        }

        void DDTestNotFalse(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsFalse({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsFalse(input, _file, _method),
                expected, "Test.IfNot.Value.IsFalse", _file, _method);

        }

        [TestMethod]
        void TestFalseNullable() {

            DDTestFalseNullable(true, (1, false, "[Value = 'True']"));
            DDTestFalseNullable(false, (2, true, "[Value = 'False']"));
            DDTestFalseNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTestFalseNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsFalse({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsFalse(input, _file, _method),
                expected, "Test.If.Value.IsFalse", _file, _method);

        }

        [TestMethod]
        void TestNotFalseNullable() {

            DDTestNotFalseNullable(true, (1, true, "[Value = 'True']"));
            DDTestNotFalseNullable(false, (2, false, "[Value = 'False']"));
            DDTestNotFalseNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTestNotFalseNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsFalse({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsFalse(input, _file, _method),
                expected, "Test.IfNot.Value.IsFalse", _file, _method);

        }

        #endregion

        #region IsClamped

        [TestMethod]
        void TestIsClamped() {

            DDTestIsClamped<Comparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTestIsClamped((null, new Comparable(0), new Comparable(0)), (2, false, "Parameter 'value' is null."));
            DDTestIsClamped((new Comparable(0), null, new Comparable(0)), (3, true, "[Value = '0'; Min = null; Max = '0']"));
            DDTestIsClamped((new Comparable(0), new Comparable(0), null), (4, true, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestIsClamped((new Comparable(0), new Comparable(0), new Comparable(0)), (5, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestIsClamped((new Comparable(0), new Comparable(-1), new Comparable(1)), (6, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestIsClamped((new Comparable(0), new Comparable(1), new Comparable(-1)), (7, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestIsClamped((new Comparable(0), new Comparable(0), new Comparable(1)), (8, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestIsClamped((new Comparable(0), new Comparable(-1), new Comparable(0)), (9, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestIsClamped((new Comparable(0), new Comparable(1), new Comparable(2)), (10, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestIsClamped((new Comparable(0), new Comparable(-2), new Comparable(-1)), (11, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTestIsClampedT<ComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTestIsClampedT((null, new ComparableT(0), new ComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTestIsClampedT((new ComparableT(0), null, new ComparableT(0)), (14, true, "[Value = '0'; Min = null; Max = '0']"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(0), null), (15, true, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(0), new ComparableT(0)), (16, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(-1), new ComparableT(1)), (17, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(1), new ComparableT(-1)), (18, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(0), new ComparableT(1)), (19, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(-1), new ComparableT(0)), (20, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(1), new ComparableT(2)), (21, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestIsClampedT((new ComparableT(0), new ComparableT(-2), new ComparableT(-1)), (22, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTestIsClamped<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note($"Test.If.Value.IsClamped({input.value.Print()}, {input.min.Print()}, {input.max.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsClamped(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClamped", _file, _method);

        }

        void DDTestIsClampedT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note($"Test.If.Value.IsClampedT({input.value.Print()}, {input.min.Print()}, {input.max.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsClampedT(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedT", _file, _method);

        }

        [TestMethod]
        void TestNotIsClamped() {

            DDTestNotIsClamped<Comparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTestNotIsClamped((null, new Comparable(0), new Comparable(0)), (2, false, "Parameter 'value' is null."));
            DDTestNotIsClamped((new Comparable(0), null, new Comparable(0)), (3, false, "[Value = '0'; Min = null; Max = '0']"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(0), null), (4, false, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(0), new Comparable(0)), (5, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(-1), new Comparable(1)), (6, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(1), new Comparable(-1)), (7, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(0), new Comparable(1)), (8, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(-1), new Comparable(0)), (9, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(1), new Comparable(2)), (10, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestNotIsClamped((new Comparable(0), new Comparable(-2), new Comparable(-1)), (11, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTestNotIsClampedT<ComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTestNotIsClampedT((null, new ComparableT(0), new ComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTestNotIsClampedT((new ComparableT(0), null, new ComparableT(0)), (14, false, "[Value = '0'; Min = null; Max = '0']"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(0), null), (15, false, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(0), new ComparableT(0)), (16, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(-1), new ComparableT(1)), (17, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(1), new ComparableT(-1)), (18, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(0), new ComparableT(1)), (19, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(-1), new ComparableT(0)), (20, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(1), new ComparableT(2)), (21, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestNotIsClampedT((new ComparableT(0), new ComparableT(-2), new ComparableT(-1)), (22, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTestNotIsClamped<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note($"Test.IfNot.Value.IsClamped({input.value.Print()}, {input.min.Print()}, {input.max.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsClamped(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClamped", _file, _method);

        }

        void DDTestNotIsClampedT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note($"Test.IfNot.Value.IsClampedT({input.value.Print()}, {input.min.Print()}, {input.max.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsClampedT(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedT", _file, _method);

        }



        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void TestIsClampedExclusive() {

            DDTestIsClampedExclusive<Comparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTestIsClampedExclusive((null, new Comparable(0), new Comparable(0)), (2, false, "Parameter 'value' is null."));
            DDTestIsClampedExclusive((new Comparable(0), null, new Comparable(0)), (3, false, "[Value = '0'; Min = null; Max = '0']"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(0), null), (4, false, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(0), new Comparable(0)), (5, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(-1), new Comparable(1)), (6, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(1), new Comparable(-1)), (7, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(0), new Comparable(1)), (8, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(-1), new Comparable(0)), (9, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(1), new Comparable(2)), (10, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestIsClampedExclusive((new Comparable(0), new Comparable(-2), new Comparable(-1)), (11, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTestIsClampedExclusiveT<ComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTestIsClampedExclusiveT((null, new ComparableT(0), new ComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTestIsClampedExclusiveT((new ComparableT(0), null, new ComparableT(0)), (14, false, "[Value = '0'; Min = null; Max = '0']"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(0), null), (15, false, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(0), new ComparableT(0)), (16, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(-1), new ComparableT(1)), (17, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(1), new ComparableT(-1)), (18, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(0), new ComparableT(1)), (19, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(-1), new ComparableT(0)), (20, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(1), new ComparableT(2)), (21, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestIsClampedExclusiveT((new ComparableT(0), new ComparableT(-2), new ComparableT(-1)), (22, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTestIsClampedExclusive<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note(String.Format("Test.If.Value.IsClampedExclusive({0}, {1}, {2})", input.value.Print(), input.min.Print(), input.max.Print()),
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsClampedExclusive(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedExclusive", _file, _method);

        }

        void DDTestIsClampedExclusiveT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note(String.Format("Test.If.Value.IsClampedExclusiveT({0}, {1}, {2})", input.value.Print(), input.min.Print(), input.max.Print()),
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Value.IsClampedExclusiveT(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedExclusiveT", _file, _method);

        }

        [TestMethod]
        void TestNotIsClampedExclusive() {

            DDTestNotIsClampedExclusive<Comparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTestNotIsClampedExclusive((null, new Comparable(0), new Comparable(0)), (2, false, "Parameter 'value' is null."));
            DDTestNotIsClampedExclusive((new Comparable(0), null, new Comparable(0)), (3, true, "[Value = '0'; Min = null; Max = '0']"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(0), null), (4, true, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(0), new Comparable(0)), (5, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(-1), new Comparable(1)), (6, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(1), new Comparable(-1)), (7, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(0), new Comparable(1)), (8, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(-1), new Comparable(0)), (9, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(1), new Comparable(2)), (10, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestNotIsClampedExclusive((new Comparable(0), new Comparable(-2), new Comparable(-1)), (11, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTestNotIsClampedExclusiveT<ComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTestNotIsClampedExclusiveT((null, new ComparableT(0), new ComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), null, new ComparableT(0)), (14, true, "[Value = '0'; Min = null; Max = '0']"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(0), null), (15, true, "[Value = '0'; Min = '0'; Max = null]"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(0), new ComparableT(0)), (16, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(-1), new ComparableT(1)), (17, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(1), new ComparableT(-1)), (18, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(0), new ComparableT(1)), (19, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(-1), new ComparableT(0)), (20, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(1), new ComparableT(2)), (21, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTestNotIsClampedExclusiveT((new ComparableT(0), new ComparableT(-2), new ComparableT(-1)), (22, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTestNotIsClampedExclusive<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note(String.Format("Test.IfNot.Value.IsClampedExclusive({0}, {1}, {2})", input.value.Print(), input.min.Print(), input.max.Print()),
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsClampedExclusive(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusive", _file, _method);

        }

        void DDTestNotIsClampedExclusiveT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note(String.Format("Test.IfNot.Value.IsClampedExclusiveT({0}, {1}, {2})", input.value.Print(), input.min.Print(), input.max.Print()),
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Value.IsClampedExclusiveT(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusiveT", _file, _method);

        }

        #endregion

    }
}
