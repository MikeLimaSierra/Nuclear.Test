using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;

namespace Nuclear.TestSite.TestSuites {
    class ReferenceTestSuite_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqual() {

            DDTIsEqual((null, null), (1, true, "References equal."));
            DDTIsEqual((null, new Object()), (2, false, "References don't equal."));
            DDTIsEqual((new Object(), null), (3, false, "References don't equal."));
            DDTIsEqual((new Object(), new Object()), (4, false, "References don't equal."));
            DDTIsEqual((DummyTestResults.Instance, DummyTestResults.Instance), (5, true, "References equal."));

        }

        void DDTIsEqual((Object @object, Object other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.If.Reference.IsEqual({input.@object.Format()}, {input.other.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.If.Reference.IsEqual(input.@object, input.other, _file, _method),
                expected, "Test.If.Reference.IsEqual", _file, _method);

        }

        [TestMethod]
        void NotIsEqual() {

            IsEqual((null, null), (1, false, "References equal."));
            IsEqual((null, new Object()), (2, true, "References don't equal."));
            IsEqual((new Object(), null), (3, true, "References don't equal."));
            IsEqual((new Object(), new Object()), (4, true, "References don't equal."));
            IsEqual((DummyTestResults.Instance, DummyTestResults.Instance), (5, false, "References equal."));

        }

        void IsEqual((Object @object, Object other) input, (Int32 count, Boolean result, String message) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.Note($"Test.IfNot.Reference.IsEqual({input.@object.Format()}, {input.other.Format()})", _file, _method);

            Statics.DDTResultState(() => DummyTest.IfNot.Reference.IsEqual(input.@object, input.other, _file, _method),
                expected, "Test.IfNot.Reference.IsEqual", _file, _method);

        }

        #endregion

    }
}
