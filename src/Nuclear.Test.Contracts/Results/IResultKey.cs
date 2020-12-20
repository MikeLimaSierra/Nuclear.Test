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


        /// <summary>
        /// Gets if the key has an assembly name defined.
        /// </summary>
        Boolean HasAssemblyName { get; }

        /// <summary>
        /// Gets if the key has a target runtime defined.
        /// </summary>
        Boolean HasTargetRuntime { get; }

        /// <summary>
        /// Gets if the key has a target framework defined.
        /// </summary>
        Boolean HasTargetFrameworkIdentifier { get; }

        /// <summary>
        /// Gets if the key has a target framework version defined.
        /// </summary>
        Boolean HasTargetFrameworkVersion { get; }

        /// <summary>
        /// Gets if the key has a fully qualified target runtime defined.
        /// </summary>
        Boolean HasFullyQualifiedTargetRuntime { get; }

        /// <summary>
        /// Gets if the key has a targeted processor architecture defined.
        /// </summary>
        Boolean HasTargetArchitecture { get; }

        /// <summary>
        /// Gets if the key has an executing runtime defined.
        /// </summary>
        Boolean HasExecutionRuntime { get; }

        /// <summary>
        /// Gets if the key has an executing framework defined.
        /// </summary>
        Boolean HasExecutionFrameworkIdentifier { get; }

        /// <summary>
        /// Gets if the key has an executing framework version defined.
        /// </summary>
        Boolean HasExecutionFrameworkVersion { get; }

        /// <summary>
        /// Gets if the key has a fully qualified executing runtime defined.
        /// </summary>
        Boolean HasFullyQualifiedExecutionRuntime { get; }

        /// <summary>
        /// Gets if the key has an executing processor architecture defined.
        /// </summary>
        Boolean HasExecutionArchitecture { get; }

        /// <summary>
        /// Gets if the key has a file name defined.
        /// </summary>
        Boolean HasFileName { get; }

        /// <summary>
        /// Gets if the key has a method name defined.
        /// </summary>
        Boolean HasMethodName { get; }


        /// <summary>
        /// Gets if the key is fully qualified to identify one set of <see cref="ITestMethodResult"/>.
        /// </summary>
        Boolean IsFullyQualified { get; }

        /// <summary>
        /// Gets the <see cref="ResultKeyItems"/> of the key.
        /// </summary>
        ResultKeyItems Precision { get; }

        #endregion

        #region methods

        /// <summary>
        /// Gets if the current key matches another key.
        /// </summary>
        /// <param name="match">The key to use as a match pattern.</param>
        /// <returns>True if it matches.</returns>
        Boolean Matches(IResultKey match);

        /// <summary>
        /// Returns a new version of the current key that is clipped to a given precision.
        /// </summary>
        /// <param name="precision">The <see cref="ResultKeyItems"/> for the new key.</param>
        /// <returns>The new key.</returns>
        IResultKey Clip(ResultKeyItems precision);

        /// <summary>
        /// Gets if two keys are equal in respect of a given precision.
        /// </summary>
        /// <param name="other">The other key to compare.</param>
        /// <param name="precision">The <see cref="ResultKeyItems"/> to use for comparing.</param>
        /// <returns>True if both keys are equal.</returns>
        Boolean Equals(IResultKey other, ResultKeyItems precision);

        #endregion

    }
}
