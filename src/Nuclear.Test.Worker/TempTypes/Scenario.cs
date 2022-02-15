﻿using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;

namespace Nuclear.Test.Worker.TempTypes {
    internal class Scenario : IScenario {

        #region properties

        public String AssemblyName { get; private set; }

        public RuntimeInfo TargetRuntime { get; private set; }

        public ProcessorArchitecture TargetArchitecture { get; private set; }

        public RuntimeInfo ExecutionRuntime { get; private set; }

        public ProcessorArchitecture ExecutionArchitecture { get; private set; }

        #endregion

        #region ctors

        internal Scenario(
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture) {

            AssemblyName = assemblyName;
            TargetRuntime = targetRuntime;
            TargetArchitecture = targetArchitecture;
            ExecutionRuntime = executionRuntime;
            ExecutionArchitecture = executionArchitecture;
        }

        #endregion

        #region methods

        public override Boolean Equals(Object obj) {
            if(obj != null && obj is IScenario other) {
                return Equals(other);
            }

            return false;
        }

        public override Int32 GetHashCode() {
            Int32 hashCode = 613849946;
            hashCode = hashCode * -1521134295 + EqualityComparer<String>.Default.GetHashCode(AssemblyName);
            hashCode = hashCode * -1521134295 + DynamicEqualityComparer.FromIEquatable<RuntimeInfo>().GetHashCode(TargetRuntime);
            hashCode = hashCode * -1521134295 + TargetArchitecture.GetHashCode();
            hashCode = hashCode * -1521134295 + DynamicEqualityComparer.FromIEquatable<RuntimeInfo>().GetHashCode(ExecutionRuntime);
            hashCode = hashCode * -1521134295 + ExecutionArchitecture.GetHashCode();
            return hashCode;
        }

        public Boolean Equals(IScenario other) =>
            other != null
            && AssemblyName == other.AssemblyName
            && TargetRuntime == other.TargetRuntime
            && TargetArchitecture == other.TargetArchitecture
            && ExecutionRuntime == other.ExecutionRuntime
            && ExecutionArchitecture == other.ExecutionArchitecture;

        public Int32 CompareTo(IScenario other) {
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
            }

            return 0;
        }

        public override String ToString() => $"[{AssemblyName.Format()};{TargetRuntime.Format()};{TargetArchitecture.Format()};{ExecutionRuntime.Format()};{ExecutionArchitecture.Format()}]";

        #endregion

    }
}
