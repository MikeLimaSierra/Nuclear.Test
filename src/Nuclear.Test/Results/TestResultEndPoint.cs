using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using log4net;

using Nuclear.Extensions;

namespace Nuclear.Test.Results {
    internal class TestResultEndPoint : ITestResultEndPoint {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(TestResultEndPoint));

        private readonly ConcurrentDictionary<IResultKey, ITestMethodResult> _results =
            new ConcurrentDictionary<IResultKey, ITestMethodResult>(DynamicEqualityComparer.FromIEquatable<IResultKey>());

        #endregion

        #region properties

        public ITestScenario Scenario { get; private set; }

        #endregion

        #region ITestResultEndPoint

        public void Add(IResultKey key, ITestMethodResult results) {
            _log.Debug($"{nameof(Add)}({key.Format()}, {results.CountEntries.Format()})");

            _results.AddOrUpdate(key, results, (_, __) => results);
        }

        public void Add(IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results) {
            _log.Debug($"{nameof(Add)}({results.Count().Format()})");

            foreach(KeyValuePair<IResultKey, ITestMethodResult> result in results) {
                Add(result.Key, result.Value);
            }
        }


        public void Initialize(ITestScenario scenario) => Scenario = scenario;

        public void Clear() => _results.Clear();

        public void PrepareResults(MethodInfo _method) {
            Factory.Instance.Create(out IResultKey key, Scenario, _method.DeclaringType.Name, _method.Name);
            Factory.Instance.Create(out ITestMethodResult result);

            _results.GetOrAdd(key, result);
        }

        public void LogError(MethodInfo _method, String message) => AddEntry(TestEntry.FromError(message), _method.DeclaringType.Name, _method.Name);

        public void LogInjection(MethodInfo _method, String message) => AddEntry(TestEntry.FromInjection(message), _method.DeclaringType.Name, _method.Name);

        public void IgnoreTestMethod(MethodInfo _method, String ignoreReason) {
            Factory.Instance.Create(out IResultKey key, Scenario, _method.DeclaringType.Name, _method.Name);
            Factory.Instance.Create(out ITestMethodResult result);

            _results.GetOrAdd(key, result).Ignore(ignoreReason);
        }

        #endregion

        #region ITestResultSource

        public IEnumerable<IResultKey> GetKeys() => _results.Keys;

        public IEnumerable<IResultKey> GetKeys(IResultKey match) => GetKeys().Where(key => key.Equals(match));

        public ITestMethodResult GetResult(IResultKey key) {
            Factory.Instance.Create(out ITestMethodResult result);

            return _results.GetOrAdd(key, result);
        }

        public IEnumerable<ITestMethodResult> GetResults() => _results.Values;

        public IEnumerable<ITestMethodResult> GetResults(IResultKey match) => _results.Where(kvp => kvp.Key.Equals(match)).Select(value => value.Value);

        public IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> GetKeyedResults() => _results;

        #endregion

        #region ITestResultSink

        public void AddResult(Boolean result, String testInstruction, String message, String _file, String _method)
            => AddEntry(TestEntry.FromResult(result, testInstruction, message), _file, _method);

        public void AddNote(String message, String _file, String _method)
            => AddEntry(TestEntry.FromNote(message), _file, _method);

        #endregion

        #region private methods

        private void AddEntry(ITestEntry entry, String _file, String _method) {
            Factory.Instance.Create(out IResultKey key, Scenario, _file, _method);
            Factory.Instance.Create(out ITestMethodResult result);

            _results.GetOrAdd(key, result).TestEntries.Add(entry);
        }

        #endregion

    }
}
