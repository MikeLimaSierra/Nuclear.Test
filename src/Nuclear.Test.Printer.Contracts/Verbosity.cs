namespace Nuclear.Test.Printer {

    /// <summary>
    /// LODs for printing test results.
    /// </summary>
    public enum Verbosity {

        /// <summary>
        /// Collapse all nodes.
        /// </summary>
        Collapsed = 0,

        /// <summary>
        /// Unfold to show assemblies.
        /// </summary>
        AssemblyName = 1,

        /// <summary>
        /// Unfold to show target framework.
        /// </summary>
        TargetFrameworkIdentifier = 2,

        /// <summary>
        /// Unfold to show target framework version.
        /// </summary>
        TargetFrameworkVersion = 3,

        /// <summary>
        /// Unfold to show target architecture.
        /// </summary>
        TargetArchitecture = 4,

        /// <summary>
        /// Unfold to show execution framework.
        /// </summary>
        ExecutionFrameworkIdentifier = 5,

        /// <summary>
        /// Unfold to show execution framework version.
        /// </summary>
        ExecutionFrameworkVersion = 6,

        /// <summary>
        /// Unfold to show execution architecture.
        /// </summary>
        ExecutionArchitecture = 7,

        /// <summary>
        /// Unfold to show file names.
        /// </summary>
        FileName = 8,

        /// <summary>
        /// Unfold to show test methods.
        /// </summary>
        MethodName = 9,

        /// <summary>
        /// Unfold to show test instructions.
        /// </summary>
        Instruction = 10
    }
}
