using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Output;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Client.Execution {
    public class TestRun {

        #region events

        public event EventHandler TestsFinished;

        #endregion

        #region fields

        private readonly Configuration _config;

        private readonly ITestResultsEndPoint _results;

        private FileInfo _file;

        private List<TestMethod> _sequentialTestMethods = new List<TestMethod>();

        private List<TestMethod> _parallelTestMethods = new List<TestMethod>();

        #endregion

        #region ctors

        public TestRun(Configuration config, ITestResultsEndPoint results) {
            Throw.If.Null(config, "config");
            Throw.If.Null(results, "results");

            _config = config;
            _results = results;
            TestSite.Tests.Test.SetTestResultsEndPoint(_results);
        }

        #endregion

        #region public methods

        public void Clear() => _file = null;

        public void LoadFile(FileInfo file) => _file = file;

        public void Run() {
            if(_file != null && _file.Exists) {
                Assembly _assembly = Assembly.LoadFrom(_file.FullName);
                TestSite.Tests.Test.SetAssemblyInfo(_assembly.GetName().ProcessorArchitecture, _assembly.GetName().Name);

                foreach(Type testClass in _assembly.GetTypes()) {
                    TestMode classMode = TestMode.Parallel;
                    TestClassAttribute attr = testClass.GetCustomAttribute<TestClassAttribute>();
                    if(attr != null) {
                        classMode = attr.TestMode;
                    }

                    foreach(MethodInfo testMethod in testClass.GetRuntimeMethods().Where(m => m.GetCustomAttributes<TestMethodAttribute>().Count() > 0)) {
                        TestMode methodMode = testMethod.GetCustomAttribute<TestMethodAttribute>().TestMode;

                        if(classMode == TestMode.Sequential || methodMode == TestMode.Sequential || _config.TestConfiguration.ForceSequential) {
                            _sequentialTestMethods.Add(new TestMethod(_results, testMethod));
                        } else {
                            _parallelTestMethods.Add(new TestMethod(_results, testMethod));
                        }
                    }
                }

                DiagnosticOutput.Log(_config, "Executing {0} sequential test methods.", _sequentialTestMethods.Count);
                _sequentialTestMethods.ForEach(m => m.Invoke());

                DiagnosticOutput.Log(_config, "Executing {0} parallel test methods.", _parallelTestMethods.Count);
                Parallel.ForEach(_parallelTestMethods, (m) => m.Invoke());
            }

            TestsFinished?.Invoke(this, new EventArgs());
        }

        #endregion

    }
}
