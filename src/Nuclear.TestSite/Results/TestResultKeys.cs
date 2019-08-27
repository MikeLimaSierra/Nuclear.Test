﻿using System;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    /// <summary>
    /// Key definition for test results of a fully qualified test method.
    /// </summary>
    public class ResultKeyMethodLevel : Tuple<String, String, ProcessorArchitecture, String, String, String> {

        #region statics

        /// <summary>
        /// Gets an empty instance of <see cref="ResultKeyMethodLevel"/>.
        /// </summary>
        public static ResultKeyMethodLevel Empty => new ResultKeyMethodLevel(null, null, ProcessorArchitecture.None, null, null, null);

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

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyMethodLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyAssemblyNameLevel"/> part of the key.</param>
        public ResultKeyMethodLevel(ResultKeyAssemblyNameLevel key)
            : this(key.Assembly, null, ProcessorArchitecture.None, null, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyMethodLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyTargetRuntimeLevel"/> part of the key.</param>
        public ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel key)
            : this(key.Assembly, key.TargetRuntime, ProcessorArchitecture.None, null, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyMethodLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyArchitectureLevel"/> part of the key.</param>
        public ResultKeyMethodLevel(ResultKeyArchitectureLevel key)
            : this(key.Assembly, key.TargetRuntime, key.Architecture, null, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyMethodLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyExecutionRuntimeLevel"/> part of the key.</param>
        public ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel key)
            : this(key.Assembly, key.TargetRuntime, key.Architecture, key.ExecutionRuntime, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyMethodLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyFileLevel"/> part of the key.</param>
        public ResultKeyMethodLevel(ResultKeyFileLevel key)
            : this(key.Assembly, key.TargetRuntime, key.Architecture, key.ExecutionRuntime, key.File, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        public ResultKeyMethodLevel(String _assembly)
            : this(_assembly, null, ProcessorArchitecture.None, null, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        public ResultKeyMethodLevel(String _assembly, String _targetRuntime)
            : this(_assembly, _targetRuntime, ProcessorArchitecture.None, null, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        public ResultKeyMethodLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture)
            : this(_assembly, _targetRuntime, _architecture, null, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        public ResultKeyMethodLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime)
            : this(_assembly, _targetRuntime, _architecture, _executionRuntime, null, null) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        /// <param name="_file">The file name part of the key.</param>
        public ResultKeyMethodLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime, String _file)
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
        public ResultKeyMethodLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime, String _file, String _method)
            : base(_assembly, _targetRuntime, _architecture, _executionRuntime, _file, _method) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyMethodLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyFileLevel"/> part of the key.</param>
        /// <param name="_method">The method name part of the key.</param>
        public ResultKeyMethodLevel(ResultKeyFileLevel key, String _method)
            : base(key.Assembly, key.TargetRuntime, key.Architecture, key.ExecutionRuntime, key.File, _method) { }

        #endregion

    }

    /// <summary>
    /// Key definition for all results of a test assembly with a name, target runtime, processor architecture, execution runtime and file name.
    /// </summary>
    public class ResultKeyFileLevel : Tuple<String, String, ProcessorArchitecture, String, String> {

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

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        /// <param name="_file">The file name part of the key.</param>
        public ResultKeyFileLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime, String _file)
            : base(_assembly, _targetRuntime, _architecture, _executionRuntime, _file) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyFileLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyExecutionRuntimeLevel"/> part of the key.</param>
        /// <param name="_file">The file name part of the key.</param>
        public ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel key, String _file)
            : base(key.Assembly, key.TargetRuntime, key.Architecture, key.ExecutionRuntime, _file) { }

        #endregion

    }

    /// <summary>
    /// Key definition for all results of a test assembly with a name, target runtime, processor architecture and execution runtime.
    /// </summary>
    public class ResultKeyExecutionRuntimeLevel : Tuple<String, String, ProcessorArchitecture, String> {

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

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyExecutionRuntimeLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        public ResultKeyExecutionRuntimeLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime)
            : base(_assembly, _targetRuntime, _architecture, _executionRuntime) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyExecutionRuntimeLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyArchitectureLevel"/> part of the key.</param>
        /// <param name="_executionRuntime">The execution runtime part of the key.</param>
        public ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel key, String _executionRuntime)
            : base(key.Assembly, key.TargetRuntime, key.Architecture, _executionRuntime) { }

        #endregion

    }

    /// <summary>
    /// Key definition for all results of a test assembly with a name, target runtime and processor architecture.
    /// </summary>
    public class ResultKeyArchitectureLevel : Tuple<String, String, ProcessorArchitecture> {

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

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyArchitectureLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        public ResultKeyArchitectureLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture)
            : base(_assembly, _targetRuntime, _architecture) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyArchitectureLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyTargetRuntimeLevel"/> part of the key.</param>
        /// <param name="_architecture">The processor architecture part of the key.</param>
        public ResultKeyArchitectureLevel(ResultKeyTargetRuntimeLevel key, ProcessorArchitecture _architecture)
            : base(key.Assembly, key.TargetRuntime, _architecture) { }

        #endregion

    }

    /// <summary>
    /// Key definition for all results of a test assembly with a name and a target runtime.
    /// </summary>
    public class ResultKeyTargetRuntimeLevel : Tuple<String, String> {

        #region properties

        /// <summary>
        /// Gets the assembly name.
        /// </summary>
        public String Assembly => Item1;

        /// <summary>
        /// Gets the target runtime.
        /// </summary>
        public String TargetRuntime => Item2;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyTargetRuntimeLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        public ResultKeyTargetRuntimeLevel(String _assembly, String _targetRuntime)
            : base(_assembly, _targetRuntime) { }

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyTargetRuntimeLevel"/>.
        /// </summary>
        /// <param name="key">The <see cref="ResultKeyAssemblyNameLevel"/> part of the key.</param>
        /// <param name="_targetRuntime">The target assembly part of the key.</param>
        public ResultKeyTargetRuntimeLevel(ResultKeyAssemblyNameLevel key, String _targetRuntime)
            : base(key.Assembly, _targetRuntime) { }

        #endregion

    }

    /// <summary>
    /// Key definition for all results of a test assembly name.
    /// </summary>
    public class ResultKeyAssemblyNameLevel {

        #region properties

        /// <summary>
        /// Gets the assembly name.
        /// </summary>
        public String Assembly { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ResultKeyAssemblyNameLevel"/>.
        /// </summary>
        /// <param name="_assembly">The assembly name part of the key.</param>
        public ResultKeyAssemblyNameLevel(String _assembly) {
            Assembly = _assembly;
        }

        #endregion

    }
}
