using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;
using Nuclear.Test.Results;
using Nuclear.TestSite;

namespace Nuclear.Test.Worker {
    internal class WorkerClient : Client<IWorkerClientConfiguration> {

        #region fields

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
            Log.Debug(nameof(OnAssemblyResolve));

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

        protected override IWorkerClientConfiguration LoadConfiguration(IMessage message) {
            Log.Debug(nameof(LoadConfiguration));

            return message.TryGetData(out IWorkerClientConfiguration config) ? config : null;
        }

        protected override void Execute() {
            Log.Debug(nameof(Execute));

            base.Execute();

            AssemblyHelper.TryGetRuntime(_entryAssembly, out RuntimeInfo entryAssemblyInfo);

            TestScenario scenario = new TestScenario(TestAssemblyName.Name,
                TestAssemblyRuntime, TestAssemblyName.ProcessorArchitecture,
                entryAssemblyInfo, RuntimeArchitecure);

            Results.Initialize(scenario);
            ResultProxy.Results = Results;

            CollectTestMethods(TestAssembly, Results, out IList<TestMethod> sequential, out IList<TestMethod> parallel);
            InvokeTestMethods(sequential, parallel);

            SendResults(Results.GetKeyedResults());
            SendFinished();
            Link.WaitForOutputFlush();
            RaiseExecutionFinished();
        }

        #endregion

        #region private methods

        private void CollectTestMethods(Assembly assembly, ITestResultEndPoint results, out IList<TestMethod> sequentialTestMethods, out IList<TestMethod> parallelTestMethods) {
            Log.Debug(nameof(CollectTestMethods));

            sequentialTestMethods = new List<TestMethod>();
            parallelTestMethods = new List<TestMethod>();

            Log.Debug("Collecting test methods.");
            
            foreach(Type type in assembly.GetTypes()) {
                Log.Debug($"Searching type {type.Format()}.");

                TestClassAttribute c_attr = type.GetCustomAttribute<TestClassAttribute>();
                TestMode classLevelMode = c_attr != null ? c_attr.TestMode : TestMode.Parallel;
                Boolean classLevelIgnore = c_attr != null && c_attr.IsIgnored;

                foreach(MethodInfo testMethod in type.GetRuntimeMethods().Where(m => m.GetCustomAttributes<TestMethodAttribute>().Count() > 0)) {
                    Log.Info($"Found test method {type.Format()}.{testMethod.Name.Format()}.");
                    TestMethodAttribute m_attr = testMethod.GetCustomAttribute<TestMethodAttribute>();

                    if(classLevelIgnore) {
                        Log.Debug($"Class ignored: {c_attr.IgnoreReason.Format()}");
                        results.IgnoreTestMethod(testMethod, $"Class ignored: {c_attr.IgnoreReason.Format()}");

                    } else if(m_attr.IsIgnored) {
                        Log.Debug($"Method ignored: {m_attr.IgnoreReason.Format()}");
                        results.IgnoreTestMethod(testMethod, $"Method ignored: {m_attr.IgnoreReason.Format()}");

                    } else {

                        if(classLevelMode == TestMode.Sequential || m_attr.TestMode == TestMode.Sequential || Configuration.TestsInSequence) {
                            Log.Info($"Adding sequential test method {type.Format()}.{testMethod.Name.Format()}.");
                            sequentialTestMethods.Add(new TestMethod(results, testMethod));

                        } else {
                            Log.Info($"Adding parallel test method {type.Format()}.{testMethod.Name.Format()}.");
                            parallelTestMethods.Add(new TestMethod(results, testMethod));
                        }
                    }
                }
            }
        }

        private void InvokeTestMethods(IEnumerable<TestMethod> sequentialTestMethods, IEnumerable<TestMethod> parallelTestMethods) {
            Log.Debug(nameof(InvokeTestMethods));

            Log.Info($"Invoking {sequentialTestMethods.Count()} sequential test methods.");
            sequentialTestMethods.Foreach(m => m.Invoke());

            Log.Info($"Invoking {parallelTestMethods.Count()} parallel test methods.");
            Parallel.ForEach(parallelTestMethods, m => m.Invoke());
        }

        #endregion

    }
}
