using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;

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
        /// Gets or sets the targeted runtime version.
        /// </summary>
        public RuntimeInfo TargetRuntime { get; private set; }

        /// <summary>
        /// Gets the targeted processor architecture.
        /// </summary>
        public ProcessorArchitecture TargetArchitecture { get; private set; }

        /// <summary>
        /// Gets or sets the executing runtime version.
        /// </summary>
        public RuntimeInfo ExecutionRuntime { get; private set; }

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
        /// <param name="targetRuntime">The targeted runtime version.</param>
        /// <param name="targetArchitecture">The targeted processor architecture.</param>
        /// <param name="executionRuntime">The executing runtime version.</param>
        /// <param name="executionArchitecture">The executing processor architecture.</param>
        public TestScenario(
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture) {

            AssemblyName = assemblyName;
            TargetRuntime = targetRuntime;
            TargetArchitecture = targetArchitecture;
            ExecutionRuntime = executionRuntime;
            ExecutionArchitecture = executionArchitecture;
        }

        #endregion

    }
}
