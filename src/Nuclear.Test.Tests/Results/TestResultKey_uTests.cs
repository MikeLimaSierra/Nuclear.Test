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

        private static readonly ITestResultKey _isFullyQualified =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
                 new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", "MethodA");

        #endregion

        #region hasValue statics

        private static readonly ITestResultKey _hasAssemblyName =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _hasTargetFramework =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _hasTargetFrameworkIdentifier =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _hasTargetFrameworkVersion =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _hasTargetArchitecture =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _hasExecutionFramework =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, null, null);

        private static readonly ITestResultKey _hasExecutionFrameworkIdentifier =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _hasExecutionFrameworkVersion =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _hasExecutionArchitecture =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.X86, null, null);

        private static readonly ITestResultKey _hasFileName =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, "FileA", null);

        private static readonly ITestResultKey _hasMethodName =
            new TestResultKey(null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
          new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, "MethodA");

        #endregion

        #region matchValue statics

        private static readonly ITestResultKey _matchAssemblyName =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
              new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _matchTargetFrameworkIdentifier =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version()), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _matchTargetFrameworkVersion =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.None,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _matchTargetArchitecture =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _matchExecutionFrameworkIdentifier =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
            new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version()), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _matchExecutionFrameworkVersion =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.None, null, null);

        private static readonly ITestResultKey _matchExecutionArchitecture =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, null, null);

        private static readonly ITestResultKey _matchFileName =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
          new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", null);

        private static readonly ITestResultKey _matchMethodName =
            new TestResultKey("asm", new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), ProcessorArchitecture.X86,
           new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), ProcessorArchitecture.X86, "FileA", "MethodA");

        #endregion

        [TestMethod]
        void TestImplementation() {

            TestX.If.Type.Implements<ITestResultKey, IEquatable<ITestResultKey>>();
            TestX.If.Type.Implements<ITestResultKey, IComparable<ITestResultKey>>();
            TestX.If.Type.Implements<TestResultKey, ITestResultKey>();

        }

        #region ctors

        [TestMethod]
        [TestData(nameof(DefaultCtorData))]
        void DefaultCtor((String assemblyName, RuntimeInfo target, ProcessorArchitecture targetArchitecture, RuntimeInfo execution, ProcessorArchitecture executionArchitecture, String file, String method) input,
            (String assemblyName, RuntimeInfo target, ProcessorArchitecture targetArchitecture, RuntimeInfo execution, ProcessorArchitecture executionArchitecture, String file, String method) expected) {

            ITestResultKey scenario = null;
            Action action = () => scenario = new TestResultKey(input.assemblyName,
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

            ITestResultKey scenario = null;

            TestX.IfNot.Action.ThrowsException(() => scenario = new TestResultKey(input.scenario, input.file, input.method), out Exception ex);
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

            ITestResultKey key = null;

            TestX.IfNot.Action.ThrowsException(() => key = TestResultKey.Empty, out Exception ex);
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
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasAssemblyName, out Exception ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasAssemblyName.HasAssemblyName, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetFramework");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasTargetRuntime, out ex);
            TestX.If.Value.IsTrue(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFramework.HasTargetRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetFrameworkIdentifier");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasTargetFrameworkIdentifier, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFrameworkIdentifier.HasTargetFrameworkIdentifier, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetFrameworkVersion");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasTargetFrameworkVersion, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFrameworkVersion.HasTargetFrameworkVersion, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasFullyQualifiedTargetRuntime");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasFullyQualifiedTargetRuntime, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFramework.HasFullyQualifiedTargetRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasTargetArchitecture");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasTargetArchitecture, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetArchitecture.HasTargetArchitecture, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionFramework");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasExecutionRuntime, out ex);
            TestX.If.Value.IsTrue(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFramework.HasExecutionRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionFrameworkIdentifier");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasExecutionFrameworkIdentifier, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFrameworkIdentifier.HasExecutionFrameworkIdentifier, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionFrameworkVersion");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasExecutionFrameworkVersion, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFrameworkVersion.HasExecutionFrameworkVersion, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasFullyQualifiedExecutionRuntime");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasFullyQualifiedExecutionRuntime, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFramework.HasFullyQualifiedExecutionRuntime, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasExecutionArchitecture");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasExecutionArchitecture, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionArchitecture.HasExecutionArchitecture, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasFileName");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasFileName, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasFileName.HasFileName, out ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasMethodName");
            TestX.IfNot.Action.ThrowsException(() => result = TestResultKey.Empty.HasMethodName, out ex);
            TestX.If.Value.IsFalse(result);
            TestX.IfNot.Action.ThrowsException(() => result = _hasMethodName.HasMethodName, out ex);
            TestX.If.Value.IsTrue(result);

        }

        [TestMethod]
        void IsFullyQualified() {

            Boolean result = false;

            TestX.Note("IsFullyQualified");
            TestX.IfNot.Action.ThrowsException(() => result = _isFullyQualified.IsFullyQualified, out Exception ex);
            TestX.If.Value.IsTrue(result);

            TestX.Note("HasAssemblyName");
            TestX.IfNot.Action.ThrowsException(() => result = _hasAssemblyName.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasTargetFramework");
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFramework.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasTargetFrameworkIdentifier");
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFrameworkIdentifier.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasTargetFrameworkVersion");
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetFrameworkVersion.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasTargetArchitecture");
            TestX.IfNot.Action.ThrowsException(() => result = _hasTargetArchitecture.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasExecutionFramework");
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFramework.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasExecutionFrameworkIdentifier");
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFrameworkIdentifier.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasExecutionFrameworkVersion");
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionFrameworkVersion.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasExecutionArchitecture");
            TestX.IfNot.Action.ThrowsException(() => result = _hasExecutionArchitecture.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasFileName");
            TestX.IfNot.Action.ThrowsException(() => result = _hasFileName.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

            TestX.Note("HasMethodName");
            TestX.IfNot.Action.ThrowsException(() => result = _hasMethodName.IsFullyQualified, out ex);
            TestX.If.Value.IsFalse(result);

        }

        [TestMethod]
        void Precision() {

            DDTPrecision(TestResultKey.Empty, TestResultKeyPrecisions.None);
            DDTPrecision(_hasAssemblyName, TestResultKeyPrecisions.AssemblyName);
            DDTPrecision(_hasTargetFramework, TestResultKeyPrecisions.None);
            DDTPrecision(_hasTargetFrameworkIdentifier, TestResultKeyPrecisions.None);
            DDTPrecision(_hasTargetFrameworkVersion, TestResultKeyPrecisions.None);
            DDTPrecision(_hasTargetArchitecture, TestResultKeyPrecisions.None);
            DDTPrecision(_hasExecutionFramework, TestResultKeyPrecisions.None);
            DDTPrecision(_hasExecutionFrameworkIdentifier, TestResultKeyPrecisions.None);
            DDTPrecision(_hasExecutionFrameworkVersion, TestResultKeyPrecisions.None);
            DDTPrecision(_hasExecutionArchitecture, TestResultKeyPrecisions.None);
            DDTPrecision(_hasFileName, TestResultKeyPrecisions.None);
            DDTPrecision(_hasMethodName, TestResultKeyPrecisions.None);
            DDTPrecision(_isFullyQualified, TestResultKeyPrecisions.MethodName);

            DDTPrecision(_matchTargetFrameworkIdentifier, TestResultKeyPrecisions.TargetFrameworkIdentifier);
            DDTPrecision(_matchTargetFrameworkVersion, TestResultKeyPrecisions.TargetFrameworkVersion);
            DDTPrecision(_matchTargetArchitecture, TestResultKeyPrecisions.TargetArchitecture);
            DDTPrecision(_matchExecutionFrameworkIdentifier, TestResultKeyPrecisions.ExecutionFrameworkIdentifier);
            DDTPrecision(_matchExecutionFrameworkVersion, TestResultKeyPrecisions.ExecutionFrameworkVersion);
            DDTPrecision(_matchExecutionArchitecture, TestResultKeyPrecisions.ExecutionArchitecture);
            DDTPrecision(_matchFileName, TestResultKeyPrecisions.FileName);
            DDTPrecision(_matchMethodName, TestResultKeyPrecisions.MethodName);

        }

        void DDTPrecision(ITestResultKey input, TestResultKeyPrecisions expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            TestX.Note($"{input} => {expected.Format()}",
                _file, _method);

            TestResultKeyPrecisions precision = TestResultKeyPrecisions.None;

            TestX.IfNot.Action.ThrowsException(() => precision = input.Precision, out Exception ex, _file, _method);
            TestX.If.Value.IsEqual(precision, expected, _file, _method);

        }

        #endregion

        #region Matches

        [TestMethod]
        void Matches() {

            DDTMatches(TestResultKey.Empty, null, false);
            DDTMatches(_isFullyQualified, null, false);

            DDTMatches(TestResultKey.Empty, TestResultKey.Empty, true);
            DDTMatches(TestResultKey.Empty, _matchAssemblyName, false);
            DDTMatches(TestResultKey.Empty, _matchTargetFrameworkIdentifier, false);
            DDTMatches(TestResultKey.Empty, _matchTargetFrameworkVersion, false);
            DDTMatches(TestResultKey.Empty, _matchTargetArchitecture, false);
            DDTMatches(TestResultKey.Empty, _matchExecutionFrameworkIdentifier, false);
            DDTMatches(TestResultKey.Empty, _matchExecutionFrameworkVersion, false);
            DDTMatches(TestResultKey.Empty, _matchExecutionArchitecture, false);
            DDTMatches(TestResultKey.Empty, _matchFileName, false);
            DDTMatches(TestResultKey.Empty, _matchMethodName, false);

            DDTMatches(_matchAssemblyName, TestResultKey.Empty, true);
            DDTMatches(_matchTargetFrameworkIdentifier, TestResultKey.Empty, true);
            DDTMatches(_matchTargetFrameworkVersion, TestResultKey.Empty, true);
            DDTMatches(_matchTargetArchitecture, TestResultKey.Empty, true);
            DDTMatches(_matchExecutionFrameworkIdentifier, TestResultKey.Empty, true);
            DDTMatches(_matchExecutionFrameworkVersion, TestResultKey.Empty, true);
            DDTMatches(_matchExecutionArchitecture, TestResultKey.Empty, true);
            DDTMatches(_matchFileName, TestResultKey.Empty, true);
            DDTMatches(_matchMethodName, TestResultKey.Empty, true);

            DDTMatches(_matchAssemblyName, _matchAssemblyName, true);
            DDTMatches(_matchTargetFrameworkIdentifier, _matchTargetFrameworkIdentifier, true);
            DDTMatches(_matchTargetFrameworkVersion, _matchTargetFrameworkVersion, true);
            DDTMatches(_matchTargetArchitecture, _matchTargetArchitecture, true);
            DDTMatches(_matchExecutionFrameworkIdentifier, _matchExecutionFrameworkIdentifier, true);
            DDTMatches(_matchExecutionFrameworkVersion, _matchExecutionFrameworkVersion, true);
            DDTMatches(_matchExecutionArchitecture, _matchExecutionArchitecture, true);
            DDTMatches(_matchFileName, _matchFileName, true);
            DDTMatches(_matchMethodName, _matchMethodName, true);

            DDTMatches(_matchTargetFrameworkIdentifier, _matchAssemblyName, true);
            DDTMatches(_matchTargetFrameworkVersion, _matchTargetFrameworkIdentifier, true);
            DDTMatches(_matchTargetArchitecture, _matchTargetFrameworkVersion, true);
            DDTMatches(_matchExecutionFrameworkIdentifier, _matchTargetArchitecture, true);
            DDTMatches(_matchExecutionFrameworkVersion, _matchExecutionFrameworkIdentifier, true);
            DDTMatches(_matchExecutionArchitecture, _matchExecutionFrameworkVersion, true);
            DDTMatches(_matchFileName, _matchExecutionArchitecture, true);
            DDTMatches(_matchMethodName, _matchFileName, true);

            DDTMatches(_matchAssemblyName, _matchTargetFrameworkIdentifier, false);
            DDTMatches(_matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion, false);
            DDTMatches(_matchTargetFrameworkVersion, _matchTargetArchitecture, false);
            DDTMatches(_matchTargetArchitecture, _matchExecutionFrameworkIdentifier, false);
            DDTMatches(_matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion, false);
            DDTMatches(_matchExecutionFrameworkVersion, _matchExecutionArchitecture, false);
            DDTMatches(_matchExecutionArchitecture, _matchFileName, false);
            DDTMatches(_matchFileName, _matchMethodName, false);

        }

        void DDTMatches(ITestResultKey key, ITestResultKey match, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            TestX.Note($"{key}.Matches({match}) => {expected.Format()}",
                _file, _method);

            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = key.Matches(match), out Exception ex, _file, _method);
            TestX.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region Clip

        [TestMethod]
        void Clip() {

            DDTClip(_isFullyQualified, TestResultKeyPrecisions.None, TestResultKey.Empty);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.AssemblyName, _matchAssemblyName);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.TargetFrameworkIdentifier, _matchTargetFrameworkIdentifier);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.TargetFrameworkVersion, _matchTargetFrameworkVersion);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.TargetArchitecture, _matchTargetArchitecture);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.ExecutionFrameworkIdentifier, _matchExecutionFrameworkIdentifier);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.ExecutionFrameworkVersion, _matchExecutionFrameworkVersion);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.ExecutionArchitecture, _matchExecutionArchitecture);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.FileName, _matchFileName);
            DDTClip(_isFullyQualified, TestResultKeyPrecisions.MethodName, _matchMethodName);

        }

        void DDTClip(ITestResultKey key, TestResultKeyPrecisions precision, ITestResultKey expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            TestX.Note($"{key}.Clip({precision.Format()}) => {expected}",
                _file, _method);

            ITestResultKey result = null;

            TestX.IfNot.Action.ThrowsException(() => result = key.Clip(precision), out Exception ex, _file, _method);
            TestX.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region Equals

        [TestMethod]
        void Equals() {

            DDTEquals(TestResultKey.Empty, null, false);

            DDTEquals(TestResultKey.Empty, TestResultKey.Empty, true);
            DDTEquals(_matchAssemblyName, _matchAssemblyName, true);
            DDTEquals(_matchTargetFrameworkIdentifier, _matchTargetFrameworkIdentifier, true);
            DDTEquals(_matchTargetFrameworkVersion, _matchTargetFrameworkVersion, true);
            DDTEquals(_matchTargetArchitecture, _matchTargetArchitecture, true);
            DDTEquals(_matchExecutionFrameworkIdentifier, _matchExecutionFrameworkIdentifier, true);
            DDTEquals(_matchExecutionFrameworkVersion, _matchExecutionFrameworkVersion, true);
            DDTEquals(_matchExecutionArchitecture, _matchExecutionArchitecture, true);
            DDTEquals(_matchFileName, _matchFileName, true);
            DDTEquals(_matchMethodName, _matchMethodName, true);

            DDTEquals(_matchAssemblyName, _matchTargetFrameworkIdentifier, false);
            DDTEquals(_matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion, false);
            DDTEquals(_matchTargetFrameworkVersion, _matchTargetArchitecture, false);
            DDTEquals(_matchTargetArchitecture, _matchExecutionFrameworkIdentifier, false);
            DDTEquals(_matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion, false);
            DDTEquals(_matchExecutionFrameworkVersion, _matchExecutionArchitecture, false);
            DDTEquals(_matchExecutionArchitecture, _matchFileName, false);
            DDTEquals(_matchFileName, _matchMethodName, false);

            DDTEquals(_matchTargetFrameworkIdentifier, _matchAssemblyName, false);
            DDTEquals(_matchTargetFrameworkVersion, _matchTargetFrameworkIdentifier, false);
            DDTEquals(_matchTargetArchitecture, _matchTargetFrameworkVersion, false);
            DDTEquals(_matchExecutionFrameworkIdentifier, _matchTargetArchitecture, false);
            DDTEquals(_matchExecutionFrameworkVersion, _matchExecutionFrameworkIdentifier, false);
            DDTEquals(_matchExecutionArchitecture, _matchExecutionFrameworkVersion, false);
            DDTEquals(_matchFileName, _matchExecutionArchitecture, false);
            DDTEquals(_matchMethodName, _matchFileName, false);

            DDTEquals(TestResultKey.Empty, _matchAssemblyName, false);
            DDTEquals(TestResultKey.Empty, _matchTargetFrameworkIdentifier, false);
            DDTEquals(TestResultKey.Empty, _matchTargetFrameworkVersion, false);
            DDTEquals(TestResultKey.Empty, _matchTargetArchitecture, false);
            DDTEquals(TestResultKey.Empty, _matchExecutionFrameworkIdentifier, false);
            DDTEquals(TestResultKey.Empty, _matchExecutionFrameworkVersion, false);
            DDTEquals(TestResultKey.Empty, _matchExecutionArchitecture, false);
            DDTEquals(TestResultKey.Empty, _matchFileName, false);
            DDTEquals(TestResultKey.Empty, _matchMethodName, false);

            DDTEquals(_matchAssemblyName, TestResultKey.Empty, false);
            DDTEquals(_matchTargetFrameworkIdentifier, TestResultKey.Empty, false);
            DDTEquals(_matchTargetFrameworkVersion, TestResultKey.Empty, false);
            DDTEquals(_matchTargetArchitecture, TestResultKey.Empty, false);
            DDTEquals(_matchExecutionFrameworkIdentifier, TestResultKey.Empty, false);
            DDTEquals(_matchExecutionFrameworkVersion, TestResultKey.Empty, false);
            DDTEquals(_matchExecutionArchitecture, TestResultKey.Empty, false);
            DDTEquals(_matchFileName, TestResultKey.Empty, false);
            DDTEquals(_matchMethodName, TestResultKey.Empty, false);

        }

        void DDTEquals(ITestResultKey key, ITestResultKey other, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            TestX.Note($"{key}.Equals({other}) => {expected.Format()}",
                _file, _method);

            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = key.Equals(other), out Exception ex, _file, _method);
            TestX.If.Value.IsEqual(result, expected, _file, _method);

        }

        [TestMethod]
        void EqualsPrecision() {

            DDTEqualsPrecision(TestResultKey.Empty, null, TestResultKeyPrecisions.None, false);

            DDTEqualsPrecision(TestResultKey.Empty, TestResultKey.Empty, TestResultKeyPrecisions.None, true);
            DDTEqualsPrecision(TestResultKey.Empty, TestResultKey.Empty, TestResultKeyPrecisions.AssemblyName, true);

            DDTEqualsPrecisionProxy((TestResultKey.Empty, _matchAssemblyName),
                (TestResultKeyPrecisions.None, TestResultKeyPrecisions.AssemblyName, TestResultKeyPrecisions.TargetFrameworkIdentifier));

            DDTEqualsPrecisionProxy((_matchAssemblyName, _matchTargetFrameworkIdentifier),
                (TestResultKeyPrecisions.AssemblyName, TestResultKeyPrecisions.TargetFrameworkIdentifier, TestResultKeyPrecisions.TargetFrameworkVersion));

            DDTEqualsPrecisionProxy((_matchTargetFrameworkIdentifier, _matchTargetFrameworkVersion),
                (TestResultKeyPrecisions.TargetFrameworkIdentifier, TestResultKeyPrecisions.TargetFrameworkVersion, TestResultKeyPrecisions.TargetArchitecture));

            DDTEqualsPrecisionProxy((_matchTargetFrameworkVersion, _matchTargetArchitecture),
                (TestResultKeyPrecisions.TargetFrameworkVersion, TestResultKeyPrecisions.TargetArchitecture, TestResultKeyPrecisions.ExecutionFrameworkIdentifier));

            DDTEqualsPrecisionProxy((_matchTargetArchitecture, _matchExecutionFrameworkIdentifier),
                (TestResultKeyPrecisions.TargetArchitecture, TestResultKeyPrecisions.ExecutionFrameworkIdentifier, TestResultKeyPrecisions.ExecutionFrameworkVersion));

            DDTEqualsPrecisionProxy((_matchExecutionFrameworkIdentifier, _matchExecutionFrameworkVersion),
                (TestResultKeyPrecisions.ExecutionFrameworkIdentifier, TestResultKeyPrecisions.ExecutionFrameworkVersion, TestResultKeyPrecisions.ExecutionArchitecture));

            DDTEqualsPrecisionProxy((_matchExecutionFrameworkVersion, _matchExecutionArchitecture),
                (TestResultKeyPrecisions.ExecutionFrameworkVersion, TestResultKeyPrecisions.ExecutionArchitecture, TestResultKeyPrecisions.FileName));

            DDTEqualsPrecisionProxy((_matchExecutionArchitecture, _matchFileName),
                (TestResultKeyPrecisions.ExecutionArchitecture, TestResultKeyPrecisions.FileName, TestResultKeyPrecisions.MethodName));

            DDTEqualsPrecisionProxy((_matchFileName, _matchMethodName),
                (TestResultKeyPrecisions.FileName, TestResultKeyPrecisions.MethodName));

        }

        void DDTEqualsPrecisionProxy((ITestResultKey low, ITestResultKey high) keys, (TestResultKeyPrecisions low, TestResultKeyPrecisions med, TestResultKeyPrecisions high) precision,
        [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            DDTEqualsPrecision(keys.low, keys.high, precision.low, true, _file, _method);
            DDTEqualsPrecision(keys.low, keys.high, precision.med, false, _file, _method);
            DDTEqualsPrecision(keys.low, keys.high, precision.high, false, _file, _method);
            DDTEqualsPrecision(keys.high, keys.high, precision.low, true, _file, _method);
            DDTEqualsPrecision(keys.high, keys.high, precision.med, true, _file, _method);
            DDTEqualsPrecision(keys.high, keys.high, precision.high, true, _file, _method);
            DDTEqualsPrecision(keys.high, keys.low, precision.low, true, _file, _method);
            DDTEqualsPrecision(keys.high, keys.low, precision.med, false, _file, _method);
            DDTEqualsPrecision(keys.high, keys.low, precision.high, false, _file, _method);

        }

        void DDTEqualsPrecisionProxy((ITestResultKey low, ITestResultKey high) keys, (TestResultKeyPrecisions low, TestResultKeyPrecisions med) precision,
        [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            DDTEqualsPrecision(keys.low, keys.high, precision.low, true, _file, _method);
            DDTEqualsPrecision(keys.low, keys.high, precision.med, false, _file, _method);
            DDTEqualsPrecision(keys.high, keys.high, precision.low, true, _file, _method);
            DDTEqualsPrecision(keys.high, keys.high, precision.med, true, _file, _method);
            DDTEqualsPrecision(keys.high, keys.low, precision.low, true, _file, _method);
            DDTEqualsPrecision(keys.high, keys.low, precision.med, false, _file, _method);

        }

        void DDTEqualsPrecision(ITestResultKey key, ITestResultKey other, TestResultKeyPrecisions precision, Boolean expected,
        [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            TestX.Note($"{key}.Equals({other}, {precision.Format()}) => {expected.Format()}",
                _file, _method);

            Boolean result = false;

            TestX.IfNot.Action.ThrowsException(() => result = key.Equals(other, precision), out Exception ex, _file, _method);
            TestX.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

    }
}
