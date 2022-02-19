using System;

namespace Nuclear.Test.Worker.TempTypes {
    public interface IResultsSink {
        void AddNote(String message, String _file, String _method);
        void AddResult(Boolean result, String testInstruction, String message, String _file, String _method);
    }
}
