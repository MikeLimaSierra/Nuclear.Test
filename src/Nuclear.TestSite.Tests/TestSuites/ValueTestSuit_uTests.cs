using Ntt;
using Nuclear.Extensions;
using Nuclear.TestSite.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nuclear.TestSite.TestSuites {
    class ValueTestSuit_uTests {

        #region EqualT

        [TestMethod]
        void EqualIEquatableT() {

            DDTEqualT<DummyIEquatableT>((null, null), (1, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualT((null, new DummyIEquatableT(0)), (2, false, "('GenericEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualT((new DummyIEquatableT(0), null), (3, false, "('GenericEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualT((new DummyIEquatableT(5), new DummyIEquatableT(0)), (4, false, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '0']"));
            DDTEqualT((new DummyIEquatableT(5), new DummyIEquatableT(5)), (5, true, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '5']"));

            DDTEqualT<DummyIComparableT>((null, null), (6, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualT((null, new DummyIComparableT(0)), (7, false, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualT((new DummyIComparableT(0), null), (8, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualT((new DummyIComparableT(5), new DummyIComparableT(0)), (9, false, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '0']"));
            DDTEqualT((new DummyIComparableT(5), new DummyIComparableT(5)), (10, true, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '5']"));

            DDTEqualT<DummyIComparable>((null, null), (11, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualT((null, new DummyIComparable(0)), (12, false, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualT((new DummyIComparable(0), null), (13, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualT((new DummyIComparable(5), new DummyIComparable(0)), (14, false, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '0']"));
            DDTEqualT((new DummyIComparable(5), new DummyIComparable(5)), (15, true, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '5']"));

            DDTEqualT<Dummy>((null, null), (16, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualT((null, new Dummy(0)), (17, false, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualT((new Dummy(0), null), (18, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualT((new Dummy(5), new Dummy(0)), (19, false, "('ObjectEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTEqualT((new Dummy(5), new Dummy(5)), (20, false, "('ObjectEqualityComparer`1') [Left = '5'; Right = '5']"));

        }

        void DDTEqualT<TType>((TType left, TType right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals<{typeof(TType).Format()}>({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        [TestMethod]
        void NotEqualIEquatableT() {

            DDTNotEqualT<DummyIEquatableT>((null, null), (1, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualT((null, new DummyIEquatableT(0)), (2, true, "('GenericEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualT((new DummyIEquatableT(0), null), (3, true, "('GenericEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualT((new DummyIEquatableT(5), new DummyIEquatableT(0)), (4, true, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '0']"));
            DDTNotEqualT((new DummyIEquatableT(5), new DummyIEquatableT(5)), (5, false, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '5']"));

            DDTNotEqualT<DummyIComparableT>((null, null), (6, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualT((null, new DummyIComparableT(0)), (7, true, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualT((new DummyIComparableT(0), null), (8, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualT((new DummyIComparableT(5), new DummyIComparableT(0)), (9, true, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '0']"));
            DDTNotEqualT((new DummyIComparableT(5), new DummyIComparableT(5)), (10, false, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '5']"));

            DDTNotEqualT<DummyIComparable>((null, null), (11, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualT((null, new DummyIComparable(0)), (12, true, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualT((new DummyIComparable(0), null), (13, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualT((new DummyIComparable(5), new DummyIComparable(0)), (14, true, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '0']"));
            DDTNotEqualT((new DummyIComparable(5), new DummyIComparable(5)), (15, false, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '5']"));

            DDTNotEqualT<Dummy>((null, null), (16, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualT((null, new Dummy(0)), (17, true, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualT((new Dummy(0), null), (18, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualT((new Dummy(5), new Dummy(0)), (19, true, "('ObjectEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTNotEqualT((new Dummy(5), new Dummy(5)), (20, true, "('ObjectEqualityComparer`1') [Left = '5'; Right = '5']"));

        }

        void DDTNotEqualT<TType>((TType left, TType right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals<{typeof(TType).Format()}>({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        #endregion

        #region EqualTEqualityComparerT

        [TestMethod]
        void EqualEqualityComparerT() {

            DDTEqualEqualityComparerT<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTEqualEqualityComparerT((null, new Dummy(0), new DummyEqualityComparerT()), (2, false, "('DummyEqualityComparerT') [Left = 'null'; Right = '0']"));
            DDTEqualEqualityComparerT((new Dummy(0), null, new DummyEqualityComparerT()), (3, false, "('DummyEqualityComparerT') [Left = '0'; Right = 'null']"));
            DDTEqualEqualityComparerT((new Dummy(0), new Dummy(0), null), (4, false, "Parameter 'comparer' is null."));
            DDTEqualEqualityComparerT((new Dummy(5), new Dummy(0), new DummyEqualityComparerT()), (5, false, "('DummyEqualityComparerT') [Left = '5'; Right = '0']"));
            DDTEqualEqualityComparerT((new Dummy(5), new Dummy(5), new DummyEqualityComparerT()), (6, true, "('DummyEqualityComparerT') [Left = '5'; Right = '5']"));
            DDTEqualEqualityComparerT((new Dummy(5), new Dummy(5), new ThrowExceptionComparerT<Dummy>()), (7, false, "Comparison threw Exception:"));

        }

        void DDTEqualEqualityComparerT<TType>((TType left, TType right, IEqualityComparer<TType> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals<{typeof(TType).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        [TestMethod]
        void NotEqualEqualityComparerT() {

            DDTNotEqualEqualityComparerT<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTNotEqualEqualityComparerT((null, new Dummy(0), new DummyEqualityComparerT()), (2, true, "('DummyEqualityComparerT') [Left = 'null'; Right = '0']"));
            DDTNotEqualEqualityComparerT((new Dummy(0), null, new DummyEqualityComparerT()), (3, true, "('DummyEqualityComparerT') [Left = '0'; Right = 'null']"));
            DDTNotEqualEqualityComparerT((new Dummy(0), new Dummy(0), null), (4, false, "Parameter 'comparer' is null."));
            DDTNotEqualEqualityComparerT((new Dummy(5), new Dummy(0), new DummyEqualityComparerT()), (5, true, "('DummyEqualityComparerT') [Left = '5'; Right = '0']"));
            DDTNotEqualEqualityComparerT((new Dummy(5), new Dummy(5), new DummyEqualityComparerT()), (6, false, "('DummyEqualityComparerT') [Left = '5'; Right = '5']"));
            DDTNotEqualEqualityComparerT((new Dummy(5), new Dummy(5), new ThrowExceptionComparerT<Dummy>()), (7, false, "Comparison threw Exception:"));

        }

        void DDTNotEqualEqualityComparerT<TType>((TType left, TType right, IEqualityComparer<TType> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals<{typeof(TType).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        #endregion

        #region single

        [TestMethod]
        void EqualSingle() {

            DDTEqualSingle((1f, 0f), (1, false, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTEqualSingle((1f, 1f), (2, true, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTEqualSingle((1e-11f, 1.1e-11f), (3, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTEqualSingle((1e-12f, 1.1e-12f), (4, true, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTEqualSingle((1e-11f, 1.1e-11f, 1e-11f), (5, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTEqualSingle((Single left, Single right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        void DDTEqualSingle((Single left, Single right, Single margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals({input.left.Format()}, {input.right.Format()}, {input.margin.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, input.margin, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        [TestMethod]
        void NotEqualSingle() {

            DDTNotEqualSingle((1f, 0f), (1, true, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTNotEqualSingle((1f, 1f), (2, false, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTNotEqualSingle((1e-11f, 1.1e-11f), (3, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTNotEqualSingle((1e-12f, 1.1e-12f), (4, false, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTNotEqualSingle((1e-11f, 1.1e-11f, 1e-11f), (5, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTNotEqualSingle((Single left, Single right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        void DDTNotEqualSingle((Single left, Single right, Single margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals({input.left.Format()}, {input.right.Format()}, {input.margin.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, input.margin, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        #endregion

        #region double

        [TestMethod]
        void EqualDouble() {

            DDTEqualDouble((1d, 0d), (1, false, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTEqualDouble((1d, 1d), (2, true, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTEqualDouble((1e-11d, 1.1e-11d), (3, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTEqualDouble((1e-12d, 1.1e-12d), (4, true, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTEqualDouble((1e-11d, 1.1e-11d, 1e-11d), (5, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTEqualDouble((Double left, Double right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        void DDTEqualDouble((Double left, Double right, Double margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals({input.left.Format()}, {input.right.Format()}, {input.margin.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, input.margin, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        [TestMethod]
        void NotEqualDouble() {

            DDTNotEqualDouble((1d, 0d), (1, true, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTNotEqualDouble((1d, 1d), (2, false, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTNotEqualDouble((1e-11d, 1.1e-11d), (3, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTNotEqualDouble((1e-12d, 1.1e-12d), (4, false, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTNotEqualDouble((1e-11d, 1.1e-11d, 1e-11d), (5, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTNotEqualDouble((Double left, Double right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        void DDTNotEqualDouble((Double left, Double right, Double margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals({input.left.Format()}, {input.right.Format()}, {input.margin.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, input.margin, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        #endregion

        #region IsTrue

        [TestMethod]
        void True() {

            DDTTrue(true, (1, true, "[Value = 'True']"));
            DDTTrue(false, (2, false, "[Value = 'False']"));

        }

        void DDTTrue(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsTrue({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsTrue(input, _file, _method),
                expected, "Test.If.Value.IsTrue", _file, _method);

        }

        [TestMethod]
        void NotTrue() {

            DDTNotTrue(true, (1, false, "[Value = 'True']"));
            DDTNotTrue(false, (2, true, "[Value = 'False']"));

        }

        void DDTNotTrue(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsTrue({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsTrue(input, _file, _method),
                expected, "Test.IfNot.Value.IsTrue", _file, _method);

        }

        [TestMethod]
        void TrueNullable() {

            DDTTrueNullable(true, (1, true, "[Value = 'True']"));
            DDTTrueNullable(false, (2, false, "[Value = 'False']"));
            DDTTrueNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTTrueNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsTrue({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsTrue(input, _file, _method),
                expected, "Test.If.Value.IsTrue", _file, _method);

        }

        [TestMethod]
        void NotTrueNullable() {

            DDTNotTrueNullable(true, (1, false, "[Value = 'True']"));
            DDTNotTrueNullable(false, (2, true, "[Value = 'False']"));
            DDTNotTrueNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTNotTrueNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsTrue({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsTrue(input, _file, _method),
                expected, "Test.IfNot.Value.IsTrue", _file, _method);

        }

        #endregion

        #region IsFalse

        [TestMethod]
        void False() {

            DDTFalse(true, (1, false, "[Value = 'True']"));
            DDTFalse(false, (2, true, "[Value = 'False']"));

        }

        void DDTFalse(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsFalse({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsFalse(input, _file, _method),
                expected, "Test.If.Value.IsFalse", _file, _method);

        }

        [TestMethod]
        void NotFalse() {

            DDTNotFalse(true, (1, true, "[Value = 'True']"));
            DDTNotFalse(false, (2, false, "[Value = 'False']"));

        }

        void DDTNotFalse(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsFalse({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsFalse(input, _file, _method),
                expected, "Test.IfNot.Value.IsFalse", _file, _method);

        }

        [TestMethod]
        void FalseNullable() {

            DDTFalseNullable(true, (1, false, "[Value = 'True']"));
            DDTFalseNullable(false, (2, true, "[Value = 'False']"));
            DDTFalseNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTFalseNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsFalse({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsFalse(input, _file, _method),
                expected, "Test.If.Value.IsFalse", _file, _method);

        }

        [TestMethod]
        void NotFalseNullable() {

            DDTNotFalseNullable(true, (1, true, "[Value = 'True']"));
            DDTNotFalseNullable(false, (2, false, "[Value = 'False']"));
            DDTNotFalseNullable(null, (3, false, "Parameter 'value' is null."));

        }

        void DDTNotFalseNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsFalse({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsFalse(input, _file, _method),
                expected, "Test.IfNot.Value.IsFalse", _file, _method);

        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClamped() {

            DDTIsClamped<DummyIComparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTIsClamped((null, new DummyIComparable(0), new DummyIComparable(0)), (2, false, "Parameter 'value' is null."));
            DDTIsClamped((new DummyIComparable(0), null, new DummyIComparable(0)), (3, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(0), null), (4, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(0)), (5, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(1)), (6, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(-1)), (7, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(1)), (8, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(0)), (9, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(2)), (10, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClamped((new DummyIComparable(0), new DummyIComparable(-2), new DummyIComparable(-1)), (11, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTIsClampedT((null, new DummyIComparableT(0), new DummyIComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTIsClampedT((new DummyIComparableT(0), null, new DummyIComparableT(0)), (14, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(0), null), (15, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(0)), (16, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(1)), (17, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(-1)), (18, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(1)), (19, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(0)), (20, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(2)), (21, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedT((new DummyIComparableT(0), new DummyIComparableT(-2), new DummyIComparableT(-1)), (22, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTIsClamped<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note($"Test.If.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClamped(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClamped", _file, _method);

        }

        void DDTIsClampedT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note($"Test.If.Value.IsClampedT({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedT(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedT", _file, _method);

        }

        [TestMethod]
        void NotIsClamped() {

            DDTNotIsClamped<DummyIComparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTNotIsClamped((null, new DummyIComparable(0), new DummyIComparable(0)), (2, false, "Parameter 'value' is null."));
            DDTNotIsClamped((new DummyIComparable(0), null, new DummyIComparable(0)), (3, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(0), null), (4, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(0)), (5, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(1)), (6, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(-1)), (7, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(1)), (8, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(0)), (9, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(2)), (10, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClamped((new DummyIComparable(0), new DummyIComparable(-2), new DummyIComparable(-1)), (11, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTNotIsClampedT((null, new DummyIComparableT(0), new DummyIComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTNotIsClampedT((new DummyIComparableT(0), null, new DummyIComparableT(0)), (14, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(0), null), (15, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(0)), (16, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(1)), (17, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(-1)), (18, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(1)), (19, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(0)), (20, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(2)), (21, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedT((new DummyIComparableT(0), new DummyIComparableT(-2), new DummyIComparableT(-1)), (22, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTNotIsClamped<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note($"Test.IfNot.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClamped(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClamped", _file, _method);

        }

        void DDTNotIsClampedT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note($"Test.IfNot.Value.IsClampedT({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedT(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedT", _file, _method);

        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusive() {

            DDTIsClampedExclusive<DummyIComparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTIsClampedExclusive((null, new DummyIComparable(0), new DummyIComparable(0)), (2, false, "Parameter 'value' is null."));
            DDTIsClampedExclusive((new DummyIComparable(0), null, new DummyIComparable(0)), (3, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(0), null), (4, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(0)), (5, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(1)), (6, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(-1)), (7, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(1)), (8, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(0)), (9, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(2)), (10, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(-2), new DummyIComparable(-1)), (11, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedExclusiveT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveT((null, new DummyIComparableT(0), new DummyIComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), null, new DummyIComparableT(0)), (14, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(0), null), (15, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(0)), (16, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(1)), (17, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(-1)), (18, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(1)), (19, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(0)), (20, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(2)), (21, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(-2), new DummyIComparableT(-1)), (22, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTIsClampedExclusive<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note(String.Format("Test.If.Value.IsClampedExclusive({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedExclusive(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedExclusive", _file, _method);

        }

        void DDTIsClampedExclusiveT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note(String.Format("Test.If.Value.IsClampedExclusiveT({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedExclusiveT(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedExclusiveT", _file, _method);

        }

        [TestMethod]
        void NotIsClampedExclusive() {

            DDTNotIsClampedExclusive<DummyIComparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusive((null, new DummyIComparable(0), new DummyIComparable(0)), (2, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusive((new DummyIComparable(0), null, new DummyIComparable(0)), (3, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(0), null), (4, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(0)), (5, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(1)), (6, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(-1)), (7, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(0), new DummyIComparable(1)), (8, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(-1), new DummyIComparable(0)), (9, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(1), new DummyIComparable(2)), (10, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedExclusive((new DummyIComparable(0), new DummyIComparable(-2), new DummyIComparable(-1)), (11, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedExclusiveT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveT((null, new DummyIComparableT(0), new DummyIComparableT(0)), (13, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), null, new DummyIComparableT(0)), (14, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(0), null), (15, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(0)), (16, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(1)), (17, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(-1)), (18, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(0), new DummyIComparableT(1)), (19, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(-1), new DummyIComparableT(0)), (20, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(1), new DummyIComparableT(2)), (21, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedExclusiveT((new DummyIComparableT(0), new DummyIComparableT(-2), new DummyIComparableT(-1)), (22, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTNotIsClampedExclusive<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable {

            Test.Note(String.Format("Test.IfNot.Value.IsClampedExclusive({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedExclusive(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusive", _file, _method);

        }

        void DDTNotIsClampedExclusiveT<TType>((TType value, TType min, TType max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TType : IComparable<TType> {

            Test.Note(String.Format("Test.IfNot.Value.IsClampedExclusiveT({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedExclusiveT(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusiveT", _file, _method);

        }

        #endregion

    }
}
