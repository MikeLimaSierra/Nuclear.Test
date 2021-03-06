﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using log4net;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Link;
using Nuclear.Test.Results;
using Nuclear.TestSite;

namespace Nuclear.Test.Execution.Worker {
    internal class WorkerClient : Client<IWorkerClientConfiguration>, IWorkerClient {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(WorkerClient));

        private readonly Assembly _entryAssembly = Assembly.GetEntryAssembly();

        #endregion

        #region ctors

        internal WorkerClient(IClientLink link)
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
            _log.Debug(nameof(OnAssemblyResolve));

            if(AssemblyResolver.Default.TryResolve(args, out IEnumerable<FileInfo> files)) {
                foreach(FileInfo file in files) {
                    if(AssemblyHelper.TryLoadFrom(file, out Assembly assembly)) {
                        _log.Debug($"Resolved assembly at {file.FullName.Format()}");

                        return assembly;
                    }
                }
            }

            if(AssemblyResolver.Nuget.TryResolve(args, out files)) {
                foreach(FileInfo file in files) {
                    if(AssemblyHelper.TryLoadFrom(file, out Assembly assembly)) {
                        _log.Debug($"Resolved assembly at {file.FullName.Format()}");

                        return assembly;
                    }
                }
            }

            _log.Debug($"No matching assembly found for {args.Name.Format()}.");

            return null;
        }

        #endregion

        #region methods

        protected override IWorkerClientConfiguration LoadConfiguration(IMessage message) {
            _log.Debug(nameof(LoadConfiguration));

            if(message == null) {
                _log.Error($"{nameof(message)} is null.");
                return null;
            }

            if(message.TryGetData(out IWorkerClientConfiguration config)) {
                return config;

            } else {
                _log.Error($"{nameof(message)} doesn't contain a configuration object.");

                return null;
            }
        }

        protected override void Execute() {
            _log.Debug(nameof(Execute));

            base.Execute();

            AssemblyHelper.TryGetRuntime(_entryAssembly, out RuntimeInfo entryAssemblyInfo);

            Factory.Instance.Create(out ITestScenario scenario, TestAssemblyName.Name,
                TestAssemblyRuntime, TestAssemblyName.ProcessorArchitecture,
                entryAssemblyInfo, RuntimeArchitecure);

            Results.Initialize(scenario);
            ResultProxy.Results = Results;

            CollectTestMethods(TestAssembly, Results, out IList<TestMethodInfo> sequential, out IList<TestMethodInfo> parallel);
            InvokeTestMethods(sequential, parallel);

            SendResults(Results.GetKeyedResults());
            SendFinished();
            RaiseExecutionFinished();
        }

        #endregion

        #region private methods

        private void CollectTestMethods(Assembly assembly, ITestResultEndPoint results, out IList<TestMethodInfo> sequentialTestMethods, out IList<TestMethodInfo> parallelTestMethods) {
            _log.Debug(nameof(CollectTestMethods));

            sequentialTestMethods = new List<TestMethodInfo>();
            parallelTestMethods = new List<TestMethodInfo>();

            foreach(Type type in assembly.GetTypes()) {
                _log.Debug($"Searching type {type.Format()}.");

                TestClassAttribute c_attr = type.GetCustomAttribute<TestClassAttribute>();
                TestMode classLevelMode = c_attr != null ? c_attr.TestMode : TestMode.Parallel;
                Boolean classLevelIgnore = c_attr != null && c_attr.IsIgnored;

                foreach(MethodInfo testMethod in type.GetRuntimeMethods().Where(m => m.GetCustomAttributes<TestMethodAttribute>().Count() > 0)) {
                    _log.Info($"Found test method {type.Format()}.{testMethod.Name.Format()}.");
                    TestMethodAttribute m_attr = testMethod.GetCustomAttribute<TestMethodAttribute>();

                    if(classLevelIgnore) {
                        _log.Debug($"Class ignored: {c_attr.IgnoreReason.Format()}");
                        results.IgnoreTestMethod(testMethod, $"Class ignored: {c_attr.IgnoreReason.Format()}");

                    } else if(m_attr.IsIgnored) {
                        _log.Debug($"Method ignored: {m_attr.IgnoreReason.Format()}");
                        results.IgnoreTestMethod(testMethod, $"Method ignored: {m_attr.IgnoreReason.Format()}");

                    } else {

                        if(classLevelMode == TestMode.Sequential || m_attr.TestMode == TestMode.Sequential || Configuration.TestMethodModeOverride == TestModeOverrides.Sequential) {
                            _log.Info($"Adding sequential test method {type.Format()}.{testMethod.Name.Format()}.");
                            sequentialTestMethods.Add(new TestMethodInfo(results, testMethod));

                        } else {
                            _log.Info($"Adding parallel test method {type.Format()}.{testMethod.Name.Format()}.");
                            parallelTestMethods.Add(new TestMethodInfo(results, testMethod));
                        }
                    }
                }
            }
        }

        private void InvokeTestMethods(IEnumerable<TestMethodInfo> sequentialTestMethods, IEnumerable<TestMethodInfo> parallelTestMethods) {
            _log.Debug(nameof(InvokeTestMethods));

            _log.Info($"Invoking {sequentialTestMethods.Count()} sequential test methods.");
            sequentialTestMethods.Foreach(m => m.Invoke());

            _log.Info($"Invoking {parallelTestMethods.Count()} parallel test methods.");
            Parallel.ForEach(parallelTestMethods, m => m.Invoke());
        }

        #endregion

    }
}
