using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.TempTypes {
    class ResultKey_uTests {

        #region statics

        private static readonly IResultKey _isFullyQualified =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
                 new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86), "FileA", "MethodA");

        #endregion

        #region matchValue statics

        private static readonly IResultKey _matchAssemblyName =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
              new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None), null, null);

        private static readonly IResultKey _matchTargetFrameworkIdentifier =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None), null, null);

        private static readonly IResultKey _matchTargetFrameworkVersion =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None), null, null);

        private static readonly IResultKey _matchTargetArchitecture =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None), null, null);

        private static readonly IResultKey _matchExecutionFrameworkIdentifier =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
            new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version()), ProcessorArchitecture.None), null, null);

        private static readonly IResultKey _matchExecutionFrameworkVersion =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.None), null, null);

        private static readonly IResultKey _matchExecutionArchitecture =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86), null, null);

        private static readonly IResultKey _matchFileName =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86), "FileA", null);

        private static readonly IResultKey _matchMethodName =
            new ResultKey(new Scenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86), "FileA", "MethodA");

        #endregion

        [TestMethod]
        void TestImplementation() {

            TestX.If.Type.Implements<IResultKey, IEquatable<IResultKey>>();
            TestX.If.Type.Implements<ResultKey, IResultKey>();

        }

        #region ctors

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(IScenario in1, String in2, String in3) {

            IResultKey sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new ResultKey(in1, in2, in3), out Exception ex);

            TestX.If.Reference.IsEqual(sut.Scenario, in1);
            TestX.If.Value.IsEqual(sut.FileName, in2);
            TestX.If.Value.IsEqual(sut.MethodName, in3);

        }

        IEnumerable<Object[]> Ctor_Data() {
            yield return new Object[] {
                new Scenario(
                    null,
                    new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                    ProcessorArchitecture.None,
                    new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()),
                    ProcessorArchitecture.None),
                null,
                null
            };
            yield return new Object[] {
                new Scenario(
                    "asm",
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    ProcessorArchitecture.X86,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)),
                    ProcessorArchitecture.X86),
                "FileA",
                "MethodA"
            };
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestData(nameof(Equals_WrongTypeData))]
        [TestData(nameof(Equals_Data))]
        void Equals(IResultKey sut, Object other, Boolean expected) {

            Boolean result = default;

            TestX.IfNot.Action.ThrowsException(() => result = sut.Equals(other), out Exception ex);

            TestX.If.Value.IsEqual(result, expected);

        }

        [TestMethod]
        [TestData(nameof(Equals_Data))]
        void Equals(IResultKey sut, IResultKey other, Boolean expected) {

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
            yield return new Object[] { _matchFileName, _matchFileName, true };
            yield return new Object[] { _matchMethodName, _matchMethodName, true };

            yield return new Object[] { _matchAssemblyName, _matchTargetFrameworkIdentifier, false };
            yield return new Object[] { _matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion, false };
            yield return new Object[] { _matchTargetFrameworkVersion, _matchTargetArchitecture, false };
            yield return new Object[] { _matchTargetArchitecture, _matchExecutionFrameworkIdentifier, false };
            yield return new Object[] { _matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion, false };
            yield return new Object[] { _matchExecutionFrameworkVersion, _matchExecutionArchitecture, false };
            yield return new Object[] { _matchExecutionArchitecture, _matchFileName, false };
            yield return new Object[] { _matchFileName, _matchMethodName, false };

            yield return new Object[] { _matchTargetFrameworkIdentifier, _matchAssemblyName, false };
            yield return new Object[] { _matchTargetFrameworkVersion, _matchTargetFrameworkIdentifier, false };
            yield return new Object[] { _matchTargetArchitecture, _matchTargetFrameworkVersion, false };
            yield return new Object[] { _matchExecutionFrameworkIdentifier, _matchTargetArchitecture, false };
            yield return new Object[] { _matchExecutionFrameworkVersion, _matchExecutionFrameworkIdentifier, false };
            yield return new Object[] { _matchExecutionArchitecture, _matchExecutionFrameworkVersion, false };
            yield return new Object[] { _matchFileName, _matchExecutionArchitecture, false };
            yield return new Object[] { _matchMethodName, _matchFileName, false };
        }

        #endregion

    }
}
