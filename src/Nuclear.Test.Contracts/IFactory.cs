using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Execution.Proxy;
using Nuclear.Test.Execution.Worker;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test {

    /// <summary>
    /// Defines a factory for internal implementations.
    /// </summary>
    public interface IFactory {

        #region Configurations

        void Create(out IProxyRemoteConfiguration @object);

        void Copy(out IProxyRemoteConfiguration @object, IProxyRemoteConfiguration original);

        void Create(out IProxyClientConfiguration @object);

        void Copy(out IProxyClientConfiguration @object, IProxyClientConfiguration original);

        void Create(out IWorkerRemoteConfiguration @object);

        void Copy(out IWorkerRemoteConfiguration @object, IWorkerRemoteConfiguration original);

        void Create(out IWorkerClientConfiguration @object);

        void Copy(out IWorkerClientConfiguration @object, IWorkerClientConfiguration original);

        #endregion

        #region Execution

        void Create(out IProxyRemoteInfo @object, IProxyRemoteConfiguration configuration);

        void Create(out IProxyRemote @object, IProxyRemoteConfiguration configuration, IServerLink link);

        void Create(out IProxyClient @object, IClientLink link);

        void Create(out IWorkerRemoteInfo @object, IProxyClientConfiguration proxyConfig, RuntimeInfo runtime);

        void Create(out IWorkerRemote @object, IWorkerRemoteConfiguration configuration, IServerLink link);

        void Create(out IWorkerClient @object, IClientLink link);

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

        void Create(out ITestScenario @object,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture);

    }
}
