using System;
using System.Collections.Concurrent;
using System.Reflection;

using Nuclear.Exceptions;
using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker {
    internal class ResultsSink : IResultsSink {

        #region fields

        internal readonly ConcurrentDictionary<ResultKey, TestMethodResults> _results = new ConcurrentDictionary<ResultKey, TestMethodResults>();

        internal readonly Scenario _scenario;

        #endregion

        #region ctors

        public ResultsSink(Scenario scenario) {
            Throw.If.Object.IsNull(scenario, nameof(scenario));

            _scenario = scenario;
        }

        #endregion

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
