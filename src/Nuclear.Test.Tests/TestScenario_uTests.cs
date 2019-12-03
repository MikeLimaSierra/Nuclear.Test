using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;
using TestX = Nuclear.TestSite.Test;


namespace Nuclear.Test {
    class TestScenario_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestScenario, ITestScenario>();

        }

        [TestMethod]
        void Ctor() {

            DDTCtor((null, FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None, FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None),
                (null, FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None, FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None));
            DDTCtor(("asm", FrameworkIdentifiers.NETStandard, new Version(1, 0), ProcessorArchitecture.X86, FrameworkIdentifiers.NETFramework, new Version(1, 0), ProcessorArchitecture.X86),
                ("asm", FrameworkIdentifiers.NETStandard, new Version(1, 0), ProcessorArchitecture.X86, FrameworkIdentifiers.NETFramework, new Version(1, 0), ProcessorArchitecture.X86));

        }

        void DDTCtor((String assemblyName,
            FrameworkIdentifiers targetFrameworkIdentifier, Version targetFrameworkVersion, ProcessorArchitecture targetArchitecture,
            FrameworkIdentifiers executionFrameworkIdentifier, Version executionFrameworkVersion, ProcessorArchitecture executionArchitecture) input,
            (String assemblyName,
            FrameworkIdentifiers targetFrameworkIdentifier, Version targetFrameworkVersion, ProcessorArchitecture targetArchitecture,
            FrameworkIdentifiers executionFrameworkIdentifier, Version executionFrameworkVersion, ProcessorArchitecture executionArchitecture) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITestScenario scenario = null;
            Action action = () => scenario = new TestScenario(input.assemblyName,
                input.targetFrameworkIdentifier, input.targetFrameworkVersion, input.targetArchitecture,
                input.executionFrameworkIdentifier, input.executionFrameworkVersion, input.executionArchitecture);

            TestX.Note(String.Format("new TestScenario({0}, {1}, {2}, {3}, {4}, {5}, {6})", input.assemblyName.Format(),
                input.targetFrameworkIdentifier.Format(), input.targetFrameworkVersion.Format(), input.targetArchitecture.Format(),
                input.executionFrameworkIdentifier.Format(), input.executionFrameworkVersion.Format(), input.executionArchitecture.Format()),
                _file, _method);

            TestX.IfNot.Action.ThrowsException(action, out Exception ex, _file, _method);
            TestX.IfNot.Object.IsNull(scenario, _file, _method);

            TestX.If.Value.Equals(scenario.AssemblyName, expected.assemblyName, _file, _method);
            TestX.If.Value.Equals(scenario.TargetFrameworkIdentifier, expected.targetFrameworkIdentifier, _file, _method);
            TestX.If.Value.Equals(scenario.TargetFrameworkVersion, expected.targetFrameworkVersion, _file, _method);
            TestX.If.Value.Equals(scenario.TargetArchitecture, expected.targetArchitecture, _file, _method);
            TestX.If.Value.Equals(scenario.ExecutionFrameworkIdentifier, expected.executionFrameworkIdentifier, _file, _method);
            TestX.If.Value.Equals(scenario.ExecutionFrameworkVersion, expected.executionFrameworkVersion, _file, _method);
            TestX.If.Value.Equals(scenario.ExecutionArchitecture, expected.executionArchitecture, _file, _method);

        }

    }
}
