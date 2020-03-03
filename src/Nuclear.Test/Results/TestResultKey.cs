using System;
using System.Reflection;
using Nuclear.Extensions;

namespace Nuclear.Test.Results {
    internal class TestResultKey : ITestResultKey {

        #region statics

        internal static ITestResultKey Empty => new TestResultKey(null,
            FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
            FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
            null, null);

        #endregion

        #region properties

        public String AssemblyName { get; private set; }

        public FrameworkIdentifiers TargetFrameworkIdentifier { get; private set; }

        public Version TargetFrameworkVersion { get; private set; }

        public ProcessorArchitecture TargetArchitecture { get; private set; }

        public FrameworkIdentifiers ExecutionFrameworkIdentifier { get; private set; }

        public Version ExecutionFrameworkVersion { get; private set; }

        public ProcessorArchitecture ExecutionArchitecture { get; private set; }

        public String FileName { get; private set; }

        public String MethodName { get; private set; }


        public Boolean HasAssemblyName => !String.IsNullOrWhiteSpace(AssemblyName);

        public Boolean HasTargetFramework => HasTargetFrameworkIdentifier && HasTargetFrameworkVersion && HasTargetArchitecture;

        public Boolean HasTargetFrameworkIdentifier => TargetFrameworkIdentifier != FrameworkIdentifiers.Unknown;

        public Boolean HasTargetFrameworkVersion => TargetFrameworkVersion != null;

        public Boolean HasTargetArchitecture => TargetArchitecture != ProcessorArchitecture.None;

        public Boolean HasExecutionFramework => HasExecutionFrameworkIdentifier && HasExecutionFrameworkVersion && HasExecutionArchitecture;

        public Boolean HasExecutionFrameworkIdentifier => ExecutionFrameworkIdentifier != FrameworkIdentifiers.Unknown;

        public Boolean HasExecutionFrameworkVersion => ExecutionFrameworkVersion != null;

        public Boolean HasExecutionArchitecture => ExecutionArchitecture != ProcessorArchitecture.None;

        public Boolean HasFileName => !String.IsNullOrWhiteSpace(FileName);

        public Boolean HasMethodName => !String.IsNullOrWhiteSpace(MethodName);


        public Boolean IsFullyQualified => HasAssemblyName && HasTargetFramework && HasExecutionFramework && HasFileName && HasMethodName;

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
                  scenario.TargetFrameworkIdentifier,
                  scenario.TargetFrameworkVersion,
                  scenario.TargetArchitecture,
                  scenario.ExecutionFrameworkIdentifier,
                  scenario.ExecutionFrameworkVersion,
                  scenario.ExecutionArchitecture,
                  fileName,
                  methodName) { }

        internal TestResultKey(
            String assemblyName,
            FrameworkIdentifiers targetFrameworkIdentifier,
            Version targetFrameworkVersion,
            ProcessorArchitecture targetArchitecture,
            FrameworkIdentifiers executionFrameworkIdentifier,
            Version executionFrameworkVersion,
            ProcessorArchitecture executionArchitecture,
            String fileName,
            String methodName) {

            AssemblyName = assemblyName;
            TargetFrameworkIdentifier = targetFrameworkIdentifier;
            TargetFrameworkVersion = targetFrameworkVersion;
            TargetArchitecture = targetArchitecture;
            ExecutionFrameworkIdentifier = executionFrameworkIdentifier;
            ExecutionFrameworkVersion = executionFrameworkVersion;
            ExecutionArchitecture = executionArchitecture;
            FileName = fileName;
            MethodName = methodName;
        }

        #endregion

        #region methods

        public Boolean Matches(ITestResultKey match) {
            if(match == null) { return false; }

            if(match.HasAssemblyName && match.AssemblyName != AssemblyName) { return false; }
            if(match.HasTargetFrameworkIdentifier && match.TargetFrameworkIdentifier != TargetFrameworkIdentifier) { return false; }
            if(match.HasTargetFrameworkVersion && match.TargetFrameworkVersion != TargetFrameworkVersion) { return false; }
            if(match.HasTargetArchitecture && match.TargetArchitecture != TargetArchitecture) { return false; }
            if(match.HasExecutionFrameworkIdentifier && match.ExecutionFrameworkIdentifier != ExecutionFrameworkIdentifier) { return false; }
            if(match.HasExecutionFrameworkVersion && match.ExecutionFrameworkVersion != ExecutionFrameworkVersion) { return false; }
            if(match.HasExecutionArchitecture && match.ExecutionArchitecture != ExecutionArchitecture) { return false; }
            if(match.HasFileName && match.FileName != FileName) { return false; }
            if(match.HasMethodName && match.MethodName != MethodName) { return false; }

            return true;
        }

        public ITestResultKey Clip(TestResultKeyPrecisions precision) {
            switch(precision) {
                case TestResultKeyPrecisions.FileName:
                    return new TestResultKey(AssemblyName,
                        TargetFrameworkIdentifier, TargetFrameworkVersion, TargetArchitecture,
                        ExecutionFrameworkIdentifier, ExecutionFrameworkVersion, ExecutionArchitecture,
                        FileName, null);
                case TestResultKeyPrecisions.ExecutionArchitecture:
                    return new TestResultKey(AssemblyName,
                        TargetFrameworkIdentifier, TargetFrameworkVersion, TargetArchitecture,
                        ExecutionFrameworkIdentifier, ExecutionFrameworkVersion, ExecutionArchitecture,
                        null, null);
                case TestResultKeyPrecisions.ExecutionFrameworkVersion:
                    return new TestResultKey(AssemblyName,
                        TargetFrameworkIdentifier, TargetFrameworkVersion, TargetArchitecture,
                        ExecutionFrameworkIdentifier, ExecutionFrameworkVersion, ProcessorArchitecture.None,
                        null, null);
                case TestResultKeyPrecisions.ExecutionFrameworkIdentifier:
                    return new TestResultKey(AssemblyName,
                        TargetFrameworkIdentifier, TargetFrameworkVersion, TargetArchitecture,
                        ExecutionFrameworkIdentifier, null, ProcessorArchitecture.None,
                        null, null);
                case TestResultKeyPrecisions.TargetArchitecture:
                    return new TestResultKey(AssemblyName,
                        TargetFrameworkIdentifier, TargetFrameworkVersion, TargetArchitecture,
                        FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
                        null, null);
                case TestResultKeyPrecisions.TargetFrameworkVersion:
                    return new TestResultKey(AssemblyName,
                        TargetFrameworkIdentifier, TargetFrameworkVersion, ProcessorArchitecture.None,
                        FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
                        null, null);
                case TestResultKeyPrecisions.TargetFrameworkIdentifier:
                    return new TestResultKey(AssemblyName,
                        TargetFrameworkIdentifier, null, ProcessorArchitecture.None,
                        FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
                        null, null);
                case TestResultKeyPrecisions.AssemblyName:
                    return new TestResultKey(AssemblyName,
                        FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
                        FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
                        null, null);
                case TestResultKeyPrecisions.None:
                    return new TestResultKey(null,
                        FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
                        FrameworkIdentifiers.Unknown, null, ProcessorArchitecture.None,
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

                result = TargetFrameworkIdentifier.CompareTo(other.TargetFrameworkIdentifier);
                if(result != 0) { return result; }

                result = TargetFrameworkVersion.CompareTo(other.TargetFrameworkVersion);
                if(result != 0) { return result; }

                result = TargetArchitecture.CompareTo(other.TargetArchitecture);
                if(result != 0) { return result; }

                result = ExecutionFrameworkIdentifier.CompareTo(other.ExecutionFrameworkIdentifier);
                if(result != 0) { return result; }

                result = ExecutionFrameworkVersion.CompareTo(other.ExecutionFrameworkVersion);
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
            hashCode -= TargetFrameworkIdentifier.GetHashCode();
            hashCode += TargetFrameworkVersion != null ? TargetFrameworkVersion.GetHashCode() : 0;
            hashCode -= TargetArchitecture.GetHashCode();
            hashCode += ExecutionFrameworkIdentifier.GetHashCode();
            hashCode -= ExecutionFrameworkVersion != null ? ExecutionFrameworkVersion.GetHashCode() : 0;
            hashCode += ExecutionArchitecture.GetHashCode();
            hashCode -= FileName != null ? FileName.GetHashCode() : 0;
            hashCode += MethodName != null ? MethodName.GetHashCode() : 0;

            return hashCode;
        }

        public override String ToString() =>
            $"[{AssemblyName.Format()};{TargetFrameworkIdentifier.Format()};{TargetFrameworkVersion.Format()};{TargetArchitecture.Format()};{ExecutionFrameworkIdentifier.Format()};{ExecutionFrameworkVersion.Format()};{ExecutionArchitecture.Format()};{FileName.Format()};{MethodName.Format()}]";

        #endregion

    }
}
