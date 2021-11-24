using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Creation;

namespace Nuclear.Test.Factories {

    /// <summary>
    /// Defines a factory for internal implementations.
    /// </summary>
    public abstract class ScenarioFactory : ICreator<ITestScenario, String, RuntimeInfo, ProcessorArchitecture, RuntimeInfo, ProcessorArchitecture> {

        #region scenario

        public abstract void Create(
            out ITestScenario obj,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture);

        public abstract Boolean TryCreate(
            out ITestScenario obj,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture);

        public abstract Boolean TryCreate(
            out ITestScenario obj,
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture,
            out Exception ex);

        #endregion

    }
}
