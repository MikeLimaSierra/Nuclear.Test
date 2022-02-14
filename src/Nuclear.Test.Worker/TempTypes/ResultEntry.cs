using System;

using Nuclear.Exceptions;

namespace Nuclear.Test.Worker.TempTypes {
    internal class ResultEntry : IResultEntry {

        #region properties

        public EntryTypes EntryType { get; }
        
        public String Instruction { get; }
        
        public String Message { get; }

        #endregion

        #region ctors

        public ResultEntry(EntryTypes type, String instruction, String message) {
            Throw.IfNot.Enum.IsDefined<EntryTypes>(type, nameof(type));
            Throw.If.String.IsNullOrWhiteSpace(message, nameof(message));

            EntryType = type;
            Message = message;

            if(EntryType == EntryTypes.ResultOk || EntryType == EntryTypes.ResultFail) {
                Throw.If.String.IsNullOrWhiteSpace(instruction, nameof(instruction));
               
                Instruction = instruction;
            }            
        }

        #endregion

        #region methods

        #endregion

    }

}
