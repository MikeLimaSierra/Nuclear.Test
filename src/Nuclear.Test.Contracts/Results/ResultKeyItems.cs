using System;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines all available items in an <see cref="IResultKey"/>.
    /// </summary>
    public enum ResultKeyItems : Int32 {

        /// <summary>
        /// An unknown item.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The test assembly name.
        /// </summary>
        AssemblyName = 1,

        /// <summary>
        /// The targeted framework.
        /// </summary>
        TargetFrameworkIdentifier = 2,

        /// <summary>
        /// The targeted framework version.
        /// </summary>
        TargetFrameworkVersion = 3,

        /// <summary>
        /// The targeted processor architecure.
        /// </summary>
        TargetArchitecture = 4,

        /// <summary>
        /// The executing framework.
        /// </summary>
        ExecutionFrameworkIdentifier = 5,

        /// <summary>
        /// The executing framework version.
        /// </summary>
        ExecutionFrameworkVersion = 6,

        /// <summary>
        /// The executing processor architecure.
        /// </summary>
        ExecutionArchitecture = 7,

        /// <summary>
        /// The file name.
        /// </summary>
        FileName = 8,

        /// <summary>
        /// The method name.
        /// </summary>
        MethodName = 9
    }
}
