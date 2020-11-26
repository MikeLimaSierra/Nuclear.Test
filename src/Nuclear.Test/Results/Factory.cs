using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;

namespace Nuclear.Test.Results {

    /// <summary>
    /// A factory for result related implementations.
    /// </summary>
    public static class Factory {

        #region methods

        public static void Create(out ITestEntry @object, EntryTypes type, String instruction, String message) => @object = new TestEntry(type, instruction, message);

        public static void Create(out ITestMethodResult @object) => @object = new TestMethodResult();

        public static void Create(out ITestResultEndPoint @object) => @object = new TestResultEndPoint();

        public static void Create(out ITestResultKey @object, ITestScenario scenario, MethodInfo methodInfo) => @object = new TestResultKey(scenario, methodInfo);

        public static void Create(out ITestResultKey @object, ITestScenario scenario, String fileName, String methodName) => @object = new TestResultKey(scenario, fileName, methodName);

        public static void Create(out ITestResultKey @object,
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
