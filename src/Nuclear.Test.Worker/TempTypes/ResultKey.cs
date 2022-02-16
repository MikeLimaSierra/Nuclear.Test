using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Extensions;

namespace Nuclear.Test.Worker.TempTypes {
    internal class ResultKey : IResultKey {

        #region properties

        public IScenario Scenario { get; }

        public String FileName { get; }

        public String MethodName { get; }

        #endregion

        #region ctors

        internal ResultKey(IScenario scenario, MethodInfo methodInfo)
            : this(scenario, methodInfo.DeclaringType.Name, methodInfo.Name) { }

        internal ResultKey(IScenario scenario, String fileName, String methodName) {
            Scenario = scenario;
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

        public override Int32 GetHashCode() {
            Int32 hashCode = 436215418;
            hashCode = hashCode * -1521134295 + DynamicEqualityComparer.FromIEquatable<IScenario>().GetHashCode(Scenario);
            hashCode = hashCode * -1521134295 + EqualityComparer<String>.Default.GetHashCode(FileName);
            hashCode = hashCode * -1521134295 + EqualityComparer<String>.Default.GetHashCode(MethodName);
            return hashCode;
        }

        public Boolean Equals(IResultKey other) =>
            other != null
            && Scenario == other.Scenario
            && FileName == other.FileName
            && MethodName == other.MethodName;

        public override String ToString() => $"[{Scenario.Format()};{FileName.Format()};{MethodName.Format()}]";

        #endregion

    }
}
