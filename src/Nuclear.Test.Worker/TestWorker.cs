using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Output;
using Nuclear.Test.Results;
using Nuclear.Test.TestExecution;
using Nuclear.TestSite;

namespace Nuclear.Test.Worker {

    internal class TestWorker : PipedTestExecutor {

        #region ctors

        internal TestWorker(String pipeName)
            : base(pipeName) {

            HeaderContent.Add(@" _   _               _                    _____           _   ");
            HeaderContent.Add(@"| \ | | _   _   ___ | |  ___   __ _  _ __|_   _|___  ___ | |_ ");
            HeaderContent.Add(@"|  \| || | | | / __|| | / _ \ / _` || '__| | | / _ \/ __|| __|");
            HeaderContent.Add(@"| |\  || |_| || (__ | ||  __/| (_| || | _  | ||  __/\__ \| |_ ");
            HeaderContent.Add(@"|_| \_| \__,_| \___||_| \___| \__,_||_|(_) |_| \___||___/ \__|");
            HeaderContent.Add(@"__        __            _                                     ");
            HeaderContent.Add(@"\ \      / /___   _ __ | | __ ___  _ __                       ");
            HeaderContent.Add(@" \ \ /\ / // _ \ | '__|| |/ // _ \| '__|                      ");
            HeaderContent.Add(@"  \ V  V /| (_) || |   |   <|  __/| |                         ");
            HeaderContent.Add(@"   \_/\_/  \___/ |_|   |_|\_\\___||_|                         ");
            HeaderContent.Add(@"                                                              ");
        }

        #endregion

        #region protected methods

        protected override void ExecuteInternal() {
            AssemblyHelper.TryGetRuntime(TestAssembly, out RuntimeInfo testAssemblyInfo);
            AssemblyHelper.TryGetRuntime(EntryAssembly, out RuntimeInfo executionAssemblyInfo);

            TestScenario scenario = new TestScenario(TestAssemblyName.Name,
                testAssemblyInfo, TestAssemblyName.ProcessorArchitecture,
                executionAssemblyInfo, RuntimeArchitecure);

            Results.Initialize(scenario);
            ResultProxy.Results = Results;

            CollectTestMethods(TestAssembly, Results, out List<TestMethod> sequential, out List<TestMethod> parallel);
            InvokeTestMethods(sequential, parallel);

            if(ResultSerializer.TrySerialize(Results, out Byte[] data)) {
                OutputConfiguration.ClientsAwaitInput |= !TrySendResultData(PipeStream, data);

            } else {
                OutputConfiguration.ClientsAwaitInput = true;
            }
        }

        #endregion

        #region private methods

        private void CollectTestMethods(Assembly assembly, ITestResultEndPoint results, out List<TestMethod> sequentialTestMethods, out List<TestMethod> parallelTestMethods) {
            sequentialTestMethods = new List<TestMethod>();
            parallelTestMethods = new List<TestMethod>();

            foreach(Type type in assembly.GetTypes()) {
                TestMode classLevelMode = TestMode.Parallel;
                Boolean classLevelIgnore = false;

                TestClassAttribute c_attr = type.GetCustomAttribute<TestClassAttribute>();

                if(c_attr != null) {
                    classLevelMode = c_attr.TestMode;
                    classLevelIgnore = c_attr.IsIgnored;
                }

                foreach(MethodInfo testMethod in type.GetRuntimeMethods().Where(m => m.GetCustomAttributes<TestMethodAttribute>().Count() > 0)) {
                    TestMethodAttribute m_attr = testMethod.GetCustomAttribute<TestMethodAttribute>();

                    if(classLevelIgnore) {
                        results.IgnoreTestMethod(testMethod, $"Class ignored: '{c_attr.IgnoreReason}'");

                    } else if(m_attr.IsIgnored) {
                        results.IgnoreTestMethod(testMethod, $"Method ignored: '{m_attr.IgnoreReason}'");

                    } else {
                        TestMode methodLevelMode = m_attr.TestMode;

                        if(classLevelMode == TestMode.Sequential || methodLevelMode == TestMode.Sequential || TestConfiguration.ForceSequential) {
                            sequentialTestMethods.Add(new TestMethod(results, testMethod));
                        } else {
                            parallelTestMethods.Add(new TestMethod(results, testMethod));
                        }
                    }
                }
            }
        }

        private void InvokeTestMethods(List<TestMethod> sequentialTestMethods, List<TestMethod> parallelTestMethods) {
            DiagnosticOutput.Log(OutputConfiguration, "Executing {0} sequential test methods.", sequentialTestMethods.Count);
            sequentialTestMethods.ForEach(m => m.Invoke());

            DiagnosticOutput.Log(OutputConfiguration, "Executing {0} parallel test methods.", parallelTestMethods.Count);
            Parallel.ForEach(parallelTestMethods, (m) => m.Invoke());
        }

        #endregion

    }
}
