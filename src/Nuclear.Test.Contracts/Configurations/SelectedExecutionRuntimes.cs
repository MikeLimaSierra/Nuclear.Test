namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines a range of targeted execution runtimes for test assemblies.
    /// </summary>
    public enum SelectedExecutionRuntimes {

        /// <summary>
        /// Run tests on lowest possible runtime versions.
        /// </summary>
        Lowest,

        /// <summary>
        /// Run tests on highest possible runtime versions.
        /// </summary>
        Highest,

        /// <summary>
        /// Run tests on all possible runtime versions.
        /// </summary>
        All,
    }
}
