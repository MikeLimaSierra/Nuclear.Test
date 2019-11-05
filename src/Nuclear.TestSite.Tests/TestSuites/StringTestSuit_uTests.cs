using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class StringTestSuit_uTests {

        #region StartsWith

        [TestMethod]
        void StartsWithChar() {

            DDTStartsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTStartsWithChar(("", 'x'), (2, false, "[String = ''; Value = 'x']"));
            DDTStartsWithChar(("ax", 'x'), (3, false, "[String = 'ax'; Value = 'x']"));
            DDTStartsWithChar(("xa", 'x'), (4, true, "[String = 'xa'; Value = 'x']"));
        }

        void DDTStartsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void NotStartsWithChar() {

            DDTNotStartsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTNotStartsWithChar(("", 'x'), (2, true, "[String = ''; Value = 'x']"));
            DDTNotStartsWithChar(("ax", 'x'), (3, true, "[String = 'ax'; Value = 'x']"));
            DDTNotStartsWithChar(("xa", 'x'), (4, false, "[String = 'xa'; Value = 'x']"));

        }

        void DDTNotStartsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void StartsWithString() {

            DDTStartsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTStartsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTStartsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTStartsWithString(("", ""), (4, true, "[String = ''; Value = '']"));
            DDTStartsWithString(("", "xy"), (5, false, "[String = ''; Value = 'xy']"));
            DDTStartsWithString(("xy", ""), (6, true, "[String = 'xy'; Value = '']"));
            DDTStartsWithString(("axy", "xy"), (7, false, "[String = 'axy'; Value = 'xy']"));
            DDTStartsWithString(("xya", "xy"), (8, true, "[String = 'xya'; Value = 'xy']"));

        }

        void DDTStartsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void NotStartsWithString() {

            DDTNotStartsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTNotStartsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTNotStartsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTNotStartsWithString(("", ""), (4, false, "[String = ''; Value = '']"));
            DDTNotStartsWithString(("", "xy"), (5, true, "[String = ''; Value = 'xy']"));
            DDTNotStartsWithString(("xy", ""), (6, false, "[String = 'xy'; Value = '']"));
            DDTNotStartsWithString(("axy", "xy"), (7, true, "[String = 'axy'; Value = 'xy']"));
            DDTNotStartsWithString(("xya", "xy"), (8, false, "[String = 'xya'; Value = 'xy']"));
        }

        void DDTNotStartsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.StartsWith", _file, _method);

        }

        #endregion

        #region EndsWith

        [TestMethod]
        void EndsWithChar() {

            DDTEndsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTEndsWithChar(("", 'x'), (2, false, "[String = ''; Value = 'x']"));
            DDTEndsWithChar(("ax", 'x'), (3, true, "[String = 'ax'; Value = 'x']"));
            DDTEndsWithChar(("xa", 'x'), (4, false, "[String = 'xa'; Value = 'x']"));
        }

        void DDTEndsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void NotEndsWithChar() {

            DDTNotEndsWithChar((null, 'x'), (1, false, "Parameter 'string' is null."));
            DDTNotEndsWithChar(("", 'x'), (2, true, "[String = ''; Value = 'x']"));
            DDTNotEndsWithChar(("ax", 'x'), (3, false, "[String = 'ax'; Value = 'x']"));
            DDTNotEndsWithChar(("xa", 'x'), (4, true, "[String = 'xa'; Value = 'x']"));

        }

        void DDTNotEndsWithChar((String @string, Char value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void EndsWithString() {

            DDTEndsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTEndsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTEndsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTEndsWithString(("", ""), (4, true, "[String = ''; Value = '']"));
            DDTEndsWithString(("", "xy"), (5, false, "[String = ''; Value = 'xy']"));
            DDTEndsWithString(("xy", ""), (6, true, "[String = 'xy'; Value = '']"));
            DDTEndsWithString(("axy", "xy"), (7, true, "[String = 'axy'; Value = 'xy']"));
            DDTEndsWithString(("xya", "xy"), (8, false, "[String = 'xya'; Value = 'xy']"));

        }

        void DDTEndsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.If.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void NotEndsWithString() {

            DDTNotEndsWithString((null, null), (1, false, "Parameter 'string' is null."));
            DDTNotEndsWithString((null, "xy"), (2, false, "Parameter 'string' is null."));
            DDTNotEndsWithString(("axy", null), (3, false, "Parameter 'value' is null."));
            DDTNotEndsWithString(("", ""), (4, false, "[String = ''; Value = '']"));
            DDTNotEndsWithString(("", "xy"), (5, true, "[String = ''; Value = 'xy']"));
            DDTNotEndsWithString(("xy", ""), (6, false, "[String = 'xy'; Value = '']"));
            DDTNotEndsWithString(("axy", "xy"), (7, false, "[String = 'axy'; Value = 'xy']"));
            DDTNotEndsWithString(("xya", "xy"), (8, true, "[String = 'xya'; Value = 'xy']"));
        }

        void DDTNotEndsWithString((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.EndsWith", _file, _method);

        }

        #endregion

        #region NullOrEmpty

        [TestMethod]
        void IsNullOrEmpty() {

            DDTIsNOE(null, (1, true, "[String = null]"));
            DDTIsNOE(String.Empty, (2, true, "[String = '']"));
            DDTIsNOE(" ", (3, false, "[String = ' ']"));
            DDTIsNOE("content", (4, false, "[String = 'content']"));

        }

        void DDTIsNOE(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.IsNullOrEmpty({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.IsNullOrEmpty(input, _file, _method),
                expected, "Test.If.String.IsNullOrEmpty", _file, _method);

        }

        [TestMethod]
        void NotIsNullOrEmpty() {

            DDTIsNotNOE(null, (1, false, "[String = null]"));
            DDTIsNotNOE(String.Empty, (2, false, "[String = '']"));
            DDTIsNotNOE(" ", (3, true, "[String = ' ']"));
            DDTIsNotNOE("content", (4, true, "[String = 'content']"));

        }

        void DDTIsNotNOE(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.IsNullOrEmpty({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.IsNullOrEmpty(input, _file, _method),
                expected, "Test.IfNot.String.IsNullOrEmpty", _file, _method);

        }

        #endregion

        #region NullOrWhiteSpace

        [TestMethod]
        void IsNullWhiteSpace() {

            DDTIsNOW(null, (1, true, "[String = null]"));
            DDTIsNOW(String.Empty, (2, true, "[String = '']"));
            DDTIsNOW(" ", (3, true, "[String = ' ']"));
            DDTIsNOW("content", (4, false, "[String = 'content']"));

        }

        void DDTIsNOW(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.IsNullOrWhiteSpace({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.IsNullOrWhiteSpace(input, _file, _method),
                expected, "Test.If.String.IsNullOrWhiteSpace", _file, _method);

        }

        [TestMethod]
        void NotIsNullWhiteSpace() {

            DDTIsNotNOW(null, (1, false, "[String = null]"));
            DDTIsNotNOW(String.Empty, (2, false, "[String = '']"));
            DDTIsNotNOW(" ", (3, false, "[String = ' ']"));
            DDTIsNotNOW("content", (4, true, "[String = 'content']"));

        }

        void DDTIsNotNOW(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.IsNullOrWhiteSpace({input.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.IsNullOrWhiteSpace(input, _file, _method),
                expected, "Test.IfNot.String.IsNullOrWhiteSpace", _file, _method);

        }

        #endregion

        #region Contains

        [TestMethod]
        void Contains() {

            DDTContains((null, null), (1, false, "Parameter 'string' is null."));
            DDTContains((null, "abc"), (2, false, "Parameter 'string' is null."));
            DDTContains(("abc", null), (3, false, "Parameter 'value' is null."));
            DDTContains((String.Empty, String.Empty), (4, true, "[String = ''; Value = '']"));
            DDTContains((String.Empty, "abc"), (5, false, "[String = ''; Value = 'abc']"));
            DDTContains(("abc", String.Empty), (6, true, "[String = 'abc'; Value = '']"));
            DDTContains(("abcd", "abcd"), (7, true, "[String = 'abcd'; Value = 'abcd']"));
            DDTContains(("abcd", "ab"), (8, true, "[String = 'abcd'; Value = 'ab']"));
            DDTContains(("abcd", "cd"), (9, true, "[String = 'abcd'; Value = 'cd']"));
            DDTContains(("abcd", "bc"), (10, true, "[String = 'abcd'; Value = 'bc']"));
            DDTContains(("abcd", "cb"), (11, false, "[String = 'abcd'; Value = 'cb']"));

        }

        void DDTContains((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.Contains({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.Contains(input.@string, input.value, _file, _method),
                expected, "Test.If.String.Contains", _file, _method);

        }

        [TestMethod]
        void NotContains() {

            DDTNotContains((null, null), (1, false, "Parameter 'string' is null."));
            DDTNotContains((null, "abc"), (2, false, "Parameter 'string' is null."));
            DDTNotContains(("abc", null), (3, false, "Parameter 'value' is null."));
            DDTNotContains((String.Empty, String.Empty), (4, false, "[String = ''; Value = '']"));
            DDTNotContains((String.Empty, "abc"), (5, true, "[String = ''; Value = 'abc']"));
            DDTNotContains(("abc", String.Empty), (6, false, "[String = 'abc'; Value = '']"));
            DDTNotContains(("abcd", "abcd"), (7, false, "[String = 'abcd'; Value = 'abcd']"));
            DDTNotContains(("abcd", "ab"), (8, false, "[String = 'abcd'; Value = 'ab']"));
            DDTNotContains(("abcd", "cd"), (9, false, "[String = 'abcd'; Value = 'cd']"));
            DDTNotContains(("abcd", "bc"), (10, false, "[String = 'abcd'; Value = 'bc']"));
            DDTNotContains(("abcd", "cb"), (11, true, "[String = 'abcd'; Value = 'cb']"));

        }

        void DDTNotContains((String @string, String value) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.Contains({input.@string.Print()}, {input.value.Print()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.Contains(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.Contains", _file, _method);

        }

        #endregion

    }
}
