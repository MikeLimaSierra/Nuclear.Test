using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Ntt;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    class EnumerableTestSuite_uTests {

        #region IsEmpty

        [TestMethod]
        void IsEmpty() {

            DDTIsEmpty(null, (1, false, "Parameter 'enumeration' is null."));
            DDTIsEmpty(Enumerable.Empty<Dummy>(), (2, true, "Enumeration is empty. Enumeration is: []"));
            DDTIsEmpty(new List<Dummy>() { 1, 2, 3 }, (3, false, "Enumeration is not empty. Enumeration is: ['1', '2', '3']"));
            DDTIsEmpty(new List<Dummy>() { 1, null, 3 }, (4, false, "Enumeration is not empty. Enumeration is: ['1', 'null', '3']"));
            DDTIsEmpty(new List<Dummy>() { null, null, }, (5, false, "Enumeration is not empty. Enumeration is: ['null', 'null']"));

            DDTIsEmptyT<Dummy>(null, (6, false, "Parameter 'enumeration' is null."));
            DDTIsEmptyT(Enumerable.Empty<Dummy>(), (7, true, "Enumeration is empty. Enumeration is: []"));
            DDTIsEmptyT(new List<Dummy>() { 1, 2, 3 }, (8, false, "Enumeration is not empty. Enumeration is: ['1', '2', '3']"));
            DDTIsEmptyT(new List<Dummy>() { 1, null, 3 }, (9, false, "Enumeration is not empty. Enumeration is: ['1', 'null', '3']"));
            DDTIsEmptyT(new List<Dummy>() { null, null, }, (10, false, "Enumeration is not empty. Enumeration is: ['null', 'null']"));

        }

        void DDTIsEmpty(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.IsEmpty({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.IsEmpty(input, _file, _method),
                expected, "Test.If.Enumerable.IsEmpty", _file, _method);

        }

        void DDTIsEmptyT<T>(IEnumerable<T> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.IsEmpty<{typeof(T).Format()}>({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.IsEmpty(input, _file, _method),
                expected, "Test.If.Enumerable.IsEmpty", _file, _method);

        }

        [TestMethod]
        void NotIsEmpty() {

            DDTNotIsEmpty(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotIsEmpty(Enumerable.Empty<Dummy>(), (2, false, "Enumeration is empty. Enumeration is: []"));
            DDTNotIsEmpty(new List<Dummy>() { 1, 2, 3 }, (3, true, "Enumeration is not empty. Enumeration is: ['1', '2', '3']"));
            DDTNotIsEmpty(new List<Dummy>() { 1, null, 3 }, (4, true, "Enumeration is not empty. Enumeration is: ['1', 'null', '3']"));
            DDTNotIsEmpty(new List<Dummy>() { null, null, }, (5, true, "Enumeration is not empty. Enumeration is: ['null', 'null']"));

            DDTNotIsEmptyT<Dummy>(null, (6, false, "Parameter 'enumeration' is null."));
            DDTNotIsEmptyT(Enumerable.Empty<Dummy>(), (7, false, "Enumeration is empty. Enumeration is: []"));
            DDTNotIsEmptyT(new List<Dummy>() { 1, 2, 3 }, (8, true, "Enumeration is not empty. Enumeration is: ['1', '2', '3']"));
            DDTNotIsEmptyT(new List<Dummy>() { 1, null, 3 }, (9, true, "Enumeration is not empty. Enumeration is: ['1', 'null', '3']"));
            DDTNotIsEmptyT(new List<Dummy>() { null, null, }, (10, true, "Enumeration is not empty. Enumeration is: ['null', 'null']"));

        }

        void DDTNotIsEmpty(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.IsEmpty({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.IsEmpty(input, _file, _method),
                expected, "Test.IfNot.Enumerable.IsEmpty", _file, _method);

        }

        void DDTNotIsEmptyT<T>(IEnumerable<T> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.IsEmpty<{typeof(T).Format()}>({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.IsEmpty(input, _file, _method),
                expected, "Test.IfNot.Enumerable.IsEmpty", _file, _method);

        }

        #endregion

        #region ContainsNull

        [TestMethod]
        void ContainsNull() {

            DDTContainsNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTContainsNull(Enumerable.Empty<Dummy>(), (2, false, "Enumeration doesn't contain null. Enumeration is: []"));
            DDTContainsNull(new List<Dummy>() { 1, 2, 3 }, (3, false, "Enumeration doesn't contain null. Enumeration is: ['1', '2', '3']"));
            DDTContainsNull(new List<Dummy>() { 1, null, 3 }, (4, true, "Enumeration contains null. Enumeration is: ['1', 'null', '3']"));

            DDTContainsNullT<Dummy>(null, (5, false, "Parameter 'enumeration' is null."));
            DDTContainsNullT(Enumerable.Empty<Dummy>(), (6, false, "Enumeration doesn't contain null. Enumeration is: []"));
            DDTContainsNullT(new List<Dummy>() { 1, 2, 3 }, (7, false, "Enumeration doesn't contain null. Enumeration is: ['1', '2', '3']"));
            DDTContainsNullT(new List<Dummy>() { 1, null, 3 }, (8, true, "Enumeration contains null. Enumeration is: ['1', 'null', '3']"));

        }

        void DDTContainsNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsNull({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsNull(input, _file, _method),
                expected, "Test.If.Enumerable.ContainsNull", _file, _method);

        }

        void DDTContainsNullT<T>(IEnumerable<T> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsNull<{typeof(T).Format()}>({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsNull(input, _file, _method),
                expected, "Test.If.Enumerable.ContainsNull", _file, _method);

        }

        [TestMethod]
        void NotContainsNull() {

            DDTNotContainsNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNull(Enumerable.Empty<Dummy>(), (2, true, "Enumeration doesn't contain null. Enumeration is: []"));
            DDTNotContainsNull(new List<Dummy>() { 1, 2, 3 }, (3, true, "Enumeration doesn't contain null. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsNull(new List<Dummy>() { 1, null, 3 }, (4, false, "Enumeration contains null. Enumeration is: ['1', 'null', '3']"));

            DDTNotContainsNullT<Dummy>(null, (5, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNullT(Enumerable.Empty<Dummy>(), (6, true, "Enumeration doesn't contain null. Enumeration is: []"));
            DDTNotContainsNullT(new List<Dummy>() { 1, 2, 3 }, (7, true, "Enumeration doesn't contain null. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsNullT(new List<Dummy>() { 1, null, 3 }, (8, false, "Enumeration contains null. Enumeration is: ['1', 'null', '3']"));

        }

        void DDTNotContainsNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsNull({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsNull(input, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsNull", _file, _method);

        }

        void DDTNotContainsNullT<T>(IEnumerable<T> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsNull<{typeof(T).Format()}>({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsNull(input, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsNull", _file, _method);

        }

        #endregion

        #region ContainsNonNull

        [TestMethod]
        void ContainsNonNull() {

            DDTContainsNonNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTContainsNonNull(Enumerable.Empty<Dummy>(), (2, false, "Enumeration doesn't contain a non null value. Enumeration is: []"));
            DDTContainsNonNull(new List<Dummy>() { 1, 2, 3 }, (3, true, "Enumeration contains a non null value. Enumeration is: ['1', '2', '3']"));
            DDTContainsNonNull(new List<Dummy>() { 1, null, 3 }, (4, true, "Enumeration contains a non null value. Enumeration is: ['1', 'null', '3']"));
            DDTContainsNonNull(new List<Dummy>() { null }, (5, false, "Enumeration doesn't contain a non null value. Enumeration is: ['null']"));

            DDTContainsNonNullT<Dummy>(null, (6, false, "Parameter 'enumeration' is null."));
            DDTContainsNonNullT(Enumerable.Empty<Dummy>(), (7, false, "Enumeration doesn't contain a non null value. Enumeration is: []"));
            DDTContainsNonNullT(new List<Dummy>() { 1, 2, 3 }, (8, true, "Enumeration contains a non null value. Enumeration is: ['1', '2', '3']"));
            DDTContainsNonNullT(new List<Dummy>() { 1, null, 3 }, (9, true, "Enumeration contains a non null value. Enumeration is: ['1', 'null', '3']"));
            DDTContainsNonNullT(new List<Dummy>() { null }, (10, false, "Enumeration doesn't contain a non null value. Enumeration is: ['null']"));

        }

        void DDTContainsNonNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsNonNull({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsNonNull(input, _file, _method),
                expected, "Test.If.Enumerable.ContainsNonNull", _file, _method);

        }

        void DDTContainsNonNullT<T>(IEnumerable<T> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsNonNull<{typeof(T).Format()}>({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsNonNull(input, _file, _method),
                expected, "Test.If.Enumerable.ContainsNonNull", _file, _method);

        }

        [TestMethod]
        void NotContainsNonNull() {

            DDTNotContainsNonNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNonNull(Enumerable.Empty<Dummy>(), (2, true, "Enumeration doesn't contain a non null value. Enumeration is: []"));
            DDTNotContainsNonNull(new List<Dummy>() { 1, 2, 3 }, (3, false, "Enumeration contains a non null value. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsNonNull(new List<Dummy>() { 1, null, 3 }, (4, false, "Enumeration contains a non null value. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsNonNull(new List<Dummy>() { null }, (5, true, "Enumeration doesn't contain a non null value. Enumeration is: ['null']"));

            DDTNotContainsNonNullT<Dummy>(null, (6, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNonNullT(Enumerable.Empty<Dummy>(), (7, true, "Enumeration doesn't contain a non null value. Enumeration is: []"));
            DDTNotContainsNonNullT(new List<Dummy>() { 1, 2, 3 }, (8, false, "Enumeration contains a non null value. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsNonNullT(new List<Dummy>() { 1, null, 3 }, (9, false, "Enumeration contains a non null value. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsNonNullT(new List<Dummy>() { null }, (10, true, "Enumeration doesn't contain a non null value. Enumeration is: ['null']"));

        }

        void DDTNotContainsNonNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsNonNull({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsNonNull(input, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsNonNull", _file, _method);

        }

        void DDTNotContainsNonNullT<T>(IEnumerable<T> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsNonNull<{typeof(T).Format()}>({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsNonNull(input, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsNonNull", _file, _method);

        }

        #endregion

        #region Contains

        [TestMethod]
        void Contains() {

            DDTContains((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContains((null, 1), (2, false, "Parameter 'enumeration' is null."));
            DDTContains((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (3, false, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTContains((new List<DummyIEquatableT>() { 1, null, 3 }, null), (4, true, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTContains((new List<DummyIEquatableT>() { 1, 2, 3 }, (DummyIEquatableT) 2), (5, true, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTContains((new List<DummyIEquatableT>() { 1, 2, 3 }, (DummyIEquatableT) 4), (6, false, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

            DDTContainsT<DummyIEquatableT>((null, null), (7, false, "Parameter 'enumeration' is null."));
            DDTContainsT<DummyIEquatableT>((null, 1), (8, false, "Parameter 'enumeration' is null."));
            DDTContainsT((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (9, false, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTContainsT((new List<DummyIEquatableT>() { 1, null, 3 }, null), (10, true, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTContainsT((new List<DummyIEquatableT>() { 1, 2, 3 }, 2), (11, true, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTContainsT((new List<DummyIEquatableT>() { 1, 2, 3 }, 4), (12, false, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

        }

        void DDTContains((IEnumerable enumeration, Object element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Contains({input.enumeration.Format()}, {input.element.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.If.Enumerable.Contains", _file, _method);

        }

        void DDTContainsT<T>((IEnumerable<T> enumeration, T element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Contains<{typeof(T).Format()}>({input.enumeration.Format()}, {input.element.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.If.Enumerable.Contains", _file, _method);

        }

        [TestMethod]
        void NotContains() {

            DDTNotContains((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContains((null, 1), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContains((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (3, true, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTNotContains((new List<DummyIEquatableT>() { 1, null, 3 }, null), (4, false, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTNotContains((new List<DummyIEquatableT>() { 1, 2, 3 }, (DummyIEquatableT) 2), (5, false, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTNotContains((new List<DummyIEquatableT>() { 1, 2, 3 }, (DummyIEquatableT) 4), (6, true, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

            DDTNotContainsT<DummyIEquatableT>((null, null), (7, false, "Parameter 'enumeration' is null."));
            DDTNotContainsT<DummyIEquatableT>((null, 1), (8, false, "Parameter 'enumeration' is null."));
            DDTNotContainsT((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (9, true, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsT((new List<DummyIEquatableT>() { 1, null, 3 }, null), (10, false, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsT((new List<DummyIEquatableT>() { 1, 2, 3 }, 2), (11, false, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsT((new List<DummyIEquatableT>() { 1, 2, 3 }, 4), (12, true, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

        }

        void DDTNotContains((IEnumerable enumeration, Object element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Contains({input.enumeration.Format()}, {input.element.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.IfNot.Enumerable.Contains", _file, _method);

        }

        void DDTNotContainsT<T>((IEnumerable<T> enumeration, T element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Contains<{typeof(T).Format()}>({input.enumeration.Format()}, {input.element.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.IfNot.Enumerable.Contains", _file, _method);

        }

        #endregion

        #region ContainsComparer

        [TestMethod]
        void ContainsWithComparer() {

            DDTContainsWithComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContainsWithComparer((null, 1, new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, null, new DummyEqualityComparer()), (3, false, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, null), (4, false, "Parameter 'comparer' is null."));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));
            DDTContainsWithComparer((new List<Dummy>() { 1, null, 3 }, null, new DummyEqualityComparer()), (6, true, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 2, new DummyEqualityComparer()), (7, true, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 4, new DummyEqualityComparer()), (8, false, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

            DDTContainsWithComparer((null, null, null), (9, false, "Parameter 'enumeration' is null."));
            DDTContainsWithComparer((null, 1, new DummyIEqualityComparer()), (10, false, "Parameter 'enumeration' is null."));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, null, new DummyIEqualityComparer()), (11, false, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, (IEqualityComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (13, false, "Comparer threw Exception:"));
            DDTContainsWithComparer((new List<Dummy>() { 1, null, 3 }, null, new DummyIEqualityComparer()), (14, true, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, (Dummy) 2, new DummyIEqualityComparer()), (15, true, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, (Dummy) 4, new DummyIEqualityComparer()), (16, false, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

            DDTContainsWithComparer((null, null, (IEqualityComparer<Dummy>) null), (17, false, "Parameter 'enumeration' is null."));
            DDTContainsWithComparer((null, 1, new DummyIEqualityComparerT()), (18, false, "Parameter 'enumeration' is null."));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, null, new DummyIEqualityComparerT()), (19, false, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, (IEqualityComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (21, false, "Comparer threw Exception:"));
            DDTContainsWithComparer((new List<Dummy>() { 1, null, 3 }, null, new DummyIEqualityComparerT()), (22, true, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 2, new DummyIEqualityComparerT()), (23, true, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 4, new DummyIEqualityComparerT()), (24, false, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

        }

        void DDTContainsWithComparer<T>((IEnumerable<T> enumeration, T element, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Contains({input.enumeration.Format()}, {input.element.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Contains(input.enumeration, input.element, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.Contains", _file, _method);

        }

        void DDTContainsWithComparer((IEnumerable enumeration, Object element, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Contains({input.enumeration.Format()}, {input.element.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Contains(input.enumeration, input.element, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.Contains", _file, _method);

        }

        void DDTContainsWithComparer<T>((IEnumerable<T> enumeration, T element, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Contains<{typeof(T).Format()}>({input.enumeration.Format()}, {input.element.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Contains(input.enumeration, input.element, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.Contains", _file, _method);

        }

        [TestMethod]
        void NotContainsWithComparer() {

            DDTNotContainsWithComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithComparer((null, 1, new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, null, new DummyEqualityComparer()), (3, true, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, null), (4, false, "Parameter 'comparer' is null."));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, null, 3 }, null, new DummyEqualityComparer()), (6, false, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 2, new DummyEqualityComparer()), (7, false, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 4, new DummyEqualityComparer()), (8, true, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

            DDTNotContainsWithComparer((null, null, null), (9, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithComparer((null, 1, new DummyIEqualityComparer()), (10, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, null, new DummyIEqualityComparer()), (11, true, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, (IEqualityComparer) null), (12, false, "Parameter 'comparer' is null."));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (13, false, "Comparer threw Exception:"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, null, 3 }, null, new DummyIEqualityComparer()), (14, false, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, (Dummy) 2, new DummyIEqualityComparer()), (15, false, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, (Dummy) 4, new DummyIEqualityComparer()), (16, true, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

            DDTNotContainsWithComparer((null, null, (IEqualityComparer<Dummy>) null), (17, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithComparer((null, 1, new DummyIEqualityComparerT()), (18, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, null, new DummyIEqualityComparerT()), (19, true, "Enumeration doesn't contain element 'null'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, (IEqualityComparer<Dummy>) null), (20, false, "Parameter 'comparer' is null."));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 1, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (21, false, "Comparer threw Exception:"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, null, 3 }, null, new DummyIEqualityComparerT()), (22, false, "Enumeration contains element 'null'. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 2, new DummyIEqualityComparerT()), (23, false, "Enumeration contains element '2'. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithComparer((new List<Dummy>() { 1, 2, 3 }, 4, new DummyIEqualityComparerT()), (24, true, "Enumeration doesn't contain element '4'. Enumeration is: ['1', '2', '3']"));

        }

        void DDTNotContainsWithComparer<T>((IEnumerable<T> enumeration, T element, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Contains({input.enumeration.Format()}, {input.element.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Contains(input.enumeration, input.element, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.Contains", _file, _method);

        }

        void DDTNotContainsWithComparer((IEnumerable enumeration, Object element, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Contains({input.enumeration.Format()}, {input.element.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Contains(input.enumeration, input.element, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.Contains", _file, _method);

        }

        void DDTNotContainsWithComparer<T>((IEnumerable<T> enumeration, T element, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Contains<{typeof(T).Format()}>({input.enumeration.Format()}, {input.element.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Contains(input.enumeration, input.element, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.Contains", _file, _method);

        }

        #endregion

        #region ContainsFilter

        [TestMethod]
        void ContainsWithFilter() {

            DDTContainsWithFilter((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContainsWithFilter((null, new Predicate<Object>((_) => true)), (2, false, "Parameter 'enumeration' is null."));
            DDTContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (3, false, "Parameter 'predicate' is null."));
            DDTContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => _ == null)), (4, false, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithFilter((new List<DummyIEquatableT>() { 1, null, 3 }, new Predicate<Object>((_) => _ == null)), (5, true, "Enumeration contains a matching element. Enumeration is: ['1', 'null', '3']"));
            DDTContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => _ as DummyIEquatableT == 2)), (6, true, "Enumeration contains a matching element. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => _ as DummyIEquatableT == 4)), (7, false, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => throw new Exception("test"))), (8, false, "Predicate threw Exception: 'test'"));

            DDTContainsWithFilterT<DummyIEquatableT>((null, null), (9, false, "Parameter 'enumeration' is null."));
            DDTContainsWithFilterT((null, new Predicate<DummyIEquatableT>((_) => true)), (10, false, "Parameter 'enumeration' is null."));
            DDTContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (11, false, "Parameter 'predicate' is null."));
            DDTContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => _ == null)), (12, false, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithFilterT((new List<DummyIEquatableT>() { 1, null, 3 }, new Predicate<DummyIEquatableT>((_) => _ == null)), (13, true, "Enumeration contains a matching element. Enumeration is: ['1', 'null', '3']"));
            DDTContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => _ == 2)), (14, true, "Enumeration contains a matching element. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => _ == 4)), (15, false, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => throw new Exception("test"))), (16, false, "Predicate threw Exception: 'test'"));

        }

        void DDTContainsWithFilter((IEnumerable enumeration, Predicate<Object> predicate) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Contains({input.enumeration.Format()}, {input.predicate.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Contains(input.enumeration, input.predicate, _file, _method),
                expected, "Test.If.Enumerable.Contains", _file, _method);

        }

        void DDTContainsWithFilterT<T>((IEnumerable<T> enumeration, Predicate<T> predicate) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Contains<{typeof(T).Format()}>({input.enumeration.Format()}, {input.predicate.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Contains(input.enumeration, input.predicate, _file, _method),
                expected, "Test.If.Enumerable.Contains", _file, _method);

        }

        [TestMethod]
        void NotContainsWithFilter() {

            DDTNotContainsWithFilter((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithFilter((null, new Predicate<Object>((_) => true)), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (3, false, "Parameter 'predicate' is null."));
            DDTNotContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => _ == null)), (4, true, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithFilter((new List<DummyIEquatableT>() { 1, null, 3 }, new Predicate<Object>((_) => _ == null)), (5, false, "Enumeration contains a matching element. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => _ as DummyIEquatableT == 2)), (6, false, "Enumeration contains a matching element. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => _ as DummyIEquatableT == 4)), (7, true, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithFilter((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<Object>((_) => throw new Exception("test"))), (8, false, "Predicate threw Exception: 'test'"));

            DDTNotContainsWithFilterT<DummyIEquatableT>((null, null), (9, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithFilterT((null, new Predicate<DummyIEquatableT>((_) => true)), (10, false, "Parameter 'enumeration' is null."));
            DDTNotContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, null), (11, false, "Parameter 'predicate' is null."));
            DDTNotContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => _ == null)), (12, true, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithFilterT((new List<DummyIEquatableT>() { 1, null, 3 }, new Predicate<DummyIEquatableT>((_) => _ == null)), (13, false, "Enumeration contains a matching element. Enumeration is: ['1', 'null', '3']"));
            DDTNotContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => _ == 2)), (14, false, "Enumeration contains a matching element. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => _ == 4)), (15, true, "Enumeration doesn't contain a matching element. Enumeration is: ['1', '2', '3']"));
            DDTNotContainsWithFilterT((new List<DummyIEquatableT>() { 1, 2, 3 }, new Predicate<DummyIEquatableT>((_) => throw new Exception("test"))), (16, false, "Predicate threw Exception: 'test'"));

        }

        void DDTNotContainsWithFilter((IEnumerable enumeration, Predicate<Object> predicate) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Contains({input.enumeration.Format()}, {input.predicate.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Contains(input.enumeration, input.predicate, _file, _method),
                expected, "Test.IfNot.Enumerable.Contains", _file, _method);

        }

        void DDTNotContainsWithFilterT<T>((IEnumerable<T> enumeration, Predicate<T> predicate) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Contains<{typeof(T).Format()}>({input.enumeration.Format()}, {input.predicate.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Contains(input.enumeration, input.predicate, _file, _method),
                expected, "Test.IfNot.Enumerable.Contains", _file, _method);

        }

        #endregion

        #region ContainsRange

        [TestMethod]
        void ContainsRange() {

            DDTContainsRange((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContainsRange((null, new List<DummyIEquatableT>()), (2, false, "Parameter 'enumeration' is null."));
            DDTContainsRange((new List<DummyIEquatableT>(), null), (3, false, "Parameter 'elements' is null."));

            DDTContainsRange((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { }), (4, true, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTContainsRange((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { 1, 2, 3 }), (5, false, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { }), (6, true, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1 }), (7, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 1 }), (8, true, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 2, 4 }), (9, false, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTContainsRange((new List<DummyIEquatableT>() { 1, 1, 3 }, new List<DummyIEquatableT>() { 1 }), (10, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

            DDTContainsRangeT<DummyIEquatableT>((null, null), (11, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeT((null, new List<DummyIEquatableT>()), (12, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeT((new List<DummyIEquatableT>(), null), (13, false, "Parameter 'elements' is null."));

            DDTContainsRangeT((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { }), (14, true, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTContainsRangeT((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { 1, 2, 3 }), (15, false, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { }), (16, true, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1 }), (17, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 1 }), (18, true, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 2, 4 }), (19, false, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTContainsRangeT((new List<DummyIEquatableT>() { 1, 1, 3 }, new List<DummyIEquatableT>() { 1 }), (20, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

        }

        void DDTContainsRange((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsRange({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumerable.ContainsRange", _file, _method);

        }

        void DDTContainsRangeT<T>((IEnumerable<T> enumeration, IEnumerable<T> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsRange<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumerable.ContainsRange", _file, _method);

        }

        [TestMethod]
        void NotContainsRange() {

            DDTNotContainsRange((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRange((null, new List<DummyIEquatableT>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRange((new List<DummyIEquatableT>(), null), (3, false, "Parameter 'elements' is null."));

            DDTNotContainsRange((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { }), (4, false, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTNotContainsRange((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { 1, 2, 3 }), (5, true, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTNotContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { }), (6, false, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTNotContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1 }), (7, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTNotContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 1 }), (8, false, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTNotContainsRange((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 2, 4 }), (9, true, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTNotContainsRange((new List<DummyIEquatableT>() { 1, 1, 3 }, new List<DummyIEquatableT>() { 1 }), (10, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

            DDTNotContainsRangeT<DummyIEquatableT>((null, null), (11, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeT((null, new List<DummyIEquatableT>()), (12, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeT((new List<DummyIEquatableT>(), null), (13, false, "Parameter 'elements' is null."));

            DDTNotContainsRangeT((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { }), (14, false, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTNotContainsRangeT((new List<DummyIEquatableT>() { }, new List<DummyIEquatableT>() { 1, 2, 3 }), (15, true, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTNotContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { }), (16, false, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTNotContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1 }), (17, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTNotContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 1 }), (18, false, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTNotContainsRangeT((new List<DummyIEquatableT>() { 1, 2, 3 }, new List<DummyIEquatableT>() { 1, 2, 4 }), (19, true, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTNotContainsRangeT((new List<DummyIEquatableT>() { 1, 1, 3 }, new List<DummyIEquatableT>() { 1 }), (20, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

        }

        void DDTNotContainsRange((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsRange({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsRange", _file, _method);

        }

        void DDTNotContainsRangeT<T>((IEnumerable<T> enumeration, IEnumerable<T> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsRange<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsRange", _file, _method);

        }

        #endregion

        #region ContainsRangeComparer

        [TestMethod]
        void ContainsRangeComparer() {

            DDTContainsRangeComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeComparer((null, new List<Dummy>(), new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeComparer((new List<Dummy>(), null, new DummyEqualityComparer()), (3, false, "Parameter 'elements' is null."));
            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), null), (4, false, "Parameter 'comparer' is null."));
            DDTContainsRangeComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));

            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), new DummyEqualityComparer()), (6, true, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>() { 1, 2, 3 }, new DummyEqualityComparer()), (7, false, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>(), new DummyEqualityComparer()), (8, true, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (9, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 1 }, new DummyEqualityComparer()), (10, true, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 2, 4 }, new DummyEqualityComparer()), (11, false, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 1, 3 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (12, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

            DDTContainsRangeComparer((null, null, null), (13, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeComparer((null, new List<Dummy>(), new DummyIEqualityComparer()), (14, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeComparer((new List<Dummy>(), null, new DummyIEqualityComparer()), (15, false, "Parameter 'elements' is null."));
            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer) null), (16, false, "Parameter 'comparer' is null."));
            DDTContainsRangeComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (17, false, "Comparer threw Exception:"));

            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), new DummyIEqualityComparer()), (18, true, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>() { 1, 2, 3 }, new DummyIEqualityComparer()), (19, false, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { }, new DummyIEqualityComparer()), (20, true, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (21, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 1 }, new DummyIEqualityComparer()), (22, true, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 2, 4 }, new DummyIEqualityComparer()), (23, false, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 1, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (24, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

            DDTContainsRangeComparer((null, null, (IEqualityComparer<Dummy>) null), (25, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeComparer((null, new List<Dummy>(), new DummyIEqualityComparerT()), (26, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeComparer((new List<Dummy>(), null, new DummyIEqualityComparerT()), (27, false, "Parameter 'elements' is null."));
            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer<Dummy>) null), (28, false, "Parameter 'comparer' is null."));
            DDTContainsRangeComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (29, false, "Comparer threw Exception:"));

            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), new DummyIEqualityComparerT()), (30, true, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTContainsRangeComparer((new List<Dummy>(), new List<Dummy>() { 1, 2, 3 }, new DummyIEqualityComparerT()), (31, false, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { }, new DummyIEqualityComparerT()), (32, true, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (33, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 1 }, new DummyIEqualityComparerT()), (34, true, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 2, 4 }, new DummyIEqualityComparerT()), (35, false, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTContainsRangeComparer((new List<Dummy>() { 1, 1, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (36, true, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

        }

        void DDTContainsRangeComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsRange<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsRange(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.ContainsRange", _file, _method);

        }

        void DDTContainsRangeComparer((IEnumerable enumeration, IEnumerable elements, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsRange({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsRange(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.ContainsRange", _file, _method);

        }

        void DDTContainsRangeComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.ContainsRange<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.ContainsRange(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.ContainsRange", _file, _method);

        }

        [TestMethod]
        void NotContainsRangeComparer() {

            DDTNotContainsRangeComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeComparer((null, new List<Dummy>(), new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>(), null, new DummyEqualityComparer()), (3, false, "Parameter 'elements' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), null), (4, false, "Parameter 'comparer' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));

            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), new DummyEqualityComparer()), (6, false, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>() { 1, 2, 3 }, new DummyEqualityComparer()), (7, true, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>(), new DummyEqualityComparer()), (8, false, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (9, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 1 }, new DummyEqualityComparer()), (10, false, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 2, 4 }, new DummyEqualityComparer()), (11, true, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 1, 3 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (12, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

            DDTNotContainsRangeComparer((null, null, null), (13, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeComparer((null, new List<Dummy>(), new DummyIEqualityComparer()), (14, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>(), null, new DummyIEqualityComparer()), (15, false, "Parameter 'elements' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer) null), (16, false, "Parameter 'comparer' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (17, false, "Comparer threw Exception:"));

            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), new DummyIEqualityComparer()), (18, false, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>() { 1, 2, 3 }, new DummyIEqualityComparer()), (19, true, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { }, new DummyIEqualityComparer()), (20, false, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (21, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 1 }, new DummyIEqualityComparer()), (22, false, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 2, 4 }, new DummyIEqualityComparer()), (23, true, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 1, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (24, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

            DDTNotContainsRangeComparer((null, null, (IEqualityComparer<Dummy>) null), (25, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeComparer((null, new List<Dummy>(), new DummyIEqualityComparerT()), (26, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>(), null, new DummyIEqualityComparerT()), (27, false, "Parameter 'elements' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer<Dummy>) null), (28, false, "Parameter 'comparer' is null."));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (29, false, "Comparer threw Exception:"));

            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>(), new DummyIEqualityComparerT()), (30, false, "Enumeration contains 0 of 0 elements. Enumeration is: []; Elements are: []"));
            DDTNotContainsRangeComparer((new List<Dummy>(), new List<Dummy>() { 1, 2, 3 }, new DummyIEqualityComparerT()), (31, true, "Enumeration contains 0 of 3 elements. Enumeration is: []; Elements are: ['1', '2', '3']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { }, new DummyIEqualityComparerT()), (32, false, "Enumeration contains 0 of 0 elements. Enumeration is: ['1', '2', '3']; Elements are: []"));

            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (33, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 1 }, new DummyIEqualityComparerT()), (34, false, "Enumeration contains 2 of 2 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '1']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 2, 3 }, new List<Dummy>() { 1, 2, 4 }, new DummyIEqualityComparerT()), (35, true, "Enumeration contains 2 of 3 elements. Enumeration is: ['1', '2', '3']; Elements are: ['1', '2', '4']"));
            DDTNotContainsRangeComparer((new List<Dummy>() { 1, 1, 3 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (36, false, "Enumeration contains 1 of 1 elements. Enumeration is: ['1', '1', '3']; Elements are: ['1']"));

        }

        void DDTNotContainsRangeComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsRange<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsRange(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsRange", _file, _method);

        }

        void DDTNotContainsRangeComparer((IEnumerable enumeration, IEnumerable elements, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsRange({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsRange(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsRange", _file, _method);

        }

        void DDTNotContainsRangeComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.ContainsRange<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.ContainsRange(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.ContainsRange", _file, _method);

        }

        #endregion

        #region Matches

        [TestMethod]
        void Matches() {

            DDTMatches((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatches((null, new List<DummyIEquatableT>()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatches((new List<DummyIEquatableT>(), null), (3, false, "Parameter 'other' is null."));

            DDTMatches((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (4, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (5, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (6, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (7, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (8, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (9, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (10, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (11, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (12, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatches((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (13, true, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTMatchesT<DummyIEquatableT>((null, null), (14, false, "Parameter 'enumeration' is null."));
            DDTMatchesT((null, new List<DummyIEquatableT>()), (15, false, "Parameter 'enumeration' is null."));
            DDTMatchesT((new List<DummyIEquatableT>(), null), (16, false, "Parameter 'other' is null."));

            DDTMatchesT((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (17, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (18, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (19, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (20, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (21, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (22, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (23, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (24, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (25, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesT((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (26, true, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTMatches((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Matches({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumerable.Matches", _file, _method);

        }

        void DDTMatchesT<T>((IEnumerable<T> enumeration, IEnumerable<T> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Matches<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumerable.Matches", _file, _method);

        }

        [TestMethod]
        void NotMatches() {

            DDTNotMatches((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatches((null, new List<DummyIEquatableT>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatches((new List<DummyIEquatableT>(), null), (3, false, "Parameter 'other' is null."));

            DDTNotMatches((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (4, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (5, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (6, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (7, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (8, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (9, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (10, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (11, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (12, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatches((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (13, false, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTNotMatchesT<DummyIEquatableT>((null, null), (14, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesT((null, new List<DummyIEquatableT>()), (15, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesT((new List<DummyIEquatableT>(), null), (16, false, "Parameter 'other' is null."));

            DDTNotMatchesT((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (17, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (18, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (19, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (20, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (21, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (22, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (23, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (24, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (25, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesT((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (26, false, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTNotMatches((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Matches({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumerable.Matches", _file, _method);

        }

        void DDTNotMatchesT<T>((IEnumerable<T> enumeration, IEnumerable<T> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Matches<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumerable.Matches", _file, _method);

        }

        #endregion

        #region MatchesComparer

        [TestMethod]
        void MatchesComparer() {

            DDTMatchesComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatchesComparer((null, new List<Dummy>(), new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatchesComparer((new List<Dummy>(), null, new DummyEqualityComparer()), (3, false, "Parameter 'other' is null."));
            DDTMatchesComparer((new List<Dummy>(), new List<Dummy>(), null), (4, false, "Parameter 'comparer' is null."));
            DDTMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));

            DDTMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (6, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyEqualityComparer()), (7, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (8, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (9, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (10, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (11, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyEqualityComparer()), (12, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyEqualityComparer()), (13, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (14, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (15, true, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTMatchesComparer((null, null, null), (16, false, "Parameter 'enumeration' is null."));
            DDTMatchesComparer((null, new List<Dummy>(), new DummyIEqualityComparer()), (17, false, "Parameter 'enumeration' is null."));
            DDTMatchesComparer((new List<Dummy>(), null, new DummyIEqualityComparer()), (18, false, "Parameter 'other' is null."));
            DDTMatchesComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer) null), (19, false, "Parameter 'comparer' is null."));
            DDTMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (20, false, "Comparer threw Exception:"));

            DDTMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (21, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparer()), (22, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (23, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (24, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (25, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (26, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparer()), (27, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparer()), (28, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (29, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (30, true, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTMatchesComparer((null, null, (IEqualityComparer<Dummy>) null), (31, false, "Parameter 'enumeration' is null."));
            DDTMatchesComparer((null, new List<Dummy>(), new DummyIEqualityComparerT()), (32, false, "Parameter 'enumeration' is null."));
            DDTMatchesComparer((new List<Dummy>(), null, new DummyIEqualityComparerT()), (33, false, "Parameter 'other' is null."));
            DDTMatchesComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer<Dummy>) null), (34, false, "Parameter 'comparer' is null."));
            DDTMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (35, false, "Comparer threw Exception:"));

            DDTMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (36, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparerT()), (37, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (38, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (39, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (40, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (41, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparerT()), (42, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparerT()), (43, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (44, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (45, true, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTMatchesComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Matches<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Matches(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.Matches", _file, _method);

        }

        void DDTMatchesComparer((IEnumerable enumeration, IEnumerable elements, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Matches({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Matches(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.Matches", _file, _method);

        }

        void DDTMatchesComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.Matches<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.Matches(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.Matches", _file, _method);

        }

        [TestMethod]
        void NotMatchesComparer() {

            DDTNotMatchesComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesComparer((null, new List<Dummy>(), new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesComparer((new List<Dummy>(), null, new DummyEqualityComparer()), (3, false, "Parameter 'other' is null."));
            DDTNotMatchesComparer((new List<Dummy>(), new List<Dummy>(), null), (4, false, "Parameter 'comparer' is null."));
            DDTNotMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));

            DDTNotMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (6, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyEqualityComparer()), (7, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (8, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (9, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (10, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (11, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyEqualityComparer()), (12, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyEqualityComparer()), (13, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (14, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (15, false, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTNotMatchesComparer((null, null, null), (16, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesComparer((null, new List<Dummy>(), new DummyIEqualityComparer()), (17, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesComparer((new List<Dummy>(), null, new DummyIEqualityComparer()), (18, false, "Parameter 'other' is null."));
            DDTNotMatchesComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer) null), (19, false, "Parameter 'comparer' is null."));
            DDTNotMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (20, false, "Comparer threw Exception:"));

            DDTNotMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (21, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparer()), (22, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (23, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (24, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (25, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (26, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparer()), (27, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparer()), (28, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (29, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (30, false, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTNotMatchesComparer((null, null, (IEqualityComparer<Dummy>) null), (31, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesComparer((null, new List<Dummy>(), new DummyIEqualityComparerT()), (32, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesComparer((new List<Dummy>(), null, new DummyIEqualityComparerT()), (33, false, "Parameter 'other' is null."));
            DDTNotMatchesComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer<Dummy>) null), (34, false, "Parameter 'comparer' is null."));
            DDTNotMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (35, false, "Comparer threw Exception:"));

            DDTNotMatchesComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (36, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparerT()), (37, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (38, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (39, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (40, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (41, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparerT()), (42, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparerT()), (43, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (44, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (45, false, "Enumerations match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTNotMatchesComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Matches<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Matches(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.Matches", _file, _method);

        }

        void DDTNotMatchesComparer((IEnumerable enumeration, IEnumerable elements, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Matches({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Matches(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.Matches", _file, _method);

        }

        void DDTNotMatchesComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.Matches<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.Matches(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.Matches", _file, _method);

        }

        #endregion

        #region MatchesExactly

        [TestMethod]
        void MatchesExactly() {

            DDTMatchesExactly((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactly((null, new List<DummyIEquatableT>()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactly((new List<DummyIEquatableT>(), null), (3, false, "Parameter 'other' is null."));

            DDTMatchesExactly((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (4, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (5, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (6, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (7, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (8, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (9, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (10, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (11, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (12, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesExactly((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (13, false, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTMatchesExactlyT<DummyIEquatableT>((null, null), (14, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyT((null, new List<DummyIEquatableT>()), (15, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyT((new List<DummyIEquatableT>(), null), (16, false, "Parameter 'other' is null."));

            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (17, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (18, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (19, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (20, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (21, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (22, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (23, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (24, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (25, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesExactlyT((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (26, false, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTMatchesExactly((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.MatchesExactly({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumerable.MatchesExactly", _file, _method);

        }

        void DDTMatchesExactlyT<T>((IEnumerable<T> enumeration, IEnumerable<T> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.MatchesExactly<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumerable.MatchesExactly", _file, _method);

        }

        [TestMethod]
        void NotMatchesExactly() {

            DDTNotMatchesExactly((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactly((null, new List<DummyIEquatableT>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactly((new List<DummyIEquatableT>(), null), (3, false, "Parameter 'other' is null."));

            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (4, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (5, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (6, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (7, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (8, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (9, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (10, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (11, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (12, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesExactly((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (13, true, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTNotMatchesExactlyT<DummyIEquatableT>((null, null), (14, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyT((null, new List<DummyIEquatableT>()), (15, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>(), null), (16, false, "Parameter 'other' is null."));

            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1 }, new List<DummyIEquatableT>() { 1 }), (17, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 2, 1 }), (18, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (19, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2 }), (20, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (21, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 1, 2 }), (22, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 1 }), (23, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, 1, 2 }, new List<DummyIEquatableT>() { 1, 2, 2 }), (24, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, null, null, 2 }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (25, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesExactlyT((new List<DummyIEquatableT>() { 1, null, 2, null }, new List<DummyIEquatableT>() { 1, null, null, 2 }), (26, true, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTNotMatchesExactly((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.MatchesExactly({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumerable.MatchesExactly", _file, _method);

        }

        void DDTNotMatchesExactlyT<T>((IEnumerable<T> enumeration, IEnumerable<T> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.MatchesExactly<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumerable.MatchesExactly", _file, _method);

        }

        #endregion

        #region MatchesExactlyComparer

        [TestMethod]
        void MatchesExactlyComparer() {

            DDTMatchesExactlyComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyComparer((null, new List<Dummy>(), new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>(), null, new DummyEqualityComparer()), (3, false, "Parameter 'other' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>(), new List<Dummy>(), null), (4, false, "Parameter 'comparer' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));

            DDTMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (6, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyEqualityComparer()), (7, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (8, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (9, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (10, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (11, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyEqualityComparer()), (12, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyEqualityComparer()), (13, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (14, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (15, false, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTMatchesExactlyComparer((null, null, null), (16, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyComparer((null, new List<Dummy>(), new DummyIEqualityComparer()), (17, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>(), null, new DummyIEqualityComparer()), (18, false, "Parameter 'other' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer) null), (19, false, "Parameter 'comparer' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (20, false, "Comparer threw Exception:"));

            DDTMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (21, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparer()), (22, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (23, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (24, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (25, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (26, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparer()), (27, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparer()), (28, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (29, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (30, false, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTMatchesExactlyComparer((null, null, (IEqualityComparer<Dummy>) null), (31, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyComparer((null, new List<Dummy>(), new DummyIEqualityComparerT()), (32, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>(), null, new DummyIEqualityComparerT()), (33, false, "Parameter 'other' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer<Dummy>) null), (34, false, "Parameter 'comparer' is null."));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (35, false, "Comparer threw Exception:"));

            DDTMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (36, true, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparerT()), (37, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (38, true, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (39, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (40, false, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (41, true, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparerT()), (42, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparerT()), (43, false, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (44, true, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTMatchesExactlyComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (45, false, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTMatchesExactlyComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.MatchesExactly<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.MatchesExactly(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.MatchesExactly", _file, _method);

        }

        void DDTMatchesExactlyComparer((IEnumerable enumeration, IEnumerable elements, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.MatchesExactly({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.MatchesExactly(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.MatchesExactly", _file, _method);

        }

        void DDTMatchesExactlyComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumerable.MatchesExactly<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumerable.MatchesExactly(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.If.Enumerable.MatchesExactly", _file, _method);

        }

        [TestMethod]
        void NotMatchesExactlyComparer() {

            DDTNotMatchesExactlyComparer<Dummy>((null, null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyComparer((null, new List<Dummy>(), new DummyEqualityComparer()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>(), null, new DummyEqualityComparer()), (3, false, "Parameter 'other' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>(), new List<Dummy>(), null), (4, false, "Parameter 'comparer' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new ThrowingEqualityComparer()), (5, false, "Comparer threw Exception:"));

            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyEqualityComparer()), (6, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyEqualityComparer()), (7, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (8, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyEqualityComparer()), (9, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (10, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyEqualityComparer()), (11, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyEqualityComparer()), (12, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyEqualityComparer()), (13, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (14, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyEqualityComparer()), (15, true, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTNotMatchesExactlyComparer((null, null, null), (16, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyComparer((null, new List<Dummy>(), new DummyIEqualityComparer()), (17, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>(), null, new DummyIEqualityComparer()), (18, false, "Parameter 'other' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer) null), (19, false, "Parameter 'comparer' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (20, false, "Comparer threw Exception:"));

            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparer()), (21, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparer()), (22, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (23, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparer()), (24, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (25, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparer()), (26, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparer()), (27, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparer()), (28, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (29, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparer()), (30, true, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

            DDTNotMatchesExactlyComparer((null, null, (IEqualityComparer<Dummy>) null), (31, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyComparer((null, new List<Dummy>(), new DummyIEqualityComparerT()), (32, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>(), null, new DummyIEqualityComparerT()), (33, false, "Parameter 'other' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>(), new List<Dummy>(), (IEqualityComparer<Dummy>) null), (34, false, "Parameter 'comparer' is null."));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, DynamicEqualityComparer.FromDelegate<Dummy>(
                (x, y) => throw new NotImplementedException(),
                (obj) => throw new NotImplementedException())),
                (35, false, "Comparer threw Exception:"));

            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1 }, new List<Dummy>() { 1 }, new DummyIEqualityComparerT()), (36, false, "Enumerations match. Enumeration is: ['1']; Elements are: ['1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 2, 1 }, new DummyIEqualityComparerT()), (37, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['2', '1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (38, false, "Enumerations match. Enumeration is: ['1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2 }, new DummyIEqualityComparerT()), (39, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (40, true, "Enumerations don't match. Enumeration is: ['1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 1, 2 }, new DummyIEqualityComparerT()), (41, false, "Enumerations match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '1', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 1 }, new DummyIEqualityComparerT()), (42, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '1']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, 1, 2 }, new List<Dummy>() { 1, 2, 2 }, new DummyIEqualityComparerT()), (43, true, "Enumerations don't match. Enumeration is: ['1', '1', '2']; Elements are: ['1', '2', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, null, null, 2 }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (44, false, "Enumerations match. Enumeration is: ['1', 'null', 'null', '2']; Elements are: ['1', 'null', 'null', '2']"));
            DDTNotMatchesExactlyComparer((new List<Dummy>() { 1, null, 2, null }, new List<Dummy>() { 1, null, null, 2 }, new DummyIEqualityComparerT()), (45, true, "Enumerations don't match. Enumeration is: ['1', 'null', '2', 'null']; Elements are: ['1', 'null', 'null', '2']"));

        }

        void DDTNotMatchesExactlyComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, EqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.MatchesExactly<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.MatchesExactly(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.MatchesExactly", _file, _method);

        }

        void DDTNotMatchesExactlyComparer((IEnumerable enumeration, IEnumerable elements, IEqualityComparer comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.MatchesExactly({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.MatchesExactly(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.MatchesExactly", _file, _method);

        }

        void DDTNotMatchesExactlyComparer<T>((IEnumerable<T> enumeration, IEnumerable<T> elements, IEqualityComparer<T> comparer) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumerable.MatchesExactly<{typeof(T).Format()}>({input.enumeration.Format()}, {input.elements.Format()}, {input.comparer.FormatType()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumerable.MatchesExactly(input.enumeration, input.elements, input.comparer, _file, _method),
                expected, "Test.IfNot.Enumerable.MatchesExactly", _file, _method);

        }

        #endregion

    }
}
