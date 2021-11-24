using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Creation;

namespace Nuclear.Test.Factories.Internal {
    internal class ScenarioFactory : Factories.ScenarioFactory {

        #region fields

        private readonly ICreator<ITestScenario, String, RuntimeInfo, ProcessorArchitecture, RuntimeInfo, ProcessorArchitecture> _factory =
            Factory.Instance.Creator.Create<ITestScenario, String, RuntimeInfo, ProcessorArchitecture, RuntimeInfo, ProcessorArchitecture>(
                (in1, in2, in3, in4, in5) => new TestScenario(in1, in2, in3, in4, in5));

        #endregion

        #region methods

        public override void Create(out ITestScenario obj, String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5)
            => _factory.Create(out obj, in1, in2, in3, in4, in5);

        public override Boolean TryCreate(out ITestScenario obj, String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5)
            => _factory.TryCreate(out obj, in1, in2, in3, in4, in5);

        public override Boolean TryCreate(out ITestScenario obj, String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5, out Exception ex)
            => _factory.TryCreate(out obj, in1, in2, in3, in4, in5, out ex);

        #endregion

    }
}
