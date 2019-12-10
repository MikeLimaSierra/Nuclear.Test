using System;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines a precision for test result keys.
    /// </summary>
    public enum TestResultKeyPrecisions : Int32 {

        /// <summary>
        /// The key is a blank and does not contain information.
        /// </summary>
        None = 0,

        /// <summary>
        /// The key is precise to the test assembly name.
        /// </summary>
        AssemblyName = 1,

        /// <summary>
        /// The key is precise to the targeted framework.
        /// </summary>
        TargetFrameworkIdentifier = 2,

        /// <summary>
        /// The key is precise to the targeted framework version.
        /// </summary>
        TargetFrameworkVersion = 3,

        /// <summary>
        /// The key is precise to the targeted processor architecure.
        /// </summary>
        TargetArchitecture = 4,

        /// <summary>
        /// The key is precise to the executing framework.
        /// </summary>
        ExecutionFrameworkIdentifier = 5,

        /// <summary>
        /// The key is precise to the executing framework version.
        /// </summary>
        ExecutionFrameworkVersion = 6,

        /// <summary>
        /// The key is precise to the executing processor architecure.
        /// </summary>
        ExecutionArchitecture = 7,

        /// <summary>
        /// The key is precise to the file name.
        /// </summary>
        FileName = 8,

        /// <summary>
        /// The key is fully qualified.
        /// </summary>
        MethodName = 9
    }
}
