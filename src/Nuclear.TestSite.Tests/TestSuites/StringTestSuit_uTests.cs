using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class StringTestSuit_uTests {

        #region StartsWith

        [TestMethod]
        void TestStartsWithChar() {

            DDTestStartsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTestStartsWithChar(("", 'x'), (2, false, "[String = ''; Value = 'x']"));
            DDTestStartsWithChar(("ax", 'x'), (3, false, "[String = 'ax'; Value = 'x']"));
            DDTestStartsWithChar(("xa", 'x'), (4, true, "[String = 'xa'; Value = 'x']"));
        }

        void DDTestStartsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void TestNotStartsWithChar() {

            DDTestNotStartsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTestNotStartsWithChar(("", 'x'), (2, true, "[String = ''; Value = 'x']"));
            DDTestNotStartsWithChar(("ax", 'x'), (3, true, "[String = 'ax'; Value = 'x']"));
            DDTestNotStartsWithChar(("xa", 'x'), (4, false, "[String = 'xa'; Value = 'x']"));

        }

        void DDTestNotStartsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void TestStartsWithString() {

            DDTestStartsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTestStartsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTestStartsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTestStartsWithString(("", ""), (4, true, "[String = ''; Value = '']"));
            DDTestStartsWithString(("", "xy"), (5, false, "[String = ''; Value = 'xy']"));
            DDTestStartsWithString(("xy", ""), (6, true, "[String = 'xy'; Value = '']"));
            DDTestStartsWithString(("axy", "xy"), (7, false, "[String = 'axy'; Value = 'xy']"));
            DDTestStartsWithString(("xya", "xy"), (8, true, "[String = 'xya'; Value = 'xy']"));

        }

        void DDTestStartsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void TestNotStartsWithString() {

            DDTestNotStartsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTestNotStartsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTestNotStartsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTestNotStartsWithString(("", ""), (4, false, "[String = ''; Value = '']"));
            DDTestNotStartsWithString(("", "xy"), (5, true, "[String = ''; Value = 'xy']"));
            DDTestNotStartsWithString(("xy", ""), (6, false, "[String = 'xy'; Value = '']"));
            DDTestNotStartsWithString(("axy", "xy"), (7, true, "[String = 'axy'; Value = 'xy']"));
            DDTestNotStartsWithString(("xya", "xy"), (8, false, "[String = 'xya'; Value = 'xy']"));
        }

        void DDTestNotStartsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.StartsWith", _file, _method);

        }

        #endregion

        #region EndsWith

        [TestMethod]
        void TestEndsWithChar() {

            DDTestEndsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTestEndsWithChar(("", 'x'), (2, false, "[String = ''; Value = 'x']"));
            DDTestEndsWithChar(("ax", 'x'), (3, true, "[String = 'ax'; Value = 'x']"));
            DDTestEndsWithChar(("xa", 'x'), (4, false, "[String = 'xa'; Value = 'x']"));
        }

        void DDTestEndsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void TestNotEndsWithChar() {

            DDTestNotEndsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTestNotEndsWithChar(("", 'x'), (2, true, "[String = ''; Value = 'x']"));
            DDTestNotEndsWithChar(("ax", 'x'), (3, false, "[String = 'ax'; Value = 'x']"));
            DDTestNotEndsWithChar(("xa", 'x'), (4, true, "[String = 'xa'; Value = 'x']"));

        }

        void DDTestNotEndsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void TestEndsWithString() {

            DDTestEndsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTestEndsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTestEndsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTestEndsWithString(("", ""), (4, true, "[String = ''; Value = '']"));
            DDTestEndsWithString(("", "xy"), (5, false, "[String = ''; Value = 'xy']"));
            DDTestEndsWithString(("xy", ""), (6, true, "[String = 'xy'; Value = '']"));
            DDTestEndsWithString(("axy", "xy"), (7, true, "[String = 'axy'; Value = 'xy']"));
            DDTestEndsWithString(("xya", "xy"), (8, false, "[String = 'xya'; Value = 'xy']"));

        }

        void DDTestEndsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void TestNotEndsWithString() {

            DDTestNotEndsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTestNotEndsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTestNotEndsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTestNotEndsWithString(("", ""), (4, false, "[String = ''; Value = '']"));
            DDTestNotEndsWithString(("", "xy"), (5, true, "[String = ''; Value = 'xy']"));
            DDTestNotEndsWithString(("xy", ""), (6, false, "[String = 'xy'; Value = '']"));
            DDTestNotEndsWithString(("axy", "xy"), (7, false, "[String = 'axy'; Value = 'xy']"));
            DDTestNotEndsWithString(("xya", "xy"), (8, true, "[String = 'xya'; Value = 'xy']"));
        }

        void DDTestNotEndsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.EndsWith", _file, _method);

        }

        #endregion

        #region NullOrEmpty

        [TestMethod]
        void TestIsNullOrEmpty() {

            DDTestIsNOE(null, (1, true, "[String = null]"));
            DDTestIsNOE(String.Empty, (2, true, "[String = '']"));
            DDTestIsNOE(" ", (3, false, "[String = ' ']"));
            DDTestIsNOE("content", (4, false, "[String = 'content']"));

        }

        void DDTestIsNOE(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.IsNullOrEmpty({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.String.IsNullOrEmpty(input, _file, _method),
                expected, "Test.If.String.IsNullOrEmpty", _file, _method);

        }

        [TestMethod]
        void TestNotIsNullOrEmpty() {

            DDTestIsNotNOE(null, (1, false, "[String = null]"));
            DDTestIsNotNOE(String.Empty, (2, false, "[String = '']"));
            DDTestIsNotNOE(" ", (3, true, "[String = ' ']"));
            DDTestIsNotNOE("content", (4, true, "[String = 'content']"));

        }

        void DDTestIsNotNOE(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.IsNullOrEmpty({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.String.IsNullOrEmpty(input, _file, _method),
                expected, "Test.IfNot.String.IsNullOrEmpty", _file, _method);

        }

        #endregion

        #region NullOrWhiteSpace

        [TestMethod]
        void TestIsNullWhiteSpace() {

            DDTestIsNOW(null, (1, true, "[String = null]"));
            DDTestIsNOW(String.Empty, (2, true, "[String = '']"));
            DDTestIsNOW(" ", (3, true, "[String = ' ']"));
            DDTestIsNOW("content", (4, false, "[String = 'content']"));

        }

        void DDTestIsNOW(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.IsNullOrWhiteSpace({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.String.IsNullOrWhiteSpace(input, _file, _method),
                expected, "Test.If.String.IsNullOrWhiteSpace", _file, _method);

        }

        [TestMethod]
        void TestNotIsNullWhiteSpace() {

            DDTestIsNotNOW(null, (1, false, "[String = null]"));
            DDTestIsNotNOW(String.Empty, (2, false, "[String = '']"));
            DDTestIsNotNOW(" ", (3, false, "[String = ' ']"));
            DDTestIsNotNOW("content", (4, true, "[String = 'content']"));

        }

        void DDTestIsNotNOW(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.IsNullOrWhiteSpace({input.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.String.IsNullOrWhiteSpace(input, _file, _method),
                expected, "Test.IfNot.String.IsNullOrWhiteSpace", _file, _method);

        }

        #endregion

        #region Contains

        [TestMethod]
        void TestContains() {

            DDTestContains((null, null), (1, false, "Parameter 'string' is null."));
            DDTestContains((null, "abc"), (2, false, "Parameter 'string' is null."));
            DDTestContains(("abc", null), (3, false, "Parameter 'value' is null."));
            DDTestContains((String.Empty, String.Empty), (4, true, "[String = ''; Value = '']"));
            DDTestContains((String.Empty, "abc"), (5, false, "[String = ''; Value = 'abc']"));
            DDTestContains(("abc", String.Empty), (6, true, "[String = 'abc'; Value = '']"));
            DDTestContains(("abcd", "abcd"), (7, true, "[String = 'abcd'; Value = 'abcd']"));
            DDTestContains(("abcd", "ab"), (8, true, "[String = 'abcd'; Value = 'ab']"));
            DDTestContains(("abcd", "cd"), (9, true, "[String = 'abcd'; Value = 'cd']"));
            DDTestContains(("abcd", "bc"), (10, true, "[String = 'abcd'; Value = 'bc']"));
            DDTestContains(("abcd", "cb"), (11, false, "[String = 'abcd'; Value = 'cb']"));

        }

        void DDTestContains((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.Contains({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.String.Contains(input.@string, input.value, _file, _method),
                expected, "Test.If.String.Contains", _file, _method);

        }

        [TestMethod]
        void TestNotContains() {

            DDTestNotContains((null, null), (1, false, "Parameter 'string' is null."));
            DDTestNotContains((null, "abc"), (2, false, "Parameter 'string' is null."));
            DDTestNotContains(("abc", null), (3, false, "Parameter 'value' is null."));
            DDTestNotContains((String.Empty, String.Empty), (4, false, "[String = ''; Value = '']"));
            DDTestNotContains((String.Empty, "abc"), (5, true, "[String = ''; Value = 'abc']"));
            DDTestNotContains(("abc", String.Empty), (6, false, "[String = 'abc'; Value = '']"));
            DDTestNotContains(("abcd", "abcd"), (7, false, "[String = 'abcd'; Value = 'abcd']"));
            DDTestNotContains(("abcd", "ab"), (8, false, "[String = 'abcd'; Value = 'ab']"));
            DDTestNotContains(("abcd", "cd"), (9, false, "[String = 'abcd'; Value = 'cd']"));
            DDTestNotContains(("abcd", "bc"), (10, false, "[String = 'abcd'; Value = 'bc']"));
            DDTestNotContains(("abcd", "cb"), (11, true, "[String = 'abcd'; Value = 'cb']"));

        }

        void DDTestNotContains((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.Contains({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.String.Contains(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.Contains", _file, _method);

        }

        #endregion

    }
}
