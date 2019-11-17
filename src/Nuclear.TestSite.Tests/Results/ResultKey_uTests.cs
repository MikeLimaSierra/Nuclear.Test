using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Results {
    class ResultKeyMethodLevel_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.IsSubClass<ResultKey, Tuple<String, String, ProcessorArchitecture, String, String, String>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(null, null, ProcessorArchitecture.None, null, null, null)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(null, null, ProcessorArchitecture.None, null, null, null), out Exception ex);

            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty), out ex);

            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\", \"SomeMethod\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"));

        }

        [TestMethod]
        void TestConstructorDefaultValues() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), out Exception ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", null, null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, null, null, null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey("SomeAssemblyName", "SomeTargetRuntime"), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey("SomeAssemblyName"), out ex);

            DDTKey(key, ("SomeAssemblyName", null, ProcessorArchitecture.None, null, null, null));

        }

        [TestMethod]
        void TestIncrementalFileConstructor() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, null)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null), null), out Exception ex);

            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, String.Empty)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty), String.Empty), out ex);

            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, \"SomeMethod\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), "SomeMethod"), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"));

        }

        [TestMethod]
        void TestFileConstructor() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null)), out Exception ex);

            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty)), out ex);

            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile")), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", null));

        }

        [TestMethod]
        void TestExecutionRuntimeConstructor() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyExecutionRuntimeLevel(null, null, ProcessorArchitecture.None, null)), out Exception ex);

            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty)), out ex);

            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyExecutionRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime")), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", null, null));

        }

        [TestMethod]
        void TestArchitectureConstructor() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyArchitectureLevel(null, null, ProcessorArchitecture.None)), out Exception ex);

            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL)), out ex);

            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyArchitectureLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL)), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, null, null, null));

        }

        [TestMethod]
        void TestTargetRuntimeConstructor() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyTargetRuntimeLevel((String) null, null)), out Exception ex);

            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty)), out ex);

            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyTargetRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime")), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.None, null, null, null));

        }

        [TestMethod]
        void TestAssemblyNameConstructor() {

            ResultKey key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyAssemblyNameLevel(null)), out Exception ex);

            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyAssemblyNameLevel(String.Empty)), out ex);

            DDTKey(key, (String.Empty, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKey(new ResultKeyAssemblyNameLevel("SomeAssemblyName")), out ex);
            Test.If.Object.IsNull(ex);

            DDTKey(key, ("SomeAssemblyName", null, ProcessorArchitecture.None, null, null, null));

        }

        void DDTKey(ResultKey key, (String assembly, String targetRuntime, ProcessorArchitecture architecture, String executionRuntime, String file, String method) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.IfNot.Object.IsNull(key, _file, _method);
            Test.If.Value.Equals(key.Assembly, expected.assembly, _file, _method);
            Test.If.Value.Equals(key.Assembly, key.Item1, _file, _method);
            Test.If.Value.Equals(key.TargetRuntime, expected.targetRuntime, _file, _method);
            Test.If.Value.Equals(key.TargetRuntime, key.Item2, _file, _method);
            Test.If.Value.Equals(key.Architecture, expected.architecture, _file, _method);
            Test.If.Value.Equals(key.Architecture, key.Item3, _file, _method);
            Test.If.Value.Equals(key.ExecutionRuntime, expected.executionRuntime, _file, _method);
            Test.If.Value.Equals(key.ExecutionRuntime, key.Item4, _file, _method);
            Test.If.Value.Equals(key.File, expected.file, _file, _method);
            Test.If.Value.Equals(key.File, key.Item5, _file, _method);
            Test.If.Value.Equals(key.Method, expected.method, _file, _method);
            Test.If.Value.Equals(key.Method, key.Item6, _file, _method);

        }

    }
}
