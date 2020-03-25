using System;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestEntry_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestEntry, ITestEntry>();

        }

        #region ctor

        [TestMethod]
        [TestParameters(EntryTypes.ResultOk, null, null, "instruction")]
        [TestParameters(EntryTypes.ResultFail, null, null, "instruction")]
        [TestParameters(EntryTypes.ResultOk, "", null, "instruction")]
        [TestParameters(EntryTypes.ResultFail, "", null, "instruction")]
        [TestParameters(EntryTypes.ResultOk, "SomeInstruction", null, "message")]
        [TestParameters(EntryTypes.ResultFail, "SomeInstruction", null, "message")]
        [TestParameters(EntryTypes.ResultOk, "SomeInstruction", "", "message")]
        [TestParameters(EntryTypes.ResultFail, "SomeInstruction", "", "message")]
        [TestParameters(EntryTypes.Note, null, null, "message")]
        [TestParameters(EntryTypes.Error, null, null, "message")]
        [TestParameters(EntryTypes.Note, null, "", "message")]
        [TestParameters(EntryTypes.Error, null, "", "message")]
        void ConstructorThrows(EntryTypes type, String instruction, String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = new TestEntry(type, instruction, message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestParameters(EntryTypes.ResultOk, "SomeInstruction", "message", EntryTypes.ResultOk, "SomeInstruction", "message")]
        [TestParameters(EntryTypes.ResultFail, "AnotherInstruction", "another message", EntryTypes.ResultFail, "AnotherInstruction", "another message")]
        [TestParameters(EntryTypes.Note, null, "message", EntryTypes.Note, null, "message")]
        [TestParameters(EntryTypes.Error, null, "message", EntryTypes.Error, null, "message")]
        [TestParameters(EntryTypes.Note, "SomeInstruction", "message", EntryTypes.Note, null, "message")]
        [TestParameters(EntryTypes.Error, "SomeInstruction", "message", EntryTypes.Error, null, "message")]
        void Constructor(EntryTypes type, String instruction, String message, EntryTypes expected_type, String expected_instruction, String expected_message) {

            ITestEntry entry = default;

            TestX.IfNot.Action.ThrowsException(() => entry = new TestEntry(type, instruction, message), out Exception ex);

            TestX.IfNot.Object.IsNull(entry);
            TestX.If.Value.IsEqual(entry.EntryType, expected_type);
            TestX.If.Value.IsEqual(entry.Instruction, expected_instruction);
            TestX.If.Value.IsEqual(entry.Message, expected_message);

        }

        #endregion

        #region FromResult

        [TestMethod]
        [TestParameters(true, null, null, "instruction")]
        [TestParameters(false, null, null, "instruction")]
        [TestParameters(true, "", null, "instruction")]
        [TestParameters(false, "", null, "instruction")]
        [TestParameters(true, "SomeInstruction", null, "message")]
        [TestParameters(false, "SomeInstruction", null, "message")]
        [TestParameters(true, "SomeInstruction", "", "message")]
        [TestParameters(false, "SomeInstruction", "", "message")]
        void FromResultThrows(Boolean result, String instruction, String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = TestEntry.FromResult(result, instruction, message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestParameters(true, "SomeInstruction", "message", EntryTypes.ResultOk, "SomeInstruction", "message")]
        [TestParameters(false, "AnotherInstruction", "another message", EntryTypes.ResultFail, "AnotherInstruction", "another message")]
        void FromResult(Boolean result, String instruction, String message, EntryTypes expected_type, String expected_instruction, String expected_message) {

            ITestEntry entry = default;

            TestX.IfNot.Action.ThrowsException(() => entry = TestEntry.FromResult(result, instruction, message), out Exception ex);

            TestX.IfNot.Object.IsNull(entry);
            TestX.If.Value.IsEqual(entry.EntryType, expected_type);
            TestX.If.Value.IsEqual(entry.Instruction, expected_instruction);
            TestX.If.Value.IsEqual(entry.Message, expected_message);

        }

        #endregion

        #region FromNote

        [TestMethod]
        [TestParameters(null, "message")]
        [TestParameters("", "message")]
        void FromNoteThrows(String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = TestEntry.FromNote(message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestParameters("message", EntryTypes.Note, null, "message")]
        void FromNote(String message, EntryTypes expected_type, String expected_instruction, String expected_message) {

            ITestEntry entry = default;

            TestX.IfNot.Action.ThrowsException(() => entry = TestEntry.FromNote(message), out Exception ex);

            TestX.IfNot.Object.IsNull(entry);
            TestX.If.Value.IsEqual(entry.EntryType, expected_type);
            TestX.If.Value.IsEqual(entry.Instruction, expected_instruction);
            TestX.If.Value.IsEqual(entry.Message, expected_message);

        }

        #endregion

        #region FromError

        [TestMethod]
        [TestParameters(null, "message")]
        [TestParameters("", "message")]
        void FromErrorThrows(String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = TestEntry.FromError(message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestParameters("message", EntryTypes.Error, null, "message")]
        void FromError(String message, EntryTypes expected_type, String expected_instruction, String expected_message) {

            ITestEntry entry = default;

            TestX.IfNot.Action.ThrowsException(() => entry = TestEntry.FromError(message), out Exception ex);

            TestX.IfNot.Object.IsNull(entry);
            TestX.If.Value.IsEqual(entry.EntryType, expected_type);
            TestX.If.Value.IsEqual(entry.Instruction, expected_instruction);
            TestX.If.Value.IsEqual(entry.Message, expected_message);

        }

        #endregion

    }
}
