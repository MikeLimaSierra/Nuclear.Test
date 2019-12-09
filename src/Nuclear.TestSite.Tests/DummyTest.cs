using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Test;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;
using Nuclear.TestSite.TestSuites;

namespace Nuclear.TestSite {
    static class DummyTest {

        #region properties

        public static TestSuiteCollection If { get; private set; } = new TestSuiteCollection(DummyTestResults.Instance);

        public static TestSuiteCollection IfNot { get; private set; } = new TestSuiteCollection(DummyTestResults.Instance, invert: true);

        #endregion

        #region ctors

        static DummyTest() {
            DummyTestResults.Instance.Initialize(Statics._scenario);
        }

        #endregion

        #region methods

        public static void Note(String note, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => DummyTestResults.Instance.AddNote(note, Path.GetFileNameWithoutExtension(_file), _method);

        #endregion

    }

    class DummyTestResults : ITestResultSink, ITestResultSource {

        #region fields

        private ConcurrentDictionary<ITestResultKey, ITestMethodResult> _results { get; } = new ConcurrentDictionary<ITestResultKey, ITestMethodResult>(new TestResultKeyEqualityComparer());

        #endregion

        #region properties

        internal static DummyTestResults Instance { get; } = new DummyTestResults();

        public ITestScenario Scenario { get; private set; }

        public IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> Values => _results;

        public IEnumerable<ITestResultKey> Keys => _results.Keys;

        public IEnumerable<ITestMethodResult> Results => _results.Values;

        public ITestMethodResult this[ITestResultKey key] => _results.GetOrAdd(key, new TestMethodResult());

        #endregion

        #region methods

        public void Initialize(ITestScenario scenario) => Scenario = scenario;

        public void Clear() => _results.Clear();

        public void PrepareResults(MethodInfo _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult());

        public void AddResult(Boolean result, String testInstruction, String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(result, testInstruction, message));

        public void AddNote(String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(message));

        public void FailTestMethod(MethodInfo _method, Exception ex)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult()).Fail(ex.ToString());

        #endregion

    }
}
