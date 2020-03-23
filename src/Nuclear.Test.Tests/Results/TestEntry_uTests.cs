using System;
using Nuclear.TestSite;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestEntry_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestEntry, ITestEntry>();

        }

        [TestMethod]
        void Constructor() {

            ITestEntry result = null;

            TestX.Note("new TestResult(false, null, null)");
            TestX.If.Action.ThrowsException(() => result = new TestEntry(EntryTypes.ResultFail, null, null), out ArgumentNullException argNullEx);
            TestX.If.Value.IsEqual(argNullEx.ParamName, "instruction");
            TestX.If.Object.IsNull(result);

            TestX.Note("new TestResult(false, String.Empty, null)");
            TestX.If.Action.ThrowsException(() => result = new TestEntry(EntryTypes.ResultFail, String.Empty, null), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, "instruction");
            TestX.If.Object.IsNull(result);

            TestX.Note("new TestResult(false, \"SomeInstruction\", null)");
            TestX.If.Action.ThrowsException(() => result = new TestEntry(EntryTypes.ResultFail, "SomeInstruction", null), out Exception ex);
            TestX.If.Object.IsNull(ex);
            TestX.IfNot.Object.IsNull(result);
            TestX.If.Value.IsEqual(result.EntryType, EntryTypes.ResultFail);
            TestX.If.Value.IsEqual(result.Instruction, "SomeInstruction");
            TestX.If.Value.IsEqual(result.Message, null);

            TestX.Note("new TestResult(false, \"SomeInstruction\", String.Empty)");
            TestX.If.Action.ThrowsException(() => result = new TestEntry(EntryTypes.ResultFail, "SomeInstruction", String.Empty), out ex);
            TestX.If.Object.IsNull(ex);
            TestX.IfNot.Object.IsNull(result);
            TestX.If.Value.IsEqual(result.EntryType, EntryTypes.ResultFail);
            TestX.If.Value.IsEqual(result.Instruction, "SomeInstruction");
            TestX.If.Value.IsEqual(result.Message, String.Empty);

            TestX.Note("new TestResult(true, \"SomeInstruction\", \"Some message\")");
            TestX.IfNot.Action.ThrowsException(() => result = new TestEntry(EntryTypes.ResultOk, "SomeInstruction", "Some message"), out ex);
            TestX.If.Object.IsNull(ex);
            TestX.IfNot.Object.IsNull(result);
            TestX.If.Value.IsEqual(result.EntryType, EntryTypes.ResultOk);
            TestX.If.Value.IsEqual(result.Instruction, "SomeInstruction");
            TestX.If.Value.IsEqual(result.Message, "Some message");

        }

    }
}
