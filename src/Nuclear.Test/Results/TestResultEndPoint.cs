using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Nuclear.Extensions;

namespace Nuclear.Test.Results {
    internal class TestResultEndPoint : ITestResultEndPoint {

        #region fields

        private readonly ConcurrentDictionary<ITestResultKey, ITestMethodResult> _results =
            new ConcurrentDictionary<ITestResultKey, ITestMethodResult>(_comparer);

        private static readonly IEqualityComparer<ITestResultKey> _comparer = DynamicEqualityComparer.FromIEquatable<ITestResultKey>();

        #endregion

        #region properties

        public ITestScenario Scenario { get; private set; }

        #endregion

        #region methods

        public void Add(ITestResultKey key, ITestMethodResult results)
            => _results.AddOrUpdate(key, results, (_, __) => results);

        public void Add(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> results) {
            foreach(KeyValuePair<ITestResultKey, ITestMethodResult> result in results) {
                Add(result.Key, result.Value);
            }
        }


        public void Initialize(ITestScenario scenario) => Scenario = scenario;

        public void Clear() => _results.Clear();

        public void PrepareResults(MethodInfo _method) {
            Factory.Instance.Create(out ITestResultKey key, Scenario, _method.DeclaringType.Name, _method.Name);
            Factory.Instance.Create(out ITestMethodResult result);

            _results.GetOrAdd(key, result);
        }

        public void LogError(MethodInfo _method, String message) => AddEntry(TestEntry.FromError(message), _method.DeclaringType.Name, _method.Name);

        public void LogInjection(MethodInfo _method, String message) => AddEntry(TestEntry.FromInjection(message), _method.DeclaringType.Name, _method.Name);

        public void IgnoreTestMethod(MethodInfo _method, String ignoreReason) {
            Factory.Instance.Create(out ITestResultKey key, Scenario, _method.DeclaringType.Name, _method.Name);
            Factory.Instance.Create(out ITestMethodResult result);
            result.Ignore(ignoreReason);

            _results.GetOrAdd(key, result);
        }

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

        public ITestMethodResult GetResult(ITestResultKey key) {
            Factory.Instance.Create(out ITestMethodResult result);

            return _results.GetOrAdd(key, result);
        }

        public IEnumerable<ITestMethodResult> GetResults() => _results.Values;

        public IEnumerable<ITestMethodResult> GetResults(ITestResultKey match) => _results.Where(kvp => kvp.Key.Matches(match)).Select(value => value.Value);

        public IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> GetKeyedResults() => _results;

        #endregion

        #region ITestResultSink

        public void AddResult(Boolean result, String testInstruction, String message, String _file, String _method)
            => AddEntry(TestEntry.FromResult(result, testInstruction, message), _file, _method);

        public void AddNote(String message, String _file, String _method)
            => AddEntry(TestEntry.FromNote(message), _file, _method);

        #endregion

        #region private methods

        private void AddEntry(ITestEntry entry, String _file, String _method) {
            Factory.Instance.Create(out ITestResultKey key, Scenario, _file, _method);
            Factory.Instance.Create(out ITestMethodResult result);

            _results.GetOrAdd(key, result).TestEntries.Add(entry);
        }


        #endregion

    }
}
