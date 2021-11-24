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

namespace Nuclear.Test.Factories.Internal {
    internal class ExecutionFactory : Factories.ExecutionFactory {

        #region fields

        private readonly ICreator<IExecutor, IExecutorConfiguration> _executorFactory =
            Factory.Instance.Creator.Create<IExecutor, IExecutorConfiguration>(
                (in1) => new Executor(in1));

        private readonly ICreator<IProxyRemoteInfo, IProxyRemoteConfiguration> _proxyRIFactory =
            Factory.Instance.Creator.Create<IProxyRemoteInfo, IProxyRemoteConfiguration>(
                (in1) => new ProxyRemoteInfo(in1));

        private readonly ICreator<IProxyRemote, IProxyRemoteConfiguration, IServerLink> _proxyRFactory =
            Factory.Instance.Creator.Create<IProxyRemote, IProxyRemoteConfiguration, IServerLink>(
                (in1, in2) => new ProxyRemote(in1, in2));

        private readonly ICreator<IProxyClient, IClientLink> _proxyCFactory =
            Factory.Instance.Creator.Create<IProxyClient, IClientLink>(
                (in1) => new ProxyClient(in1));

        private readonly ICreator<IWorkerRemoteInfo, IProxyClientConfiguration, RuntimeInfo> _workerRIFactory =
            Factory.Instance.Creator.Create<IWorkerRemoteInfo, IProxyClientConfiguration, RuntimeInfo>(
                (in1, in2) => new WorkerRemoteInfo(in1, in2));

        private readonly ICreator<IWorkerRemote, IWorkerRemoteConfiguration, IServerLink> _workerRFactory =
            Factory.Instance.Creator.Create<IWorkerRemote, IWorkerRemoteConfiguration, IServerLink>(
                (in1, in2) => new WorkerRemote(in1, in2));

        private readonly ICreator<IWorkerClient, IClientLink> _workerCFactory =
            Factory.Instance.Creator.Create<IWorkerClient, IClientLink>(
                (in1) => new WorkerClient(in1));

        #endregion

        #region methods

        public override void Create(out IExecutor obj, IExecutorConfiguration in1)
            => _executorFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IExecutor obj, IExecutorConfiguration in1)
            => _executorFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IExecutor obj, IExecutorConfiguration in1, out Exception ex)
            => _executorFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IProxyRemoteInfo obj, IProxyRemoteConfiguration in1)
            => _proxyRIFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IProxyRemoteInfo obj, IProxyRemoteConfiguration in1)
            => _proxyRIFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IProxyRemoteInfo obj, IProxyRemoteConfiguration in1, out Exception ex)
            => _proxyRIFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IProxyRemote obj, IProxyRemoteConfiguration in1, IServerLink in2)
            => _proxyRFactory.Create(out obj, in1, in2);

        public override Boolean TryCreate(out IProxyRemote obj, IProxyRemoteConfiguration in1, IServerLink in2)
            => _proxyRFactory.TryCreate(out obj, in1, in2);

        public override Boolean TryCreate(out IProxyRemote obj, IProxyRemoteConfiguration in1, IServerLink in2, out Exception ex)
            => _proxyRFactory.TryCreate(out obj, in1, in2, out ex);

        public override void Create(out IProxyClient obj, IClientLink in1)
            => _proxyCFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IProxyClient obj, IClientLink in1)
            => _proxyCFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IProxyClient obj, IClientLink in1, out Exception ex)
            => _proxyCFactory.TryCreate(out obj, in1, out ex);

        public override void Create(out IWorkerRemoteInfo obj, IProxyClientConfiguration in1, RuntimeInfo in2)
            => _workerRIFactory.Create(out obj, in1, in2);

        public override Boolean TryCreate(out IWorkerRemoteInfo obj, IProxyClientConfiguration in1, RuntimeInfo in2)
            => _workerRIFactory.TryCreate(out obj, in1, in2);

        public override Boolean TryCreate(out IWorkerRemoteInfo obj, IProxyClientConfiguration in1, RuntimeInfo in2, out Exception ex)
            => _workerRIFactory.TryCreate(out obj, in1, in2, out ex);

        public override void Create(out IWorkerRemote obj, IWorkerRemoteConfiguration in1, IServerLink in2)
            => _workerRFactory.Create(out obj, in1, in2);

        public override Boolean TryCreate(out IWorkerRemote obj, IWorkerRemoteConfiguration in1, IServerLink in2)
            => _workerRFactory.TryCreate(out obj, in1, in2);

        public override Boolean TryCreate(out IWorkerRemote obj, IWorkerRemoteConfiguration in1, IServerLink in2, out Exception ex)
            => _workerRFactory.TryCreate(out obj, in1, in2, out ex);

        public override void Create(out IWorkerClient obj, IClientLink in1)
            => _workerCFactory.Create(out obj, in1);

        public override Boolean TryCreate(out IWorkerClient obj, IClientLink in1)
            => _workerCFactory.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IWorkerClient obj, IClientLink in1, out Exception ex)
            => _workerCFactory.TryCreate(out obj, in1, out ex);

        #endregion

    }
}
