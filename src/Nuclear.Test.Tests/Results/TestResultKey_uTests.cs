using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestResultKey_uTests {

        #region statics

        private static readonly IResultKey _isFullyQualified =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
                 new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", "MethodA");

        #endregion

        #region hasValue statics

        private static readonly IResultKey _hasAssemblyName =
            new ResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _hasTargetFramework =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _hasTargetFrameworkIdentifier =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _hasTargetFrameworkVersion =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _hasTargetArchitecture =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _hasExecutionFramework =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, null, null);

        private static readonly IResultKey _hasExecutionFrameworkIdentifier =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _hasExecutionFrameworkVersion =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), ProcessorArchitecture.None, null, null);

        private static readonly IResultKey _hasExecutionArchitecture =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.X86, null, null);

        private static readonly IResultKey _hasFileName =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, "FileA", null);

        private static readonly IResultKey _hasMethodName =
            new ResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, "MethodA");

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

        #region properties

        [TestMethod]
        void EmptyGetter() {

            IResultKey key = null;

            TestX.IfNot.Action.ThrowsException(() => key = ResultKey.Empty, out Exception ex);
            TestX.IfNot.Object.IsNull(key);

            TestX.If.Object.IsNull(key.AssemblyName);
            TestX.If.Value.IsEqual(key.TargetRuntime.Framework, FrameworkIdentifiers.Unsupported);
            TestX.If.Value.IsEqual(key.TargetRuntime.Version, new Version());
            TestX.If.Value.IsEqual(key.TargetArchitecture, ProcessorArchitecture.None);
            TestX.If.Value.IsEqual(key.ExecutionRuntime.Framework, FrameworkIdentifiers.Unsupported);
            TestX.If.Value.IsEqual(key.ExecutionRuntime.Version, new Version());
            TestX.If.Value.IsEqual(key.ExecutionArchitecture, ProcessorArchitecture.None);
            TestX.If.Object.IsNull(key.FileName);
            TestX.If.Object.IsNull(key.MethodName);

        }

        [TestMethod]
        void HasValueGetters() {

            Boolean result = false;

            TestX.Note("HasAssemblyName");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasAssemblyName, out Exception ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasAssemblyName.HasAssemblyName, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetFramework");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasTargetRuntime, out ex);
            TestX.If.Value.IsTrue(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFramework.HasTargetRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetFrameworkIdentifier");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasTargetFrameworkIdentifier, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFrameworkIdentifier.HasTargetFrameworkIdentifier, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetFrameworkVersion");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasTargetFrameworkVersion, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFrameworkVersion.HasTargetFrameworkVersion, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasFullyQualifiedTargetRuntime");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasFullyQualifiedTargetRuntime, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFramework.HasFullyQualifiedTargetRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetArchitecture");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasTargetArchitecture, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetArchitecture.HasTargetArchitecture, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionFramework");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasExecutionRuntime, out ex);
            TestX.If.Value.IsTrue(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFramework.HasExecutionRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionFrameworkIdentifier");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasExecutionFrameworkIdentifier, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFrameworkIdentifier.HasExecutionFrameworkIdentifier, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionFrameworkVersion");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasExecutionFrameworkVersion, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFrameworkVersion.HasExecutionFrameworkVersion, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasFullyQualifiedExecutionRuntime");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasFullyQualifiedExecutionRuntime, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFramework.HasFullyQualifiedExecutionRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionArchitecture");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasExecutionArchitecture, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionArchitecture.HasExecutionArchitecture, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasFileName");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasFileName, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasFileName.HasFileName, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasMethodName");
            TestX.IfNot.Action.ThrowsException(() => result = ResultKey.Empty.HasMethodName, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasMethodName.HasMethodName, out ex);
            TestX.If.Value.IsTrue(result);

        }

        [TestMethod]
        [TestData(nameof(IsFullyQualifiedData))]
        void IsFullyQualified(IResultKey key, Boolean expected) {

            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = key.IsFullyQualified, out Exception ex);
            TestX.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsFullyQualifiedData() {
            return new List<Object[]>() {
                new Object[] { _isFullyQualified, true },
                new Object[] { _hasAssemblyName, false },
                new Object[] { _hasTargetFramework, false },
                new Object[] { _hasTargetFrameworkIdentifier, false },
                new Object[] { _hasTargetFrameworkVersion, false },
                new Object[] { _hasTargetArchitecture, false },
                new Object[] { _hasExecutionFramework, false },
                new Object[] { _hasExecutionFrameworkIdentifier, false },
                new Object[] { _hasExecutionFrameworkVersion, false },
                new Object[] { _hasExecutionArchitecture, false },
                new Object[] { _hasFileName, false },
                new Object[] { _hasMethodName, false },
            };
        }

        [TestMethod]
        [TestData(nameof(PrecisionData))]
        void Precision(IResultKey input, TestResultKeyPrecisions expected) {

            TestResultKeyPrecisions precision = TestResultKeyPrecisions.None;

            TestX.IfNot.Action.ThrowsException(() => precision = input.Precision, out Exception ex);
            TestX.If.Value.IsEqual(precision, expected);

        }

        IEnumerable<Object[]> PrecisionData() {
            return new List<Object[]>() {
                new Object[] { ResultKey.Empty, TestResultKeyPrecisions.None },
                new Object[] { _hasAssemblyName, TestResultKeyPrecisions.AssemblyName },
                new Object[] { _hasTargetFramework, TestResultKeyPrecisions.None },
                new Object[] { _hasTargetFrameworkIdentifier, TestResultKeyPrecisions.None },
                new Object[] { _hasTargetFrameworkVersion, TestResultKeyPrecisions.None },
                new Object[] { _hasTargetArchitecture, TestResultKeyPrecisions.None },
                new Object[] { _hasExecutionFramework, TestResultKeyPrecisions.None },
                new Object[] { _hasExecutionFrameworkIdentifier, TestResultKeyPrecisions.None },
                new Object[] { _hasExecutionFrameworkVersion, TestResultKeyPrecisions.None },
                new Object[] { _hasExecutionArchitecture, TestResultKeyPrecisions.None },
                new Object[] { _hasFileName, TestResultKeyPrecisions.None },
                new Object[] { _hasMethodName, TestResultKeyPrecisions.None },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.MethodName },

                new Object[] { _matchTargetFrameworkIdentifier, TestResultKeyPrecisions.TargetFrameworkIdentifier },
                new Object[] { _matchTargetFrameworkVersion, TestResultKeyPrecisions.TargetFrameworkVersion },
                new Object[] { _matchTargetArchitecture, TestResultKeyPrecisions.TargetArchitecture },
                new Object[] { _matchExecutionFrameworkIdentifier, TestResultKeyPrecisions.ExecutionFrameworkIdentifier },
                new Object[] { _matchExecutionFrameworkVersion, TestResultKeyPrecisions.ExecutionFrameworkVersion },
                new Object[] { _matchExecutionArchitecture, TestResultKeyPrecisions.ExecutionArchitecture },
                new Object[] { _matchFileName, TestResultKeyPrecisions.FileName },
                new Object[] { _matchMethodName, TestResultKeyPrecisions.MethodName },
            };
        }

        #endregion

        #region Matches

        [TestMethod]
        [TestData(nameof(MatchesData))]
        void Matches(IResultKey key, IResultKey match, Boolean expected) {

            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = key.Matches(match), out Exception ex);
            TestX.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> MatchesData() {
            return new List<Object[]>() {
                new Object[] { ResultKey.Empty, null, false },
                new Object[] { _isFullyQualified, null, false },

                new Object[] { ResultKey.Empty, ResultKey.Empty, true },
                new Object[] { ResultKey.Empty, _matchAssemblyName, false },
                new Object[] { ResultKey.Empty, _matchTargetFrameworkIdentifier, false },
                new Object[] { ResultKey.Empty, _matchTargetFrameworkVersion, false },
                new Object[] { ResultKey.Empty, _matchTargetArchitecture, false },
                new Object[] { ResultKey.Empty, _matchExecutionFrameworkIdentifier, false },
                new Object[] { ResultKey.Empty, _matchExecutionFrameworkVersion, false },
                new Object[] { ResultKey.Empty, _matchExecutionArchitecture, false },
                new Object[] { ResultKey.Empty, _matchFileName, false },
                new Object[] { ResultKey.Empty, _matchMethodName, false },

                new Object[] { _matchAssemblyName, ResultKey.Empty, true },
                new Object[] { _matchTargetFrameworkIdentifier, ResultKey.Empty, true },
                new Object[] { _matchTargetFrameworkVersion, ResultKey.Empty, true },
                new Object[] { _matchTargetArchitecture, ResultKey.Empty, true },
                new Object[] { _matchExecutionFrameworkIdentifier, ResultKey.Empty, true },
                new Object[] { _matchExecutionFrameworkVersion, ResultKey.Empty, true },
                new Object[] { _matchExecutionArchitecture, ResultKey.Empty, true },
                new Object[] { _matchFileName, ResultKey.Empty, true },
                new Object[] { _matchMethodName, ResultKey.Empty, true },

                new Object[] { _matchAssemblyName, _matchAssemblyName, true },
                new Object[] { _matchTargetFrameworkIdentifier, _matchTargetFrameworkIdentifier, true },
                new Object[] { _matchTargetFrameworkVersion, _matchTargetFrameworkVersion, true },
                new Object[] { _matchTargetArchitecture, _matchTargetArchitecture, true },
                new Object[] { _matchExecutionFrameworkIdentifier, _matchExecutionFrameworkIdentifier, true },
                new Object[] { _matchExecutionFrameworkVersion, _matchExecutionFrameworkVersion, true },
                new Object[] { _matchExecutionArchitecture, _matchExecutionArchitecture, true },
                new Object[] { _matchFileName, _matchFileName, true },
                new Object[] { _matchMethodName, _matchMethodName, true },

                new Object[] { _matchTargetFrameworkIdentifier, _matchAssemblyName, true },
                new Object[] { _matchTargetFrameworkVersion, _matchTargetFrameworkIdentifier, true },
                new Object[] { _matchTargetArchitecture, _matchTargetFrameworkVersion, true },
                new Object[] { _matchExecutionFrameworkIdentifier, _matchTargetArchitecture, true },
                new Object[] { _matchExecutionFrameworkVersion, _matchExecutionFrameworkIdentifier, true },
                new Object[] { _matchExecutionArchitecture, _matchExecutionFrameworkVersion, true },
                new Object[] { _matchFileName, _matchExecutionArchitecture, true },
                new Object[] { _matchMethodName, _matchFileName, true },

                new Object[] { _matchAssemblyName, _matchTargetFrameworkIdentifier, false },
                new Object[] { _matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion, false },
                new Object[] { _matchTargetFrameworkVersion, _matchTargetArchitecture, false },
                new Object[] { _matchTargetArchitecture, _matchExecutionFrameworkIdentifier, false },
                new Object[] { _matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion, false },
                new Object[] { _matchExecutionFrameworkVersion, _matchExecutionArchitecture, false },
                new Object[] { _matchExecutionArchitecture, _matchFileName, false },
                new Object[] { _matchFileName, _matchMethodName, false },
            };
        }

        #endregion

        #region Clip

        [TestMethod]
        [TestData(nameof(ClipData))]
        void Clip(IResultKey key, TestResultKeyPrecisions precision, IResultKey expected) {

            IResultKey result = null;

            TestX.IfNot.Action.ThrowsException(() => result = key.Clip(precision), out Exception ex);
            TestX.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> ClipData() {
            return new List<Object[]>() {
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.None, ResultKey.Empty },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.AssemblyName, _matchAssemblyName },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.TargetFrameworkIdentifier, _matchTargetFrameworkIdentifier },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.TargetFrameworkVersion, _matchTargetFrameworkVersion },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.TargetArchitecture, _matchTargetArchitecture },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.ExecutionFrameworkIdentifier, _matchExecutionFrameworkIdentifier },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.ExecutionFrameworkVersion, _matchExecutionFrameworkVersion },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.ExecutionArchitecture, _matchExecutionArchitecture },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.FileName, _matchFileName },
                new Object[] { _isFullyQualified, TestResultKeyPrecisions.MethodName, _matchMethodName },
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
                new Object[] { ResultKey.Empty, null, false },

                new Object[] { ResultKey.Empty, ResultKey.Empty, true },
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

                new Object[] { ResultKey.Empty, _matchAssemblyName, false },
                new Object[] { ResultKey.Empty, _matchTargetFrameworkIdentifier, false },
                new Object[] { ResultKey.Empty, _matchTargetFrameworkVersion, false },
                new Object[] { ResultKey.Empty, _matchTargetArchitecture, false },
                new Object[] { ResultKey.Empty, _matchExecutionFrameworkIdentifier, false },
                new Object[] { ResultKey.Empty, _matchExecutionFrameworkVersion, false },
                new Object[] { ResultKey.Empty, _matchExecutionArchitecture, false },
                new Object[] { ResultKey.Empty, _matchFileName, false },
                new Object[] { ResultKey.Empty, _matchMethodName, false },

                new Object[] { _matchAssemblyName, ResultKey.Empty, false },
                new Object[] { _matchTargetFrameworkIdentifier, ResultKey.Empty, false },
                new Object[] { _matchTargetFrameworkVersion, ResultKey.Empty, false },
                new Object[] { _matchTargetArchitecture, ResultKey.Empty, false },
                new Object[] { _matchExecutionFrameworkIdentifier, ResultKey.Empty, false },
                new Object[] { _matchExecutionFrameworkVersion, ResultKey.Empty, false },
                new Object[] { _matchExecutionArchitecture, ResultKey.Empty, false },
                new Object[] { _matchFileName, ResultKey.Empty, false },
                new Object[] { _matchMethodName, ResultKey.Empty, false },
            };
        }

        [TestMethod]
        void EqualsPrecision() {

            DDTEqualsPrecision(ResultKey.Empty, null, TestResultKeyPrecisions.None, false);

            DDTEqualsPrecision(ResultKey.Empty, ResultKey.Empty, TestResultKeyPrecisions.None, true);
            DDTEqualsPrecision(ResultKey.Empty, ResultKey.Empty, TestResultKeyPrecisions.AssemblyName, true);

        }


        [TestMethod]
        [TestData(nameof(EqualsPrecisionLMHData))]
        void EqualsPrecisionLMH((IResultKey low, IResultKey high) keys, (TestResultKeyPrecisions low, TestResultKeyPrecisions med, TestResultKeyPrecisions high) precision) {

            DDTEqualsPrecision(keys.low, keys.high, precision.low, true);
            DDTEqualsPrecision(keys.low, keys.high, precision.med, false);
            DDTEqualsPrecision(keys.low, keys.high, precision.high, false);
            DDTEqualsPrecision(keys.high, keys.high, precision.low, true);
            DDTEqualsPrecision(keys.high, keys.high, precision.med, true);
            DDTEqualsPrecision(keys.high, keys.high, precision.high, true);
            DDTEqualsPrecision(keys.high, keys.low, precision.low, true);
            DDTEqualsPrecision(keys.high, keys.low, precision.med, false);
            DDTEqualsPrecision(keys.high, keys.low, precision.high, false);

        }

        IEnumerable<Object[]> EqualsPrecisionLMHData() {
            return new List<Object[]>() {
                new Object[] { (ResultKey.Empty, _matchAssemblyName), (TestResultKeyPrecisions.None, TestResultKeyPrecisions.AssemblyName, TestResultKeyPrecisions.TargetFrameworkIdentifier) },
                new Object[] { (_matchAssemblyName, _matchTargetFrameworkIdentifier), (TestResultKeyPrecisions.AssemblyName, TestResultKeyPrecisions.TargetFrameworkIdentifier, TestResultKeyPrecisions.TargetFrameworkVersion) },
                new Object[] { (_matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion), (TestResultKeyPrecisions.TargetFrameworkIdentifier, TestResultKeyPrecisions.TargetFrameworkVersion, TestResultKeyPrecisions.TargetArchitecture) },
                new Object[] { (_matchTargetFrameworkVersion, _matchTargetArchitecture), (TestResultKeyPrecisions.TargetFrameworkVersion, TestResultKeyPrecisions.TargetArchitecture, TestResultKeyPrecisions.ExecutionFrameworkIdentifier) },
                new Object[] { (_matchTargetArchitecture, _matchExecutionFrameworkIdentifier), (TestResultKeyPrecisions.TargetArchitecture, TestResultKeyPrecisions.ExecutionFrameworkIdentifier, TestResultKeyPrecisions.ExecutionFrameworkVersion) },
                new Object[] { (_matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion), (TestResultKeyPrecisions.ExecutionFrameworkIdentifier, TestResultKeyPrecisions.ExecutionFrameworkVersion, TestResultKeyPrecisions.ExecutionArchitecture) },
                new Object[] { (_matchExecutionFrameworkVersion, _matchExecutionArchitecture), (TestResultKeyPrecisions.ExecutionFrameworkVersion, TestResultKeyPrecisions.ExecutionArchitecture, TestResultKeyPrecisions.FileName) },
                new Object[] { (_matchExecutionArchitecture, _matchFileName), (TestResultKeyPrecisions.ExecutionArchitecture, TestResultKeyPrecisions.FileName, TestResultKeyPrecisions.MethodName) },
            };
        }

        [TestMethod]
        [TestData(nameof(EqualsPrecisionLMData))]
        void EqualsPrecisionLM((IResultKey low, IResultKey high) keys, (TestResultKeyPrecisions low, TestResultKeyPrecisions med) precision) {

            DDTEqualsPrecision(keys.low, keys.high, precision.low, true);
            DDTEqualsPrecision(keys.low, keys.high, precision.med, false);
            DDTEqualsPrecision(keys.high, keys.high, precision.low, true);
            DDTEqualsPrecision(keys.high, keys.high, precision.med, true);
            DDTEqualsPrecision(keys.high, keys.low, precision.low, true);
            DDTEqualsPrecision(keys.high, keys.low, precision.med, false);

        }

        IEnumerable<Object[]> EqualsPrecisionLMData() {
            return new List<Object[]>() {
                new Object[] { (_matchFileName, _matchMethodName), (TestResultKeyPrecisions.FileName, TestResultKeyPrecisions.MethodName) },
            };
        }

        void DDTEqualsPrecision(IResultKey key, IResultKey other, TestResultKeyPrecisions precision, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            TestX.Note($"{key}.Equals({other}, {precision.Format()}) => {expected.Format()}",
                _file, _method);

            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = key.Equals(other, precision), out Exception ex, null, _file, _method);
            TestX.If.Value.IsEqual(result, expected, null, _file, _method);

        }

        #endregion

    }
}
