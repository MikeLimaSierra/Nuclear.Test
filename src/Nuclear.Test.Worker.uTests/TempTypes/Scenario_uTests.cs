using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.TempTypes {
    class Scenario_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<Scenario, IScenario>();

        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5) {

            IScenario sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new Scenario(in1, in2, in3, in4, in5), out Exception ex);

            TestX.If.Value.IsEqual(sut.AssemblyName, in1);
            TestX.If.Value.IsEqual(sut.TargetRuntime, in2);
            TestX.If.Value.IsEqual(sut.TargetArchitecture, in3);
            TestX.If.Value.IsEqual(sut.ExecutionRuntime, in4);
            TestX.If.Value.IsEqual(sut.ExecutionArchitecture, in5);

        }

        IEnumerable<Object[]> Ctor_Data() {
            yield return new Object[] {
                null,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None
            };
            yield return new Object[] {
                "asm",
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                ProcessorArchitecture.X86,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)),
                ProcessorArchitecture.X86
            };
        }

    }
}
