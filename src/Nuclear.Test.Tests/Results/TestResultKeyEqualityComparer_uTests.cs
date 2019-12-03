using System;
using System.Collections.Generic;
using System.Reflection;
using Nuclear.TestSite;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestResultKeyEqualityComparer_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestResultKeyEqualityComparer, IEqualityComparer<ITestResultKey>>();

        }

        [TestMethod]
        void Equals() {

            TestResultKeyEqualityComparer comp = new TestResultKeyEqualityComparer();
            ITestResultKey x = new TestResultKey("asm_x",
                FrameworkIdentifiers.NETStandard, new Version(1, 0), ProcessorArchitecture.MSIL,
                FrameworkIdentifiers.NETFramework, new Version(1, 0), ProcessorArchitecture.MSIL,
                "FileA", "MethodA");
            ITestResultKey y = new TestResultKey("asm_y",
                FrameworkIdentifiers.NETStandard, new Version(1, 0), ProcessorArchitecture.MSIL,
                FrameworkIdentifiers.NETFramework, new Version(1, 0), ProcessorArchitecture.MSIL,
                "FileA", "MethodA");
            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = comp.Equals(null, null), out Exception ex);
            TestX.If.Value.IsTrue(result);

            TestX.IfNot.Action.ThrowsException(() => result = comp.Equals(x, null), out ex);
            TestX.If.Value.IsFalse(result);

            TestX.IfNot.Action.ThrowsException(() => result = comp.Equals(null, y), out ex);
            TestX.If.Value.IsFalse(result);

            TestX.IfNot.Action.ThrowsException(() => result = comp.Equals(x, y), out ex);
            TestX.If.Value.IsFalse(result);

            TestX.IfNot.Action.ThrowsException(() => result = comp.Equals(x, x), out ex);
            TestX.If.Value.IsTrue(result);

        }

    }
}
