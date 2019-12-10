using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    class ReferenceTestSuite_uTests {

        #region ReferencesEqual

        [TestMethod]
        void ReferencesEqual() {

            DDTReferencesEqual((null, null), (1, true, "References equal."));
            DDTReferencesEqual((null, new Object()), (2, false, "References don't equal."));
            DDTReferencesEqual((new Object(), null), (3, false, "References don't equal."));
            DDTReferencesEqual((new Object(), new Object()), (4, false, "References don't equal."));
            DDTReferencesEqual((DummyTestResults.Instance, DummyTestResults.Instance), (5, true, "References equal."));

        }

        void DDTReferencesEqual((Object @object, Object other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Reference.Equals({input.@object.Format()}, {input.other.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Reference.Equals(input.@object, input.other, _file, _method),
                expected, "Test.If.Reference.Equals", _file, _method);

        }

        [TestMethod]
        void NotReferencesEqual() {

            DDTNotReferencesEqual((null, null), (1, false, "References equal."));
            DDTNotReferencesEqual((null, new Object()), (2, true, "References don't equal."));
            DDTNotReferencesEqual((new Object(), null), (3, true, "References don't equal."));
            DDTNotReferencesEqual((new Object(), new Object()), (4, true, "References don't equal."));
            DDTNotReferencesEqual((DummyTestResults.Instance, DummyTestResults.Instance), (5, false, "References equal."));

        }

        void DDTNotReferencesEqual((Object @object, Object other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Reference.Equals({input.@object.Format()}, {input.other.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Reference.Equals(input.@object, input.other, _file, _method),
                expected, "Test.IfNot.Reference.Equals", _file, _method);

        }

        #endregion

    }
}
