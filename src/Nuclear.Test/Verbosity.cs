namespace Nuclear.Test {

    /// <summary>
    /// LODs for presenting test results.
    /// </summary>
    public enum Verbosity {
        /// <summary>
        /// Collapse all nodes.
        /// </summary>
        Collapsed = 0,
        /// <summary>
        /// Unfold to show assemblies.
        /// </summary>
        Assembly = 1,
        /// <summary>
        /// Unfold to show architectures.
        /// </summary>
        Architecture = 2,
        /// <summary>
        /// Unfold to show runtime versions.
        /// </summary>
        Runtime = 3,
        /// <summary>
        /// Unfold to show file names.
        /// </summary>
        File = 4,
        /// <summary>
        /// Unfold to show test methods.
        /// </summary>
        Method = 5,
        /// <summary>
        /// Unfold to show test instructions.
        /// </summary>
        Instruction = 6
    }
}
