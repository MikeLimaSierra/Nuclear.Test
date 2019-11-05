using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class EnumerationTestSuite_uTests {

        #region IsEmpty

        [TestMethod]
        void IsEmpty() {

            DDTIsEmpty(null, (1, false, "Parameter 'enumeration' is null."));
            DDTIsEmpty(Enumerable.Empty<Object>(), (2, true, "Enumeration is empty."));
            DDTIsEmpty(new List<String>() { "1", "2", "3" }, (3, false, "Enumeration is not empty"));
            DDTIsEmpty(new List<String>() { "1", null, "3" }, (4, false, "Enumeration is not empty"));
            DDTIsEmpty(new List<String>() { null, null, }, (5, false, "Enumeration is not empty"));

        }

        void DDTIsEmpty(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.IsEmpty({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.IsEmpty(input, _file, _method),
                expected, "Test.If.Enumeration.IsEmpty", _file, _method);

        }

        [TestMethod]
        void NotIsEmpty() {

            DDTNotIsEmpty(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotIsEmpty(Enumerable.Empty<Object>(), (2, false, "Enumeration is empty."));
            DDTNotIsEmpty(new List<String>() { "1", "2", "3" }, (3, true, "Enumeration is not empty"));
            DDTNotIsEmpty(new List<String>() { "1", null, "3" }, (4, true, "Enumeration is not empty"));
            DDTNotIsEmpty(new List<String>() { null, null, }, (5, true, "Enumeration is not empty"));

        }

        void DDTNotIsEmpty(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.IsEmpty({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.IsEmpty(input, _file, _method),
                expected, "Test.IfNot.Enumeration.IsEmpty", _file, _method);

        }

        [TestMethod]
        void IsEmptyT() {

            DDTIsEmptyT<Object>(null, (1, false, "Parameter 'enumeration' is null."));
            DDTIsEmptyT(Enumerable.Empty<Object>(), (2, true, "Enumeration is empty."));
            DDTIsEmptyT(new List<String>() { "1", "2", "3" }, (3, false, "Enumeration is not empty"));
            DDTIsEmptyT(new List<String>() { "1", null, "3" }, (4, false, "Enumeration is not empty"));
            DDTIsEmptyT(new List<String>() { null, null, }, (5, false, "Enumeration is not empty"));

        }

        void DDTIsEmptyT<TType>(IEnumerable<TType> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.IsEmpty<{typeof(TType).Print()}>({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.IsEmpty(input, _file, _method),
                expected, "Test.If.Enumeration.IsEmpty", _file, _method);

        }

        [TestMethod]
        void NotIsEmptyT() {

            DDTNotIsEmptyT<Object>(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotIsEmptyT(Enumerable.Empty<Object>(), (2, false, "Enumeration is empty."));
            DDTNotIsEmptyT(new List<String>() { "1", "2", "3" }, (3, true, "Enumeration is not empty"));
            DDTNotIsEmptyT(new List<String>() { "1", null, "3" }, (4, true, "Enumeration is not empty"));
            DDTNotIsEmptyT(new List<String>() { null, null, }, (5, true, "Enumeration is not empty"));

        }

        void DDTNotIsEmptyT<TType>(IEnumerable<TType> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.IsEmpty<{typeof(TType).Print()}>({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.IsEmpty(input, _file, _method),
                expected, "Test.IfNot.Enumeration.IsEmpty", _file, _method);

        }

        #endregion

        #region ContainsNull

        [TestMethod]
        void ContainsNull() {

            DDTContainsNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTContainsNull(Enumerable.Empty<Object>(), (2, false, "Enumeration doesn't contain null."));
            DDTContainsNull(new List<String>() { "1", "2", "3" }, (3, false, "Enumeration doesn't contain null."));
            DDTContainsNull(new List<String>() { "1", null, "3" }, (4, true, "Enumeration contains null."));

        }

        void DDTContainsNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsNull({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.ContainsNull(input, _file, _method),
                expected, "Test.If.Enumeration.ContainsNull", _file, _method);

        }

        [TestMethod]
        void NotContainsNull() {

            DDTNotContainsNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNull(Enumerable.Empty<Object>(), (2, true, "Enumeration doesn't contain null."));
            DDTNotContainsNull(new List<String>() { "1", "2", "3" }, (3, true, "Enumeration doesn't contain null."));
            DDTNotContainsNull(new List<String>() { "1", null, "3" }, (4, false, "Enumeration contains null."));

        }

        void DDTNotContainsNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsNull({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.ContainsNull(input, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsNull", _file, _method);

        }

        [TestMethod]
        void ContainsNullT() {

            DDTContainsNullT<Object>(null, (1, false, "Parameter 'enumeration' is null."));
            DDTContainsNullT(Enumerable.Empty<Object>(), (2, false, "Enumeration doesn't contain null."));
            DDTContainsNullT(new List<String>() { "1", "2", "3" }, (3, false, "Enumeration doesn't contain null."));
            DDTContainsNullT(new List<String>() { "1", null, "3" }, (4, true, "Enumeration contains null."));

        }

        void DDTContainsNullT<TType>(IEnumerable<TType> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsNull<{typeof(TType).Print()}>({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.ContainsNull(input, _file, _method),
                expected, "Test.If.Enumeration.ContainsNull", _file, _method);

        }

        [TestMethod]
        void NotContainsNullT() {

            DDTNotContainsNullT<Object>(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNullT(Enumerable.Empty<Object>(), (2, true, "Enumeration doesn't contain null."));
            DDTNotContainsNullT(new List<String>() { "1", "2", "3" }, (3, true, "Enumeration doesn't contain null."));
            DDTNotContainsNullT(new List<String>() { "1", null, "3" }, (4, false, "Enumeration contains null."));

        }

        void DDTNotContainsNullT<TType>(IEnumerable<TType> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsNull<{typeof(TType).Print()}>({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.ContainsNull(input, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsNull", _file, _method);

        }

        #endregion

        #region ContainsNonNull

        [TestMethod]
        void ContainsNonNull() {

            DDTContainsNonNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTContainsNonNull(Enumerable.Empty<Object>(), (2, false, "Enumeration doesn't contain a non null value."));
            DDTContainsNonNull(new List<String>() { "1", "2", "3" }, (3, true, "Enumeration contains a non null value."));
            DDTContainsNonNull(new List<String>() { "1", null, "3" }, (4, true, "Enumeration contains a non null value."));
            DDTContainsNonNull(new List<String>() { null }, (5, false, "Enumeration doesn't contain a non null value."));

        }

        void DDTContainsNonNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsNonNull({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.ContainsNonNull(input, _file, _method),
                expected, "Test.If.Enumeration.ContainsNonNull", _file, _method);

        }

        [TestMethod]
        void NotContainsNonNull() {

            DDTNotContainsNonNull(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNonNull(Enumerable.Empty<Object>(), (2, true, "Enumeration doesn't contain a non null value."));
            DDTNotContainsNonNull(new List<String>() { "1", "2", "3" }, (3, false, "Enumeration contains a non null value."));
            DDTNotContainsNonNull(new List<String>() { "1", null, "3" }, (4, false, "Enumeration contains a non null value."));
            DDTNotContainsNonNull(new List<String>() { null }, (5, true, "Enumeration doesn't contain a non null value."));

        }

        void DDTNotContainsNonNull(IEnumerable input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsNonNull({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.ContainsNonNull(input, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsNonNull", _file, _method);

        }

        [TestMethod]
        void ContainsNonNullT() {

            DDTContainsNonNullT<Object>(null, (1, false, "Parameter 'enumeration' is null."));
            DDTContainsNonNullT(Enumerable.Empty<Object>(), (2, false, "Enumeration doesn't contain a non null value."));
            DDTContainsNonNullT(new List<String>() { "1", "2", "3" }, (3, true, "Enumeration contains a non null value."));
            DDTContainsNonNullT(new List<String>() { "1", null, "3" }, (4, true, "Enumeration contains a non null value."));
            DDTContainsNonNullT(new List<String>() { null }, (5, false, "Enumeration doesn't contain a non null value."));

        }

        void DDTContainsNonNullT<TType>(IEnumerable<TType> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsNonNull<{typeof(TType).Print()}>({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.ContainsNonNull(input, _file, _method),
                expected, "Test.If.Enumeration.ContainsNonNull", _file, _method);

        }

        [TestMethod]
        void NotContainsNonNullT() {

            DDTNotContainsNonNullT<Object>(null, (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsNonNullT(Enumerable.Empty<Object>(), (2, true, "Enumeration doesn't contain a non null value."));
            DDTNotContainsNonNullT(new List<String>() { "1", "2", "3" }, (3, false, "Enumeration contains a non null value."));
            DDTNotContainsNonNullT(new List<String>() { "1", null, "3" }, (4, false, "Enumeration contains a non null value."));
            DDTNotContainsNonNullT(new List<String>() { null }, (5, true, "Enumeration doesn't contain a non null value."));

        }

        void DDTNotContainsNonNullT<TType>(IEnumerable<TType> input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsNonNull<{typeof(TType).Print()}>({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.ContainsNonNull(input, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsNonNull", _file, _method);

        }

        #endregion

        #region Contains

        [TestMethod]
        void Contains() {

            DDTContains((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContains((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTContains((new List<String>() { "1", "2", "3" }, null), (3, false, "Enumeration doesn't contain element null."));
            DDTContains((new List<String>() { "1", null, "3" }, null), (4, true, "Enumeration contains element null."));
            DDTContains((new List<String>() { "1", "2", "3" }, "2"), (5, true, "Enumeration contains element '2'."));
            DDTContains((new List<String>() { "1", "2", "3" }, "4"), (6, false, "Enumeration doesn't contain element '4'."));

        }

        void DDTContains((IEnumerable enumeration, Object element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.Contains({input.element.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.If.Enumeration.Contains", _file, _method);

        }

        [TestMethod]
        void NotContains() {

            DDTNotContains((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContains((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContains((new List<String>() { "1", "2", "3" }, null), (3, true, "Enumeration doesn't contain element null."));
            DDTNotContains((new List<String>() { "1", null, "3" }, null), (4, false, "Enumeration contains element null."));
            DDTNotContains((new List<String>() { "1", "2", "3" }, "2"), (5, false, "Enumeration contains element '2'."));
            DDTNotContains((new List<String>() { "1", "2", "3" }, "4"), (6, true, "Enumeration doesn't contain element '4'."));

        }

        void DDTNotContains((IEnumerable enumeration, Object element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.Contains({input.element.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.IfNot.Enumeration.Contains", _file, _method);

        }

        [TestMethod]
        void ContainsT() {

            DDTContainsT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContainsT((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTContainsT((new List<String>() { "1", "2", "3" }, null), (3, false, "Enumeration doesn't contain element null."));
            DDTContainsT((new List<String>() { "1", null, "3" }, null), (4, true, "Enumeration contains element null."));
            DDTContainsT((new List<String>() { "1", "2", "3" }, "2"), (5, true, "Enumeration contains element '2'."));
            DDTContainsT((new List<String>() { "1", "2", "3" }, "4"), (6, false, "Enumeration doesn't contain element '4'."));

        }

        void DDTContainsT<TType>((IEnumerable<TType> enumeration, TType element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.Contains<{typeof(TType).Print()}>({input.element.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.If.Enumeration.Contains", _file, _method);

        }

        [TestMethod]
        void NotContainsT() {

            DDTNotContainsT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsT((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContainsT((new List<String>() { "1", "2", "3" }, null), (3, true, "Enumeration doesn't contain element null."));
            DDTNotContainsT((new List<String>() { "1", null, "3" }, null), (4, false, "Enumeration contains element null."));
            DDTNotContainsT((new List<String>() { "1", "2", "3" }, "2"), (5, false, "Enumeration contains element '2'."));
            DDTNotContainsT((new List<String>() { "1", "2", "3" }, "4"), (6, true, "Enumeration doesn't contain element '4'."));

        }

        void DDTNotContainsT<TType>((IEnumerable<TType> enumeration, TType element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.Contains<{typeof(TType).Print()}>({input.element.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.IfNot.Enumeration.Contains", _file, _method);

        }

        #endregion

        #region ContainsRange

        [TestMethod]
        void ContainsRange() {

            DDTContainsRange((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContainsRange((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTContainsRange((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTContainsRange((new List<String>() { }, new List<String>() { }), (4, true, "Enumeration contains 0 of 0 elements."));
            DDTContainsRange((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, false, "Enumeration contains 0 of 3 elements."));
            DDTContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, true, "Enumeration contains 0 of 0 elements."));

            DDTContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, true, "Enumeration contains 1 of 1 elements."));
            DDTContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, true, "Enumeration contains 2 of 2 elements."));
            DDTContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, false, "Enumeration contains 2 of 3 elements."));
            DDTContainsRange((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, true, "Enumeration contains 1 of 1 elements."));

        }

        void DDTContainsRange((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsRange({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.ContainsRange", _file, _method);

        }

        [TestMethod]
        void NotContainsRange() {

            DDTNotContainsRange((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRange((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRange((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTNotContainsRange((new List<String>() { }, new List<String>() { }), (4, false, "Enumeration contains 0 of 0 elements."));
            DDTNotContainsRange((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, true, "Enumeration contains 0 of 3 elements."));
            DDTNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, false, "Enumeration contains 0 of 0 elements."));

            DDTNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, false, "Enumeration contains 1 of 1 elements."));
            DDTNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, false, "Enumeration contains 2 of 2 elements."));
            DDTNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, true, "Enumeration contains 2 of 3 elements."));
            DDTNotContainsRange((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, false, "Enumeration contains 1 of 1 elements."));

        }

        void DDTNotContainsRange((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsRange({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsRange", _file, _method);

        }

        [TestMethod]
        void ContainsRangeT() {

            DDTContainsRangeT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTContainsRangeT((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTContainsRangeT((new List<String>() { }, new List<String>() { }), (4, true, "Enumeration contains 0 of 0 elements."));
            DDTContainsRangeT((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, false, "Enumeration contains 0 of 3 elements."));
            DDTContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, true, "Enumeration contains 0 of 0 elements."));

            DDTContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, true, "Enumeration contains 1 of 1 elements."));
            DDTContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, true, "Enumeration contains 2 of 2 elements."));
            DDTContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, false, "Enumeration contains 2 of 3 elements."));
            DDTContainsRangeT((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, true, "Enumeration contains 1 of 1 elements."));

        }

        void DDTContainsRangeT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsRange<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.ContainsRange", _file, _method);

        }

        [TestMethod]
        void NotContainsRangeT() {

            DDTNotContainsRangeT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotContainsRangeT((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTNotContainsRangeT((new List<String>() { }, new List<String>() { }), (4, false, "Enumeration contains 0 of 0 elements."));
            DDTNotContainsRangeT((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, true, "Enumeration contains 0 of 3 elements."));
            DDTNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, false, "Enumeration contains 0 of 0 elements."));

            DDTNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, false, "Enumeration contains 1 of 1 elements."));
            DDTNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, false, "Enumeration contains 2 of 2 elements."));
            DDTNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, true, "Enumeration contains 2 of 3 elements."));
            DDTNotContainsRangeT((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, false, "Enumeration contains 1 of 1 elements."));

        }

        void DDTNotContainsRangeT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsRange<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsRange", _file, _method);

        }

        #endregion

        #region Matches

        [TestMethod]
        void Matches() {

            DDTMatches((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatches((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatches((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTMatches((new List<String>() { "1" }, new List<String>() { "1" }), (4, true, "Enumerations match."));
            DDTMatches((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, true, "Enumerations match."));
            DDTMatches((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, true, "Enumerations match."));
            DDTMatches((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, false, "Enumerations don't match."));
            DDTMatches((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, false, "Enumerations don't match."));
            DDTMatches((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, true, "Enumerations match."));
            DDTMatches((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, true, "Enumerations match."));

        }

        void DDTMatches((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.Matches({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.Matches", _file, _method);

        }

        [TestMethod]
        void NotMatches() {

            DDTNotMatches((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatches((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatches((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTNotMatches((new List<String>() { "1" }, new List<String>() { "1" }), (4, false, "Enumerations match."));
            DDTNotMatches((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, false, "Enumerations match."));
            DDTNotMatches((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, false, "Enumerations match."));
            DDTNotMatches((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, true, "Enumerations don't match."));
            DDTNotMatches((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, true, "Enumerations don't match."));
            DDTNotMatches((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, false, "Enumerations match."));
            DDTNotMatches((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, false, "Enumerations match."));

        }

        void DDTNotMatches((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.Matches({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.Matches", _file, _method);

        }

        [TestMethod]
        void MatchesT() {

            DDTMatchesT<Object>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatchesT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatchesT((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTMatchesT((new List<String>() { "1" }, new List<String>() { "1" }), (4, true, "Enumerations match."));
            DDTMatchesT((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, true, "Enumerations match."));
            DDTMatchesT((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, true, "Enumerations match."));
            DDTMatchesT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, false, "Enumerations don't match."));
            DDTMatchesT((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, false, "Enumerations don't match."));
            DDTMatchesT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, true, "Enumerations match."));
            DDTMatchesT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, true, "Enumerations match."));

        }

        void DDTMatchesT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.Matches<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.Matches", _file, _method);

        }

        [TestMethod]
        void NotMatchesT() {

            DDTNotMatchesT<Object>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesT((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTNotMatchesT((new List<String>() { "1" }, new List<String>() { "1" }), (4, false, "Enumerations match."));
            DDTNotMatchesT((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, false, "Enumerations match."));
            DDTNotMatchesT((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, false, "Enumerations match."));
            DDTNotMatchesT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, true, "Enumerations don't match."));
            DDTNotMatchesT((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, true, "Enumerations don't match."));
            DDTNotMatchesT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, false, "Enumerations match."));
            DDTNotMatchesT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, false, "Enumerations match."));

        }

        void DDTNotMatchesT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.Matches<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.Matches(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.Matches", _file, _method);

        }

        #endregion

        #region MatchesExactly

        [TestMethod]
        void MatchesExactly() {

            DDTMatchesExactly((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactly((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactly((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTMatchesExactly((new List<String>() { "1" }, new List<String>() { "1" }), (4, true, "Enumerations match."));
            DDTMatchesExactly((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, false, "Enumerations don't match."));
            DDTMatchesExactly((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, true, "Enumerations match."));
            DDTMatchesExactly((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, false, "Enumerations don't match."));
            DDTMatchesExactly((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, false, "Enumerations don't match."));
            DDTMatchesExactly((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, true, "Enumerations match."));
            DDTMatchesExactly((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, false, "Enumerations don't match."));

        }

        void DDTMatchesExactly((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.MatchesExactly({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.MatchesExactly", _file, _method);

        }

        [TestMethod]
        void NotMatchesExactly() {

            DDTNotMatchesExactly((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactly((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactly((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTNotMatchesExactly((new List<String>() { "1" }, new List<String>() { "1" }), (4, false, "Enumerations match."));
            DDTNotMatchesExactly((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, true, "Enumerations don't match."));
            DDTNotMatchesExactly((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, false, "Enumerations match."));
            DDTNotMatchesExactly((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, true, "Enumerations don't match."));
            DDTNotMatchesExactly((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, true, "Enumerations don't match."));
            DDTNotMatchesExactly((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, false, "Enumerations match."));
            DDTNotMatchesExactly((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, true, "Enumerations don't match."));

        }

        void DDTNotMatchesExactly((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.MatchesExactly({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.MatchesExactly", _file, _method);

        }

        [TestMethod]
        void MatchesExactlyT() {

            DDTMatchesExactlyT<Object>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTMatchesExactlyT((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTMatchesExactlyT((new List<String>() { "1" }, new List<String>() { "1" }), (4, true, "Enumerations match."));
            DDTMatchesExactlyT((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, false, "Enumerations don't match."));
            DDTMatchesExactlyT((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, true, "Enumerations match."));
            DDTMatchesExactlyT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, false, "Enumerations don't match."));
            DDTMatchesExactlyT((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, false, "Enumerations don't match."));
            DDTMatchesExactlyT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, true, "Enumerations match."));
            DDTMatchesExactlyT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, false, "Enumerations don't match."));

        }

        void DDTMatchesExactlyT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.MatchesExactly<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Enumeration.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.MatchesExactly", _file, _method);

        }

        [TestMethod]
        void NotMatchesExactlyT() {

            DDTNotMatchesExactlyT<Object>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTNotMatchesExactlyT((new List<String>(), null), (3, false, "Parameter 'other' is null."));

            DDTNotMatchesExactlyT((new List<String>() { "1" }, new List<String>() { "1" }), (4, false, "Enumerations match."));
            DDTNotMatchesExactlyT((new List<String>() { "1", "2" }, new List<String>() { "2", "1" }), (5, true, "Enumerations don't match."));
            DDTNotMatchesExactlyT((new List<String>() { "1", "2" }, new List<String>() { "1", "2" }), (6, false, "Enumerations match."));
            DDTNotMatchesExactlyT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2" }), (7, true, "Enumerations don't match."));
            DDTNotMatchesExactlyT((new List<String>() { "1", "2" }, new List<String>() { "1", "1", "2" }), (8, true, "Enumerations don't match."));
            DDTNotMatchesExactlyT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "1", "2" }), (9, false, "Enumerations match."));
            DDTNotMatchesExactlyT((new List<String>() { "1", "1", "2" }, new List<String>() { "1", "2", "1" }), (10, true, "Enumerations don't match."));

        }

        void DDTNotMatchesExactlyT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.MatchesExactly<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Enumeration.MatchesExactly(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.MatchesExactly", _file, _method);

        }

        #endregion

    }
}
