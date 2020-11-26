using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Results;

namespace Nuclear.Test {

    /// <summary>
    /// A factory for result related implementations.
    /// </summary>
    public class Factory : IFactory {

        #region properties

        public static IFactory Instance { get; } = new Factory();

        #endregion

        #region ctors

        private Factory() { }

        #endregion

        #region results

        public void Create(out ITestEntry @object, EntryTypes type, String instruction, String message) => @object = new TestEntry(type, instruction, message);

        public void Create(out ITestMethodResult @object) => @object = new TestMethodResult();

        public void Create(out ITestResultEndPoint @object) => @object = new TestResultEndPoint();

        public void CreateEmpty(out ITestResultKey @object) => @object = TestResultKey.Empty;

        public void Create(out ITestResultKey @object, ITestScenario scenario, MethodInfo methodInfo) => @object = new TestResultKey(scenario, methodInfo);

        public void Create(out ITestResultKey @object, ITestScenario scenario, String fileName, String methodName) => @object = new TestResultKey(scenario, fileName, methodName);

        public void Create(out ITestResultKey @object,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture,
            String fileName,
            String methodName) => @object = new TestResultKey(assemblyName, targetRuntime, targetArchitecture, executionRuntime, executionArchitecture, fileName, methodName);

        #endregion

    }
}
