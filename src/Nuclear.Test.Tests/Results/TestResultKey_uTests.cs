//using System;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using Nuclear.TestSite.Attributes;

//namespace Nuclear.TestSite.Results {
//    class TestResultKey_uTests {

//        [TestMethod]
//        void TestImplementation() {

//            Test.If.Type.IsSubClass<TestResultKey, Tuple<String, String, ProcessorArchitecture, String, String, String>>();

//        }

//        [TestMethod]
//        void TestConstructor() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(null, null, ProcessorArchitecture.None, null, null, null)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(null, null, ProcessorArchitecture.None, null, null, null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty));

//            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\", \"SomeMethod\")");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"));

//        }

//        [TestMethod]
//        void TestConstructorDefaultValues() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\")");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), out Exception ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", null));

//            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\")");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", null, null));

//            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\")");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\")");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName"), out ex);

//            DDTKey(key, ("SomeAssemblyName", null, ProcessorArchitecture.None, null, null, null));

//        }

//        [TestMethod]
//        void TestIncrementalFileConstructor() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, null)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(null, null, ProcessorArchitecture.None, null, null, null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, String.Empty)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, \"SomeMethod\")");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"));

//        }

//        [TestMethod]
//        void TestFileConstructor() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(null, null, ProcessorArchitecture.None, null, null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", null));

//        }

//        [TestMethod]
//        void TestExecutionRuntimeConstructor() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(null, null, ProcessorArchitecture.None, null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", null, null));

//        }

//        [TestMethod]
//        void TestArchitectureConstructor() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(null, null, ProcessorArchitecture.None), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(String.Empty, String.Empty, ProcessorArchitecture.MSIL), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, null, null, null));

//        }

//        [TestMethod]
//        void TestTargetRuntimeConstructor() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey((String) null, null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(String.Empty, String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName", "SomeTargetRuntime"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.None, null, null, null));

//        }

//        [TestMethod]
//        void TestAssemblyNameConstructor() {

//            TestResultKey key = null;

//            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey(String.Empty), out ex);

//            DDTKey(key, (String.Empty, null, ProcessorArchitecture.None, null, null, null));

//            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
//            Test.IfNot.Action.ThrowsException(() => key = new TestResultKey("SomeAssemblyName"), out ex);
//            Test.If.Object.IsNull(ex);

//            DDTKey(key, ("SomeAssemblyName", null, ProcessorArchitecture.None, null, null, null));

//        }

//        void DDTKey(TestResultKey key, (String assembly, String targetRuntime, ProcessorArchitecture architecture, String executionRuntime, String file, String method) expected,
//            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

//            Test.IfNot.Object.IsNull(key, _file, _method);
//            Test.If.Value.Equals(key.Assembly, expected.assembly, _file, _method);
//            Test.If.Value.Equals(key.Assembly, key.Item1, _file, _method);
//            Test.If.Value.Equals(key.TargetRuntime, expected.targetRuntime, _file, _method);
//            Test.If.Value.Equals(key.TargetRuntime, key.Item2, _file, _method);
//            Test.If.Value.Equals(key.Architecture, expected.architecture, _file, _method);
//            Test.If.Value.Equals(key.Architecture, key.Item3, _file, _method);
//            Test.If.Value.Equals(key.ExecutionRuntime, expected.executionRuntime, _file, _method);
//            Test.If.Value.Equals(key.ExecutionRuntime, key.Item4, _file, _method);
//            Test.If.Value.Equals(key.File, expected.file, _file, _method);
//            Test.If.Value.Equals(key.File, key.Item5, _file, _method);
//            Test.If.Value.Equals(key.Method, expected.method, _file, _method);
//            Test.If.Value.Equals(key.Method, key.Item6, _file, _method);

//        }

//    }
//}
