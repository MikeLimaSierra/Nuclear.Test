using System;
using System.IO;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for a worker <see cref="IClient"/>.
    /// </summary>
    public class WorkerConfiguration : IWorkerConfiguration {

        #region constants

        /// <summary>
        /// Configuration values for <see cref="File"/>.
        /// </summary>
        public const String FILE = "Worker.File";

        /// <summary>
        /// Configuration values for <see cref="TestsInSequence"/>.
        /// </summary>
        public const String TESTS_IN_SEQUENCE = "Worker.TestsInSequence";

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the file path of the test assembly.
        /// </summary>
        public FileInfo File { get; set; }

        /// <summary>
        /// Gets or sets if tests in an assembly should all be executed in a sequence.
        ///     If set to true, the worker will execute one test after the other resulting in no parallelism at all.
        ///     If set to false, the worker will execute each test as configured via attributes.
        /// </summary>
        public Boolean TestsInSequence { get; set; }

        #endregion

    }
}
