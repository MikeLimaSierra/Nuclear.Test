using System;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Key definition for test results of a fully qualified test method.
    /// </summary>
    public class TestResultKey : Tuple<String, String, ProcessorArchitecture, String, String, String> {

        #region statics

        /// <summary>
        /// Gets an empty instance of <see cref="TestResultKey"/>.
        /// </summary>
        public static TestResultKey Empty => new TestResultKey(null, null, ProcessorArchitecture.None, null, null, null);

        #endregion

        #region properties

        /// <summary>
        /// Gets the assembly name.
        /// </summary>
        public String Assembly => Item1;

        /// <summary>
        /// Gets the target runtime.
        /// </summary>
        public String TargetRuntime => Item2;

        /// <summary>
        /// Gets the processor architecture.
        /// </summary>
        public ProcessorArchitecture Architecture => Item3;

        /// <summary>
        /// Gets the execution runtime.
        /// </summary>
        public String ExecutionRuntime => Item4;

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public String File => Item5;

        /// <summary>
        /// Gets the method name.
        /// </summary>
        public String Method => Item6;


        /// <summary>
        /// Gets if the Assembly property was set.
        /// </summary>
        public Boolean HasAssembly => !String.IsNullOrWhiteSpace(Assembly);

        /// <summary>
        /// Gets if the TargetRuntime property was set.
        /// </summary>
        public Boolean HasTargetRuntime => !String.IsNullOrWhiteSpace(TargetRuntime);

        /// <summary>
        /// Gets if the Architecture property was set.
        /// </summary>
        public Boolean HasArchitecture => Architecture != ProcessorArchitecture.None;

        /// <summary>
        /// Gets if the ExecutionRuntime property was set.
        /// </summary>
        public Boolean HasExecutionRuntime => !String.IsNullOrWhiteSpace(ExecutionRuntime);

        /// <summary>
        /// Gets if the File property was set.
        /// </summary>
        public Boolean HasFile => !String.IsNullOrWhiteSpace(File);

        /// <summary>
        /// Gets if the Method property was set.
        /// </summary>
        public Boolean HasMethod => !String.IsNullOrWhiteSpace(Method);


        /// <summary>
        /// Gets if the key object is empty.
        /// </summary>
        public Boolean IsEmpty => !HasAssembly && !HasTargetRuntime && !HasArchitecture && !HasExecutionRuntime && !HasFile && !HasMethod;

        /// <summary>
        /// Gets if the key object is completely set.
        /// </summary>
        public Boolean IsSet => HasAssembly && HasTargetRuntime && HasArchitecture && HasExecutionRuntime && HasFile && HasMethod;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        public TestResultKey(String _assembly)
            : this(_assembly, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        public TestResultKey(String _assembly, String _targetRuntime)
            : this(_assembly, _targetRuntime, ProcessorArchitecture.None) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        public TestResultKey(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture)
            : this(_assembly, _targetRuntime, _architecture, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        public TestResultKey(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime)
            : this(_assembly, _targetRuntime, _architecture, _executionRuntime, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        /// <param name="_file">The file name part of the key.</param>
        public TestResultKey(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime, String _file)
            : this(_assembly, _targetRuntime, _architecture, _executionRuntime, _file, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        /// <param name="_file">The file name part of the key.</param>
        /// <param name="_method">The method name part of the key.</param>
        public TestResultKey(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime, String _file, String _method)
            : base(_assembly, _targetRuntime, _architecture, _executionRuntime, _file, _method) { }

        #endregion

        #region methods

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override String ToString() => String.Format("('{0}','{1}','{2}','{3}','{4}','{5}')",
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            Assembly ?? "null", TargetRuntime ?? "null", Architecture, ExecutionRuntime ?? "null", File ?? "null", Method ?? "null");

        #endregion

    }

}
