using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;

namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Defines a scenario relevant to running tests.
    /// </summary>
    public interface IScenario : IEquatable<IScenario>, IComparable<IScenario> {

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

        #endregion

    }

}
