using System;
using Nuclear.TestSite;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestInstructionResult_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestInstructionResult, ITestInstructionResult>();

        }

        [TestMethod]
        void ResultConstructor() {

            ITestInstructionResult result = null;

            TestX.Note("new TestResult(false, null, null)");
            TestX.If.Action.ThrowsException(() => result = new TestInstructionResult(false, null, null), out ArgumentNullException argNullEx);
            TestX.IfNot.Object.IsNull(argNullEx);
            TestX.If.Value.IsEqual(argNullEx.ParamName, "instruction");
            TestX.If.Object.IsNull(result);

            TestX.Note("new TestResult(false, String.Empty, null)");
            TestX.If.Action.ThrowsException(() => result = new TestInstructionResult(false, String.Empty, null), out ArgumentException argEx);
            TestX.IfNot.Object.IsNull(argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, "instruction");
            TestX.If.Object.IsNull(result);

            TestX.Note("new TestResult(false, \"SomeInstruction\", null)");
            TestX.IfNot.Action.ThrowsException(() => result = new TestInstructionResult(false, "SomeInstruction", null), out Exception ex);
            TestX.If.Object.IsNull(ex);
            TestX.IfNot.Object.IsNull(result);
            TestX.If.Value.IsTrue(result.Result.HasValue);
            TestX.If.Value.IsFalse(result.Result);
            TestX.If.Value.IsEqual(result.Instruction, "SomeInstruction");
            TestX.If.Value.IsEqual(result.Message, null);

            TestX.Note("new TestResult(true, \"SomeInstruction\", \"Some message\")");
            TestX.IfNot.Action.ThrowsException(() => result = new TestInstructionResult(true, "SomeInstruction", "Some message"), out ex);
            TestX.If.Object.IsNull(ex);
            TestX.IfNot.Object.IsNull(result);
            TestX.If.Value.IsTrue(result.Result.HasValue);
            TestX.If.Value.IsTrue(result.Result);
            TestX.If.Value.IsEqual(result.Instruction, "SomeInstruction");
            TestX.If.Value.IsEqual(result.Message, "Some message");

        }

        [TestMethod]
        void NoteConstructor() {

            ITestInstructionResult result = null;

            TestX.Note("new TestResult(null)");
            TestX.If.Action.ThrowsException(() => result = new TestInstructionResult(null), out ArgumentNullException argNullEx);
            TestX.IfNot.Object.IsNull(argNullEx);
            TestX.If.Value.IsEqual(argNullEx.ParamName, "message");
            TestX.If.Object.IsNull(result);

            TestX.Note("new TestResult(String.Empty)");
            TestX.If.Action.ThrowsException(() => result = new TestInstructionResult(String.Empty), out ArgumentException argEx);
            TestX.IfNot.Object.IsNull(argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, "message");
            TestX.If.Object.IsNull(result);

            TestX.Note("new TestResult(\"Some test note\")");
            TestX.IfNot.Action.ThrowsException(() => result = new TestInstructionResult("Some test note"), out Exception ex);
            TestX.If.Object.IsNull(ex);
            TestX.IfNot.Object.IsNull(result);
            TestX.If.Value.IsFalse(result.Result.HasValue);
            TestX.If.Object.IsNull(result.Instruction);
            TestX.If.Value.IsEqual(result.Message, "Some test note");

        }

    }
}
