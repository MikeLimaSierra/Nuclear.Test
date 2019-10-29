using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.TestSuites {
    class TestSuiteCollection_uTests {

        #region ReferencesEqual

        [TestMethod]
        void TestReferencesEqual() {

            DDTestReferencesEqual((null, null), (1, true, "References equal."));
            DDTestReferencesEqual((null, new Object()), (2, false, "References don't equal."));
            DDTestReferencesEqual((new Object(), null), (3, false, "References don't equal."));
            DDTestReferencesEqual((new Object(), new Object()), (4, false, "References don't equal."));
            DDTestReferencesEqual((DummyTestResults.Instance, DummyTestResults.Instance), (5, true, "References equal."));

        }

        void DDTestReferencesEqual((Object @object, Object other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.ReferencesEqual({input.@object.Print()}, {input.other.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.If.ReferencesEqual(input.@object, input.other, _file, _method),
                expected, "Test.If.ReferencesEqual", _file, _method);

        }

        [TestMethod]
        void TestNotReferencesEqual() {

            DDTestNotReferencesEqual((null, null), (1, false, "References equal."));
            DDTestNotReferencesEqual((null, new Object()), (2, true, "References don't equal."));
            DDTestNotReferencesEqual((new Object(), null), (3, true, "References don't equal."));
            DDTestNotReferencesEqual((new Object(), new Object()), (4, true, "References don't equal."));
            DDTestNotReferencesEqual((DummyTestResults.Instance, DummyTestResults.Instance), (5, false, "References equal."));

        }

        void DDTestNotReferencesEqual((Object @object, Object other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.ReferencesEqual({input.@object.Print()}, {input.other.Print()})", _file, _method);

            Statics.DDTestResultState(() => DummyTest.IfNot.ReferencesEqual(input.@object, input.other, _file, _method),
                expected, "Test.IfNot.ReferencesEqual", _file, _method);

        }

        #endregion

    }
}
