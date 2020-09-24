using System;
using System.IO;

using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for a worker <see cref="IClient"/>.
    /// </summary>
    public interface IWorkerConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the file path of the test assembly.
        /// </summary>
        FileInfo File { get; set; }

        /// <summary>
        /// Gets or sets if tests in an assembly should all be executed in a sequence.
        ///     If set to true, the worker will execute one test after the other resulting in no parallelism at all.
        ///     If set to false, the worker will execute each test as configured via attributes.
        /// </summary>
        Boolean TestsInSequence { get; set; }

        #endregion

    }
}
