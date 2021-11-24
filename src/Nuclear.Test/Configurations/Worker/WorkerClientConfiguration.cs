namespace Nuclear.Test.Configurations.Worker {
    internal class WorkerClientConfiguration : ClientConfiguration, IWorkerClientConfiguration {

        #region properties

        public TestModeOverrides TestMethodModeOverride { get; set; }

        #endregion

        #region ctors

        internal WorkerClientConfiguration() : this(null) { }

        internal WorkerClientConfiguration(IWorkerClientConfiguration original) : base(original) {
            if(original != null) {
                TestMethodModeOverride = original.TestMethodModeOverride;
            }
        }

        #endregion

    }
}
