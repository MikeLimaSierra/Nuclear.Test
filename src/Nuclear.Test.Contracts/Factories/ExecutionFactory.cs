using System;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Creation;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Execution;
using Nuclear.Test.Execution.Proxy;
using Nuclear.Test.Execution.Worker;
using Nuclear.Test.Link;

namespace Nuclear.Test.Factories {

    /// <summary>
    /// Defines a factory for internal implementations.
    /// </summary>
    public abstract class ExecutionFactory :
        ICreator<IExecutor, IExecutorConfiguration>,
        ICreator<IProxyRemoteInfo, IProxyRemoteConfiguration>,
        ICreator<IProxyRemote, IProxyRemoteConfiguration, IServerLink>,
        ICreator<IProxyClient, IClientLink>,
        ICreator<IWorkerRemoteInfo, IProxyClientConfiguration, RuntimeInfo>,
        ICreator<IWorkerRemote, IWorkerRemoteConfiguration, IServerLink>,
        ICreator<IWorkerClient, IClientLink> {

        public abstract void Create(out IExecutor obj, IExecutorConfiguration configuration);

        public abstract Boolean TryCreate(out IExecutor obj, IExecutorConfiguration configuration);

        public abstract Boolean TryCreate(out IExecutor obj, IExecutorConfiguration configuration, out Exception ex);

        public abstract void Create(out IProxyRemoteInfo obj, IProxyRemoteConfiguration configuration);

        public abstract Boolean TryCreate(out IProxyRemoteInfo obj, IProxyRemoteConfiguration configuration);

        public abstract Boolean TryCreate(out IProxyRemoteInfo obj, IProxyRemoteConfiguration configuration, out Exception ex);

        public abstract void Create(out IProxyRemote obj, IProxyRemoteConfiguration configuration, IServerLink link);

        public abstract Boolean TryCreate(out IProxyRemote obj, IProxyRemoteConfiguration configuration, IServerLink link);

        public abstract Boolean TryCreate(out IProxyRemote obj, IProxyRemoteConfiguration configuration, IServerLink link, out Exception ex);

        public abstract void Create(out IProxyClient obj, IClientLink link);

        public abstract Boolean TryCreate(out IProxyClient obj, IClientLink link);

        public abstract Boolean TryCreate(out IProxyClient obj, IClientLink link, out Exception ex);

        public abstract void Create(out IWorkerRemoteInfo obj, IProxyClientConfiguration configuration, RuntimeInfo runtime);

        public abstract Boolean TryCreate(out IWorkerRemoteInfo obj, IProxyClientConfiguration configuration, RuntimeInfo runtime);

        public abstract Boolean TryCreate(out IWorkerRemoteInfo obj, IProxyClientConfiguration configuration, RuntimeInfo runtime, out Exception ex);

        public abstract void Create(out IWorkerRemote obj, IWorkerRemoteConfiguration configuration, IServerLink link);

        public abstract Boolean TryCreate(out IWorkerRemote obj, IWorkerRemoteConfiguration configuration, IServerLink link);

        public abstract Boolean TryCreate(out IWorkerRemote obj, IWorkerRemoteConfiguration configuration, IServerLink link, out Exception ex);

        public abstract void Create(out IWorkerClient obj, IClientLink link);

        public abstract Boolean TryCreate(out IWorkerClient obj, IClientLink link);

        public abstract Boolean TryCreate(out IWorkerClient obj, IClientLink link, out Exception ex);

    }

}
