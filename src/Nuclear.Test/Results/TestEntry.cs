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
            if(type != EntryTypes.Note && type != EntryTypes.Error) {
                Throw.If.String.IsNullOrWhiteSpace(instruction, nameof(instruction));
            }

            Throw.If.String.IsNullOrWhiteSpace(message, nameof(message));

            EntryType = type;
            Instruction = instruction;
            Message = message;
        }

        #endregion

    }
}
