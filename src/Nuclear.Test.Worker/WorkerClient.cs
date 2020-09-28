using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;
using Nuclear.Test.Results;
using Nuclear.TestSite;

namespace Nuclear.Test.Worker {
    class WorkerClient : Client {

        #region fields

        private IWorkerConfiguration _workerConfig;

        private readonly Assembly _entryAssembly = Assembly.GetEntryAssembly();

        #endregion

        #region ctors

        public WorkerClient(IClientLink link)
            : base(link) {

            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

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

        #region eventhandlers

        private Assembly OnAssemblyResolve(Object sender, ResolveEventArgs args) {
            IEnumerable<FileInfo> files;

            IDefaultResolver defaultResolver = AssemblyResolver.Default;

            if(defaultResolver.TryResolve(args, out files)) {
                foreach(FileInfo file in files) {
                    if(AssemblyHelper.TryLoadFrom(file, out Assembly assembly)) {
                        return assembly;
                    }
                }
            }

            INugetResolver nugetResolver = AssemblyResolver.Nuget;

            if(nugetResolver.TryResolve(args, out files)) {
                foreach(FileInfo file in files) {
                    if(AssemblyHelper.TryLoadFrom(file, out Assembly assembly)) {
                        return assembly;
                    }
                }
            }

            return null;
        }

        #endregion

        #region methods

        protected override void Setup(IMessage message) {
            base.Setup(message);

            message.TryGetData(out _workerConfig);
        }

        protected override void Execute() {
            base.Execute();

            AssemblyHelper.TryGetRuntime(_entryAssembly, out RuntimeInfo entryAssemblyInfo);

            TestScenario scenario = new TestScenario(TestAssemblyName.Name,
                TestAssemblyRuntime, TestAssemblyName.ProcessorArchitecture,
                entryAssemblyInfo, RuntimeArchitecure);

            Results.Initialize(scenario);
            ResultProxy.Results = Results;

            CollectTestMethods(TestAssembly, Results, out List<TestMethod> sequential, out List<TestMethod> parallel);
            InvokeTestMethods(sequential, parallel);

            SendResults(Results.GetKeyedResults());
            RaiseExecutionFinished();

            Link.Send(new Message(Commands.Finished));
        }

        #endregion

        #region private methods

        private void CollectTestMethods(Assembly assembly, ITestResultEndPoint results, out List<TestMethod> sequentialTestMethods, out List<TestMethod> parallelTestMethods) {
            sequentialTestMethods = new List<TestMethod>();
            parallelTestMethods = new List<TestMethod>();

            //DiagnosticOutput.Log(OutputConfiguration, "Collecting test methods.");

            foreach(Type type in assembly.GetTypes()) {
                //DiagnosticOutput.Log(OutputConfiguration, "Searching Type {0}.", type.Format());

                TestMode classLevelMode = TestMode.Parallel;
                Boolean classLevelIgnore = false;

                TestClassAttribute c_attr = type.GetCustomAttribute<TestClassAttribute>();

                if(c_attr != null) {
                    classLevelMode = c_attr.TestMode;
                    classLevelIgnore = c_attr.IsIgnored;
                }

                foreach(MethodInfo testMethod in type.GetRuntimeMethods().Where(m => m.GetCustomAttributes<TestMethodAttribute>().Count() > 0)) {
                    //DiagnosticOutput.Log(OutputConfiguration, "Found test method {0}.", testMethod.Name.Format());

                    TestMethodAttribute m_attr = testMethod.GetCustomAttribute<TestMethodAttribute>();

                    if(classLevelIgnore) {
                        results.IgnoreTestMethod(testMethod, $"Class ignored: '{c_attr.IgnoreReason}'");

                    } else if(m_attr.IsIgnored) {
                        results.IgnoreTestMethod(testMethod, $"Method ignored: '{m_attr.IgnoreReason}'");

                    } else {
                        TestMode methodLevelMode = m_attr.TestMode;

                        if(classLevelMode == TestMode.Sequential || methodLevelMode == TestMode.Sequential || _workerConfig.TestsInSequence) {
                            sequentialTestMethods.Add(new TestMethod(results, testMethod));
                        } else {
                            parallelTestMethods.Add(new TestMethod(results, testMethod));
                        }
                    }
                }
            }
        }

        private void InvokeTestMethods(List<TestMethod> sequentialTestMethods, List<TestMethod> parallelTestMethods) {
            //DiagnosticOutput.Log(OutputConfiguration, "Executing {0} sequential test methods.", sequentialTestMethods.Count);
            sequentialTestMethods.ForEach(m => m.Invoke());

            //DiagnosticOutput.Log(OutputConfiguration, "Executing {0} parallel test methods.", parallelTestMethods.Count);
            Parallel.ForEach(parallelTestMethods, m => m.Invoke());
        }

        #endregion

    }
}
