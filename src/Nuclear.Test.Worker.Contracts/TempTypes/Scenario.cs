using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Defines a scenario relevant to running tests.
    /// </summary>
    public class Scenario : IEquatable<Scenario> {

        #region properties

        /// <summary>
        /// Gets the name of the test assembly.
        /// </summary>
        public String AssemblyName { get; private set; }

        /// <summary>
        /// Gets the targeted runtime version.
        /// </summary>
        public RuntimeInfo TargetRuntime { get; private set; }

        /// <summary>
        /// Gets the targeted processor architecture.
        /// </summary>
        public ProcessorArchitecture TargetArchitecture { get; private set; }

        /// <summary>
        /// Gets the executing runtime version.
        /// </summary>
        public RuntimeInfo ExecutionRuntime { get; private set; }

        /// <summary>
        /// Gets the executing processor architecture.
        /// </summary>
        public ProcessorArchitecture ExecutionArchitecture { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="Scenario"/>.
        /// </summary>
        /// <param name="assemblyName">The name of the test assembly.</param>
        /// <param name="targetRuntime">The targeted runtime version.</param>
        /// <param name="targetArchitecture">The targeted processor architecture.</param>
        /// <param name="executionRuntime">The executing runtime version.</param>
        /// <param name="executionArchitecture">The executing processor architecture.</param>
        public Scenario(
            String assemblyName,
            RuntimeInfo targetRuntime,
            ProcessorArchitecture targetArchitecture,
            RuntimeInfo executionRuntime,
            ProcessorArchitecture executionArchitecture) {

            Throw.If.String.IsNullOrWhiteSpace(assemblyName, nameof(assemblyName));
            Throw.If.Object.IsNull(targetRuntime, nameof(targetRuntime));
            Throw.IfNot.Enum.IsDefined<ProcessorArchitecture>(targetArchitecture, nameof(targetArchitecture));
            Throw.If.Object.IsNull(executionRuntime, nameof(executionRuntime));
            Throw.IfNot.Enum.IsDefined<ProcessorArchitecture>(executionArchitecture, nameof(executionArchitecture));

            AssemblyName = assemblyName;
            TargetRuntime = targetRuntime;
            TargetArchitecture = targetArchitecture;
            ExecutionRuntime = executionRuntime;
            ExecutionArchitecture = executionArchitecture;
        }

        #endregion

        #region methods

        public override Boolean Equals(Object obj) {
            if(obj != null && obj is Scenario other) {
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

        public Boolean Equals(Scenario other) =>
            other != null
            && AssemblyName == other.AssemblyName
            && TargetRuntime == other.TargetRuntime
            && TargetArchitecture == other.TargetArchitecture
            && ExecutionRuntime == other.ExecutionRuntime
            && ExecutionArchitecture == other.ExecutionArchitecture;

        public override String ToString() => $"[{AssemblyName.Format()};{TargetRuntime.Format()};{TargetArchitecture.Format()};{ExecutionRuntime.Format()};{ExecutionArchitecture.Format()}]";

        #endregion

    }
}
