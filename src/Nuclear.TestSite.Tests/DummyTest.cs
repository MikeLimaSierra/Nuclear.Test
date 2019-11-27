using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            => DummyTestResults.Instance.Add(note, Path.GetFileNameWithoutExtension(_file), _method);

        #endregion

    }

    class DummyTestResults : ITestResultsSink, ITestResultsSource {

        #region fields

        private ConcurrentDictionary<TestResultKey, TestMethodResult> _results { get; } = new ConcurrentDictionary<TestResultKey, TestMethodResult>();

        #endregion

        #region properties

        internal static DummyTestResults Instance { get; } = new DummyTestResults();

        public TestScenario Scenario { get; private set; }

        public IEnumerable<KeyValuePair<TestResultKey, TestMethodResult>> Values => _results;

        public IEnumerable<TestResultKey> Keys => _results.Keys;

        public IEnumerable<TestMethodResult> Results => _results.Values;

        public TestMethodResult this[TestResultKey key] => _results.GetOrAdd(key, new TestMethodResult());

        #endregion

        #region methods

        public void Initialize(TestScenario scenario) => Scenario = scenario;

        public void Clear() => _results.Clear();

        public void PrepareResults(MethodInfo _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult());

        public void Add(Boolean result, String testInstruction, String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(result, testInstruction, message));

        public void Add(String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(message));

        public void FailTestMethod(MethodInfo _method, Exception ex)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult()).Fail(ex.ToString());

        #endregion

    }
}
