using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using Nuclear.TestSite;

namespace Nuclear.Test.Results {
    internal class TestResultEndPoint : ITestResultEndPoint {

        #region fields

        private readonly ConcurrentDictionary<ITestResultKey, ITestMethodResult> _results = new ConcurrentDictionary<ITestResultKey, ITestMethodResult>(new TestResultKeyEqualityComparer());

        #endregion

        #region properties

        public ITestScenario Scenario { get; private set; }

        public IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> Values => _results;

        public IEnumerable<ITestResultKey> Keys => _results.Keys;

        public IEnumerable<ITestMethodResult> Results => _results.Values;

        public ITestMethodResult this[ITestResultKey key] => _results.GetOrAdd(key, new TestMethodResult());

        #endregion

        #region methods

        public void Add(ITestResultKey key, ITestMethodResult results)
            => _results.AddOrUpdate(key, results, (_key, value) => results);

        public void Add(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results) {
            foreach(KeyValuePair<ITestResultKey, ITestMethodResult> result in results) {
                Add(result.Key, result.Value);
            }
        }


        public void Initialize(ITestScenario scenario) => Scenario = scenario;

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
