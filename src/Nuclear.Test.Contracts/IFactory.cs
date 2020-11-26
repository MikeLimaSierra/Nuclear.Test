using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test {
    public interface IFactory {

        #region Configurations

        void Create(out IProxyRemoteConfiguration @object);

        void Create(out IProxyClientConfiguration @object);

        void Create(out IWorkerRemoteConfiguration @object);

        void Create(out IWorkerClientConfiguration @object);

        #endregion

        #region Link

        void Create(out IClientLink @object);

        void Create(out IClientLink @object, String pipeID);

        void Create(out IServerLink @object);

        void Create(out IServerLink @object, String pipeID);

        void Create(out IMessage @object, String command);

        #endregion

        #region Results

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
