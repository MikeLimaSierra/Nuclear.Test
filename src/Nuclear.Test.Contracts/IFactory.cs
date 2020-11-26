using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Results;

namespace Nuclear.Test {
    public interface IFactory {

        #region results

        void Create(out ITestEntry @object, EntryTypes type, String instruction, String message);

        void Create(out ITestMethodResult @object);

        void Create(out ITestResultEndPoint @object);

        void CreateEmpty(out ITestResultKey @object);

        void Create(out ITestResultKey @object, ITestScenario scenario, MethodInfo methodInfo);

        void Create(out ITestResultKey @object, ITestScenario scenario, String fileName, String methodName);

        void Create(out ITestResultKey @object,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture,
            String fileName,
            String methodName);

        #endregion

    }
}
