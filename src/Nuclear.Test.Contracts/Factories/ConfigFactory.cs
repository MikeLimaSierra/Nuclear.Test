using System;

using Nuclear.Creation;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Factories {

    /// <summary>
    /// Defines a factory for internal implementations.
    /// </summary>
    public abstract class ConfigFactory :
          ICreator<IExecutorConfiguration>,
          ICreator<IProxyRemoteConfiguration>,
          ICreator<IProxyRemoteConfiguration, IProxyRemoteConfiguration>,
          ICreator<IProxyClientConfiguration>,
          ICreator<IProxyClientConfiguration, IProxyClientConfiguration>,
          ICreator<IWorkerRemoteConfiguration>,
          ICreator<IWorkerRemoteConfiguration, IWorkerRemoteConfiguration>,
          ICreator<IWorkerClientConfiguration>,
          ICreator<IWorkerClientConfiguration, IWorkerClientConfiguration> {

        public abstract void Create(out IExecutorConfiguration obj);

        public abstract Boolean TryCreate(out IExecutorConfiguration obj);

        public abstract Boolean TryCreate(out IExecutorConfiguration obj, out Exception ex);

        public abstract void Create(out IProxyRemoteConfiguration obj);

        public abstract Boolean TryCreate(out IProxyRemoteConfiguration obj);

        public abstract Boolean TryCreate(out IProxyRemoteConfiguration obj, out Exception ex);

        public abstract void Create(out IProxyRemoteConfiguration obj, IProxyRemoteConfiguration original);

        public abstract Boolean TryCreate(out IProxyRemoteConfiguration obj, IProxyRemoteConfiguration original);

        public abstract Boolean TryCreate(out IProxyRemoteConfiguration obj, IProxyRemoteConfiguration original, out Exception ex);

        public abstract void Create(out IProxyClientConfiguration obj);

        public abstract Boolean TryCreate(out IProxyClientConfiguration obj);

        public abstract Boolean TryCreate(out IProxyClientConfiguration obj, out Exception ex);

        public abstract void Create(out IProxyClientConfiguration obj, IProxyClientConfiguration original);

        public abstract Boolean TryCreate(out IProxyClientConfiguration obj, IProxyClientConfiguration original);

        public abstract Boolean TryCreate(out IProxyClientConfiguration obj, IProxyClientConfiguration original, out Exception ex);

        public abstract void Create(out IWorkerRemoteConfiguration obj);

        public abstract Boolean TryCreate(out IWorkerRemoteConfiguration obj);

        public abstract Boolean TryCreate(out IWorkerRemoteConfiguration obj, out Exception ex);

        public abstract void Create(out IWorkerRemoteConfiguration obj, IWorkerRemoteConfiguration original);

        public abstract Boolean TryCreate(out IWorkerRemoteConfiguration obj, IWorkerRemoteConfiguration original);

        public abstract Boolean TryCreate(out IWorkerRemoteConfiguration obj, IWorkerRemoteConfiguration original, out Exception ex);

        public abstract void Create(out IWorkerClientConfiguration obj);

        public abstract Boolean TryCreate(out IWorkerClientConfiguration obj);

        public abstract Boolean TryCreate(out IWorkerClientConfiguration obj, out Exception ex);

        public abstract void Create(out IWorkerClientConfiguration obj, IWorkerClientConfiguration original);

        public abstract Boolean TryCreate(out IWorkerClientConfiguration obj, IWorkerClientConfiguration original);

        public abstract Boolean TryCreate(out IWorkerClientConfiguration obj, IWorkerClientConfiguration original, out Exception ex);

    }

}
