using Nuclear.Creation;

namespace Nuclear.Test.Factories {

    /// <summary>
    /// Extends the functionality of <see cref="IFactory"/>.
    /// </summary>
    public static class IFactoryExtensions {

        /// <summary>
        /// Returns a new instance of type <see cref="ExecutionFactory"/>.
        /// </summary>
        /// <param name="this">The extended <see cref="IFactory"/> instance.</param>
        /// <returns>A new instance of type <see cref="ExecutionFactory"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static ExecutionFactory Execution(this IFactory @this) => new Internal.ExecutionFactory();
#pragma warning restore IDE0060 // Remove unused parameter

        /// <summary>
        /// Returns a new instance of type <see cref="LinkFactory"/>.
        /// </summary>
        /// <param name="this">The extended <see cref="IFactory"/> instance.</param>
        /// <returns>A new instance of type <see cref="LinkFactory"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static LinkFactory Links(this IFactory @this) => new Internal.LinkFactory();
#pragma warning restore IDE0060 // Remove unused parameter

        /// <summary>
        /// Returns a new instance of type <see cref="ResultFactory"/>.
        /// </summary>
        /// <param name="this">The extended <see cref="IFactory"/> instance.</param>
        /// <returns>A new instance of type <see cref="ResultFactory"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static ResultFactory Results(this IFactory @this) => new Internal.ResultFactory();
#pragma warning restore IDE0060 // Remove unused parameter

        /// <summary>
        /// Returns a new instance of type <see cref="ScenarioFactory"/>.
        /// </summary>
        /// <param name="this">The extended <see cref="IFactory"/> instance.</param>
        /// <returns>A new instance of type <see cref="ScenarioFactory"/>.</returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static ScenarioFactory Scenario(this IFactory @this) => new Internal.ScenarioFactory();
#pragma warning restore IDE0060 // Remove unused parameter

    }
}
