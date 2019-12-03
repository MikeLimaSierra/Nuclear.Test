using System;
using System.Reflection;
using Nuclear.TestSite;

namespace Nuclear.Test {

    /// <summary>
    /// Defines a scenario relevant to running tests.
    /// </summary>
    public interface ITestScenario {

        #region properties

        /// <summary>
        /// Gets the name of the test assembly.
        /// </summary>
        String AssemblyName { get; }

        /// <summary>
        /// Gets the targeted framework.
        /// </summary>
        FrameworkIdentifiers TargetFrameworkIdentifier { get; }

        /// <summary>
        /// Gets the targeted framework version.
        /// </summary>
        Version TargetFrameworkVersion { get; }

        /// <summary>
        /// Gets the targeted processor architecture.
        /// </summary>
        ProcessorArchitecture TargetArchitecture { get; }

        /// <summary>
        /// Gets the executing framework.
        /// </summary>
        FrameworkIdentifiers ExecutionFrameworkIdentifier { get; }

        /// <summary>
        /// Gets the executing framework version.
        /// </summary>
        Version ExecutionFrameworkVersion { get; }

        /// <summary>
        /// Gets the executing processor architecture.
        /// </summary>
        ProcessorArchitecture ExecutionArchitecture { get; }

        #endregion

    }
}
