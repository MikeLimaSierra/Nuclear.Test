
using Nuclear.Test.Configurations;
using Nuclear.Test.Results;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// Defines the base functionality of an executor.
    /// </summary>
    public interface IExecutor {

        #region properties

        /// <summary>
        /// Gets the client configuration object.
        /// </summary>
        IExecutorConfiguration Configuration { get; }

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        ITestResultEndPoint Results { get; }

        #endregion

        #region methods

        /// <summary>
        /// Commands to execute.
        /// </summary>
        void Execute();

        #endregion

    }
}
