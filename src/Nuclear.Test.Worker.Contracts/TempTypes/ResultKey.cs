using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Extensions;

namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Defines the key structure that identifies test method results.
    /// </summary>
    public class ResultKey : IEquatable<ResultKey> {

        #region properties

        /// <summary>
        /// Gets the test scenario.
        /// </summary>
        public Scenario Scenario { get; }

        /// <summary>
        /// Gets the file name of the test.
        /// </summary>
        public String FileName { get; }

        /// <summary>
        /// Gets the calling method name of the test.
        /// </summary>
        public String MethodName { get; }

        #endregion

        #region ctors

        public ResultKey(Scenario scenario, MethodInfo methodInfo)
            : this(scenario, methodInfo.DeclaringType.Name, methodInfo.Name) { }

        public ResultKey(Scenario scenario, String fileName, String methodName) {
            Scenario = scenario;
            FileName = fileName;
            MethodName = methodName;
        }

        #endregion

        #region methods

        public override Boolean Equals(Object obj) => obj is ResultKey other && Equals(other);

        public override Int32 GetHashCode() {
            Int32 hashCode = 436215418;
            hashCode = hashCode * -1521134295 + DynamicEqualityComparer.FromIEquatable<Scenario>().GetHashCode(Scenario);
            hashCode = hashCode * -1521134295 + EqualityComparer<String>.Default.GetHashCode(FileName);
            hashCode = hashCode * -1521134295 + EqualityComparer<String>.Default.GetHashCode(MethodName);
            return hashCode;
        }

        public Boolean Equals(ResultKey other) =>
            other != null
            && Scenario == other.Scenario
            && FileName == other.FileName
            && MethodName == other.MethodName;

        public override String ToString() => $"[{Scenario.Format()};{FileName.Format()};{MethodName.Format()}]";

        #endregion

    }
}
