using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestResultKey_uTests {

        #region statics

        private static readonly IResultKey _isFullyQualified =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
                 new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", "MethodA");

        #endregion

        #region matchValue statics

        private static readonly IResultKey _matchAssemblyName =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
              new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _matchTargetFrameworkIdentifier =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _matchTargetFrameworkVersion =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _matchTargetArchitecture =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _matchExecutionFrameworkIdentifier =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
            new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _matchExecutionFrameworkVersion =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _matchExecutionArchitecture =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, null, null);

        private static readonly IResultKey _matchFileName =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", null);

        private static readonly IResultKey _matchMethodName =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", "MethodA");

        #endregion

        [TestMethod]
        void TestImplementation() {

            TestX.If.Type.Implements<IResultKey, IEquatable<IResultKey>>();
            TestX.If.Type.Implements<IResultKey, IComparable<IResultKey>>();
            TestX.If.Type.Implements<ResultKey, IResultKey>();

        }

        #region ctors

        [TestMethod]
        [TestData(nameof(DefaultCtorData))]
        void DefaultCtor((String assemblyName, RuntimeInfo target, ProcessorArchitecture targetArchitecture, RuntimeInfo execution, ProcessorArchitecture executionArchitecture, String file, String method) input,
            (String assemblyName, RuntimeInfo target, ProcessorArchitecture targetArchitecture, RuntimeInfo execution, ProcessorArchitecture executionArchitecture, String file, String method) expected) {

            IResultKey scenario = null;
            Action action = () => scenario = new ResultKey(input.assemblyName,
                input.target, input.targetArchitecture,
                input.execution, input.executionArchitecture,
                input.file, input.method);

            TestX.IfNot.Action.ThrowsException(action, out Exception ex);
            TestX.IfNot.Object.IsNull(scenario);

            TestX.If.Value.IsEqual(scenario.AssemblyName, expected.assemblyName);
            TestX.If.Value.IsEqual(scenario.TargetRuntime, expected.target);
            TestX.If.Value.IsEqual(scenario.TargetArchitecture, expected.targetArchitecture);
            TestX.If.Value.IsEqual(scenario.ExecutionRuntime, expected.execution);
            TestX.If.Value.IsEqual(scenario.ExecutionArchitecture, expected.executionArchitecture);
            TestX.If.Value.IsEqual(scenario.FileName, expected.file);
            TestX.If.Value.IsEqual(scenario.MethodName, expected.method);

        }

        IEnumerable<Object[]> DefaultCtorData() {
            return new List<Object[]>() {
                new Object[] { ((String) null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, (String) null, (String) null), ((String) null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, (String) null, (String) null) },
                new Object[] { ("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", "MethodA"), ("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", "MethodA") },
            };
        }

        [TestMethod]
        [TestData(nameof(ScenarioCtorData))]
        void ScenarioCtor((TestScenario scenario, String file, String method) input, (TestScenario scenario, String file, String method) expected) {

            IResultKey scenario = null;

            TestX.IfNot.Action.ThrowsException(() => scenario = new ResultKey(input.scenario, input.file, input.method), out Exception ex);
            TestX.IfNot.Object.IsNull(scenario);

            TestX.If.Value.IsEqual(scenario.AssemblyName, expected.scenario.AssemblyName);
            TestX.If.Value.IsEqual(scenario.TargetRuntime, expected.scenario.TargetRuntime);
            TestX.If.Value.IsEqual(scenario.TargetArchitecture, expected.scenario.TargetArchitecture);
            TestX.If.Value.IsEqual(scenario.ExecutionRuntime, expected.scenario.ExecutionRuntime);
            TestX.If.Value.IsEqual(scenario.ExecutionArchitecture, expected.scenario.ExecutionArchitecture);
            TestX.If.Value.IsEqual(scenario.FileName, expected.file);
            TestX.If.Value.IsEqual(scenario.MethodName, expected.method);

        }

        IEnumerable<Object[]> ScenarioCtorData() {
            return new List<Object[]>() {
                new Object[] { (new TestScenario(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None), (String) null, (String) null), (new TestScenario(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None), (String) null, (String) null) },
                new Object[] { (new TestScenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86), "FileA", "MethodA"), (new TestScenario("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86), "FileA", "MethodA") },
            };
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestData(nameof(EqualsData))]
        void Equals(IResultKey key, IResultKey other, Boolean expected) {

            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = key.Equals(other), out Exception ex);
            TestX.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> EqualsData() {
            return new List<Object[]>() {
                new Object[] { _matchAssemblyName, null, false },

                new Object[] { _matchAssemblyName, _matchAssemblyName, true },
                new Object[] { _matchTargetFrameworkIdentifier, _matchTargetFrameworkIdentifier, true },
                new Object[] { _matchTargetFrameworkVersion, _matchTargetFrameworkVersion, true },
                new Object[] { _matchTargetArchitecture, _matchTargetArchitecture, true },
                new Object[] { _matchExecutionFrameworkIdentifier, _matchExecutionFrameworkIdentifier, true },
                new Object[] { _matchExecutionFrameworkVersion, _matchExecutionFrameworkVersion, true },
                new Object[] { _matchExecutionArchitecture, _matchExecutionArchitecture, true },
                new Object[] { _matchFileName, _matchFileName, true },
                new Object[] { _matchMethodName, _matchMethodName, true },

                new Object[] { _matchAssemblyName, _matchTargetFrameworkIdentifier, false },
                new Object[] { _matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion, false },
                new Object[] { _matchTargetFrameworkVersion, _matchTargetArchitecture, false },
                new Object[] { _matchTargetArchitecture, _matchExecutionFrameworkIdentifier, false },
                new Object[] { _matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion, false },
                new Object[] { _matchExecutionFrameworkVersion, _matchExecutionArchitecture, false },
                new Object[] { _matchExecutionArchitecture, _matchFileName, false },
                new Object[] { _matchFileName, _matchMethodName, false },

                new Object[] { _matchTargetFrameworkIdentifier, _matchAssemblyName, false },
                new Object[] { _matchTargetFrameworkVersion, _matchTargetFrameworkIdentifier, false },
                new Object[] { _matchTargetArchitecture, _matchTargetFrameworkVersion, false },
                new Object[] { _matchExecutionFrameworkIdentifier, _matchTargetArchitecture, false },
                new Object[] { _matchExecutionFrameworkVersion, _matchExecutionFrameworkIdentifier, false },
                new Object[] { _matchExecutionArchitecture, _matchExecutionFrameworkVersion, false },
                new Object[] { _matchFileName, _matchExecutionArchitecture, false },
                new Object[] { _matchMethodName, _matchFileName, false },
            };
        }

        #endregion

    }
}
