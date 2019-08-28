using System;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Tests {
    class TestTests {

        [TestMethod]
        void TestNote() {

            Test.Note("Test.Note(\"This is a note\")");
            Test.IfNot.ThrowsException(() => DummyTest.Note("This is a note"), out Exception ex);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result.HasValue);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "This is a note");

            Test.Note("Test.Note(String.Empty)");
            Test.If.ThrowsException(() => DummyTest.Note(String.Empty), out ArgumentException argEx);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result.HasValue);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "This is a note");

            Test.Note("Test.Note(null)");
            Test.If.ThrowsException(() => DummyTest.Note(null), out ArgumentNullException argNullEx);
            Test.If.ValuesEqual(Statics.GetResults(DummyTestResults.Instance).Count, 1);
            Test.If.False(Statics.GetLastResult(DummyTestResults.Instance).Result.HasValue);
            Test.If.ValuesEqual(Statics.GetLastResult(DummyTestResults.Instance).Message, "This is a note");

        }

    }
}
