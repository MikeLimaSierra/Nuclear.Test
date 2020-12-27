using System;
using System.Reflection;

namespace Nuclear.Test {

    /// <summary>
    /// Defines a scenario relevant to running tests.
    /// </summary>
    internal class TestScenario : ITestScenario {

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

        internal TestScenario(
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
