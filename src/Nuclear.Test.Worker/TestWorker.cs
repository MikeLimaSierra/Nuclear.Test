﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Nuclear.Test.Configurations;
using Nuclear.Test.Output;
using Nuclear.Test.Results;
using Nuclear.Test.TestExecution;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Worker {

    internal class TestWorker : PipedTestExecutor {

        #region ctors

        internal TestWorker(ITestResultsEndPoint results, String pipeName)
            : base(results, pipeName) {

            TestSite.Tests.Test.SetTestResultsEndPoint(Results);

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
            TestSite.Tests.Test.SetAssemblyInfo(TestAssemblyName.ProcessorArchitecture, TestAssemblyName.Name, Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName);

            CollectTestMethods(TestAssembly, Results, out List<TestMethod> sequential, out List<TestMethod> parallel);
            InvokeTestMethods(sequential, parallel);

            if(ResultSerializer.TrySerialize(Results.ResultMap, out Byte[] data)) {
                OutputConfiguration.ClientsAwaitInput |= !TrySendResultData(PipeStream, data);

            } else {
                OutputConfiguration.ClientsAwaitInput = true;
            }
        }

        #endregion

        #region private methods

        private void CollectTestMethods(Assembly assembly, ITestResultsEndPoint results, out List<TestMethod> sequentialTestMethods, out List<TestMethod> parallelTestMethods) {
            sequentialTestMethods = new List<TestMethod>();
            parallelTestMethods = new List<TestMethod>();

            foreach(Type type in assembly.GetTypes()) {
                TestClassAttribute attr = type.GetCustomAttribute<TestClassAttribute>();
                TestMode classLevelMode = attr != null ? attr.TestMode : TestMode.Parallel;

                foreach(MethodInfo testMethod in type.GetRuntimeMethods().Where(m => m.GetCustomAttributes<TestMethodAttribute>().Count() > 0)) {
                    TestMode methodLevelMode = testMethod.GetCustomAttribute<TestMethodAttribute>().TestMode;

                    if(classLevelMode == TestMode.Sequential || methodLevelMode == TestMode.Sequential || TestConfiguration.ForceSequential) {
                        sequentialTestMethods.Add(new TestMethod(results, testMethod));
                    } else {
                        parallelTestMethods.Add(new TestMethod(results, testMethod));
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