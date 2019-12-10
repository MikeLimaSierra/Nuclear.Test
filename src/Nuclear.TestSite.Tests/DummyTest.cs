using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.Test;
using Nuclear.Test.Results;
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

        private ConcurrentDictionary<ITestResultKey, ITestMethodResult> _results { get; } =
            new ConcurrentDictionary<ITestResultKey, ITestMethodResult>(DynamicEqualityComparer.FromIEquatable<ITestResultKey>());

        private static readonly IEqualityComparer<ITestResultKey> _comparer = DynamicEqualityComparer.FromIEquatable<ITestResultKey>();

        #endregion

        #region properties

        internal static DummyTestResults Instance { get; } = new DummyTestResults();

        public ITestScenario Scenario { get; private set; }

        #endregion

        #region methods

        public void Initialize(ITestScenario scenario) => Scenario = scenario;

        public void Clear() => _results.Clear();

        public void PrepareResults(MethodInfo _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult());

        public void FailTestMethod(MethodInfo _method, Exception ex)
            => _results.GetOrAdd(new TestResultKey(Scenario, _method.DeclaringType.Name, _method.Name),
                new TestMethodResult()).Fail(ex.ToString());

        #endregion

        #region ITestResultSource

        public IEnumerable<ITestResultKey> GetKeys() => _results.Keys;

        public IEnumerable<ITestResultKey> GetKeys(ITestResultKey match) => GetKeys().Where(key => key.Matches(match));

        public IEnumerable<ITestResultKey> GetKeys(ITestResultKey match, TestResultKeyPrecisions precision) {
            List<ITestResultKey> keys = new List<ITestResultKey>();

            foreach(ITestResultKey key in GetKeys(match)) {
                ITestResultKey clippedKey = key.Clip(precision);

                if(!keys.Contains(clippedKey, _comparer)) {
                    keys.Add(clippedKey);
                }
            }

            return keys;
        }

        public ITestMethodResult GetResult(ITestResultKey key) => _results.GetOrAdd(key, new TestMethodResult());

        public IEnumerable<ITestMethodResult> GetResults() => _results.Values;

        public IEnumerable<ITestMethodResult> GetResults(ITestResultKey match) => _results.Where(value => value.Key.Matches(match)).Select(value => value.Value);

        public IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> GetKeyedResults() => _results;

        #endregion

        #region ITestResultSink

        public void AddResult(Boolean result, String testInstruction, String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(result, testInstruction, message));

        public void AddNote(String message, String _file, String _method)
            => _results.GetOrAdd(new TestResultKey(Scenario, _file, _method),
                new TestMethodResult()).InstructionResults.Add(new TestInstructionResult(message));

        #endregion

    }
}
