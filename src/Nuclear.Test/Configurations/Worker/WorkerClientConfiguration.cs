using System;

using Nuclear.Exceptions;

namespace Nuclear.Test.Configurations.Worker {
    internal class WorkerClientConfiguration : ClientConfiguration, IWorkerClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets if tests in an assembly should all be executed in a sequence.
        ///     If set to true, the worker will execute one test after the other resulting in no parallelism at all.
        ///     If set to false, the worker will execute each test as configured via attributes.
        /// </summary>
        public Boolean TestsInSequence { get; set; }

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
