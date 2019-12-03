using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    class ValueTestSuit_uTests {

        #region Equals

        [TestMethod]
        void Equals() {

            DDTEqualsT<DummyIEquatableT>((null, null), (1, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualsT((null, new DummyIEquatableT(0)), (2, false, "('GenericEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualsT((new DummyIEquatableT(0), null), (3, false, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '0'; Right = 'null']"));
            DDTEqualsT((new DummyIEquatableT(5), new DummyIEquatableT(0)), (4, false, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '0']"));
            DDTEqualsT((new DummyIEquatableT(5), new DummyIEquatableT(5)), (5, true, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '5']"));

            DDTEqualsT<DummyIComparableT>((null, null), (6, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualsT((null, new DummyIComparableT(0)), (7, false, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualsT((new DummyIComparableT(0), null), (8, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualsT((new DummyIComparableT(5), new DummyIComparableT(0)), (9, false, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '0']"));
            DDTEqualsT((new DummyIComparableT(5), new DummyIComparableT(5)), (10, true, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '5']"));

            DDTEqualsT<DummyIComparable>((null, null), (11, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualsT((null, new DummyIComparable(0)), (12, false, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualsT((new DummyIComparable(0), null), (13, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualsT((new DummyIComparable(5), new DummyIComparable(0)), (14, false, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '0']"));
            DDTEqualsT((new DummyIComparable(5), new DummyIComparable(5)), (15, true, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '5']"));

            DDTEqualsT<Dummy>((null, null), (16, true, "[Left = 'null'; Right = 'null']"));
            DDTEqualsT((null, new Dummy(0)), (17, false, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualsT((new Dummy(0), null), (18, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualsT((new Dummy(5), new Dummy(0)), (19, false, "('ObjectEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTEqualsT((new Dummy(5), new Dummy(5)), (20, false, "('ObjectEqualityComparer`1') [Left = '5'; Right = '5']"));

        }

        void DDTEqualsT<T>((T left, T right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        [TestMethod]
        void NotEquals() {

            DDTNotEqualsT<DummyIEquatableT>((null, null), (1, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualsT((null, new DummyIEquatableT(0)), (2, true, "('GenericEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualsT((new DummyIEquatableT(0), null), (3, true, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '0'; Right = 'null']"));
            DDTNotEqualsT((new DummyIEquatableT(5), new DummyIEquatableT(0)), (4, true, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '0']"));
            DDTNotEqualsT((new DummyIEquatableT(5), new DummyIEquatableT(5)), (5, false, "('Ntt.DummyIEquatableT'.IEquatable<T>) [Left = '5'; Right = '5']"));

            DDTNotEqualsT<DummyIComparableT>((null, null), (6, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualsT((null, new DummyIComparableT(0)), (7, true, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualsT((new DummyIComparableT(0), null), (8, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualsT((new DummyIComparableT(5), new DummyIComparableT(0)), (9, true, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '0']"));
            DDTNotEqualsT((new DummyIComparableT(5), new DummyIComparableT(5)), (10, false, "('Ntt.DummyIComparableT'.IComparable<T>) [Left = '5'; Right = '5']"));

            DDTNotEqualsT<DummyIComparable>((null, null), (11, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualsT((null, new DummyIComparable(0)), (12, true, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualsT((new DummyIComparable(0), null), (13, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualsT((new DummyIComparable(5), new DummyIComparable(0)), (14, true, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '0']"));
            DDTNotEqualsT((new DummyIComparable(5), new DummyIComparable(5)), (15, false, "('Ntt.DummyIComparable'.IComparable) [Left = '5'; Right = '5']"));

            DDTNotEqualsT<Dummy>((null, null), (16, false, "[Left = 'null'; Right = 'null']"));
            DDTNotEqualsT((null, new Dummy(0)), (17, true, "('ObjectEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualsT((new Dummy(0), null), (18, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualsT((new Dummy(5), new Dummy(0)), (19, true, "('ObjectEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTNotEqualsT((new Dummy(5), new Dummy(5)), (20, true, "('ObjectEqualityComparer`1') [Left = '5'; Right = '5']"));

        }

        void DDTNotEqualsT<T>((T left, T right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        #endregion

        #region EqualsComparer

        [TestMethod]
        void EqualsComparer() {

            DDTEqualsComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTEqualsComparer((null, 0, new DummyEqualityComparer()), (2, false, "('DummyEqualityComparer') [Left = 'null'; Right = '0']"));
            DDTEqualsComparer((0, null, new DummyEqualityComparer()), (3, false, "('DummyEqualityComparer') [Left = '0'; Right = 'null']"));
            DDTEqualsComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTEqualsComparer<Dummy>((5, 0, new DummyEqualityComparer()), (5, false, "('DummyEqualityComparer') [Left = '5'; Right = '0']"));
            DDTEqualsComparer<Dummy>((5, 5, new DummyEqualityComparer()), (6, true, "('DummyEqualityComparer') [Left = '5'; Right = '5']"));
            DDTEqualsComparer<Dummy>((5, 5, new ThrowingEqualityComparer()), (7, false, "Comparison threw Exception:"));

            DDTEqualsComparer<Dummy>((null, null, (IEqualityComparer) null), (8, false, "Parameter 'comparer' is null."));
            DDTEqualsComparer<Dummy>((null, 0, new DummyIEqualityComparer()), (9, false, "('DynamicEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTEqualsComparer<Dummy>((0, null, new DummyIEqualityComparer()), (10, false, "('DynamicEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTEqualsComparer<Dummy>((0, 0, (IEqualityComparer) null), (11, false, "Parameter 'comparer' is null."));
            DDTEqualsComparer<Dummy>((5, 0, new DummyIEqualityComparer()), (12, false, "('DynamicEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTEqualsComparer<Dummy>((5, 5, new DummyIEqualityComparer()), (13, true, "('DynamicEqualityComparer`1') [Left = '5'; Right = '5']"));
            DDTEqualsComparer<Dummy>((5, 5, DynamicEqualityComparer.From(
                new EqualityComparison<Object>((x, y) => throw new NotImplementedException()),
                new GetHashCode<Object>((obj) => throw new NotImplementedException()))),
                (14, false, "Comparison threw Exception:"));

            DDTEqualsComparer((null, null, (IEqualityComparer<Dummy>) null), (15, false, "Parameter 'comparer' is null."));
            DDTEqualsComparer((null, 0, new DummyIEqualityComparerT()), (16, false, "('DummyIEqualityComparerT') [Left = 'null'; Right = '0']"));
            DDTEqualsComparer((0, null, new DummyIEqualityComparerT()), (17, false, "('DummyIEqualityComparerT') [Left = '0'; Right = 'null']"));
            DDTEqualsComparer((0, 0, (IEqualityComparer<Dummy>) null), (18, false, "Parameter 'comparer' is null."));
            DDTEqualsComparer((5, 0, new DummyIEqualityComparerT()), (19, false, "('DummyIEqualityComparerT') [Left = '5'; Right = '0']"));
            DDTEqualsComparer((5, 5, new DummyIEqualityComparerT()), (20, true, "('DummyIEqualityComparerT') [Left = '5'; Right = '5']"));
            DDTEqualsComparer((5, 5, DynamicEqualityComparer<Dummy>.From(
                new EqualityComparison<Dummy>((x, y) => throw new NotImplementedException()),
                new GetHashCode<Dummy>((obj) => throw new NotImplementedException()))),
                (21, false, "Comparison threw Exception:"));

        }

        void DDTEqualsComparer<T>((T left, T right, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        void DDTEqualsComparer<T>((T left, T right, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        void DDTEqualsComparer<T>((T left, T right, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.If.Value.Equals", _file, _method);

        }

        [TestMethod]
        void NotEqualsComparer() {

            DDTNotEqualsComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTNotEqualsComparer((null, 0, new DummyEqualityComparer()), (2, true, "('DummyEqualityComparer') [Left = 'null'; Right = '0']"));
            DDTNotEqualsComparer((0, null, new DummyEqualityComparer()), (3, true, "('DummyEqualityComparer') [Left = '0'; Right = 'null']"));
            DDTNotEqualsComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTNotEqualsComparer<Dummy>((5, 0, new DummyEqualityComparer()), (5, true, "('DummyEqualityComparer') [Left = '5'; Right = '0']"));
            DDTNotEqualsComparer<Dummy>((5, 5, new DummyEqualityComparer()), (6, false, "('DummyEqualityComparer') [Left = '5'; Right = '5']"));
            DDTNotEqualsComparer<Dummy>((5, 5, new ThrowingEqualityComparer()), (7, false, "Comparison threw Exception:"));

            DDTNotEqualsComparer<Dummy>((null, null, (IEqualityComparer) null), (8, false, "Parameter 'comparer' is null."));
            DDTNotEqualsComparer<Dummy>((null, 0, new DummyIEqualityComparer()), (9, true, "('DynamicEqualityComparer`1') [Left = 'null'; Right = '0']"));
            DDTNotEqualsComparer<Dummy>((0, null, new DummyIEqualityComparer()), (10, true, "('DynamicEqualityComparer`1') [Left = '0'; Right = 'null']"));
            DDTNotEqualsComparer<Dummy>((0, 0, (IEqualityComparer) null), (11, false, "Parameter 'comparer' is null."));
            DDTNotEqualsComparer<Dummy>((5, 0, new DummyIEqualityComparer()), (12, true, "('DynamicEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTNotEqualsComparer<Dummy>((5, 5, new DummyIEqualityComparer()), (13, false, "('DynamicEqualityComparer`1') [Left = '5'; Right = '5']"));
            DDTNotEqualsComparer<Dummy>((5, 5, DynamicEqualityComparer.From(
                new EqualityComparison<Object>((x, y) => throw new NotImplementedException()),
                new GetHashCode<Object>((obj) => throw new NotImplementedException()))),
                (14, false, "Comparison threw Exception:"));

            DDTNotEqualsComparer((null, null, (IEqualityComparer<Dummy>) null), (15, false, "Parameter 'comparer' is null."));
            DDTNotEqualsComparer((null, 0, new DummyIEqualityComparerT()), (16, true, "('DummyIEqualityComparerT') [Left = 'null'; Right = '0']"));
            DDTNotEqualsComparer((0, null, new DummyIEqualityComparerT()), (17, true, "('DummyIEqualityComparerT') [Left = '0'; Right = 'null']"));
            DDTNotEqualsComparer((0, 0, (IEqualityComparer<Dummy>) null), (18, false, "Parameter 'comparer' is null."));
            DDTNotEqualsComparer((5, 0, new DummyIEqualityComparerT()), (19, true, "('DummyIEqualityComparerT') [Left = '5'; Right = '0']"));
            DDTNotEqualsComparer((5, 5, new DummyIEqualityComparerT()), (20, false, "('DummyIEqualityComparerT') [Left = '5'; Right = '5']"));
            DDTNotEqualsComparer((5, 5, DynamicEqualityComparer<Dummy>.From(
                new EqualityComparison<Dummy>((x, y) => throw new NotImplementedException()),
                new GetHashCode<Dummy>((obj) => throw new NotImplementedException()))),
                (21, false, "Comparison threw Exception:"));

        }

        void DDTNotEqualsComparer<T>((T left, T right, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        void DDTNotEqualsComparer<T>((T left, T right, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        void DDTNotEqualsComparer<T>((T left, T right, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.Equals<{typeof(T).Format()}>({input.left.Format()}, {input.right.Format()}, {input.comparer.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.Equals(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.Equals", _file, _method);

        }

        #endregion

        #region EqualsSingle

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

        #region EqualsDouble

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

        #region IsLessThan

        [TestMethod]
        void IsLessThan() {

            DDTIsLessThan<DummyIComparable>((0, 0), (1, false, "[Value = '0'; Other = '0']"));
            DDTIsLessThan<DummyIComparable>((0, 1), (2, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThan<DummyIComparable>((1, 0), (3, false, "[Value = '1'; Other = '0']"));

            DDTIsLessThanT<DummyIComparableT>((0, 0), (4, false, "[Value = '0'; Other = '0']"));
            DDTIsLessThanT<DummyIComparableT>((0, 1), (5, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanT<DummyIComparableT>((1, 0), (6, false, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThan<DummyIComparable>((0, 0), (7, true, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThan<DummyIComparable>((0, 1), (8, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThan<DummyIComparable>((1, 0), (9, true, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThanT<DummyIComparableT>((0, 0), (10, true, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanT<DummyIComparableT>((0, 1), (11, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanT<DummyIComparableT>((1, 0), (12, true, "[Value = '1'; Other = '0']"));

        }

        void DDTIsLessThan<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.If.Value.IsLessThan({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThan(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsLessThan", _file, _method);

        }

        void DDTIsLessThanT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.If.Value.IsLessThanT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThanT(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsLessThan", _file, _method);

        }

        void DDTNotIsLessThan<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.IfNot.Value.IsLessThan({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThan(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsLessThan", _file, _method);

        }

        void DDTNotIsLessThanT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.IfNot.Value.IsLessThanT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThanT(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsLessThan", _file, _method);

        }

        #endregion

        #region IsLessThanComparer

        [TestMethod]
        void IsLessThanComparer() {

            DDTIsLessThanComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTIsLessThanComparer((null, 0, new DummyComparer()), (2, true, "[Value = 'null'; Other = '0']"));
            DDTIsLessThanComparer((0, null, new DummyComparer()), (3, false, "[Value = '0'; Other = 'null']"));
            DDTIsLessThanComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTIsLessThanComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTIsLessThanComparer<Dummy>((0, 0, new DummyComparer()), (6, false, "[Value = '0'; Other = '0']"));
            DDTIsLessThanComparer<Dummy>((0, 1, new DummyComparer()), (7, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanComparer<Dummy>((1, 0, new DummyComparer()), (8, false, "[Value = '1'; Other = '0']"));

            DDTIsLessThanComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTIsLessThanComparer<Dummy>((null, 0, new DummyIComparer()), (10, true, "[Value = 'null'; Other = '0']"));
            DDTIsLessThanComparer<Dummy>((0, null, new DummyIComparer()), (11, false, "[Value = '0'; Other = 'null']"));
            DDTIsLessThanComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTIsLessThanComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTIsLessThanComparer<Dummy>((0, 0, new DummyIComparer()), (14, false, "[Value = '0'; Other = '0']"));
            DDTIsLessThanComparer<Dummy>((0, 1, new DummyIComparer()), (15, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanComparer<Dummy>((1, 0, new DummyIComparer()), (16, false, "[Value = '1'; Other = '0']"));

            DDTIsLessThanComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTIsLessThanComparer((null, 0, new DummyIComparerT()), (18, true, "[Value = 'null'; Other = '0']"));
            DDTIsLessThanComparer((0, null, new DummyIComparerT()), (19, false, "[Value = '0'; Other = 'null']"));
            DDTIsLessThanComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTIsLessThanComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTIsLessThanComparer((0, 0, new DummyIComparerT()), (22, false, "[Value = '0'; Other = '0']"));
            DDTIsLessThanComparer((0, 1, new DummyIComparerT()), (23, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanComparer((1, 0, new DummyIComparerT()), (24, false, "[Value = '1'; Other = '0']"));

        }

        void DDTIsLessThanComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsLessThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsLessThan", _file, _method);

        }

        void DDTIsLessThanComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsLessThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsLessThan", _file, _method);

        }

        void DDTIsLessThanComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsLessThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsLessThan", _file, _method);

        }

        [TestMethod]
        void NotIsLessThanComparer() {

            DDTNotIsLessThanComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanComparer((null, 0, new DummyComparer()), (2, false, "[Value = 'null'; Other = '0']"));
            DDTNotIsLessThanComparer((0, null, new DummyComparer()), (3, true, "[Value = '0'; Other = 'null']"));
            DDTNotIsLessThanComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTNotIsLessThanComparer<Dummy>((0, 0, new DummyComparer()), (6, true, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanComparer<Dummy>((0, 1, new DummyComparer()), (7, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanComparer<Dummy>((1, 0, new DummyComparer()), (8, true, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThanComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanComparer<Dummy>((null, 0, new DummyIComparer()), (10, false, "[Value = 'null'; Other = '0']"));
            DDTNotIsLessThanComparer<Dummy>((0, null, new DummyIComparer()), (11, true, "[Value = '0'; Other = 'null']"));
            DDTNotIsLessThanComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTNotIsLessThanComparer<Dummy>((0, 0, new DummyIComparer()), (14, true, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanComparer<Dummy>((0, 1, new DummyIComparer()), (15, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanComparer<Dummy>((1, 0, new DummyIComparer()), (16, true, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThanComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanComparer((null, 0, new DummyIComparerT()), (18, false, "[Value = 'null'; Other = '0']"));
            DDTNotIsLessThanComparer((0, null, new DummyIComparerT()), (19, true, "[Value = '0'; Other = 'null']"));
            DDTNotIsLessThanComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTNotIsLessThanComparer((0, 0, new DummyIComparerT()), (22, true, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanComparer((0, 1, new DummyIComparerT()), (23, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanComparer((1, 0, new DummyIComparerT()), (24, true, "[Value = '1'; Other = '0']"));

        }

        void DDTNotIsLessThanComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsLessThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsLessThan", _file, _method);

        }

        void DDTNotIsLessThanComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsLessThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsLessThan", _file, _method);

        }

        void DDTNotIsLessThanComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsLessThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsLessThan", _file, _method);

        }

        #endregion

        #region IsLessThanOrEquals

        [TestMethod]
        void IsLessThanOrEquals() {

            DDTIsLessThanOrEquals<DummyIComparable>((0, 0), (1, true, "[Value = '0'; Other = '0']"));
            DDTIsLessThanOrEquals<DummyIComparable>((0, 1), (2, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanOrEquals<DummyIComparable>((1, 0), (3, false, "[Value = '1'; Other = '0']"));

            DDTIsLessThanOrEqualsT<DummyIComparableT>((0, 0), (4, true, "[Value = '0'; Other = '0']"));
            DDTIsLessThanOrEqualsT<DummyIComparableT>((0, 1), (5, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanOrEqualsT<DummyIComparableT>((1, 0), (6, false, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThanOrEquals<DummyIComparable>((0, 0), (7, false, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanOrEquals<DummyIComparable>((0, 1), (8, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanOrEquals<DummyIComparable>((1, 0), (9, true, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThanOrEqualsT<DummyIComparableT>((0, 0), (10, false, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanOrEqualsT<DummyIComparableT>((0, 1), (11, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanOrEqualsT<DummyIComparableT>((1, 0), (12, true, "[Value = '1'; Other = '0']"));

        }

        void DDTIsLessThanOrEquals<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.If.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThanOrEquals(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsLessThanOrEquals", _file, _method);

        }

        void DDTIsLessThanOrEqualsT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.If.Value.IsLessThanOrEqualsT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThanOrEqualsT(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsLessThanOrEquals", _file, _method);

        }

        void DDTNotIsLessThanOrEquals<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.IfNot.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThanOrEquals(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsLessThanOrEquals", _file, _method);

        }

        void DDTNotIsLessThanOrEqualsT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.IfNot.Value.IsLessThanOrEqualsT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThanOrEqualsT(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsLessThanOrEquals", _file, _method);

        }

        #endregion

        #region IsLessThanOrEqualsComparer

        [TestMethod]
        void IsLessThanOrEqualsComparer() {

            DDTIsLessThanOrEqualsComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTIsLessThanOrEqualsComparer((null, 0, new DummyComparer()), (2, true, "[Value = 'null'; Other = '0']"));
            DDTIsLessThanOrEqualsComparer((0, null, new DummyComparer()), (3, false, "[Value = '0'; Other = 'null']"));
            DDTIsLessThanOrEqualsComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTIsLessThanOrEqualsComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTIsLessThanOrEqualsComparer<Dummy>((0, 0, new DummyComparer()), (6, true, "[Value = '0'; Other = '0']"));
            DDTIsLessThanOrEqualsComparer<Dummy>((0, 1, new DummyComparer()), (7, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanOrEqualsComparer<Dummy>((1, 0, new DummyComparer()), (8, false, "[Value = '1'; Other = '0']"));

            DDTIsLessThanOrEqualsComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTIsLessThanOrEqualsComparer<Dummy>((null, 0, new DummyIComparer()), (10, true, "[Value = 'null'; Other = '0']"));
            DDTIsLessThanOrEqualsComparer<Dummy>((0, null, new DummyIComparer()), (11, false, "[Value = '0'; Other = 'null']"));
            DDTIsLessThanOrEqualsComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTIsLessThanOrEqualsComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTIsLessThanOrEqualsComparer<Dummy>((0, 0, new DummyIComparer()), (14, true, "[Value = '0'; Other = '0']"));
            DDTIsLessThanOrEqualsComparer<Dummy>((0, 1, new DummyIComparer()), (15, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanOrEqualsComparer<Dummy>((1, 0, new DummyIComparer()), (16, false, "[Value = '1'; Other = '0']"));

            DDTIsLessThanOrEqualsComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTIsLessThanOrEqualsComparer((null, 0, new DummyIComparerT()), (18, true, "[Value = 'null'; Other = '0']"));
            DDTIsLessThanOrEqualsComparer((0, null, new DummyIComparerT()), (19, false, "[Value = '0'; Other = 'null']"));
            DDTIsLessThanOrEqualsComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTIsLessThanOrEqualsComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTIsLessThanOrEqualsComparer((0, 0, new DummyIComparerT()), (22, true, "[Value = '0'; Other = '0']"));
            DDTIsLessThanOrEqualsComparer((0, 1, new DummyIComparerT()), (23, true, "[Value = '0'; Other = '1']"));
            DDTIsLessThanOrEqualsComparer((1, 0, new DummyIComparerT()), (24, false, "[Value = '1'; Other = '0']"));

        }

        void DDTIsLessThanOrEqualsComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsLessThanOrEquals", _file, _method);

        }

        void DDTIsLessThanOrEqualsComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsLessThanOrEquals", _file, _method);

        }

        void DDTIsLessThanOrEqualsComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsLessThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsLessThanOrEquals", _file, _method);

        }

        [TestMethod]
        void NotIsLessThanOrEqualsComparer() {

            DDTNotIsLessThanOrEqualsComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanOrEqualsComparer((null, 0, new DummyComparer()), (2, false, "[Value = 'null'; Other = '0']"));
            DDTNotIsLessThanOrEqualsComparer((0, null, new DummyComparer()), (3, true, "[Value = '0'; Other = 'null']"));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 0, new DummyComparer()), (6, false, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 1, new DummyComparer()), (7, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((1, 0, new DummyComparer()), (8, true, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThanOrEqualsComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((null, 0, new DummyIComparer()), (10, false, "[Value = 'null'; Other = '0']"));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, null, new DummyIComparer()), (11, true, "[Value = '0'; Other = 'null']"));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 0, new DummyIComparer()), (14, false, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((0, 1, new DummyIComparer()), (15, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanOrEqualsComparer<Dummy>((1, 0, new DummyIComparer()), (16, true, "[Value = '1'; Other = '0']"));

            DDTNotIsLessThanOrEqualsComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanOrEqualsComparer((null, 0, new DummyIComparerT()), (18, false, "[Value = 'null'; Other = '0']"));
            DDTNotIsLessThanOrEqualsComparer((0, null, new DummyIComparerT()), (19, true, "[Value = '0'; Other = 'null']"));
            DDTNotIsLessThanOrEqualsComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTNotIsLessThanOrEqualsComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTNotIsLessThanOrEqualsComparer((0, 0, new DummyIComparerT()), (22, false, "[Value = '0'; Other = '0']"));
            DDTNotIsLessThanOrEqualsComparer((0, 1, new DummyIComparerT()), (23, false, "[Value = '0'; Other = '1']"));
            DDTNotIsLessThanOrEqualsComparer((1, 0, new DummyIComparerT()), (24, true, "[Value = '1'; Other = '0']"));

        }

        void DDTNotIsLessThanOrEqualsComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsLessThanOrEquals", _file, _method);

        }

        void DDTNotIsLessThanOrEqualsComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsLessThanOrEquals", _file, _method);

        }

        void DDTNotIsLessThanOrEqualsComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsLessThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsLessThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsLessThanOrEquals", _file, _method);

        }

        #endregion

        #region IsGreaterThan

        [TestMethod]
        void IsGreaterThan() {

            DDTIsGreaterThan<DummyIComparable>((0, 0), (1, false, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThan<DummyIComparable>((0, 1), (2, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThan<DummyIComparable>((1, 0), (3, true, "[Value = '1'; Other = '0']"));

            DDTIsGreaterThanT<DummyIComparableT>((0, 0), (4, false, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanT<DummyIComparableT>((0, 1), (5, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanT<DummyIComparableT>((1, 0), (6, true, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThan<DummyIComparable>((0, 0), (7, true, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThan<DummyIComparable>((0, 1), (8, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThan<DummyIComparable>((1, 0), (9, false, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThanT<DummyIComparableT>((0, 0), (10, true, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanT<DummyIComparableT>((0, 1), (11, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanT<DummyIComparableT>((1, 0), (12, false, "[Value = '1'; Other = '0']"));

        }

        void DDTIsGreaterThan<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.If.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThan(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsGreaterThan", _file, _method);

        }

        void DDTIsGreaterThanT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.If.Value.IsGreaterThanT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThanT(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsGreaterThan", _file, _method);

        }

        void DDTNotIsGreaterThan<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.IfNot.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThan(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThan", _file, _method);

        }

        void DDTNotIsGreaterThanT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.IfNot.Value.IsGreaterThanT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThanT(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThan", _file, _method);

        }

        #endregion

        #region IsGreaterThanComparer

        [TestMethod]
        void IsGreaterThanComparer() {

            DDTIsGreaterThanComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanComparer((null, 0, new DummyComparer()), (2, false, "[Value = 'null'; Other = '0']"));
            DDTIsGreaterThanComparer((0, null, new DummyComparer()), (3, true, "[Value = '0'; Other = 'null']"));
            DDTIsGreaterThanComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTIsGreaterThanComparer<Dummy>((0, 0, new DummyComparer()), (6, false, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanComparer<Dummy>((0, 1, new DummyComparer()), (7, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanComparer<Dummy>((1, 0, new DummyComparer()), (8, true, "[Value = '1'; Other = '0']"));

            DDTIsGreaterThanComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanComparer<Dummy>((null, 0, new DummyIComparer()), (10, false, "[Value = 'null'; Other = '0']"));
            DDTIsGreaterThanComparer<Dummy>((0, null, new DummyIComparer()), (11, true, "[Value = '0'; Other = 'null']"));
            DDTIsGreaterThanComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTIsGreaterThanComparer<Dummy>((0, 0, new DummyIComparer()), (14, false, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanComparer<Dummy>((0, 1, new DummyIComparer()), (15, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanComparer<Dummy>((1, 0, new DummyIComparer()), (16, true, "[Value = '1'; Other = '0']"));

            DDTIsGreaterThanComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanComparer((null, 0, new DummyIComparerT()), (18, false, "[Value = 'null'; Other = '0']"));
            DDTIsGreaterThanComparer((0, null, new DummyIComparerT()), (19, true, "[Value = '0'; Other = 'null']"));
            DDTIsGreaterThanComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTIsGreaterThanComparer((0, 0, new DummyIComparerT()), (22, false, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanComparer((0, 1, new DummyIComparerT()), (23, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanComparer((1, 0, new DummyIComparerT()), (24, true, "[Value = '1'; Other = '0']"));

        }

        void DDTIsGreaterThanComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsGreaterThan", _file, _method);

        }

        void DDTIsGreaterThanComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsGreaterThan", _file, _method);

        }

        void DDTIsGreaterThanComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsGreaterThan", _file, _method);

        }

        [TestMethod]
        void NotIsGreaterThanComparer() {

            DDTNotIsGreaterThanComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanComparer((null, 0, new DummyComparer()), (2, true, "[Value = 'null'; Other = '0']"));
            DDTNotIsGreaterThanComparer((0, null, new DummyComparer()), (3, false, "[Value = '0'; Other = 'null']"));
            DDTNotIsGreaterThanComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTNotIsGreaterThanComparer<Dummy>((0, 0, new DummyComparer()), (6, true, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanComparer<Dummy>((0, 1, new DummyComparer()), (7, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanComparer<Dummy>((1, 0, new DummyComparer()), (8, false, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThanComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanComparer<Dummy>((null, 0, new DummyIComparer()), (10, true, "[Value = 'null'; Other = '0']"));
            DDTNotIsGreaterThanComparer<Dummy>((0, null, new DummyIComparer()), (11, false, "[Value = '0'; Other = 'null']"));
            DDTNotIsGreaterThanComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTNotIsGreaterThanComparer<Dummy>((0, 0, new DummyIComparer()), (14, true, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanComparer<Dummy>((0, 1, new DummyIComparer()), (15, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanComparer<Dummy>((1, 0, new DummyIComparer()), (16, false, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThanComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanComparer((null, 0, new DummyIComparerT()), (18, true, "[Value = 'null'; Other = '0']"));
            DDTNotIsGreaterThanComparer((0, null, new DummyIComparerT()), (19, false, "[Value = '0'; Other = 'null']"));
            DDTNotIsGreaterThanComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTNotIsGreaterThanComparer((0, 0, new DummyIComparerT()), (22, true, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanComparer((0, 1, new DummyIComparerT()), (23, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanComparer((1, 0, new DummyIComparerT()), (24, false, "[Value = '1'; Other = '0']"));

        }

        void DDTNotIsGreaterThanComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThan", _file, _method);

        }

        void DDTNotIsGreaterThanComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThan", _file, _method);

        }

        void DDTNotIsGreaterThanComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsGreaterThan({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThan(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThan", _file, _method);

        }

        #endregion

        #region IsGreaterThanOrEquals

        [TestMethod]
        void IsGreaterThanOrEquals() {

            DDTIsGreaterThanOrEquals<DummyIComparable>((0, 0), (1, true, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanOrEquals<DummyIComparable>((0, 1), (2, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanOrEquals<DummyIComparable>((1, 0), (3, true, "[Value = '1'; Other = '0']"));

            DDTIsGreaterThanOrEqualsT<DummyIComparableT>((0, 0), (4, true, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanOrEqualsT<DummyIComparableT>((0, 1), (5, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanOrEqualsT<DummyIComparableT>((1, 0), (6, true, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThanOrEquals<DummyIComparable>((0, 0), (7, false, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanOrEquals<DummyIComparable>((0, 1), (8, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanOrEquals<DummyIComparable>((1, 0), (9, false, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThanOrEqualsT<DummyIComparableT>((0, 0), (10, false, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanOrEqualsT<DummyIComparableT>((0, 1), (11, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanOrEqualsT<DummyIComparableT>((1, 0), (12, false, "[Value = '1'; Other = '0']"));

        }

        void DDTIsGreaterThanOrEquals<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.If.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThanOrEquals(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsGreaterThanOrEquals", _file, _method);

        }

        void DDTIsGreaterThanOrEqualsT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.If.Value.IsGreaterThanOrEqualsT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThanOrEqualsT(input.value, input.other, _file, _method),
                expected, "Test.If.Value.IsGreaterThanOrEquals", _file, _method);

        }

        void DDTNotIsGreaterThanOrEquals<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.IfNot.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThanOrEquals(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThanOrEquals", _file, _method);

        }

        void DDTNotIsGreaterThanOrEqualsT<T>((T value, T other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.IfNot.Value.IsGreaterThanOrEqualsT({input.value.Format()}, {input.other.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThanOrEqualsT(input.value, input.other, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThanOrEquals", _file, _method);

        }

        #endregion

        #region IsGreaterThanOrEqualsComparer

        [TestMethod]
        void IsGreaterThanOrEqualsComparer() {

            DDTIsGreaterThanOrEqualsComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanOrEqualsComparer((null, 0, new DummyComparer()), (2, false, "[Value = 'null'; Other = '0']"));
            DDTIsGreaterThanOrEqualsComparer((0, null, new DummyComparer()), (3, true, "[Value = '0'; Other = 'null']"));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 0, new DummyComparer()), (6, true, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 1, new DummyComparer()), (7, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((1, 0, new DummyComparer()), (8, true, "[Value = '1'; Other = '0']"));

            DDTIsGreaterThanOrEqualsComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((null, 0, new DummyIComparer()), (10, false, "[Value = 'null'; Other = '0']"));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, null, new DummyIComparer()), (11, true, "[Value = '0'; Other = 'null']"));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 0, new DummyIComparer()), (14, true, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((0, 1, new DummyIComparer()), (15, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanOrEqualsComparer<Dummy>((1, 0, new DummyIComparer()), (16, true, "[Value = '1'; Other = '0']"));

            DDTIsGreaterThanOrEqualsComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanOrEqualsComparer((null, 0, new DummyIComparerT()), (18, false, "[Value = 'null'; Other = '0']"));
            DDTIsGreaterThanOrEqualsComparer((0, null, new DummyIComparerT()), (19, true, "[Value = '0'; Other = 'null']"));
            DDTIsGreaterThanOrEqualsComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTIsGreaterThanOrEqualsComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTIsGreaterThanOrEqualsComparer((0, 0, new DummyIComparerT()), (22, true, "[Value = '0'; Other = '0']"));
            DDTIsGreaterThanOrEqualsComparer((0, 1, new DummyIComparerT()), (23, false, "[Value = '0'; Other = '1']"));
            DDTIsGreaterThanOrEqualsComparer((1, 0, new DummyIComparerT()), (24, true, "[Value = '1'; Other = '0']"));

        }

        void DDTIsGreaterThanOrEqualsComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsGreaterThanOrEquals", _file, _method);

        }

        void DDTIsGreaterThanOrEqualsComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsGreaterThanOrEquals", _file, _method);

        }

        void DDTIsGreaterThanOrEqualsComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsGreaterThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.If.Value.IsGreaterThanOrEquals", _file, _method);

        }

        [TestMethod]
        void NotIsGreaterThanOrEqualsComparer() {

            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanOrEqualsComparer((null, 0, new DummyComparer()), (2, true, "[Value = 'null'; Other = '0']"));
            DDTNotIsGreaterThanOrEqualsComparer((0, null, new DummyComparer()), (3, false, "[Value = '0'; Other = 'null']"));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 0, null), (4, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 0, new ThrowingComparer()), (5, false, "Comparer threw Exception:"));

            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 0, new DummyComparer()), (6, false, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 1, new DummyComparer()), (7, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((1, 0, new DummyComparer()), (8, false, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((null, null, (IComparer) null), (9, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((null, 0, new DummyIComparer()), (10, true, "[Value = 'null'; Other = '0']"));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, null, new DummyIComparer()), (11, false, "[Value = '0'; Other = 'null']"));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 0, (IComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (13, false, "Comparer threw Exception:"));

            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 0, new DummyIComparer()), (14, false, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((0, 1, new DummyIComparer()), (15, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanOrEqualsComparer<Dummy>((1, 0, new DummyIComparer()), (16, false, "[Value = '1'; Other = '0']"));

            DDTNotIsGreaterThanOrEqualsComparer((null, null, (IComparer<Dummy>) null), (17, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanOrEqualsComparer((null, 0, new DummyIComparerT()), (18, true, "[Value = 'null'; Other = '0']"));
            DDTNotIsGreaterThanOrEqualsComparer((0, null, new DummyIComparerT()), (19, false, "[Value = '0'; Other = 'null']"));
            DDTNotIsGreaterThanOrEqualsComparer((0, 0, (IComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTNotIsGreaterThanOrEqualsComparer((0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (21, false, "Comparer threw Exception:"));

            DDTNotIsGreaterThanOrEqualsComparer((0, 0, new DummyIComparerT()), (22, false, "[Value = '0'; Other = '0']"));
            DDTNotIsGreaterThanOrEqualsComparer((0, 1, new DummyIComparerT()), (23, true, "[Value = '0'; Other = '1']"));
            DDTNotIsGreaterThanOrEqualsComparer((1, 0, new DummyIComparerT()), (24, false, "[Value = '1'; Other = '0']"));

        }

        void DDTNotIsGreaterThanOrEqualsComparer<T>((T value, T other, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThanOrEquals", _file, _method);

        }

        void DDTNotIsGreaterThanOrEqualsComparer<T>((T value, T other, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThanOrEquals", _file, _method);

        }

        void DDTNotIsGreaterThanOrEqualsComparer<T>((T value, T other, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsGreaterThanOrEquals({input.value.Format()}, {input.other.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsGreaterThanOrEquals(input.value, input.other, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsGreaterThanOrEquals", _file, _method);

        }

        #endregion

        #region IsTrue

        [TestMethod]
        void True() {

            DDTTrue(true, (1, true, "[Value = 'True']"));
            DDTTrue(false, (2, false, "[Value = 'False']"));

            DDTTrueNullable(true, (3, true, "[Value = 'True']"));
            DDTTrueNullable(false, (4, false, "[Value = 'False']"));
            DDTTrueNullable(null, (5, false, "Parameter 'value' is null."));

        }

        void DDTTrue(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsTrue({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsTrue(input, _file, _method),
                expected, "Test.If.Value.IsTrue", _file, _method);

        }

        void DDTTrueNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsTrue({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsTrue(input, _file, _method),
                expected, "Test.If.Value.IsTrue", _file, _method);

        }

        [TestMethod]
        void NotTrue() {

            DDTNotTrue(true, (1, false, "[Value = 'True']"));
            DDTNotTrue(false, (2, true, "[Value = 'False']"));

            DDTNotTrueNullable(true, (3, false, "[Value = 'True']"));
            DDTNotTrueNullable(false, (4, true, "[Value = 'False']"));
            DDTNotTrueNullable(null, (5, false, "Parameter 'value' is null."));

        }

        void DDTNotTrue(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsTrue({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsTrue(input, _file, _method),
                expected, "Test.IfNot.Value.IsTrue", _file, _method);

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

            DDTFalseNullable(true, (3, false, "[Value = 'True']"));
            DDTFalseNullable(false, (4, true, "[Value = 'False']"));
            DDTFalseNullable(null, (5, false, "Parameter 'value' is null."));

        }

        void DDTFalse(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsFalse({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsFalse(input, _file, _method),
                expected, "Test.If.Value.IsFalse", _file, _method);

        }

        void DDTFalseNullable(Boolean? input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsFalse({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsFalse(input, _file, _method),
                expected, "Test.If.Value.IsFalse", _file, _method);

        }

        [TestMethod]
        void NotFalse() {

            DDTNotFalse(true, (1, true, "[Value = 'True']"));
            DDTNotFalse(false, (2, false, "[Value = 'False']"));

            DDTNotFalseNullable(true, (3, true, "[Value = 'True']"));
            DDTNotFalseNullable(false, (4, false, "[Value = 'False']"));
            DDTNotFalseNullable(null, (5, false, "Parameter 'value' is null."));

        }

        void DDTNotFalse(Boolean input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsFalse({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsFalse(input, _file, _method),
                expected, "Test.IfNot.Value.IsFalse", _file, _method);

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
            DDTIsClamped<DummyIComparable>((null, 0, 0), (2, false, "Parameter 'value' is null."));
            DDTIsClamped<DummyIComparable>((0, null, 0), (3, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClamped<DummyIComparable>((0, 0, null), (4, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClamped<DummyIComparable>((0, 0, 0), (5, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClamped<DummyIComparable>((0, -1, 1), (6, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClamped<DummyIComparable>((0, 1, -1), (7, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClamped<DummyIComparable>((0, 0, 1), (8, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClamped<DummyIComparable>((0, -1, 0), (9, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClamped<DummyIComparable>((0, 1, 2), (10, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClamped<DummyIComparable>((0, -2, -1), (11, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTIsClampedT<DummyIComparableT>((null, 0, 0), (13, false, "Parameter 'value' is null."));
            DDTIsClampedT<DummyIComparableT>((0, null, 0), (14, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedT<DummyIComparableT>((0, 0, null), (15, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedT<DummyIComparableT>((0, 0, 0), (16, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedT<DummyIComparableT>((0, -1, 1), (17, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedT<DummyIComparableT>((0, 1, -1), (18, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedT<DummyIComparableT>((0, 0, 1), (19, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedT<DummyIComparableT>((0, -1, 0), (20, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedT<DummyIComparableT>((0, 1, 2), (21, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedT<DummyIComparableT>((0, -2, -1), (22, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTIsClamped<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.If.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClamped(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClamped", _file, _method);

        }

        void DDTIsClampedT<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.If.Value.IsClampedT({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedT(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClamped", _file, _method);

        }

        [TestMethod]
        void NotIsClamped() {

            DDTNotIsClamped<DummyIComparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTNotIsClamped<DummyIComparable>((null, 0, 0), (2, false, "Parameter 'value' is null."));
            DDTNotIsClamped<DummyIComparable>((0, null, 0), (3, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClamped<DummyIComparable>((0, 0, null), (4, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClamped<DummyIComparable>((0, 0, 0), (5, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClamped<DummyIComparable>((0, -1, 1), (6, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClamped<DummyIComparable>((0, 1, -1), (7, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClamped<DummyIComparable>((0, 0, 1), (8, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClamped<DummyIComparable>((0, -1, 0), (9, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClamped<DummyIComparable>((0, 1, 2), (10, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClamped<DummyIComparable>((0, -2, -1), (11, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTNotIsClampedT<DummyIComparableT>((null, 0, 0), (13, false, "Parameter 'value' is null."));
            DDTNotIsClampedT<DummyIComparableT>((0, null, 0), (14, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedT<DummyIComparableT>((0, 0, null), (15, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedT<DummyIComparableT>((0, 0, 0), (16, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedT<DummyIComparableT>((0, -1, 1), (17, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedT<DummyIComparableT>((0, 1, -1), (18, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedT<DummyIComparableT>((0, 0, 1), (19, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedT<DummyIComparableT>((0, -1, 0), (20, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedT<DummyIComparableT>((0, 1, 2), (21, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedT<DummyIComparableT>((0, -2, -1), (22, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTNotIsClamped<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note($"Test.IfNot.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClamped(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClamped", _file, _method);

        }

        void DDTNotIsClampedT<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note($"Test.IfNot.Value.IsClampedT({input.value.Format()}, {input.min.Format()}, {input.max.Format()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedT(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClamped", _file, _method);

        }

        #endregion

        #region IsClampedComparer

        [TestMethod]
        void IsClampedComparer() {

            DDTIsClampedComparer<Dummy>((null, null, null, null), (1, false, "Parameter 'value' is null."));
            DDTIsClampedComparer((null, 0, 0, new DummyComparer()), (2, false, "Parameter 'value' is null."));
            DDTIsClampedComparer((0, null, 0, new DummyComparer()), (3, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedComparer((0, 0, null, new DummyComparer()), (4, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedComparer<Dummy>((0, 0, 0, null), (5, false, "Parameter 'comparer' is null."));
            DDTIsClampedComparer<Dummy>((0, 0, 0, new ThrowingComparer()), (6, false, "Comparer threw Exception:"));

            DDTIsClampedComparer<Dummy>((0, 0, 0, new DummyComparer()), (7, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedComparer<Dummy>((0, -1, 1, new DummyComparer()), (8, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedComparer<Dummy>((0, 1, -1, new DummyComparer()), (9, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedComparer<Dummy>((0, 0, 1, new DummyComparer()), (10, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedComparer<Dummy>((0, -1, 0, new DummyComparer()), (11, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedComparer<Dummy>((0, 1, 2, new DummyComparer()), (12, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedComparer<Dummy>((0, -2, -1, new DummyComparer()), (13, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedComparer<Dummy>((null, null, null, (IComparer) null), (14, false, "Parameter 'value' is null."));
            DDTIsClampedComparer<Dummy>((null, 0, 0, new DummyIComparer()), (15, false, "Parameter 'value' is null."));
            DDTIsClampedComparer<Dummy>((0, null, 0, new DummyIComparer()), (16, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedComparer<Dummy>((0, 0, null, new DummyIComparer()), (17, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedComparer<Dummy>((0, 0, 0, (IComparer) null), (18, false, "Parameter 'comparer' is null."));
            DDTIsClampedComparer<Dummy>((0, 0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (19, false, "Comparer threw Exception:"));

            DDTIsClampedComparer<Dummy>((0, 0, 0, new DummyIComparer()), (20, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedComparer<Dummy>((0, -1, 1, new DummyIComparer()), (21, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedComparer<Dummy>((0, 1, -1, new DummyIComparer()), (22, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedComparer<Dummy>((0, 0, 1, new DummyIComparer()), (23, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedComparer<Dummy>((0, -1, 0, new DummyIComparer()), (24, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedComparer<Dummy>((0, 1, 2, new DummyIComparer()), (25, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedComparer<Dummy>((0, -2, -1, new DummyIComparer()), (26, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedComparer((null, null, null, (IComparer<Dummy>) null), (27, false, "Parameter 'value' is null."));
            DDTIsClampedComparer((null, 0, 0, new DummyIComparerT()), (28, false, "Parameter 'value' is null."));
            DDTIsClampedComparer((0, null, 0, new DummyIComparerT()), (29, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedComparer((0, 0, null, new DummyIComparerT()), (30, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedComparer((0, 0, 0, (IComparer<Dummy>) null), (31, false, "Parameter 'comparer' is null."));
            DDTIsClampedComparer((0, 0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (32, false, "Comparer threw Exception:"));

            DDTIsClampedComparer((0, 0, 0, new DummyIComparerT()), (33, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedComparer((0, -1, 1, new DummyIComparerT()), (34, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedComparer((0, 1, -1, new DummyIComparerT()), (35, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedComparer((0, 0, 1, new DummyIComparerT()), (36, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedComparer((0, -1, 0, new DummyIComparerT()), (37, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedComparer((0, 1, 2, new DummyIComparerT()), (38, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedComparer((0, -2, -1, new DummyIComparerT()), (39, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTIsClampedComparer<T>((T value, T min, T max, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClamped(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.If.Value.IsClamped", _file, _method);

        }

        void DDTIsClampedComparer<T>((T value, T min, T max, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClamped(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.If.Value.IsClamped", _file, _method);

        }

        void DDTIsClampedComparer<T>((T value, T min, T max, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClamped(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.If.Value.IsClamped", _file, _method);

        }

        [TestMethod]
        void NotIsClampedComparer() {

            DDTNotIsClampedComparer<Dummy>((null, null, null, null), (1, false, "Parameter 'value' is null."));
            DDTNotIsClampedComparer((null, 0, 0, new DummyComparer()), (2, false, "Parameter 'value' is null."));
            DDTNotIsClampedComparer((0, null, 0, new DummyComparer()), (3, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedComparer((0, 0, null, new DummyComparer()), (4, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedComparer<Dummy>((0, 0, 0, null), (5, false, "Parameter 'comparer' is null."));
            DDTNotIsClampedComparer<Dummy>((0, 0, 0, new ThrowingComparer()), (6, false, "Comparer threw Exception:"));

            DDTNotIsClampedComparer<Dummy>((0, 0, 0, new DummyComparer()), (7, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedComparer<Dummy>((0, -1, 1, new DummyComparer()), (8, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedComparer<Dummy>((0, 1, -1, new DummyComparer()), (9, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedComparer<Dummy>((0, 0, 1, new DummyComparer()), (10, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedComparer<Dummy>((0, -1, 0, new DummyComparer()), (11, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedComparer<Dummy>((0, 1, 2, new DummyComparer()), (12, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedComparer<Dummy>((0, -2, -1, new DummyComparer()), (13, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedComparer<Dummy>((null, null, null, (IComparer) null), (14, false, "Parameter 'value' is null."));
            DDTNotIsClampedComparer<Dummy>((null, 0, 0, new DummyIComparer()), (15, false, "Parameter 'value' is null."));
            DDTNotIsClampedComparer<Dummy>((0, null, 0, new DummyIComparer()), (16, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedComparer<Dummy>((0, 0, null, new DummyIComparer()), (17, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedComparer<Dummy>((0, 0, 0, (IComparer) null), (18, false, "Parameter 'comparer' is null."));
            DDTNotIsClampedComparer<Dummy>((0, 0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (19, false, "Comparer threw Exception:"));

            DDTNotIsClampedComparer<Dummy>((0, 0, 0, new DummyIComparer()), (20, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedComparer<Dummy>((0, -1, 1, new DummyIComparer()), (21, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedComparer<Dummy>((0, 1, -1, new DummyIComparer()), (22, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedComparer<Dummy>((0, 0, 1, new DummyIComparer()), (23, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedComparer<Dummy>((0, -1, 0, new DummyIComparer()), (24, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedComparer<Dummy>((0, 1, 2, new DummyIComparer()), (25, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedComparer<Dummy>((0, -2, -1, new DummyIComparer()), (26, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedComparer((null, null, null, (IComparer<Dummy>) null), (27, false, "Parameter 'value' is null."));
            DDTNotIsClampedComparer((null, 0, 0, new DummyIComparerT()), (28, false, "Parameter 'value' is null."));
            DDTNotIsClampedComparer((0, null, 0, new DummyIComparerT()), (29, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedComparer((0, 0, null, new DummyIComparerT()), (30, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedComparer((0, 0, 0, (IComparer<Dummy>) null), (31, false, "Parameter 'comparer' is null."));
            DDTNotIsClampedComparer((0, 0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (32, false, "Comparer threw Exception:"));

            DDTNotIsClampedComparer((0, 0, 0, new DummyIComparerT()), (33, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedComparer((0, -1, 1, new DummyIComparerT()), (34, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedComparer((0, 1, -1, new DummyIComparerT()), (35, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedComparer((0, 0, 1, new DummyIComparerT()), (36, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedComparer((0, -1, 0, new DummyIComparerT()), (37, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedComparer((0, 1, 2, new DummyIComparerT()), (38, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedComparer((0, -2, -1, new DummyIComparerT()), (39, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTNotIsClampedComparer<T>((T value, T min, T max, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClamped(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsClamped", _file, _method);

        }

        void DDTNotIsClampedComparer<T>((T value, T min, T max, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClamped(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsClamped", _file, _method);

        }

        void DDTNotIsClampedComparer<T>((T value, T min, T max, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsClamped({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClamped(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsClamped", _file, _method);

        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusive() {

            DDTIsClampedExclusive<DummyIComparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTIsClampedExclusive<DummyIComparable>((null, 0, 0), (2, false, "Parameter 'value' is null."));
            DDTIsClampedExclusive<DummyIComparable>((0, null, 0), (3, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedExclusive<DummyIComparable>((0, 0, null), (4, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedExclusive<DummyIComparable>((0, 0, 0), (5, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedExclusive<DummyIComparable>((0, -1, 1), (6, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedExclusive<DummyIComparable>((0, 1, -1), (7, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedExclusive<DummyIComparable>((0, 0, 1), (8, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedExclusive<DummyIComparable>((0, -1, 0), (9, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedExclusive<DummyIComparable>((0, 1, 2), (10, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedExclusive<DummyIComparable>((0, -2, -1), (11, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedExclusiveT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveT<DummyIComparableT>((null, 0, 0), (13, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, null, 0), (14, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, 0, null), (15, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, 0, 0), (16, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, -1, 1), (17, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, 1, -1), (18, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, 0, 1), (19, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, -1, 0), (20, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, 1, 2), (21, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedExclusiveT<DummyIComparableT>((0, -2, -1), (22, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTIsClampedExclusive<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note(String.Format("Test.If.Value.IsClampedExclusive({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedExclusive(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedExclusive", _file, _method);

        }

        void DDTIsClampedExclusiveT<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note(String.Format("Test.If.Value.IsClampedExclusiveT({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedExclusiveT(input.value, input.min, input.max, _file, _method),
                expected, "Test.If.Value.IsClampedExclusive", _file, _method);

        }

        [TestMethod]
        void NotIsClampedExclusive() {

            DDTNotIsClampedExclusive<DummyIComparable>((null, null, null), (1, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusive<DummyIComparable>((null, 0, 0), (2, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusive<DummyIComparable>((0, null, 0), (3, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, 0, null), (4, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, 0, 0), (5, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, -1, 1), (6, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, 1, -1), (7, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, 0, 1), (8, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, -1, 0), (9, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, 1, 2), (10, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedExclusive<DummyIComparable>((0, -2, -1), (11, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedExclusiveT<DummyIComparableT>((null, null, null), (12, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((null, 0, 0), (13, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, null, 0), (14, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, 0, null), (15, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, 0, 0), (16, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, -1, 1), (17, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, 1, -1), (18, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, 0, 1), (19, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, -1, 0), (20, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, 1, 2), (21, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedExclusiveT<DummyIComparableT>((0, -2, -1), (22, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTNotIsClampedExclusive<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            Test.Note(String.Format("Test.IfNot.Value.IsClampedExclusive({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedExclusive(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusive", _file, _method);

        }

        void DDTNotIsClampedExclusiveT<T>((T value, T min, T max) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            Test.Note(String.Format("Test.IfNot.Value.IsClampedExclusiveT({0}, {1}, {2})", input.value.Format(), input.min.Format(), input.max.Format()),
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedExclusiveT(input.value, input.min, input.max, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusive", _file, _method);

        }

        #endregion

        #region IsClampedExclusiveComparer

        [TestMethod]
        void IsClampedExclusiveComparer() {

            DDTIsClampedExclusiveComparer<Dummy>((null, null, null, null), (1, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveComparer((null, 0, 0, new DummyComparer()), (2, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveComparer((0, null, 0, new DummyComparer()), (3, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedExclusiveComparer((0, 0, null, new DummyComparer()), (4, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 0, null), (5, false, "Parameter 'comparer' is null."));
            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 0, new ThrowingComparer()), (6, false, "Comparer threw Exception:"));

            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 0, new DummyComparer()), (7, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, -1, 1, new DummyComparer()), (8, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 1, -1, new DummyComparer()), (9, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 1, new DummyComparer()), (10, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, -1, 0, new DummyComparer()), (11, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 1, 2, new DummyComparer()), (12, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, -2, -1, new DummyComparer()), (13, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedExclusiveComparer<Dummy>((null, null, null, (IComparer) null), (14, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveComparer<Dummy>((null, 0, 0, new DummyIComparer()), (15, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveComparer<Dummy>((0, null, 0, new DummyIComparer()), (16, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 0, null, new DummyIComparer()), (17, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 0, (IComparer) null), (18, false, "Parameter 'comparer' is null."));
            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (19, false, "Comparer threw Exception:"));

            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 0, new DummyIComparer()), (20, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, -1, 1, new DummyIComparer()), (21, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 1, -1, new DummyIComparer()), (22, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 0, 1, new DummyIComparer()), (23, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, -1, 0, new DummyIComparer()), (24, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, 1, 2, new DummyIComparer()), (25, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedExclusiveComparer<Dummy>((0, -2, -1, new DummyIComparer()), (26, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTIsClampedExclusiveComparer((null, null, null, (IComparer<Dummy>) null), (27, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveComparer((null, 0, 0, new DummyIComparerT()), (28, false, "Parameter 'value' is null."));
            DDTIsClampedExclusiveComparer((0, null, 0, new DummyIComparerT()), (29, false, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTIsClampedExclusiveComparer((0, 0, null, new DummyIComparerT()), (30, false, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTIsClampedExclusiveComparer((0, 0, 0, (IComparer<Dummy>) null), (31, false, "Parameter 'comparer' is null."));
            DDTIsClampedExclusiveComparer((0, 0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (32, false, "Comparer threw Exception:"));

            DDTIsClampedExclusiveComparer((0, 0, 0, new DummyIComparerT()), (33, false, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTIsClampedExclusiveComparer((0, -1, 1, new DummyIComparerT()), (34, true, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTIsClampedExclusiveComparer((0, 1, -1, new DummyIComparerT()), (35, true, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTIsClampedExclusiveComparer((0, 0, 1, new DummyIComparerT()), (36, false, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTIsClampedExclusiveComparer((0, -1, 0, new DummyIComparerT()), (37, false, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTIsClampedExclusiveComparer((0, 1, 2, new DummyIComparerT()), (38, false, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTIsClampedExclusiveComparer((0, -2, -1, new DummyIComparerT()), (39, false, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTIsClampedExclusiveComparer<T>((T value, T min, T max, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsClampedExclusive({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedExclusive(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.If.Value.IsClampedExclusive", _file, _method);

        }

        void DDTIsClampedExclusiveComparer<T>((T value, T min, T max, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsClampedExclusive({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedExclusive(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.If.Value.IsClampedExclusive", _file, _method);

        }

        void DDTIsClampedExclusiveComparer<T>((T value, T min, T max, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Value.IsClampedExclusive({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Value.IsClampedExclusive(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.If.Value.IsClampedExclusive", _file, _method);

        }

        [TestMethod]
        void NotIsClampedExclusiveComparer() {

            DDTNotIsClampedExclusiveComparer<Dummy>((null, null, null, null), (1, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveComparer((null, 0, 0, new DummyComparer()), (2, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveComparer((0, null, 0, new DummyComparer()), (3, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer((0, 0, null, new DummyComparer()), (4, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 0, null), (5, false, "Parameter 'comparer' is null."));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 0, new ThrowingComparer()), (6, false, "Comparer threw Exception:"));

            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 0, new DummyComparer()), (7, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, -1, 1, new DummyComparer()), (8, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 1, -1, new DummyComparer()), (9, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 1, new DummyComparer()), (10, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, -1, 0, new DummyComparer()), (11, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 1, 2, new DummyComparer()), (12, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, -2, -1, new DummyComparer()), (13, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedExclusiveComparer<Dummy>((null, null, null, (IComparer) null), (14, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveComparer<Dummy>((null, 0, 0, new DummyIComparer()), (15, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, null, 0, new DummyIComparer()), (16, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, null, new DummyIComparer()), (17, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 0, (IComparer) null), (18, false, "Parameter 'comparer' is null."));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 0, DynamicComparer.From((x, y) => throw new NotImplementedException())), (19, false, "Comparer threw Exception:"));

            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 0, new DummyIComparer()), (20, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, -1, 1, new DummyIComparer()), (21, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 1, -1, new DummyIComparer()), (22, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 0, 1, new DummyIComparer()), (23, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, -1, 0, new DummyIComparer()), (24, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, 1, 2, new DummyIComparer()), (25, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedExclusiveComparer<Dummy>((0, -2, -1, new DummyIComparer()), (26, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

            DDTNotIsClampedExclusiveComparer((null, null, null, (IComparer<Dummy>) null), (27, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveComparer((null, 0, 0, new DummyIComparerT()), (28, false, "Parameter 'value' is null."));
            DDTNotIsClampedExclusiveComparer((0, null, 0, new DummyIComparerT()), (29, true, "[Value = '0'; Min = 'null'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer((0, 0, null, new DummyIComparerT()), (30, true, "[Value = '0'; Min = '0'; Max = 'null']"));
            DDTNotIsClampedExclusiveComparer((0, 0, 0, (IComparer<Dummy>) null), (31, false, "Parameter 'comparer' is null."));
            DDTNotIsClampedExclusiveComparer((0, 0, 0, DynamicComparer<Dummy>.From((x, y) => throw new NotImplementedException())), (32, false, "Comparer threw Exception:"));

            DDTNotIsClampedExclusiveComparer((0, 0, 0, new DummyIComparerT()), (33, true, "[Value = '0'; Min = '0'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer((0, -1, 1, new DummyIComparerT()), (34, false, "[Value = '0'; Min = '-1'; Max = '1']"));
            DDTNotIsClampedExclusiveComparer((0, 1, -1, new DummyIComparerT()), (35, false, "[Value = '0'; Min = '1'; Max = '-1']"));
            DDTNotIsClampedExclusiveComparer((0, 0, 1, new DummyIComparerT()), (36, true, "[Value = '0'; Min = '0'; Max = '1']"));
            DDTNotIsClampedExclusiveComparer((0, -1, 0, new DummyIComparerT()), (37, true, "[Value = '0'; Min = '-1'; Max = '0']"));
            DDTNotIsClampedExclusiveComparer((0, 1, 2, new DummyIComparerT()), (38, true, "[Value = '0'; Min = '1'; Max = '2']"));
            DDTNotIsClampedExclusiveComparer((0, -2, -1, new DummyIComparerT()), (39, true, "[Value = '0'; Min = '-2'; Max = '-1']"));

        }

        void DDTNotIsClampedExclusiveComparer<T>((T value, T min, T max, Comparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsClampedExclusive({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedExclusive(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusive", _file, _method);

        }

        void DDTNotIsClampedExclusiveComparer<T>((T value, T min, T max, IComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsClampedExclusive({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedExclusive(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusive", _file, _method);

        }

        void DDTNotIsClampedExclusiveComparer<T>((T value, T min, T max, IComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Value.IsClampedExclusive({input.value.Format()}, {input.min.Format()}, {input.max.Format()}, {input.comparer.FormatType()})",
                _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Value.IsClampedExclusive(input.value, input.min, input.max, input.comparer, _file, _method),
                expected, "Test.IfNot.Value.IsClampedExclusive", _file, _method);

        }

        #endregion

    }
}
