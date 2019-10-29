using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class EnumerationTestSuite_uTests {

        #region Contains

        [TestMethod]
        void TestContains() {

            DDTestContains((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestContains((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTestContains((new List<String>() { "1", "2", "3" }, null), (3, false, "Enumeration doesn't contain element null."));
            DDTestContains((new List<String>() { "1", null, "3" }, null), (4, true, "Enumeration contains element null."));
            DDTestContains((new List<String>() { "1", "2", "3" }, "2"), (5, true, "Enumeration contains element '2'."));
            DDTestContains((new List<String>() { "1", "2", "3" }, "4"), (6, false, "Enumeration doesn't contain element '4'."));

        }

        void DDTestContains((IEnumerable enumeration, Object element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.Contains({input.element.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.If.Enumeration.Contains", _file, _method);

        }

        [TestMethod]
        void TestNotContains() {

            DDTestNotContains((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestNotContains((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTestNotContains((new List<String>() { "1", "2", "3" }, null), (3, true, "Enumeration doesn't contain element null."));
            DDTestNotContains((new List<String>() { "1", null, "3" }, null), (4, false, "Enumeration contains element null."));
            DDTestNotContains((new List<String>() { "1", "2", "3" }, "2"), (5, false, "Enumeration contains element '2'."));
            DDTestNotContains((new List<String>() { "1", "2", "3" }, "4"), (6, true, "Enumeration doesn't contain element '4'."));

        }

        void DDTestNotContains((IEnumerable enumeration, Object element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.Contains({input.element.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.IfNot.Enumeration.Contains", _file, _method);

        }

        [TestMethod]
        void TestContainsT() {

            DDTestContainsT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestContainsT((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTestContainsT((new List<String>() { "1", "2", "3" }, null), (3, false, "Enumeration doesn't contain element null."));
            DDTestContainsT((new List<String>() { "1", null, "3" }, null), (4, true, "Enumeration contains element null."));
            DDTestContainsT((new List<String>() { "1", "2", "3" }, "2"), (5, true, "Enumeration contains element '2'."));
            DDTestContainsT((new List<String>() { "1", "2", "3" }, "4"), (6, false, "Enumeration doesn't contain element '4'."));

        }

        void DDTestContainsT<TType>((IEnumerable<TType> enumeration, TType element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.Contains<{typeof(TType).Print()}>({input.element.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.If.Enumeration.Contains", _file, _method);

        }

        [TestMethod]
        void TestNotContainsT() {

            DDTestNotContainsT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestNotContainsT((null, "test"), (2, false, "Parameter 'enumeration' is null."));
            DDTestNotContainsT((new List<String>() { "1", "2", "3" }, null), (3, true, "Enumeration doesn't contain element null."));
            DDTestNotContainsT((new List<String>() { "1", null, "3" }, null), (4, false, "Enumeration contains element null."));
            DDTestNotContainsT((new List<String>() { "1", "2", "3" }, "2"), (5, false, "Enumeration contains element '2'."));
            DDTestNotContainsT((new List<String>() { "1", "2", "3" }, "4"), (6, true, "Enumeration doesn't contain element '4'."));

        }

        void DDTestNotContainsT<TType>((IEnumerable<TType> enumeration, TType element) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.Contains<{typeof(TType).Print()}>({input.element.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Enumeration.Contains(input.enumeration, input.element, _file, _method),
                expected, "Test.IfNot.Enumeration.Contains", _file, _method);

        }

        #endregion

        #region ContainsRange

        [TestMethod]
        void TestContainsRange() {

            DDTestContainsRange((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestContainsRange((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTestContainsRange((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTestContainsRange((new List<String>() { }, new List<String>() { }), (4, true, "Enumeration contains 0 of 0 elements."));
            DDTestContainsRange((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, false, "Enumeration contains 0 of 3 elements."));
            DDTestContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, true, "Enumeration contains 0 of 0 elements."));

            DDTestContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, true, "Enumeration contains 1 of 1 elements."));
            DDTestContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, true, "Enumeration contains 2 of 2 elements."));
            DDTestContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, false, "Enumeration contains 2 of 3 elements."));
            DDTestContainsRange((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, true, "Enumeration contains 1 of 1 elements."));

        }

        void DDTestContainsRange((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsRange({input.elements.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.ContainsRange", _file, _method);

        }

        [TestMethod]
        void TestNotContainsRange() {

            DDTestNotContainsRange((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestNotContainsRange((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTestNotContainsRange((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTestNotContainsRange((new List<String>() { }, new List<String>() { }), (4, false, "Enumeration contains 0 of 0 elements."));
            DDTestNotContainsRange((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, true, "Enumeration contains 0 of 3 elements."));
            DDTestNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, false, "Enumeration contains 0 of 0 elements."));

            DDTestNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, false, "Enumeration contains 1 of 1 elements."));
            DDTestNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, false, "Enumeration contains 2 of 2 elements."));
            DDTestNotContainsRange((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, true, "Enumeration contains 2 of 3 elements."));
            DDTestNotContainsRange((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, false, "Enumeration contains 1 of 1 elements."));

        }

        void DDTestNotContainsRange((IEnumerable enumeration, IEnumerable elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsRange({input.elements.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsRange", _file, _method);

        }

        [TestMethod]
        void TestContainsRangeT() {

            DDTestContainsRangeT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestContainsRangeT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTestContainsRangeT((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTestContainsRangeT((new List<String>() { }, new List<String>() { }), (4, true, "Enumeration contains 0 of 0 elements."));
            DDTestContainsRangeT((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, false, "Enumeration contains 0 of 3 elements."));
            DDTestContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, true, "Enumeration contains 0 of 0 elements."));

            DDTestContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, true, "Enumeration contains 1 of 1 elements."));
            DDTestContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, true, "Enumeration contains 2 of 2 elements."));
            DDTestContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, false, "Enumeration contains 2 of 3 elements."));
            DDTestContainsRangeT((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, true, "Enumeration contains 1 of 1 elements."));

        }

        void DDTestContainsRangeT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Enumeration.ContainsRange<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.If.Enumeration.ContainsRange", _file, _method);

        }

        [TestMethod]
        void TestNotContainsRangeT() {

            DDTestNotContainsRangeT<String>((null, null), (1, false, "Parameter 'enumeration' is null."));
            DDTestNotContainsRangeT((null, new List<String>()), (2, false, "Parameter 'enumeration' is null."));
            DDTestNotContainsRangeT((new List<String>(), null), (3, false, "Parameter 'elements' is null."));

            DDTestNotContainsRangeT((new List<String>() { }, new List<String>() { }), (4, false, "Enumeration contains 0 of 0 elements."));
            DDTestNotContainsRangeT((new List<String>() { }, new List<String>() { "1", "2", "3" }), (5, true, "Enumeration contains 0 of 3 elements."));
            DDTestNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { }), (6, false, "Enumeration contains 0 of 0 elements."));

            DDTestNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1" }), (7, false, "Enumeration contains 1 of 1 elements."));
            DDTestNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "1" }), (8, false, "Enumeration contains 2 of 2 elements."));
            DDTestNotContainsRangeT((new List<String>() { "1", "2", "3" }, new List<String>() { "1", "2", "4" }), (9, true, "Enumeration contains 2 of 3 elements."));
            DDTestNotContainsRangeT((new List<String>() { "1", "1", "3" }, new List<String>() { "1" }), (10, false, "Enumeration contains 1 of 1 elements."));

        }

        void DDTestNotContainsRangeT<TType>((IEnumerable<TType> enumeration, IEnumerable<TType> elements) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Enumeration.ContainsRange<{typeof(TType).Print()}>({input.elements.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.Enumeration.ContainsRange(input.enumeration, input.elements, _file, _method),
                expected, "Test.IfNot.Enumeration.ContainsRange", _file, _method);

        }

        #endregion

    }
}
