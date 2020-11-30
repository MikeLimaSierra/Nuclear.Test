using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;
using Nuclear.Test.Execution;
using Nuclear.Test.Link;
using Nuclear.Test.Results;

namespace Nuclear.Test {
    internal class InternalFactory : IFactory {

        #region Configurations

        public void Create(out IProxyRemoteConfiguration @object) => @object = new ProxyRemoteConfiguration();

        public void Create(out IProxyClientConfiguration @object) => @object = new ProxyClientConfiguration();

        public void Create(out IWorkerRemoteConfiguration @object) => @object = new WorkerRemoteConfiguration();

        public void Create(out IWorkerClientConfiguration @object) => @object = new WorkerClientConfiguration();

        #endregion

        #region Execution

        public void Create(out IProxyRemote @object, IProxyRemoteConfiguration configuration, IServerLink link) => @object = new ProxyRemote(configuration, link);

        public void Create(out IProxyClient @object, IClientLink link) => @object = new ProxyClient(link);

        public void Create(out IWorkerRemote @object, IWorkerRemoteConfiguration configuration, IServerLink link) => @object = new WorkerRemote(configuration, link);

        public void Create(out IWorkerClient @object, IClientLink link) => @object = new WorkerClient(link);

        #endregion

        #region Link

        public void Create(out IClientLink @object) => Create(out @object, Guid.NewGuid().ToString());

        public void Create(out IClientLink @object, String pipeID) => @object = new ClientLink(pipeID);

        public void Create(out IServerLink @object) => Create(out @object, Guid.NewGuid().ToString());

        public void Create(out IServerLink @object, String pipeID) => @object = new ServerLink(pipeID);

        public void Create(out IMessage @object, String command) => @object = new Message(command);

        #endregion

        #region Results

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
