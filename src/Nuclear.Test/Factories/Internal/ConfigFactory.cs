using System;

using Nuclear.Creation;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Factories.Internal {
    internal class ConfigFactory : Factories.ConfigFactory {

        #region fields

        private readonly ICreator<IExecutorConfiguration> _executorFactory =
            Factory.Instance.Creator.Create<IExecutorConfiguration>(
                () => new ExecutorConfiguration());

        private readonly ICreator<IProxyRemoteConfiguration, IProxyRemoteConfiguration> _proxyRFactory =
            Factory.Instance.Creator.Create<IProxyRemoteConfiguration, IProxyRemoteConfiguration>(
                (in1) => new ProxyRemoteConfiguration(in1));

        private readonly ICreator<IProxyClientConfiguration, IProxyClientConfiguration> _proxyCFactory =
            Factory.Instance.Creator.Create<IProxyClientConfiguration, IProxyClientConfiguration>(
                (in1) => new ProxyClientConfiguration(in1));

        private readonly ICreator<IWorkerRemoteConfiguration, IWorkerRemoteConfiguration> _workerRFactory =
            Factory.Instance.Creator.Create<IWorkerRemoteConfiguration, IWorkerRemoteConfiguration>(
                (in1) => new WorkerRemoteConfiguration(in1));

        private readonly ICreator<IWorkerClientConfiguration, IWorkerClientConfiguration> _workerCFactory =
            Factory.Instance.Creator.Create<IWorkerClientConfiguration, IWorkerClientConfiguration>(
                (in1) => new WorkerClientConfiguration(in1));

        #endregion

        #region methods

        public override void Create(out IExecutorConfiguration obj)
            => _executorFactory.Create(out obj);

        public override Boolean TryCreate(out IExecutorConfiguration obj)
            => _executorFactory.TryCreate(out obj);

        public override Boolean TryCreate(out IExecutorConfiguration obj, out Exception ex)
            => _executorFactory.TryCreate(out obj, out ex);

        public override void Create(out IProxyRemoteConfiguration obj)
            => _proxyRFactory.Create(out obj, null);

        public override Boolean TryCreate(out IProxyRemoteConfiguration obj)
            => _proxyRFactory.TryCreate(out obj, null);

        public override Boolean TryCreate(out IProxyRemoteConfiguration obj, out Exception ex)
            => _proxyRFactory.TryCreate(out obj, null, out ex);

        public override void Create(out IProxyRemoteConfiguration obj, IProxyRemoteConfiguration in1)
            => _proxyRFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IProxyRemoteConfiguration obj, IProxyRemoteConfiguration in1)
            => _proxyRFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IProxyRemoteConfiguration obj, IProxyRemoteConfiguration in1, out Exception ex)
            => _proxyRFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IProxyClientConfiguration obj)
            => _proxyCFactory.Create(out obj, null);

        public override Boolean TryCreate(out IProxyClientConfiguration obj)
            => _proxyCFactory.TryCreate(out obj, null);

        public override Boolean TryCreate(out IProxyClientConfiguration obj, out Exception ex)
            => _proxyCFactory.TryCreate(out obj, null, out ex);

        public override void Create(out IProxyClientConfiguration obj, IProxyClientConfiguration in1)
            => _proxyCFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IProxyClientConfiguration obj, IProxyClientConfiguration in1)
            => _proxyCFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IProxyClientConfiguration obj, IProxyClientConfiguration in1, out Exception ex)
            => _proxyCFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IWorkerRemoteConfiguration obj)
            => _workerRFactory.Create(out obj, null);

        public override Boolean TryCreate(out IWorkerRemoteConfiguration obj)
            => _workerRFactory.TryCreate(out obj, null);

        public override Boolean TryCreate(out IWorkerRemoteConfiguration obj, out Exception ex)
            => _workerRFactory.TryCreate(out obj, null, out ex);

        public override void Create(out IWorkerRemoteConfiguration obj, IWorkerRemoteConfiguration in1)
            => _workerRFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IWorkerRemoteConfiguration obj, IWorkerRemoteConfiguration in1)
            => _workerRFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IWorkerRemoteConfiguration obj, IWorkerRemoteConfiguration in1, out Exception ex)
            => _workerRFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IWorkerClientConfiguration obj)
            => _workerCFactory.Create(out obj, null);

        public override Boolean TryCreate(out IWorkerClientConfiguration obj)
            => _workerCFactory.TryCreate(out obj, null);

        public override Boolean TryCreate(out IWorkerClientConfiguration obj, out Exception ex)
            => _workerCFactory.TryCreate(out obj, null, out ex);

        public override void Create(out IWorkerClientConfiguration obj, IWorkerClientConfiguration in1)
            => _workerCFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IWorkerClientConfiguration obj, IWorkerClientConfiguration in1)
            => _workerCFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IWorkerClientConfiguration obj, IWorkerClientConfiguration in1, out Exception ex)
            => _workerCFactory.TryCreate(out obj, in1, out ex);

        #endregion

    }
}
