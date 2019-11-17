using System;
using System.Reflection;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Results {

    internal class ResultKeyFileLevel : Tuple<String, String, ProcessorArchitecture, String, String> {

        #region properties

        internal String Assembly => Item1;

        internal String TargetRuntime => Item2;

        internal ProcessorArchitecture Architecture => Item3;

        internal String ExecutionRuntime => Item4;

        internal String File => Item5;

        #endregion

        #region ctors

        internal ResultKeyFileLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime, String _file)
            : base(_assembly, _targetRuntime, _architecture, _executionRuntime, _file) { }

        internal ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel key, String _file)
            : base(key.Assembly, key.TargetRuntime, key.Architecture, key.ExecutionRuntime, _file) { }

        #endregion

        #region operators

        public static implicit operator TestResultKey(ResultKeyFileLevel key) => new TestResultKey(key.Assembly, key.TargetRuntime, key.Architecture, key.ExecutionRuntime, key.File);

        #endregion

    }

    internal class ResultKeyExecutionRuntimeLevel : Tuple<String, String, ProcessorArchitecture, String> {

        #region properties

        internal String Assembly => Item1;

        internal String TargetRuntime => Item2;

        internal ProcessorArchitecture Architecture => Item3;

        internal String ExecutionRuntime => Item4;

        #endregion

        #region ctors

        public ResultKeyExecutionRuntimeLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture, String _executionRuntime)
            : base(_assembly, _targetRuntime, _architecture, _executionRuntime) { }

        public ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel key, String _executionRuntime)
            : base(key.Assembly, key.TargetRuntime, key.Architecture, _executionRuntime) { }

        #endregion

        #region operators

        public static implicit operator TestResultKey(ResultKeyExecutionRuntimeLevel key) => new TestResultKey(key.Assembly, key.TargetRuntime, key.Architecture, key.ExecutionRuntime);

        #endregion

    }

    internal class ResultKeyArchitectureLevel : Tuple<String, String, ProcessorArchitecture> {

        #region properties

        internal String Assembly => Item1;

        internal String TargetRuntime => Item2;

        internal ProcessorArchitecture Architecture => Item3;

        #endregion

        #region ctors

        internal ResultKeyArchitectureLevel(String _assembly, String _targetRuntime, ProcessorArchitecture _architecture)
            : base(_assembly, _targetRuntime, _architecture) { }

        internal ResultKeyArchitectureLevel(ResultKeyTargetRuntimeLevel key, ProcessorArchitecture _architecture)
            : base(key.Assembly, key.TargetRuntime, _architecture) { }

        #endregion

        #region operators

        public static implicit operator TestResultKey(ResultKeyArchitectureLevel key) => new TestResultKey(key.Assembly, key.TargetRuntime, key.Architecture);

        #endregion

    }

    internal class ResultKeyTargetRuntimeLevel : Tuple<String, String> {

        #region properties

        internal String Assembly => Item1;

        internal String TargetRuntime => Item2;

        #endregion

        #region ctors

        internal ResultKeyTargetRuntimeLevel(String _assembly, String _targetRuntime)
            : base(_assembly, _targetRuntime) { }

        internal ResultKeyTargetRuntimeLevel(ResultKeyAssemblyNameLevel key, String _targetRuntime)
            : base(key.Assembly, _targetRuntime) { }

        #endregion

        #region operators

        public static implicit operator TestResultKey(ResultKeyTargetRuntimeLevel key) => new TestResultKey(key.Assembly, key.TargetRuntime);

        #endregion

    }

    internal class ResultKeyAssemblyNameLevel {

        #region properties

        internal String Assembly { get; private set; }

        #endregion

        #region ctors

        internal ResultKeyAssemblyNameLevel(String _assembly) {
            Assembly = _assembly;
        }

        #endregion

        #region operators

        public static implicit operator TestResultKey(ResultKeyAssemblyNameLevel key) => new TestResultKey(key.Assembly);

        #endregion

    }
}
