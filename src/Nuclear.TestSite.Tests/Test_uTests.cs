using System;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite {
    class Test_uTests {

        [TestMethod]
        void TestNote() {

            Test.Note("Test.Note(\"This is a note\")");
            Test.IfNot.Action.ThrowsException(() => DummyTest.Note("This is a note"), out Exception ex);
            Test.If.Value.Equals(Statics.GetResults(DummyTestResults.Instance).CountResults, 1);
            Test.If.Value.IsFalse(Statics.GetLastResult(DummyTestResults.Instance).Result.HasValue);
            Test.If.Value.Equals(Statics.GetLastResult(DummyTestResults.Instance).Message, "This is a note");

            Test.Note("Test.Note(String.Empty)");
            Test.If.Action.ThrowsException(() => DummyTest.Note(String.Empty), out ArgumentException argEx);
            Test.If.Value.Equals(Statics.GetResults(DummyTestResults.Instance).CountResults, 1);
            Test.If.Value.IsFalse(Statics.GetLastResult(DummyTestResults.Instance).Result.HasValue);
            Test.If.Value.Equals(Statics.GetLastResult(DummyTestResults.Instance).Message, "This is a note");

            Test.Note("Test.Note(null)");
            Test.If.Action.ThrowsException(() => DummyTest.Note(null), out ArgumentNullException argNullEx);
            Test.If.Value.Equals(Statics.GetResults(DummyTestResults.Instance).CountResults, 1);
            Test.If.Value.IsFalse(Statics.GetLastResult(DummyTestResults.Instance).Result.HasValue);
            Test.If.Value.Equals(Statics.GetLastResult(DummyTestResults.Instance).Message, "This is a note");

        }

    }
}
