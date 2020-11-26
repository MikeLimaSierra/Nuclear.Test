using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;

namespace Nuclear.Test.Results {
    internal class TestResultKey : ITestResultKey {

        #region statics

        internal static ITestResultKey Empty => new TestResultKey(null,
            new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
            new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
            null, null);

        #endregion

        #region properties

        public String AssemblyName { get; private set; }

        public RuntimeInfo TargetRuntime { get; private set; }

        public ProcessorArchitecture TargetArchitecture { get; private set; }

        public RuntimeInfo ExecutionRuntime { get; private set; }

        public ProcessorArchitecture ExecutionArchitecture { get; private set; }

        public String FileName { get; private set; }

        public String MethodName { get; private set; }


        public Boolean HasAssemblyName => !String.IsNullOrWhiteSpace(AssemblyName);

        public Boolean HasTargetRuntime => TargetRuntime != null;

        public Boolean HasTargetFrameworkIdentifier => HasTargetRuntime && TargetRuntime.Framework != FrameworkIdentifiers.Unsupported;

        public Boolean HasTargetFrameworkVersion => HasTargetRuntime && TargetRuntime.Version != new Version();

        public Boolean HasFullyQualifiedTargetRuntime => HasTargetRuntime && HasTargetFrameworkIdentifier && HasTargetFrameworkVersion;

        public Boolean HasTargetArchitecture => TargetArchitecture != ProcessorArchitecture.None;

        public Boolean HasExecutionRuntime => ExecutionRuntime != null;

        public Boolean HasExecutionFrameworkIdentifier => HasExecutionRuntime && ExecutionRuntime.Framework != FrameworkIdentifiers.Unsupported;

        public Boolean HasExecutionFrameworkVersion => HasExecutionRuntime && ExecutionRuntime.Version != new Version();

        public Boolean HasFullyQualifiedExecutionRuntime => HasExecutionRuntime && HasExecutionFrameworkIdentifier && HasExecutionFrameworkVersion;

        public Boolean HasExecutionArchitecture => ExecutionArchitecture != ProcessorArchitecture.None;

        public Boolean HasFileName => !String.IsNullOrWhiteSpace(FileName);

        public Boolean HasMethodName => !String.IsNullOrWhiteSpace(MethodName);


        public Boolean IsFullyQualified => HasAssemblyName && HasFullyQualifiedTargetRuntime && HasTargetArchitecture && HasFullyQualifiedExecutionRuntime && HasExecutionArchitecture && HasFileName && HasMethodName;

        public TestResultKeyPrecisions Precision {
            get {
                if(!HasAssemblyName) { return TestResultKeyPrecisions.None; }
                if(!HasTargetFrameworkIdentifier) { return TestResultKeyPrecisions.AssemblyName; }
                if(!HasTargetFrameworkVersion) { return TestResultKeyPrecisions.TargetFrameworkIdentifier; }
                if(!HasTargetArchitecture) { return TestResultKeyPrecisions.TargetFrameworkVersion; }
                if(!HasExecutionFrameworkIdentifier) { return TestResultKeyPrecisions.TargetArchitecture; }
                if(!HasExecutionFrameworkVersion) { return TestResultKeyPrecisions.ExecutionFrameworkIdentifier; }
                if(!HasExecutionArchitecture) { return TestResultKeyPrecisions.ExecutionFrameworkVersion; }
                if(!HasFileName) { return TestResultKeyPrecisions.ExecutionArchitecture; }
                if(!HasMethodName) { return TestResultKeyPrecisions.FileName; }

                return TestResultKeyPrecisions.MethodName;
            }
        }

        #endregion

        #region ctors

        internal TestResultKey(ITestScenario scenario, MethodInfo methodInfo)
            : this(scenario, methodInfo.DeclaringType.Name, methodInfo.Name) { }

        internal TestResultKey(ITestScenario scenario, String fileName, String methodName)
            : this(scenario.AssemblyName,
                  scenario.TargetRuntime,
                  scenario.TargetArchitecture,
                  scenario.ExecutionRuntime,
                  scenario.ExecutionArchitecture,
                  fileName,
                  methodName) { }

        internal TestResultKey(
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture,
            String fileName,
            String methodName) {

            AssemblyName = assemblyName;
            TargetRuntime = targetRuntime;
            TargetArchitecture = targetArchitecture;
            ExecutionRuntime = executionRuntime;
            ExecutionArchitecture = executionArchitecture;
            FileName = fileName;
            MethodName = methodName;
        }

        #endregion

        #region methods

        public Boolean Matches(ITestResultKey match) {
            if(match == null) { return false; }

            if(match.HasAssemblyName && match.AssemblyName != AssemblyName) { return false; }

            if(match.HasTargetFrameworkIdentifier && match.TargetRuntime.Framework != TargetRuntime.Framework) { return false; }
            if(match.HasTargetFrameworkVersion && match.TargetRuntime.Version != TargetRuntime.Version) { return false; }

            if(match.HasTargetArchitecture && match.TargetArchitecture != TargetArchitecture) { return false; }

            if(match.HasExecutionFrameworkIdentifier && match.ExecutionRuntime.Framework != ExecutionRuntime.Framework) { return false; }
            if(match.HasExecutionFrameworkVersion && match.ExecutionRuntime.Version != ExecutionRuntime.Version) { return false; }

            if(match.HasExecutionArchitecture && match.ExecutionArchitecture != ExecutionArchitecture) { return false; }
            if(match.HasFileName && match.FileName != FileName) { return false; }
            if(match.HasMethodName && match.MethodName != MethodName) { return false; }

            return true;
        }

        public ITestResultKey Clip(TestResultKeyPrecisions precision) {
            switch(precision) {
                case TestResultKeyPrecisions.FileName:
                    return new TestResultKey(AssemblyName,
                        TargetRuntime, TargetArchitecture,
                        ExecutionRuntime, ExecutionArchitecture,
                        FileName, null);

                case TestResultKeyPrecisions.ExecutionArchitecture:
                    return new TestResultKey(AssemblyName,
                        TargetRuntime, TargetArchitecture,
                        ExecutionRuntime, ExecutionArchitecture,
                        null, null);

                case TestResultKeyPrecisions.ExecutionFrameworkVersion:
                    return new TestResultKey(AssemblyName,
                        TargetRuntime, TargetArchitecture,
                        ExecutionRuntime, ProcessorArchitecture.None,
                        null, null);

                case TestResultKeyPrecisions.ExecutionFrameworkIdentifier:
                    return new TestResultKey(AssemblyName,
                        TargetRuntime, TargetArchitecture,
                        new RuntimeInfo(ExecutionRuntime.Framework, new Version()), ProcessorArchitecture.None,
                        null, null);

                case TestResultKeyPrecisions.TargetArchitecture:
                    return new TestResultKey(AssemblyName,
                        TargetRuntime, TargetArchitecture,
                        new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                        null, null);

                case TestResultKeyPrecisions.TargetFrameworkVersion:
                    return new TestResultKey(AssemblyName,
                        TargetRuntime, ProcessorArchitecture.None,
                        new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                        null, null);

                case TestResultKeyPrecisions.TargetFrameworkIdentifier:
                    return new TestResultKey(AssemblyName,
                        new RuntimeInfo(TargetRuntime.Framework, new Version()), ProcessorArchitecture.None,
                        new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                        null, null);

                case TestResultKeyPrecisions.AssemblyName:
                    return new TestResultKey(AssemblyName,
                        new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                        new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                        null, null);

                case TestResultKeyPrecisions.None:
                    return new TestResultKey(null,
                        new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                        new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version()), ProcessorArchitecture.None,
                        null, null);

                default:
                    break;
            }

            return this;
        }

        public override Boolean Equals(Object obj) {
            if(obj != null && obj is ITestResultKey other) {
                return Equals(other);
            }

            return false;
        }

        public Boolean Equals(ITestResultKey other) {
            if(other == null || Precision != other.Precision) { return false; }

            return Equals(other, Precision);
        }

        public Boolean Equals(ITestResultKey other, TestResultKeyPrecisions precision) {
            if(other == null) { return false; }

            if(Precision != other.Precision && (Precision < precision || other.Precision < precision)) { return false; }

            return Matches(other.Clip(precision));
        }

        public Int32 CompareTo(ITestResultKey other) {
            if(!Equals(other)) {
                Int32 result = AssemblyName.CompareTo(other.AssemblyName);
                if(result != 0) { return result; }

                result = TargetRuntime.Framework.CompareTo(other.TargetRuntime.Framework);
                if(result != 0) { return result; }

                result = TargetRuntime.Version.CompareTo(other.TargetRuntime.Version);
                if(result != 0) { return result; }

                result = TargetArchitecture.CompareTo(other.TargetArchitecture);
                if(result != 0) { return result; }

                result = ExecutionRuntime.Framework.CompareTo(other.ExecutionRuntime.Framework);
                if(result != 0) { return result; }

                result = ExecutionRuntime.Version.CompareTo(other.ExecutionRuntime.Version);
                if(result != 0) { return result; }

                result = ExecutionArchitecture.CompareTo(other.ExecutionArchitecture);
                if(result != 0) { return result; }

                result = FileName.CompareTo(other.FileName);
                if(result != 0) { return result; }

                result = MethodName.CompareTo(other.MethodName);
                if(result != 0) { return result; }
            }

            return 0;
        }

        public override Int32 GetHashCode() {
            Int32 hashCode = 0;

            hashCode += AssemblyName != null ? AssemblyName.GetHashCode() : 0;
            hashCode -= HasTargetRuntime ? TargetRuntime.GetHashCode() : 0;
            hashCode += TargetArchitecture.GetHashCode();
            hashCode -= HasExecutionRuntime ? ExecutionRuntime.GetHashCode() : 0;
            hashCode += ExecutionArchitecture.GetHashCode();
            hashCode -= FileName != null ? FileName.GetHashCode() : 0;
            hashCode += MethodName != null ? MethodName.GetHashCode() : 0;

            return hashCode;
        }

        public override String ToString() =>
            $"[{AssemblyName.Format()};{TargetRuntime.Format()};{TargetArchitecture.Format()};{ExecutionRuntime.Format()};{ExecutionArchitecture.Format()};{FileName.Format()};{MethodName.Format()}]";

        #endregion

    }
}
