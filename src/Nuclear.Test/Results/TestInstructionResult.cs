using System;
using Nuclear.Exceptions;

namespace Nuclear.Test.Results {
    internal class TestInstructionResult : ITestInstructionResult {

        #region properties

        public Boolean? Result { get; private set; }

        public String Instruction { get; private set; }

        public String Message { get; private set; }

        #endregion

        #region ctors

        internal TestInstructionResult(Boolean result, String instruction, String message) {
            Throw.If.NullOrWhiteSpace(instruction, "testInstruction");

            Result = result;
            Instruction = instruction;
            Message = message;
        }

        internal TestInstructionResult(String message) {
            Throw.If.NullOrWhiteSpace(message, "message");

            Result = null;
            Instruction = null;
            Message = message;
        }

        #endregion

    }
}
