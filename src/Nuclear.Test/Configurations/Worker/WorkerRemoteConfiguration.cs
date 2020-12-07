using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations.Worker {
    internal class WorkerRemoteConfiguration : RemoteConfiguration<IWorkerClientConfiguration>, IWorkerRemoteConfiguration {

        #region ctors

        internal WorkerRemoteConfiguration() : base() { }

        internal WorkerRemoteConfiguration(IWorkerRemoteConfiguration original) : base(original) {
            Throw.If.Object.IsNull(original, nameof(original));

            Factory.Instance.Copy(out IWorkerClientConfiguration clientConfig, original.ClientConfiguration);
            ClientConfiguration = clientConfig;
        }

        #endregion

    }
}
