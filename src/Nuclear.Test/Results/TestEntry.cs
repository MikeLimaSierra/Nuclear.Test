using System;

using Nuclear.Exceptions;

namespace Nuclear.Test.Results {
    internal class TestEntry : ITestEntry {

        #region properties

        public EntryTypes EntryType { get; private set; }

        public String Instruction { get; private set; }

        public String Message { get; private set; }

        #endregion

        #region ctors

        internal TestEntry(EntryTypes type, String instruction, String message) {
            if(type == EntryTypes.ResultOk || type == EntryTypes.ResultFail) {
                Throw.If.String.IsNullOrWhiteSpace(instruction, nameof(instruction));
                Instruction = instruction;
            }

            Throw.If.String.IsNullOrWhiteSpace(message, nameof(message));

            EntryType = type;
            Message = message;
        }

        #endregion

        #region methods

        internal static ITestEntry FromResult(Boolean result, String instruction, String message) {
            Throw.If.String.IsNullOrWhiteSpace(instruction, nameof(instruction));
            Throw.If.String.IsNullOrWhiteSpace(message, nameof(message));

            return new TestEntry(result ? EntryTypes.ResultOk : EntryTypes.ResultFail, instruction, message);
        }

        internal static ITestEntry FromNote(String message) {
            Throw.If.String.IsNullOrWhiteSpace(message, nameof(message));

            return new TestEntry(EntryTypes.Note, null, message);
        }

        internal static ITestEntry FromError(String message) {
            Throw.If.String.IsNullOrWhiteSpace(message, nameof(message));

            return new TestEntry(EntryTypes.Error, null, message);
        }

        #endregion

    }
}
