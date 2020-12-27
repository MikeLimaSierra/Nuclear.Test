using Nuclear.Exceptions;
using Nuclear.TestSite;

namespace Nuclear.Test.Configurations.Worker {
    internal class WorkerClientConfiguration : ClientConfiguration, IWorkerClientConfiguration {

        #region properties

        public TestMode TestsInSequence { get; set; }

        #endregion

        #region ctors

        internal WorkerClientConfiguration() : base() { }

        internal WorkerClientConfiguration(IWorkerClientConfiguration original) : base(original) {
            Throw.If.Object.IsNull(original, nameof(original));

            TestsInSequence = original.TestsInSequence;
        }

        #endregion

    }
}
