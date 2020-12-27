using Nuclear.Test.Execution.Worker;
using Nuclear.TestSite;

namespace Nuclear.Test.Configurations.Worker {

    /// <summary>
    /// Defines configuration values for an <see cref="IWorkerClient"/>.
    /// </summary>
    public interface IWorkerClientConfiguration : IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets how tests in an assembly should be executed.
        /// </summary>
        TestMode TestsInSequence { get; set; }

        #endregion

    }
}
