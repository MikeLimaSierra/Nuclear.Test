using System;
using Nuclear.Test.Results;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Results {
    class TestInstructionResult_uTests {

        [TestMethod]
        void TestResultConstructor() {

            TestInstructionResult result = null;

            Test.Note("new TestResult(false, null, null)");
            Test.If.Action.ThrowsException(() => result = new TestInstructionResult(false, null, null), out ArgumentNullException argNullEx);
            Test.IfNot.Object.IsNull(argNullEx);
            Test.If.Value.Equals(argNullEx.ParamName, "testInstruction");
            Test.If.Object.IsNull(result);

            Test.Note("new TestResult(false, String.Empty, null)");
            Test.If.Action.ThrowsException(() => result = new TestInstructionResult(false, String.Empty, null), out ArgumentException argEx);
            Test.IfNot.Object.IsNull(argEx);
            Test.If.Value.Equals(argEx.ParamName, "testInstruction");
            Test.If.Object.IsNull(result);

            Test.Note("new TestResult(false, \"SomeInstruction\", null)");
            Test.IfNot.Action.ThrowsException(() => result = new TestInstructionResult(false, "SomeInstruction", null), out Exception ex);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsTrue(result.Result.HasValue);
            Test.If.Value.IsFalse(result.Result);
            Test.If.Value.Equals(result.Instruction, "SomeInstruction");
            Test.If.Value.Equals(result.Message, null);

            Test.Note("new TestResult(true, \"SomeInstruction\", \"Some message\")");
            Test.IfNot.Action.ThrowsException(() => result = new TestInstructionResult(true, "SomeInstruction", "Some message"), out ex);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsTrue(result.Result.HasValue);
            Test.If.Value.IsTrue(result.Result);
            Test.If.Value.Equals(result.Instruction, "SomeInstruction");
            Test.If.Value.Equals(result.Message, "Some message");

        }

        [TestMethod]
        void TestNoteConstructor() {

            TestInstructionResult result = null;

            Test.Note("new TestResult(null)");
            Test.If.Action.ThrowsException(() => result = new TestInstructionResult(null), out ArgumentNullException argNullEx);
            Test.IfNot.Object.IsNull(argNullEx);
            Test.If.Value.Equals(argNullEx.ParamName, "message");
            Test.If.Object.IsNull(result);

            Test.Note("new TestResult(String.Empty)");
            Test.If.Action.ThrowsException(() => result = new TestInstructionResult(String.Empty), out ArgumentException argEx);
            Test.IfNot.Object.IsNull(argEx);
            Test.If.Value.Equals(argEx.ParamName, "message");
            Test.If.Object.IsNull(result);

            Test.Note("new TestResult(\"Some test note\")");
            Test.IfNot.Action.ThrowsException(() => result = new TestInstructionResult("Some test note"), out Exception ex);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsFalse(result.Result.HasValue);
            Test.If.Object.IsNull(result.Instruction);
            Test.If.Value.Equals(result.Message, "Some test note");

        }

    }
}
