using System;
using System.Reflection;
using System.Runtime.CompilerServices;

using Nuclear.Assemblies.Runtimes;
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

            DDTCtor((null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None),
                (null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None));
            DDTCtor(("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86),
                ("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86));

        }

        void DDTCtor((String assemblyName, RuntimeInfo target, ProcessorArchitecture targetArchitecture, RuntimeInfo execution, ProcessorArchitecture executionArchitecture) input,
            (String assemblyName, RuntimeInfo target, ProcessorArchitecture targetArchitecture, RuntimeInfo execution, ProcessorArchitecture executionArchitecture) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITestScenario scenario = null;
            Action action = () => scenario = new TestScenario(input.assemblyName, input.target, input.targetArchitecture, input.execution, input.executionArchitecture);

            TestX.Note(String.Format("new TestScenario({0}, {1}, {2}, {3}, {4})",
                input.assemblyName.Format(), input.target.Format(), input.targetArchitecture.Format(), input.execution.Format(), input.executionArchitecture.Format()),
                _file, _method);

            TestX.IfNot.Action.ThrowsException(action, out Exception ex, _file, _method);
            TestX.IfNot.Object.IsNull(scenario, _file, _method);

            TestX.If.Value.IsEqual(scenario.AssemblyName, expected.assemblyName, _file, _method);
            TestX.If.Value.IsEqual(scenario.TargetRuntime, expected.target, _file, _method);
            TestX.If.Value.IsEqual(scenario.TargetArchitecture, expected.targetArchitecture, _file, _method);
            TestX.If.Value.IsEqual(scenario.ExecutionRuntime, expected.execution, _file, _method);
            TestX.If.Value.IsEqual(scenario.ExecutionArchitecture, expected.executionArchitecture, _file, _method);

        }

    }
}
