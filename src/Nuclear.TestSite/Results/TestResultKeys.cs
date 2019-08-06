using System;
using System.Reflection;

namespace Nuclear.TestSite.Results {

    public class ResultKeyMethodLevel : Tuple<String, ProcessorArchitecture, String, String, String> {

        #region statics

        public static ResultKeyMethodLevel Empty => new ResultKeyMethodLevel(null, ProcessorArchitecture.None, null, null, null);

        #endregion

        #region properties

        public String Assembly => Item1;

        public ProcessorArchitecture Architecture => Item2;

        public String Runtime => Item3;

        public String File => Item4;

        public String Method => Item5;

        #endregion

        #region ctors

        public ResultKeyMethodLevel(ResultKeyAssemblyLevel key) : this(key.Assembly, ProcessorArchitecture.None, null, null, null) { }

        public ResultKeyMethodLevel(ResultKeyArchitectureLevel key) : this(key.Assembly, key.Architecture, null, null, null) { }

        public ResultKeyMethodLevel(ResultKeyRuntimeLevel key) : this(key.Assembly, key.Architecture, key.Runtime, null, null) { }

        public ResultKeyMethodLevel(ResultKeyFileLevel key) : this(key.Assembly, key.Architecture, key.Runtime, key.File, null) { }

        public ResultKeyMethodLevel(String _assembly) : this(_assembly, ProcessorArchitecture.None, null, null, null) { }

        public ResultKeyMethodLevel(String _assembly, ProcessorArchitecture _architecture) : this(_assembly, _architecture, null, null, null) { }

        public ResultKeyMethodLevel(String _assembly, ProcessorArchitecture _architecture, String _runtime) : this(_assembly, _architecture, _runtime, null, null) { }

        public ResultKeyMethodLevel(String _assembly, ProcessorArchitecture _architecture, String _runtime, String _file) : this(_assembly, _architecture, _runtime, _file, null) { }

        public ResultKeyMethodLevel(String _assembly, ProcessorArchitecture _architecture, String _runtime, String _file, String _method) : base(_assembly, _architecture, _runtime, _file, _method) { }

        public ResultKeyMethodLevel(ResultKeyFileLevel key, String _method) : base(key.Assembly, key.Architecture, key.Runtime, key.File, _method) { }

        #endregion

    }

    public class ResultKeyFileLevel : Tuple<String, ProcessorArchitecture, String, String> {

        #region properties

        public String Assembly => Item1;

        public ProcessorArchitecture Architecture => Item2;

        public String Runtime => Item3;

        public String File => Item4;

        #endregion

        #region ctors

        public ResultKeyFileLevel(String _assembly, ProcessorArchitecture _architecture, String _runtime, String _file) : base(_assembly, _architecture, _runtime, _file) { }

        public ResultKeyFileLevel(ResultKeyRuntimeLevel key, String _file) : base(key.Assembly, key.Architecture, key.Runtime, _file) { }

        #endregion

    }

    public class ResultKeyRuntimeLevel : Tuple<String, ProcessorArchitecture, String> {

        #region properties

        public String Assembly => Item1;

        public ProcessorArchitecture Architecture => Item2;

        public String Runtime => Item3;

        #endregion

        #region ctors

        public ResultKeyRuntimeLevel(String _assembly, ProcessorArchitecture _architecture, String _runtime) : base(_assembly, _architecture, _runtime) { }

        public ResultKeyRuntimeLevel(ResultKeyArchitectureLevel key, String _runtime) : base(key.Assembly, key.Architecture, _runtime) { }

        #endregion

    }

    public class ResultKeyArchitectureLevel : Tuple<String, ProcessorArchitecture> {

        #region properties

        public String Assembly => Item1;

        public ProcessorArchitecture Architecture => Item2;

        #endregion

        #region ctors

        public ResultKeyArchitectureLevel(String _assembly, ProcessorArchitecture _architecture) : base(_assembly, _architecture) { }

        public ResultKeyArchitectureLevel(ResultKeyAssemblyLevel key, ProcessorArchitecture _architecture) : base(key.Assembly, _architecture) { }

        #endregion

    }

    public class ResultKeyAssemblyLevel {

        #region properties

        public String Assembly { get; private set; }

        #endregion

        #region ctors

        public ResultKeyAssemblyLevel(String _assembly) {
            Assembly = _assembly;
        }

        #endregion

    }
}
