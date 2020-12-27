using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;


namespace Nuclear.Test {
    class TestScenario_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestScenario, ITestScenario>();

        }

        [TestMethod]
        [TestData(nameof(CtorData))]
        void Ctor(String input1, RuntimeInfo input2, ProcessorArchitecture input3, RuntimeInfo input4, ProcessorArchitecture input5,
            (String assemblyName, RuntimeInfo target, ProcessorArchitecture targetArchitecture, RuntimeInfo execution, ProcessorArchitecture executionArchitecture) expected) {

            ITestScenario scenario = null;
            Action action = () => scenario = new TestScenario(input1, input2, input3, input4, input5);

            TestX.IfNot.Action.ThrowsException(action, out Exception ex);
            TestX.IfNot.Object.IsNull(scenario);

            TestX.If.Value.IsEqual(scenario.AssemblyName, expected.assemblyName);
            TestX.If.Value.IsEqual(scenario.TargetRuntime, expected.target);
            TestX.If.Value.IsEqual(scenario.TargetArchitecture, expected.targetArchitecture);
            TestX.If.Value.IsEqual(scenario.ExecutionRuntime, expected.execution);
            TestX.If.Value.IsEqual(scenario.ExecutionArchitecture, expected.executionArchitecture);

        }


        IEnumerable<Object[]> CtorData() {
            return new List<Object[]>() {
                new Object[] { null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                    (null as String, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None) },
                new Object[] {"asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86,
                    ("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86) },
            };
        }

    }
}
