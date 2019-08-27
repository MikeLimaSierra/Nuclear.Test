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
        /// Unfold to show target runtimes.
        /// </summary>
        TargetRuntime = 2,

        /// <summary>
        /// Unfold to show architectures.
        /// </summary>
        Architecture = 3,

        /// <summary>
        /// Unfold to show execution runtimes.
        /// </summary>
        ExecutionRuntime = 4,

        /// <summary>
        /// Unfold to show file names.
        /// </summary>
        File = 5,

        /// <summary>
        /// Unfold to show test methods.
        /// </summary>
        Method = 6,

        /// <summary>
        /// Unfold to show test instructions.
        /// </summary>
        Instruction = 7
    }
}
