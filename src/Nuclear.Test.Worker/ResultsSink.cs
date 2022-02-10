using System;
using System.Reflection;

namespace Nuclear.Test.Worker {
    internal class ResultsSink : IResultsSink {

        #region method

        internal void Prepare(MethodInfo method) => throw new NotImplementedException();

        internal void LogError(MethodInfo method, String message) => throw new NotImplementedException();

        internal void LogDataSource(MethodInfo method, String sourceString) => throw new NotImplementedException();

        internal void LogParameterInjection(MethodInfo method, params Object[] parameters) => throw new NotImplementedException();

        internal void LogIgnore(MethodInfo method, String reason) => throw new NotImplementedException();

        public void AddNote(String message, String _file, String _method) => throw new NotImplementedException();

        public void AddResult(Boolean result, String testInstruction, String message, String _file, String _method) => throw new NotImplementedException();

        #endregion

    }
}
