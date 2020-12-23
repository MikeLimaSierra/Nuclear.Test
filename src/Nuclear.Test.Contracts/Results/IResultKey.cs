using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;

namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines the key structure that identifies test method results.
    /// </summary>
    public interface IResultKey : IEquatable<IResultKey>, IComparable<IResultKey> {

        #region properties

        /// <summary>
        /// Gets the name of the test assembly.
        /// </summary>
        String AssemblyName { get; }

        /// <summary>
        /// Gets or sets the targeted runtime version.
        /// </summary>
        RuntimeInfo TargetRuntime { get; }

        /// <summary>
        /// Gets the targeted processor architecture.
        /// </summary>
        ProcessorArchitecture TargetArchitecture { get; }

        /// <summary>
        /// Gets or sets the executing runtime version.
        /// </summary>
        RuntimeInfo ExecutionRuntime { get; }

        /// <summary>
        /// Gets the executing processor architecture.
        /// </summary>
        ProcessorArchitecture ExecutionArchitecture { get; }

        /// <summary>
        /// Gets the file name of the test.
        /// </summary>
        String FileName { get; }

        /// <summary>
        /// Gets the calling method name of the test.
        /// </summary>
        String MethodName { get; }

        #endregion

    }
}
