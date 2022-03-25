using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.TempTypes {
    class Scenario_uTests {

        #region statics

        private static readonly Scenario _isFullyQualified =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
                 new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86);

        #endregion

        #region matchValue statics

        private static readonly Scenario _matchAssemblyName =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
              new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None);

        private static readonly Scenario _matchTargetFrameworkIdentifier =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None);

        private static readonly Scenario _matchTargetFrameworkVersion =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None);

        private static readonly Scenario _matchTargetArchitecture =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None);

        private static readonly Scenario _matchExecutionFrameworkIdentifier =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
            new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version()), ProcessorArchitecture.None);

        private static readonly Scenario _matchExecutionFrameworkVersion =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.None);

        private static readonly Scenario _matchExecutionArchitecture =
            new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86);

        #endregion

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<Scenario, IEquatable<Scenario>>();

        }

        #region Ctor

        [TestMethod]
        [TestData(nameof(CtorThrows_Data))]
        void CtorThrows<TException>(String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5, String expected)
            where TException : ArgumentException {

            Scenario sut = default;

            TestX.If.Action.ThrowsException(() => sut = new Scenario(in1, in2, in3, in4, in5), out TException ex);

            TestX.If.Value.IsEqual(ex.ParamName, expected);

        }

        IEnumerable<Object[]> CtorThrows_Data() {
            yield return new Object[] {
                typeof(ArgumentNullException),
                null,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                "assemblyName"
            };
            yield return new Object[] {
                typeof(ArgumentException),
                "",
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                "assemblyName"
            };
            yield return new Object[] {
                typeof(ArgumentException),
                " ",
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                "assemblyName"
            };
            yield return new Object[] {
                typeof(ArgumentNullException),
                "asm",
                null,
                ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                "targetRuntime"
            };
            yield return new Object[] {
                typeof(ArgumentException),
                "asm",
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                (ProcessorArchitecture) 42,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                "targetArchitecture"
            };
            yield return new Object[] {
                typeof(ArgumentNullException),
                "asm",
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                null,
                ProcessorArchitecture.None,
                "executionRuntime"
            };
            yield return new Object[] {
                typeof(ArgumentException),
                "asm",
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                (ProcessorArchitecture) 42,
                "executionArchitecture"
            };
        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5) {

            Scenario sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new Scenario(in1, in2, in3, in4, in5), out Exception _);

            TestX.If.Value.IsEqual(sut.AssemblyName, in1);
            TestX.If.Value.IsEqual(sut.TargetRuntime, in2);
            TestX.If.Value.IsEqual(sut.TargetArchitecture, in3);
            TestX.If.Value.IsEqual(sut.ExecutionRuntime, in4);
            TestX.If.Value.IsEqual(sut.ExecutionArchitecture, in5);

        }

        IEnumerable<Object[]> Ctor_Data() {
            yield return new Object[] {
                "asm",
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                ProcessorArchitecture.X86,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)),
                ProcessorArchitecture.X86
            };
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestData(nameof(Equals_WrongTypeData))]
        [TestData(nameof(Equals_Data))]
        void Equals(Scenario sut, Object other, Boolean expected) {

            Boolean result = default;

            TestX.IfNot.Action.ThrowsException(() => result = sut.Equals(other), out Exception ex);

            TestX.If.Value.IsEqual(result, expected);

        }

        [TestMethod]
        [TestData(nameof(Equals_Data))]
        void Equals(Scenario sut, Scenario other, Boolean expected) {

            Boolean result = default;

            TestX.IfNot.Action.ThrowsException(() => result = sut.Equals(other), out Exception ex);

            TestX.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> Equals_WrongTypeData() {
            yield return new Object[] { _matchAssemblyName, new Object(), false };
            yield return new Object[] { _matchAssemblyName, DateTime.Now, false };
        }

        IEnumerable<Object[]> Equals_Data() {
            yield return new Object[] { _matchAssemblyName, null, false };

            yield return new Object[] { _matchAssemblyName, _matchAssemblyName, true };
            yield return new Object[] { _matchTargetFrameworkIdentifier, _matchTargetFrameworkIdentifier, true };
            yield return new Object[] { _matchTargetFrameworkVersion, _matchTargetFrameworkVersion, true };
            yield return new Object[] { _matchTargetArchitecture, _matchTargetArchitecture, true };
            yield return new Object[] { _matchExecutionFrameworkIdentifier, _matchExecutionFrameworkIdentifier, true };
            yield return new Object[] { _matchExecutionFrameworkVersion, _matchExecutionFrameworkVersion, true };
            yield return new Object[] { _matchExecutionArchitecture, _matchExecutionArchitecture, true };

            yield return new Object[] { _matchAssemblyName, _matchTargetFrameworkIdentifier, false };
            yield return new Object[] { _matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion, false };
            yield return new Object[] { _matchTargetFrameworkVersion, _matchTargetArchitecture, false };
            yield return new Object[] { _matchTargetArchitecture, _matchExecutionFrameworkIdentifier, false };
            yield return new Object[] { _matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion, false };
            yield return new Object[] { _matchExecutionFrameworkVersion, _matchExecutionArchitecture, false };

            yield return new Object[] { _matchTargetFrameworkIdentifier, _matchAssemblyName, false };
            yield return new Object[] { _matchTargetFrameworkVersion, _matchTargetFrameworkIdentifier, false };
            yield return new Object[] { _matchTargetArchitecture, _matchTargetFrameworkVersion, false };
            yield return new Object[] { _matchExecutionFrameworkIdentifier, _matchTargetArchitecture, false };
            yield return new Object[] { _matchExecutionFrameworkVersion, _matchExecutionFrameworkIdentifier, false };
            yield return new Object[] { _matchExecutionArchitecture, _matchExecutionFrameworkVersion, false };
        }

        #endregion

    }
}
