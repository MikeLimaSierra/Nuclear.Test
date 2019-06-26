using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Output;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Server.Execution {
    public class TestRun {

        #region events

        public event EventHandler TestsFinished;

        #endregion

        #region fields

        private readonly Configuration _config;

        private readonly ITestResultsEndPoint _results;

        private List<FileInfo> _files = new List<FileInfo>();

        private List<TestItem> _testItems = new List<TestItem>();

        private Int32 _runningTests;

        #endregion

        #region ctors

        public TestRun(ITestResultsEndPoint results, Configuration config) {
            Throw.If.Null(results, "results");
            Throw.If.Null(config, "config");

            _results = results;
            _config = config;
        }

        #endregion

        #region eventhandlers

        private void OnTestsCompleted(Object sender, TestCompletedEventArgs e) {
            (sender as TestItem).TestsCompleted -= OnTestsCompleted;

            if(e.Results != null) {
                foreach(KeyValuePair<Tuple<String, ProcessorArchitecture, String, String>, TestResultCollection> kvp in e.Results) {
                    kvp.Value.ForEach(result => _results.CollectResult(result, kvp.Key.Item1, kvp.Key.Item2, kvp.Key.Item3, kvp.Key.Item4));
                }
            }

            if(Interlocked.Decrement(ref _runningTests) <= 0) {
                TestsFinished?.Invoke(this, new EventArgs());
            }
        }

        #endregion

        #region public methods

        public void Clear() {
            DiagnosticOutput.Log(_config, "Unloading all assemblies.");
            _files.Clear();
        }

        public void LoadFile(FileInfo file) {
            DiagnosticOutput.Log(_config, "Loading assembly '{0}'.", file.FullName);
            _files.Add(file);
        }

        public void LoadFiles(IEnumerable<FileInfo> files) {
            files.ToList().ForEach(file => DiagnosticOutput.Log(_config, "Loading assembly '{0}'.", file.FullName));
            _files.AddRange(files);
        }

        public void RemoveFile(FileInfo file) {
            DiagnosticOutput.Log(_config, "Unloading assembly '{0}'.", file.FullName);
            _files.Remove(file);
        }

        public void RemoveFiles(IEnumerable<FileInfo> files) => files.ToList().ForEach(file => RemoveFile(file));

        public void Run() {
            _testItems.ForEach(item => {
                item.TestsCompleted += OnTestsCompleted;
            });
            _testItems.Clear();
            _runningTests = 0;

            foreach(FileInfo file in _files) {
                TestItem testItem = new TestItem(file, _config);
                _runningTests++;
                testItem.TestsCompleted += OnTestsCompleted;
                _testItems.Add(testItem);
            }

            _testItems.ForEach(item => item.Run());
        }

        #endregion

    }
}
