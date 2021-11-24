namespace Nuclear.Test.Configurations.Worker {
    internal class WorkerRemoteConfiguration : RemoteConfiguration<IWorkerClientConfiguration>, IWorkerRemoteConfiguration {

        #region ctors

        internal WorkerRemoteConfiguration() : this(null) { }

        internal WorkerRemoteConfiguration(IWorkerRemoteConfiguration original) : base(original) {
            if(original != null) {
                Factory.Instance.Copy(out IWorkerClientConfiguration clientConfig, original.ClientConfiguration);
                ClientConfiguration = clientConfig;
            }
        }

        #endregion

    }
}
