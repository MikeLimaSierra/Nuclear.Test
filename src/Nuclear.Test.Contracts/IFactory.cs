using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Execution;
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

        /// <summary>
        /// Creates a new instance of <see cref="IExecutorConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IExecutorConfiguration"/> instance.</param>
        void Create(out IExecutorConfiguration @object);

        /// <summary>
        /// Creates a new instance of <see cref="IProxyRemoteConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IProxyRemoteConfiguration"/> instance.</param>
        void Create(out IProxyRemoteConfiguration @object);

        /// <summary>
        /// Creates a new instance of <see cref="IProxyRemoteConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IProxyRemoteConfiguration"/> instance.</param>
        /// <param name="original">The original instance from which to copy.</param>
        void Copy(out IProxyRemoteConfiguration @object, IProxyRemoteConfiguration original);

        /// <summary>
        /// Creates a new instance of <see cref="IProxyClientConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IProxyClientConfiguration"/> instance.</param>
        void Create(out IProxyClientConfiguration @object);

        /// <summary>
        /// Creates a new instance of <see cref="IProxyClientConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IProxyClientConfiguration"/> instance.</param>
        /// <param name="original">The original instance from which to copy.</param>
        void Copy(out IProxyClientConfiguration @object, IProxyClientConfiguration original);

        /// <summary>
        /// Creates a new instance of <see cref="IWorkerRemoteConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IWorkerRemoteConfiguration"/> instance.</param>
        void Create(out IWorkerRemoteConfiguration @object);

        /// <summary>
        /// Creates a new instance of <see cref="IWorkerRemoteConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IWorkerRemoteConfiguration"/> instance.</param>
        /// <param name="original">The original instance from which to copy.</param>
        void Copy(out IWorkerRemoteConfiguration @object, IWorkerRemoteConfiguration original);

        /// <summary>
        /// Creates a new instance of <see cref="IWorkerClientConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IWorkerClientConfiguration"/> instance.</param>
        void Create(out IWorkerClientConfiguration @object);

        /// <summary>
        /// Creates a new instance of <see cref="IWorkerClientConfiguration"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IWorkerClientConfiguration"/> instance.</param>
        /// <param name="original">The original instance from which to copy.</param>
        void Copy(out IWorkerClientConfiguration @object, IWorkerClientConfiguration original);

        #endregion

        #region Execution

        /// <summary>
        /// Creates a new instance of <see cref="IExecutor"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IExecutor"/> instance.</param>
        /// <param name="configuration">The configuration object.</param>
        void Create(out IExecutor @object, IExecutorConfiguration configuration);

        /// <summary>
        /// Creates a new instance of <see cref="IProxyRemoteInfo"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IProxyRemoteInfo"/> instance.</param>
        /// <param name="configuration">The configuration object.</param>
        void Create(out IProxyRemoteInfo @object, IProxyRemoteConfiguration configuration);

        /// <summary>
        /// Creates a new instance of <see cref="IProxyRemote"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IProxyRemote"/> instance.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <param name="link">The server link used for communication.</param>
        void Create(out IProxyRemote @object, IProxyRemoteConfiguration configuration, IServerLink link);

        /// <summary>
        /// Creates a new instance of <see cref="IProxyClient"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IProxyClient"/> instance.</param>
        /// <param name="link">The client link used for communication.</param>
        void Create(out IProxyClient @object, IClientLink link);

        /// <summary>
        /// Creates a new instance of <see cref="IWorkerRemoteInfo"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IWorkerRemoteInfo"/> instance.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <param name="runtime">The runtime information associated with the instance.</param>
        void Create(out IWorkerRemoteInfo @object, IProxyClientConfiguration configuration, RuntimeInfo runtime);

        /// <summary>
        /// Creates a new instance of <see cref="IWorkerRemote"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IWorkerRemote"/> instance.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <param name="link">The server link used for communication.</param>
        void Create(out IWorkerRemote @object, IWorkerRemoteConfiguration configuration, IServerLink link);

        /// <summary>
        /// Creates a new instance of <see cref="IWorkerClient"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IWorkerClient"/> instance.</param>
        /// <param name="link">The client link used for communication.</param>
        void Create(out IWorkerClient @object, IClientLink link);

        #endregion

        #region Link

        /// <summary>
        /// Creates a new instance of <see cref="IClientLink"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IClientLink"/> instance.</param>
        void Create(out IClientLink @object);

        /// <summary>
        /// Creates a new instance of <see cref="IClientLink"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IClientLink"/> instance.</param>
        /// <param name="pipeID">The pipe ID that is used.</param>
        void Create(out IClientLink @object, String pipeID);

        /// <summary>
        /// Creates a new instance of <see cref="IServerLink"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IServerLink"/> instance.</param>
        void Create(out IServerLink @object);

        /// <summary>
        /// Creates a new instance of <see cref="IServerLink"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IServerLink"/> instance.</param>
        /// <param name="pipeID">The pipe ID that is used.</param>
        void Create(out IServerLink @object, String pipeID);

        /// <summary>
        /// Creates a new instance of <see cref="IMessage"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IMessage"/> instance.</param>
        /// <param name="command">The message command.</param>
        void Create(out IMessage @object, String command);

        #endregion

        #region Results

        /// <summary>
        /// Creates a new instance of <see cref="ITestEntry"/>.
        /// </summary>
        /// <param name="object">The created <see cref="ITestEntry"/> instance.</param>
        /// <param name="type">The entry type.</param>
        /// <param name="instruction">The test instruction.</param>
        /// <param name="message">The test message.</param>
        void Create(out ITestEntry @object, EntryTypes type, String instruction, String message);

        /// <summary>
        /// Creates a new instance of <see cref="ITestMethodResult"/>.
        /// </summary>
        /// <param name="object">The created <see cref="ITestMethodResult"/> instance.</param>
        void Create(out ITestMethodResult @object);

        /// <summary>
        /// Creates a new instance of <see cref="ITestResultEndPoint"/>.
        /// </summary>
        /// <param name="object">The created <see cref="ITestResultEndPoint"/> instance.</param>
        void Create(out ITestResultEndPoint @object);

        /// <summary>
        /// Creates a new instance of <see cref="IResultKey"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IResultKey"/> instance.</param>
        /// <param name="scenario">The test scenario.</param>
        /// <param name="methodInfo">The <see cref="MethodInfo"/> of the calling method.</param>
        void Create(out IResultKey @object, ITestScenario scenario, MethodInfo methodInfo);

        /// <summary>
        /// Creates a new instance of <see cref="IResultKey"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IResultKey"/> instance.</param>
        /// <param name="scenario">The test scenario.</param>
        /// <param name="fileName">The file name of the test.</param>
        /// <param name="methodName">The calling method name of the test.</param>
        void Create(out IResultKey @object, ITestScenario scenario, String fileName, String methodName);

        /// <summary>
        /// Creates a new instance of <see cref="IResultKey"/>.
        /// </summary>
        /// <param name="object">The created <see cref="IResultKey"/> instance.</param>
        /// <param name="assemblyName">The name of the test assembly.</param>
        /// <param name="targetRuntime">The targeted runtime version.</param>
        /// <param name="targetArchitecture">The targeted processor architecture.</param>
        /// <param name="executionRuntime">The executing runtime version.</param>
        /// <param name="executionArchitecture">The executing processor architecture.</param>
        /// <param name="fileName">The file name of the test.</param>
        /// <param name="methodName">The calling method name of the test.</param>
        void Create(out IResultKey @object,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture,
            String fileName,
            String methodName);

        #endregion

        /// <summary>
        /// Creates a new instance of <see cref="ITestScenario"/>.
        /// </summary>
        /// <param name="object">The created <see cref="ITestScenario"/> instance.</param>
        /// <param name="assemblyName">The name of the test assembly.</param>
        /// <param name="targetRuntime">The targeted runtime version.</param>
        /// <param name="targetArchitecture">The targeted processor architecture.</param>
        /// <param name="executionRuntime">The executing runtime version.</param>
        /// <param name="executionArchitecture">The executing processor architecture.</param>
        void Create(out ITestScenario @object,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture);

    }
}
