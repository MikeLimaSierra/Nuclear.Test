using Nuclear.Test.Execution.Worker;

namespace Nuclear.Test.Configurations.Worker {

    /// <summary>
    /// Defines configuration values for an <see cref="IWorkerClient"/>.
    /// </summary>
    public interface IWorkerClientConfiguration : IClientConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets how tests in an assembly should be executed.
        /// </summary>
        TestModeOverrides TestMethodModeOverride { get; set; }

        #endregion

    }
}
