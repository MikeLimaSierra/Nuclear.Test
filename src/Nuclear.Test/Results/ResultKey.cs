using System;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;

namespace Nuclear.Test.Results {
    internal class ResultKey : IResultKey {

        #region properties

        public String AssemblyName { get; private set; }

        public RuntimeInfo TargetRuntime { get; private set; }

        public ProcessorArchitecture TargetArchitecture { get; private set; }

        public RuntimeInfo ExecutionRuntime { get; private set; }

        public ProcessorArchitecture ExecutionArchitecture { get; private set; }

        public String FileName { get; private set; }

        public String MethodName { get; private set; }

        #endregion

        #region ctors

        internal ResultKey(ITestScenario scenario, MethodInfo methodInfo)
            : this(scenario, methodInfo.DeclaringType.Name, methodInfo.Name) { }

        internal ResultKey(ITestScenario scenario, String fileName, String methodName) {
            AssemblyName = scenario.AssemblyName;
            TargetRuntime = scenario.TargetRuntime;
            TargetArchitecture = scenario.TargetArchitecture;
            ExecutionRuntime = scenario.ExecutionRuntime;
            ExecutionArchitecture = scenario.ExecutionArchitecture;
            FileName = fileName;
            MethodName = methodName;
        }

        #endregion

        #region methods

        public override Boolean Equals(Object obj) {
            if(obj != null && obj is IResultKey other) {
                return Equals(other);
            }

            return false;
        }

        public Boolean Equals(IResultKey other) {
            if(other == null) { return false; }

            if(other.AssemblyName != AssemblyName) { return false; }
            if(other.TargetRuntime != TargetRuntime) { return false; }
            if(other.TargetArchitecture != TargetArchitecture) { return false; }
            if(other.ExecutionRuntime != ExecutionRuntime) { return false; }
            if(other.ExecutionArchitecture != ExecutionArchitecture) { return false; }
            if(other.FileName != FileName) { return false; }
            if(other.MethodName != MethodName) { return false; }

            return true;
        }

        public Int32 CompareTo(IResultKey other) {
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

            hashCode += AssemblyName.GetHashCode();
            hashCode -= TargetRuntime.GetHashCode();
            hashCode += TargetArchitecture.GetHashCode();
            hashCode -= ExecutionRuntime.GetHashCode();
            hashCode += ExecutionArchitecture.GetHashCode();
            hashCode -= FileName.GetHashCode();
            hashCode += MethodName.GetHashCode();

            return hashCode;
        }

        public override String ToString() =>
            $"[{AssemblyName.Format()};{TargetRuntime.Format()};{TargetArchitecture.Format()};{ExecutionRuntime.Format()};{ExecutionArchitecture.Format()};{FileName.Format()};{MethodName.Format()}]";

        #endregion

    }
}
