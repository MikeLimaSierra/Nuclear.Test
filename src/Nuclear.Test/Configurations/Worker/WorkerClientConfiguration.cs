using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations.Worker {
    internal class WorkerClientConfiguration : ClientConfiguration, IWorkerClientConfiguration {

        #region properties

        public TestModeOverrides TestMethodModeOverride { get; set; }

        #endregion

        #region ctors

        internal WorkerClientConfiguration() : base() { }

        internal WorkerClientConfiguration(IWorkerClientConfiguration original) : base(original) {
            Throw.If.Object.IsNull(original, nameof(original));

            TestMethodModeOverride = original.TestMethodModeOverride;
        }

        #endregion

    }
}
