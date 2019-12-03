using System;
using System.Reflection;

namespace Nuclear.Test {

    /// <summary>
    /// Defines a scenario relevant to running tests.
    /// </summary>
    public class TestScenario : ITestScenario {

        #region properties

        /// <summary>
        /// Gets the name of the test assembly.
        /// </summary>
        public String AssemblyName { get; private set; }

        /// <summary>
        /// Gets the targeted framework.
        /// </summary>
        public FrameworkIdentifiers TargetFrameworkIdentifier { get; private set; }

        /// <summary>
        /// Gets the targeted framework version.
        /// </summary>
        public Version TargetFrameworkVersion { get; private set; }

        /// <summary>
        /// Gets the targeted processor architecture.
        /// </summary>
        public ProcessorArchitecture TargetArchitecture { get; private set; }

        /// <summary>
        /// Gets the executing framework.
        /// </summary>
        public FrameworkIdentifiers ExecutionFrameworkIdentifier { get; private set; }

        /// <summary>
        /// Gets the executing framework version.
        /// </summary>
        public Version ExecutionFrameworkVersion { get; private set; }

        /// <summary>
        /// Gets the executing processor architecture.
        /// </summary>
        public ProcessorArchitecture ExecutionArchitecture { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestScenario"/>.
        /// </summary>
        /// <param name="assemblyName">The name of the test assembly.</param>
        /// <param name="targetFrameworkIdentifier">The targeted framework.</param>
        /// <param name="targetFrameworkVersion">The targeted framework version.</param>
        /// <param name="targetArchitecture">The targeted processor architecture.</param>
        /// <param name="executionFrameworkIdentifier">The executing framework.</param>
        /// <param name="executionFrameworkVersion">The executing framework version.</param>
        /// <param name="executionArchitecture">The executing processor architecture.</param>
        public TestScenario(
            String assemblyName,
            FrameworkIdentifiers targetFrameworkIdentifier,
            Version targetFrameworkVersion,
            ProcessorArchitecture targetArchitecture,
            FrameworkIdentifiers executionFrameworkIdentifier,
            Version executionFrameworkVersion,
            ProcessorArchitecture executionArchitecture) {

            AssemblyName = assemblyName;
            TargetFrameworkIdentifier = targetFrameworkIdentifier;
            TargetFrameworkVersion = targetFrameworkVersion;
            TargetArchitecture = targetArchitecture;
            ExecutionFrameworkIdentifier = executionFrameworkIdentifier;
            ExecutionFrameworkVersion = executionFrameworkVersion;
            ExecutionArchitecture = executionArchitecture;
        }

        #endregion

    }
}
