using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class ValuesTestSuit_uTests {

        #region EqualT

        [TestMethod]
        void TestEqualIEquatableT() {

            DDTestEqualT<EquatableT>((null, null), (1, true, "[Left = null; Right = null]"));
            DDTestEqualT((null, new EquatableT(0)), (2, false, "('GenericEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestEqualT((new EquatableT(0), null), (3, false, "('GenericEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestEqualT((new EquatableT(5), new EquatableT(0)), (4, false, "('Ntt.EquatableT'.IEquatable<T>) [Left = '5'; Right = '0']"));
            DDTestEqualT((new EquatableT(5), new EquatableT(5)), (5, true, "('Ntt.EquatableT'.IEquatable<T>) [Left = '5'; Right = '5']"));

            DDTestEqualT<ComparableT>((null, null), (6, true, "[Left = null; Right = null]"));
            DDTestEqualT((null, new ComparableT(0)), (7, false, "('ObjectEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestEqualT((new ComparableT(0), null), (8, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestEqualT((new ComparableT(5), new ComparableT(0)), (9, false, "('Ntt.ComparableT'.IComparable<T>) [Left = '5'; Right = '0']"));
            DDTestEqualT((new ComparableT(5), new ComparableT(5)), (10, true, "('Ntt.ComparableT'.IComparable<T>) [Left = '5'; Right = '5']"));

            DDTestEqualT<Comparable>((null, null), (11, true, "[Left = null; Right = null]"));
            DDTestEqualT((null, new Comparable(0)), (12, false, "('ObjectEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestEqualT((new Comparable(0), null), (13, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestEqualT((new Comparable(5), new Comparable(0)), (14, false, "('Ntt.Comparable'.IComparable) [Left = '5'; Right = '0']"));
            DDTestEqualT((new Comparable(5), new Comparable(5)), (15, true, "('Ntt.Comparable'.IComparable) [Left = '5'; Right = '5']"));

            DDTestEqualT<ImplementsNone>((null, null), (16, true, "[Left = null; Right = null]"));
            DDTestEqualT((null, new ImplementsNone(0)), (17, false, "('ObjectEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestEqualT((new ImplementsNone(0), null), (18, false, "('ObjectEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestEqualT((new ImplementsNone(5), new ImplementsNone(0)), (19, false, "('ObjectEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTestEqualT((new ImplementsNone(5), new ImplementsNone(5)), (20, false, "('ObjectEqualityComparer`1') [Left = '5'; Right = '5']"));

        }

        void DDTestEqualT<TType>((TType left, TType right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Values.Equal<{typeof(TType).Print()}>({input.left.Print()}, {input.right.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Values.Equal(input.left, input.right, _file, _method),
                expected, "Test.If.Values.Equal", _file, _method);

        }

        [TestMethod]
        void TestNotEqualIEquatableT() {

            DDTestNotEqualT<EquatableT>((null, null), (1, false, "[Left = null; Right = null]"));
            DDTestNotEqualT((null, new EquatableT(0)), (2, true, "('GenericEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestNotEqualT((new EquatableT(0), null), (3, true, "('GenericEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestNotEqualT((new EquatableT(5), new EquatableT(0)), (4, true, "('Ntt.EquatableT'.IEquatable<T>) [Left = '5'; Right = '0']"));
            DDTestNotEqualT((new EquatableT(5), new EquatableT(5)), (5, false, "('Ntt.EquatableT'.IEquatable<T>) [Left = '5'; Right = '5']"));

            DDTestNotEqualT<ComparableT>((null, null), (6, false, "[Left = null; Right = null]"));
            DDTestNotEqualT((null, new ComparableT(0)), (7, true, "('ObjectEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestNotEqualT((new ComparableT(0), null), (8, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestNotEqualT((new ComparableT(5), new ComparableT(0)), (9, true, "('Ntt.ComparableT'.IComparable<T>) [Left = '5'; Right = '0']"));
            DDTestNotEqualT((new ComparableT(5), new ComparableT(5)), (10, false, "('Ntt.ComparableT'.IComparable<T>) [Left = '5'; Right = '5']"));

            DDTestNotEqualT<Comparable>((null, null), (11, false, "[Left = null; Right = null]"));
            DDTestNotEqualT((null, new Comparable(0)), (12, true, "('ObjectEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestNotEqualT((new Comparable(0), null), (13, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestNotEqualT((new Comparable(5), new Comparable(0)), (14, true, "('Ntt.Comparable'.IComparable) [Left = '5'; Right = '0']"));
            DDTestNotEqualT((new Comparable(5), new Comparable(5)), (15, false, "('Ntt.Comparable'.IComparable) [Left = '5'; Right = '5']"));

            DDTestNotEqualT<ImplementsNone>((null, null), (16, false, "[Left = null; Right = null]"));
            DDTestNotEqualT((null, new ImplementsNone(0)), (17, true, "('ObjectEqualityComparer`1') [Left = null; Right = '0']"));
            DDTestNotEqualT((new ImplementsNone(0), null), (18, true, "('ObjectEqualityComparer`1') [Left = '0'; Right = null]"));
            DDTestNotEqualT((new ImplementsNone(5), new ImplementsNone(0)), (19, true, "('ObjectEqualityComparer`1') [Left = '5'; Right = '0']"));
            DDTestNotEqualT((new ImplementsNone(5), new ImplementsNone(5)), (20, true, "('ObjectEqualityComparer`1') [Left = '5'; Right = '5']"));

        }

        void DDTestNotEqualT<TType>((TType left, TType right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Values.Equal<{typeof(TType).Print()}>({input.left.Print()}, {input.right.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Values.Equal(input.left, input.right, _file, _method),
                expected, "Test.IfNot.Values.Equal", _file, _method);

        }

        #endregion

        #region EqualTEqualityComparerT

        [TestMethod]
        void TestEqualEqualityComparerT() {

            DDTestEqualEqualityComparerT<ImplementsNone>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTestEqualEqualityComparerT((null, new ImplementsNone(0), new TestEqualityComparer()), (2, false, "Comparison threw Exception:"));
            DDTestEqualEqualityComparerT((new ImplementsNone(0), null, new TestEqualityComparer()), (3, false, "Comparison threw Exception:"));
            DDTestEqualEqualityComparerT((new ImplementsNone(0), new ImplementsNone(0), null), (4, false, "Parameter 'comparer' is null."));
            DDTestEqualEqualityComparerT((new ImplementsNone(5), new ImplementsNone(0), new TestEqualityComparer()), (5, false, "('TestEqualityComparer') [Left = '5'; Right = '0']"));
            DDTestEqualEqualityComparerT((new ImplementsNone(5), new ImplementsNone(5), new TestEqualityComparer()), (6, true, "('TestEqualityComparer') [Left = '5'; Right = '5']"));

        }

        void DDTestEqualEqualityComparerT<TType>((TType left, TType right, IEqualityComparer<TType> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Values.Equal<{typeof(TType).Print()}>({input.left.Print()}, {input.right.Print()}, {input.comparer.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Values.Equal(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.If.Values.Equal", _file, _method);

        }

        [TestMethod]
        void TestNotEqualEqualityComparerT() {

            DDTestNotEqualEqualityComparerT<ImplementsNone>((null, null, null), (1, false, "Parameter 'comparer' is null."));
            DDTestNotEqualEqualityComparerT((null, new ImplementsNone(0), new TestEqualityComparer()), (2, false, "Comparison threw Exception:"));
            DDTestNotEqualEqualityComparerT((new ImplementsNone(0), null, new TestEqualityComparer()), (3, false, "Comparison threw Exception:"));
            DDTestNotEqualEqualityComparerT((new ImplementsNone(0), new ImplementsNone(0), null), (4, false, "Parameter 'comparer' is null."));
            DDTestNotEqualEqualityComparerT((new ImplementsNone(5), new ImplementsNone(0), new TestEqualityComparer()), (5, true, "('TestEqualityComparer') [Left = '5'; Right = '0']"));
            DDTestNotEqualEqualityComparerT((new ImplementsNone(5), new ImplementsNone(5), new TestEqualityComparer()), (6, false, "('TestEqualityComparer') [Left = '5'; Right = '5']"));

        }

        void DDTestNotEqualEqualityComparerT<TType>((TType left, TType right, IEqualityComparer<TType> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Values.Equal<{typeof(TType).Print()}>({input.left.Print()}, {input.right.Print()}, {input.comparer.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Values.Equal(input.left, input.right, input.comparer, _file, _method),
                expected, "Test.IfNot.Values.Equal", _file, _method);

        }

        #endregion

        #region single

        [TestMethod]
        void TestEqualSingle() {

            DDTestEqualSingle((1f, 0f), (1, false, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTestEqualSingle((1f, 1f), (2, true, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTestEqualSingle((1e-11f, 1.1e-11f), (3, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTestEqualSingle((1e-12f, 1.1e-12f), (4, true, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTestEqualSingle((1e-11f, 1.1e-11f, 1e-11f), (5, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTestEqualSingle((Single left, Single right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Values.Equal({input.left.Print()}, {input.right.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Values.Equal(input.left, input.right, _file, _method),
                expected, "Test.If.Values.Equal", _file, _method);

        }

        void DDTestEqualSingle((Single left, Single right, Single margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Values.Equal({input.left.Print()}, {input.right.Print()}, {input.margin.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Values.Equal(input.left, input.right, input.margin, _file, _method),
                expected, "Test.If.Values.Equal", _file, _method);

        }

        [TestMethod]
        void TestNotEqualSingle() {

            DDTestNotEqualSingle((1f, 0f), (1, true, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTestNotEqualSingle((1f, 1f), (2, false, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTestNotEqualSingle((1e-11f, 1.1e-11f), (3, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTestNotEqualSingle((1e-12f, 1.1e-12f), (4, false, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTestNotEqualSingle((1e-11f, 1.1e-11f, 1e-11f), (5, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTestNotEqualSingle((Single left, Single right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Values.Equal({input.left.Print()}, {input.right.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Values.Equal(input.left, input.right, _file, _method),
                expected, "Test.IfNot.Values.Equal", _file, _method);

        }

        void DDTestNotEqualSingle((Single left, Single right, Single margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Values.Equal({input.left.Print()}, {input.right.Print()}, {input.margin.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Values.Equal(input.left, input.right, input.margin, _file, _method),
                expected, "Test.IfNot.Values.Equal", _file, _method);

        }

        #endregion

        #region double

        [TestMethod]
        void TestEqualDouble() {

            DDTestEqualDouble((1d, 0d), (1, false, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTestEqualDouble((1d, 1d), (2, true, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTestEqualDouble((1e-11d, 1.1e-11d), (3, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTestEqualDouble((1e-12d, 1.1e-12d), (4, true, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTestEqualDouble((1e-11d, 1.1e-11d, 1e-11d), (5, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTestEqualDouble((Double left, Double right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Values.Equal({input.left.Print()}, {input.right.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Values.Equal(input.left, input.right, _file, _method),
                expected, "Test.If.Values.Equal", _file, _method);

        }

        void DDTestEqualDouble((Double left, Double right, Double margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Values.Equal({input.left.Print()}, {input.right.Print()}, {input.margin.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Values.Equal(input.left, input.right, input.margin, _file, _method),
                expected, "Test.If.Values.Equal", _file, _method);

        }

        [TestMethod]
        void TestNotEqualDouble() {

            DDTestNotEqualDouble((1d, 0d), (1, true, "[Left = '1'; Right = '0'; Margin = '1E-12']"));
            DDTestNotEqualDouble((1d, 1d), (2, false, "[Left = '1'; Right = '1'; Margin = '1E-12']"));
            DDTestNotEqualDouble((1e-11d, 1.1e-11d), (3, true, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-12']"));
            DDTestNotEqualDouble((1e-12d, 1.1e-12d), (4, false, "[Left = '1E-12'; Right = '1.1E-12'; Margin = '1E-12']"));
            DDTestNotEqualDouble((1e-11d, 1.1e-11d, 1e-11d), (5, false, "[Left = '1E-11'; Right = '1.1E-11'; Margin = '1E-11']"));

        }

        void DDTestNotEqualDouble((Double left, Double right) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Values.Equal({input.left.Print()}, {input.right.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Values.Equal(input.left, input.right, _file, _method),
                expected, "Test.IfNot.Values.Equal", _file, _method);

        }

        void DDTestNotEqualDouble((Double left, Double right, Double margin) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Values.Equal({input.left.Print()}, {input.right.Print()}, {input.margin.Print()})",
                _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Values.Equal(input.left, input.right, input.margin, _file, _method),
                expected, "Test.IfNot.Values.Equal", _file, _method);

        }

        #endregion
    }
}
