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
        [TestData(EntryTypes.ResultOk, null, null, "instruction")]
        [TestData(EntryTypes.ResultFail, null, null, "instruction")]
        [TestData(EntryTypes.ResultOk, "", null, "instruction")]
        [TestData(EntryTypes.ResultFail, "", null, "instruction")]
        [TestData(EntryTypes.ResultOk, "SomeInstruction", null, "message")]
        [TestData(EntryTypes.ResultFail, "SomeInstruction", null, "message")]
        [TestData(EntryTypes.ResultOk, "SomeInstruction", "", "message")]
        [TestData(EntryTypes.ResultFail, "SomeInstruction", "", "message")]
        [TestData(EntryTypes.Note, null, null, "message")]
        [TestData(EntryTypes.Error, null, null, "message")]
        [TestData(EntryTypes.Note, null, "", "message")]
        [TestData(EntryTypes.Error, null, "", "message")]
        void ConstructorThrows(EntryTypes type, String instruction, String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = new TestEntry(type, instruction, message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestData(EntryTypes.ResultOk, "SomeInstruction", "message", EntryTypes.ResultOk, "SomeInstruction", "message")]
        [TestData(EntryTypes.ResultFail, "AnotherInstruction", "another message", EntryTypes.ResultFail, "AnotherInstruction", "another message")]
        [TestData(EntryTypes.Note, null, "message", EntryTypes.Note, null, "message")]
        [TestData(EntryTypes.Error, null, "message", EntryTypes.Error, null, "message")]
        [TestData(EntryTypes.Note, "SomeInstruction", "message", EntryTypes.Note, null, "message")]
        [TestData(EntryTypes.Error, "SomeInstruction", "message", EntryTypes.Error, null, "message")]
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
        [TestData(true, null, null, "instruction")]
        [TestData(false, null, null, "instruction")]
        [TestData(true, "", null, "instruction")]
        [TestData(false, "", null, "instruction")]
        [TestData(true, "SomeInstruction", null, "message")]
        [TestData(false, "SomeInstruction", null, "message")]
        [TestData(true, "SomeInstruction", "", "message")]
        [TestData(false, "SomeInstruction", "", "message")]
        void FromResultThrows(Boolean result, String instruction, String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = TestEntry.FromResult(result, instruction, message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestData(true, "SomeInstruction", "message", EntryTypes.ResultOk, "SomeInstruction", "message")]
        [TestData(false, "AnotherInstruction", "another message", EntryTypes.ResultFail, "AnotherInstruction", "another message")]
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
        [TestData(null, "message")]
        [TestData("", "message")]
        void FromNoteThrows(String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = TestEntry.FromNote(message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestData("message", EntryTypes.Note, null, "message")]
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
        [TestData(null, "message")]
        [TestData("", "message")]
        void FromErrorThrows(String message, String paramName) {

            ITestEntry entry = default;

            TestX.If.Action.ThrowsException(() => entry = TestEntry.FromError(message), out ArgumentException argEx);
            TestX.If.Value.IsEqual(argEx.ParamName, paramName);
            TestX.If.Object.IsNull(entry);

        }

        [TestMethod]
        [TestData("message", EntryTypes.Error, null, "message")]
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
