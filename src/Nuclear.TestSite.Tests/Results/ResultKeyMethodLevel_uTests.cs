using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Results {
    class ResultKeyMethodLevel_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.IsSubClass<ResultKeyMethodLevel, Tuple<String, String, ProcessorArchitecture, String, String, String>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(null, null, ProcessorArchitecture.None, null, null, null)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(null, null, ProcessorArchitecture.None, null, null, null), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\", \"SomeMethod\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"));

        }

        [TestMethod]
        void TestConstructorDefaultValues() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), out Exception ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", null, null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, null, null, null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime"), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName"), out ex);

            DDTestKey(key, ("SomeAssemblyName", null, ProcessorArchitecture.None, null, null, null));

        }

        [TestMethod]
        void TestIncrementalFileConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, null)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null), null), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, String.Empty)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty), String.Empty), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, \"SomeMethod\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), "SomeMethod"), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"));

        }

        [TestMethod]
        void TestFileConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null)), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty)), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile")), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", null));

        }

        [TestMethod]
        void TestExecutionRuntimeConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyExecutionRuntimeLevel(null, null, ProcessorArchitecture.None, null)), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty)), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyExecutionRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime")), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", null, null));

        }

        [TestMethod]
        void TestArchitectureConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyArchitectureLevel(null, null, ProcessorArchitecture.None)), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL)), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyArchitectureLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL)), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, null, null, null));

        }

        [TestMethod]
        void TestTargetRuntimeConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyTargetRuntimeLevel((String) null, null)), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty)), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyTargetRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime")), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.None, null, null, null));

        }

        [TestMethod]
        void TestAssemblyNameConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyAssemblyNameLevel(null)), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyAssemblyNameLevel(String.Empty)), out ex);

            DDTestKey(key, (String.Empty, null, ProcessorArchitecture.None, null, null, null));

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyAssemblyNameLevel("SomeAssemblyName")), out ex);
            Test.If.Object.IsNull(ex);

            DDTestKey(key, ("SomeAssemblyName", null, ProcessorArchitecture.None, null, null, null));

        }

        void DDTestKey(ResultKeyMethodLevel key, (String assembly, String targetRuntime, ProcessorArchitecture architecture, String executionRuntime, String file, String method) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.IfNot.Object.IsNull(key, _file, _method);
            Test.If.Values.Equal(key.Assembly, expected.assembly, _file, _method);
            Test.If.Values.Equal(key.Assembly, key.Item1, _file, _method);
            Test.If.Values.Equal(key.TargetRuntime, expected.targetRuntime, _file, _method);
            Test.If.Values.Equal(key.TargetRuntime, key.Item2, _file, _method);
            Test.If.Values.Equal(key.Architecture, expected.architecture, _file, _method);
            Test.If.Values.Equal(key.Architecture, key.Item3, _file, _method);
            Test.If.Values.Equal(key.ExecutionRuntime, expected.executionRuntime, _file, _method);
            Test.If.Values.Equal(key.ExecutionRuntime, key.Item4, _file, _method);
            Test.If.Values.Equal(key.File, expected.file, _file, _method);
            Test.If.Values.Equal(key.File, key.Item5, _file, _method);
            Test.If.Values.Equal(key.Method, expected.method, _file, _method);
            Test.If.Values.Equal(key.Method, key.Item6, _file, _method);

        }

    }
}
