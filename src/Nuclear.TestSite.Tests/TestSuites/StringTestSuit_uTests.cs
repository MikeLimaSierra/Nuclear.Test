using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;

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

            Test.Note($"Test.If.String.StartsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

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

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

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

            Test.Note($"Test.If.String.StartsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

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

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.StartsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.StartsWith", _file, _method);

        }

        #endregion

        #region StartsWithComparison

        [TestMethod]
        void StartsWithCharComparison() {

            DDTStartsWithCharComparison((null, 'x', StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTStartsWithCharComparison(("", 'x', (StringComparison) 10), (2, false, "Parameter 'comparisonType' is out of bounds."));
            DDTStartsWithCharComparison(("", 'x', StringComparison.CurrentCulture), (3, false, "[String = ''; Value = 'x']"));
            DDTStartsWithCharComparison(("ax", 'x', StringComparison.CurrentCulture), (4, false, "[String = 'ax'; Value = 'x']"));
            DDTStartsWithCharComparison(("xa", 'x', StringComparison.CurrentCulture), (5, true, "[String = 'xa'; Value = 'x']"));
            DDTStartsWithCharComparison(("Xa", 'x', StringComparison.CurrentCulture), (6, false, "[String = 'Xa'; Value = 'x']"));
            DDTStartsWithCharComparison(("Xa", 'x', StringComparison.CurrentCultureIgnoreCase), (7, true, "[String = 'Xa'; Value = 'x'; ComparisonType = 'CurrentCultureIgnoreCase']"));
        }

        void DDTStartsWithCharComparison((String @string, Char value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.StartsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.StartsWith(input.@string, input.value, input.comparisonType, _file, _method),
                expected, "Test.If.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void NotStartsWithCharComparison() {

            DDTNotStartsWithCharComparison((null, 'x', StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTNotStartsWithCharComparison(("", 'x', (StringComparison) 10), (2, false, "Parameter 'comparisonType' is out of bounds."));
            DDTNotStartsWithCharComparison(("", 'x', StringComparison.CurrentCulture), (3, true, "[String = ''; Value = 'x']"));
            DDTNotStartsWithCharComparison(("ax", 'x', StringComparison.CurrentCulture), (4, true, "[String = 'ax'; Value = 'x']"));
            DDTNotStartsWithCharComparison(("xa", 'x', StringComparison.CurrentCulture), (5, false, "[String = 'xa'; Value = 'x']"));
            DDTNotStartsWithCharComparison(("Xa", 'x', StringComparison.CurrentCulture), (6, true, "[String = 'Xa'; Value = 'x']"));
            DDTNotStartsWithCharComparison(("Xa", 'x', StringComparison.CurrentCultureIgnoreCase), (7, false, "[String = 'Xa'; Value = 'x'; ComparisonType = 'CurrentCultureIgnoreCase']"));

        }

        void DDTNotStartsWithCharComparison((String @string, Char value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.StartsWith(input.@string, input.value, input.comparisonType, _file, _method),
                expected, "Test.IfNot.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void StartsWithStringComparison() {

            DDTStartsWithStringComparison((null, null, StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTStartsWithStringComparison((null, "xy", StringComparison.CurrentCulture), (2, false, "Parameter 'string' is null."));
            DDTStartsWithStringComparison(("axy", null, StringComparison.CurrentCulture), (3, false, "Parameter 'value' is null."));
            DDTStartsWithStringComparison(("", "", (StringComparison) 10), (4, false, "Parameter 'comparisonType' is out of bounds."));
            DDTStartsWithStringComparison(("", "", StringComparison.CurrentCulture), (5, true, "[String = ''; Value = '']"));
            DDTStartsWithStringComparison(("", "xy", StringComparison.CurrentCulture), (6, false, "[String = ''; Value = 'xy']"));
            DDTStartsWithStringComparison(("xy", "", StringComparison.CurrentCulture), (7, true, "[String = 'xy'; Value = '']"));
            DDTStartsWithStringComparison(("axy", "xy", StringComparison.CurrentCulture), (8, false, "[String = 'axy'; Value = 'xy']"));
            DDTStartsWithStringComparison(("xya", "xy", StringComparison.CurrentCulture), (9, true, "[String = 'xya'; Value = 'xy']"));
            DDTStartsWithStringComparison(("Xya", "xy", StringComparison.CurrentCulture), (10, false, "[String = 'Xya'; Value = 'xy']"));
            DDTStartsWithStringComparison(("Xya", "xy", StringComparison.CurrentCultureIgnoreCase), (11, true, "[String = 'Xya'; Value = 'xy'; ComparisonType = 'CurrentCultureIgnoreCase']"));

        }

        void DDTStartsWithStringComparison((String @string, String value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.StartsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.StartsWith(input.@string, input.value, input.comparisonType, _file, _method),
                expected, "Test.If.String.StartsWith", _file, _method);

        }

        [TestMethod]
        void NotStartsWithStringComparison() {

            DDTNotStartsWithStringComparison((null, null, StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTNotStartsWithStringComparison((null, "xy", StringComparison.CurrentCulture), (2, false, "Parameter 'string' is null."));
            DDTNotStartsWithStringComparison(("axy", null, StringComparison.CurrentCulture), (3, false, "Parameter 'value' is null."));
            DDTNotStartsWithStringComparison(("", "", (StringComparison) 10), (4, false, "Parameter 'comparisonType' is out of bounds."));
            DDTNotStartsWithStringComparison(("", "", StringComparison.CurrentCulture), (5, false, "[String = ''; Value = '']"));
            DDTNotStartsWithStringComparison(("", "xy", StringComparison.CurrentCulture), (6, true, "[String = ''; Value = 'xy']"));
            DDTNotStartsWithStringComparison(("xy", "", StringComparison.CurrentCulture), (7, false, "[String = 'xy'; Value = '']"));
            DDTNotStartsWithStringComparison(("axy", "xy", StringComparison.CurrentCulture), (8, true, "[String = 'axy'; Value = 'xy']"));
            DDTNotStartsWithStringComparison(("xya", "xy", StringComparison.CurrentCulture), (9, false, "[String = 'xya'; Value = 'xy']"));
            DDTNotStartsWithStringComparison(("Xya", "xy", StringComparison.CurrentCulture), (10, true, "[String = 'Xya'; Value = 'xy']"));
            DDTNotStartsWithStringComparison(("Xya", "xy", StringComparison.CurrentCultureIgnoreCase), (11, false, "[String = 'Xya'; Value = 'xy'; ComparisonType = 'CurrentCultureIgnoreCase']"));
        }

        void DDTNotStartsWithStringComparison((String @string, String value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.StartsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.StartsWith(input.@string, input.value, input.comparisonType, _file, _method),
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

            Test.Note($"Test.If.String.EndsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

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

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

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

            Test.Note($"Test.If.String.EndsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

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

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Format()}, {input.value.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.EndsWith(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.EndsWith", _file, _method);

        }

        #endregion

        #region EndsWithComparison

        [TestMethod]
        void EndsWithCharComparison() {

            DDTEndsWithCharComparison((null, 'x', StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTEndsWithCharComparison(("", 'x', (StringComparison) 10), (2, false, "Parameter 'comparisonType' is out of bounds."));
            DDTEndsWithCharComparison(("", 'x', StringComparison.CurrentCulture), (3, false, "[String = ''; Value = 'x']"));
            DDTEndsWithCharComparison(("xa", 'x', StringComparison.CurrentCulture), (4, false, "[String = 'xa'; Value = 'x']"));
            DDTEndsWithCharComparison(("ax", 'x', StringComparison.CurrentCulture), (5, true, "[String = 'ax'; Value = 'x']"));
            DDTEndsWithCharComparison(("aX", 'x', StringComparison.CurrentCulture), (6, false, "[String = 'aX'; Value = 'x']"));
            DDTEndsWithCharComparison(("aX", 'x', StringComparison.CurrentCultureIgnoreCase), (7, true, "[String = 'aX'; Value = 'x'; ComparisonType = 'CurrentCultureIgnoreCase']"));

        }

        void DDTEndsWithCharComparison((String @string, Char value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.EndsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.EndsWith(input.@string, input.value, input.comparisonType, _file, _method),
                expected, "Test.If.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void NotEndsWithCharComparison() {

            DDTNotEndsWithCharComparison((null, 'x', StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTNotEndsWithCharComparison(("", 'x', (StringComparison) 10), (2, false, "Parameter 'comparisonType' is out of bounds."));
            DDTNotEndsWithCharComparison(("", 'x', StringComparison.CurrentCulture), (3, true, "[String = ''; Value = 'x']"));
            DDTNotEndsWithCharComparison(("xa", 'x', StringComparison.CurrentCulture), (4, true, "[String = 'xa'; Value = 'x']"));
            DDTNotEndsWithCharComparison(("ax", 'x', StringComparison.CurrentCulture), (5, false, "[String = 'ax'; Value = 'x']"));
            DDTNotEndsWithCharComparison(("aX", 'x', StringComparison.CurrentCulture), (6, true, "[String = 'aX'; Value = 'x']"));
            DDTNotEndsWithCharComparison(("aX", 'x', StringComparison.CurrentCultureIgnoreCase), (7, false, "[String = 'aX'; Value = 'x'; ComparisonType = 'CurrentCultureIgnoreCase']"));

        }

        void DDTNotEndsWithCharComparison((String @string, Char value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.EndsWith(input.@string, input.value, input.comparisonType, _file, _method),
                expected, "Test.IfNot.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void EndsWithStringComparison() {

            DDTEndsWithStringComparison((null, null, StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTEndsWithStringComparison((null, "xy", StringComparison.CurrentCulture), (2, false, "Parameter 'string' is null."));
            DDTEndsWithStringComparison(("axy", null, StringComparison.CurrentCulture), (3, false, "Parameter 'value' is null."));
            DDTEndsWithStringComparison(("", "", (StringComparison) 10), (4, false, "Parameter 'comparisonType' is out of bounds."));
            DDTEndsWithStringComparison(("", "", StringComparison.CurrentCulture), (5, true, "[String = ''; Value = '']"));
            DDTEndsWithStringComparison(("", "xy", StringComparison.CurrentCulture), (6, false, "[String = ''; Value = 'xy']"));
            DDTEndsWithStringComparison(("xy", "", StringComparison.CurrentCulture), (7, true, "[String = 'xy'; Value = '']"));
            DDTEndsWithStringComparison(("xya", "xy", StringComparison.CurrentCulture), (8, false, "[String = 'xya'; Value = 'xy']"));
            DDTEndsWithStringComparison(("axy", "xy", StringComparison.CurrentCulture), (9, true, "[String = 'axy'; Value = 'xy']"));
            DDTEndsWithStringComparison(("aXy", "xy", StringComparison.CurrentCulture), (10, false, "[String = 'aXy'; Value = 'xy']"));
            DDTEndsWithStringComparison(("aXy", "xy", StringComparison.CurrentCultureIgnoreCase), (11, true, "[String = 'aXy'; Value = 'xy'; ComparisonType = 'CurrentCultureIgnoreCase']"));

        }

        void DDTEndsWithStringComparison((String @string, String value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.EndsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.EndsWith(input.@string, input.value, input.comparisonType, _file, _method),
                expected, "Test.If.String.EndsWith", _file, _method);

        }

        [TestMethod]
        void NotEndsWithStringComparison() {

            DDTNotEndsWithStringComparison((null, null, StringComparison.CurrentCulture), (1, false, "Parameter 'string' is null."));
            DDTNotEndsWithStringComparison((null, "xy", StringComparison.CurrentCulture), (2, false, "Parameter 'string' is null."));
            DDTNotEndsWithStringComparison(("axy", null, StringComparison.CurrentCulture), (3, false, "Parameter 'value' is null."));
            DDTNotEndsWithStringComparison(("", "", (StringComparison) 10), (4, false, "Parameter 'comparisonType' is out of bounds."));
            DDTNotEndsWithStringComparison(("", "", StringComparison.CurrentCulture), (5, false, "[String = ''; Value = '']"));
            DDTNotEndsWithStringComparison(("", "xy", StringComparison.CurrentCulture), (6, true, "[String = ''; Value = 'xy']"));
            DDTNotEndsWithStringComparison(("xy", "", StringComparison.CurrentCulture), (7, false, "[String = 'xy'; Value = '']"));
            DDTNotEndsWithStringComparison(("xya", "xy", StringComparison.CurrentCulture), (8, true, "[String = 'xya'; Value = 'xy']"));
            DDTNotEndsWithStringComparison(("axy", "xy", StringComparison.CurrentCulture), (9, false, "[String = 'axy'; Value = 'xy']"));
            DDTNotEndsWithStringComparison(("aXy", "xy", StringComparison.CurrentCulture), (10, true, "[String = 'aXy'; Value = 'xy']"));
            DDTNotEndsWithStringComparison(("aXy", "xy", StringComparison.CurrentCultureIgnoreCase), (11, false, "[String = 'aXy'; Value = 'xy'; ComparisonType = 'CurrentCultureIgnoreCase']"));
        }

        void DDTNotEndsWithStringComparison((String @string, String value, StringComparison comparisonType) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.EndsWith({input.@string.Format()}, {input.value.Format()}, {input.comparisonType.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.EndsWith(input.@string, input.value, input.comparisonType, _file, _method),
                expected, "Test.IfNot.String.EndsWith", _file, _method);

        }

        #endregion

        #region NullOrEmpty

        [TestMethod]
        void IsNullOrEmpty() {

            DDTIsNOE(null, (1, true, "[String = 'null']"));
            DDTIsNOE(String.Empty, (2, true, "[String = '']"));
            DDTIsNOE(" ", (3, false, "[String = ' ']"));
            DDTIsNOE("content", (4, false, "[String = 'content']"));

        }

        void DDTIsNOE(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.IsNullOrEmpty({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.IsNullOrEmpty(input, _file, _method),
                expected, "Test.If.String.IsNullOrEmpty", _file, _method);

        }

        [TestMethod]
        void NotIsNullOrEmpty() {

            DDTIsNotNOE(null, (1, false, "[String = 'null']"));
            DDTIsNotNOE(String.Empty, (2, false, "[String = '']"));
            DDTIsNotNOE(" ", (3, true, "[String = ' ']"));
            DDTIsNotNOE("content", (4, true, "[String = 'content']"));

        }

        void DDTIsNotNOE(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.IsNullOrEmpty({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.IsNullOrEmpty(input, _file, _method),
                expected, "Test.IfNot.String.IsNullOrEmpty", _file, _method);

        }

        #endregion

        #region NullOrWhiteSpace

        [TestMethod]
        void IsNullWhiteSpace() {

            DDTIsNOW(null, (1, true, "[String = 'null']"));
            DDTIsNOW(String.Empty, (2, true, "[String = '']"));
            DDTIsNOW(" ", (3, true, "[String = ' ']"));
            DDTIsNOW("content", (4, false, "[String = 'content']"));

        }

        void DDTIsNOW(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.String.IsNullOrWhiteSpace({input.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.String.IsNullOrWhiteSpace(input, _file, _method),
                expected, "Test.If.String.IsNullOrWhiteSpace", _file, _method);

        }

        [TestMethod]
        void NotIsNullWhiteSpace() {

            DDTIsNotNOW(null, (1, false, "[String = 'null']"));
            DDTIsNotNOW(String.Empty, (2, false, "[String = '']"));
            DDTIsNotNOW(" ", (3, false, "[String = ' ']"));
            DDTIsNotNOW("content", (4, true, "[String = 'content']"));

        }

        void DDTIsNotNOW(String input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.String.IsNullOrWhiteSpace({input.Format()})", _file, _method);

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

            Test.Note($"Test.If.String.Contains({input.@string.Format()}, {input.value.Format()})", _file, _method);

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

            Test.Note($"Test.IfNot.String.Contains({input.@string.Format()}, {input.value.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.String.Contains(input.@string, input.value, _file, _method),
                expected, "Test.IfNot.String.Contains", _file, _method);

        }

        #endregion

    }
}
