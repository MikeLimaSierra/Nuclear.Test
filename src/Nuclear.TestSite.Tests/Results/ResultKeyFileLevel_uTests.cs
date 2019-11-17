//using System;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using Nuclear.TestSite.Attributes;

//namespace Nuclear.TestSite.Results {
//    class ResultKeyFileLevel_uTests {

//        [TestMethod]
//        void TestImplementation() {

//            Test.If.Type.IsSubClass<ResultKeyFileLevel, Tuple<String, String, ProcessorArchitecture, String, String>>();

//        }

//        [TestMethod]
//        void TestConstructor() {

//            ResultKeyFileLevel key = null;

//            Test.Note("new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null, null));

//            Test.Note("new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty));

//            Test.Note("new ResultKeyFileLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\")");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"));

//        }

//        [TestMethod]
//        void TestIncrementalConstructor() {

//            ResultKeyFileLevel key = null;

//            Test.Note("new ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel, null)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyFileLevel(new ResultKeyExecutionRuntimeLevel(String.Empty, null, ProcessorArchitecture.None, null), null), out Exception ex);

//            DDTKey(key, (String.Empty, null, ProcessorArchitecture.None, null, null));

//            Test.Note("new ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel, String.Empty)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyFileLevel(new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty), String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty));

//            Test.Note("new ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel, \"SomeFile\")");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyFileLevel(new ResultKeyExecutionRuntimeLevel("ASDF", String.Empty, ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), "SomeFile"), out ex);

//            DDTKey(key, ("ASDF", String.Empty, ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"));

//        }

//        void DDTKey(ResultKeyFileLevel key, (String assembly, String targetRuntime, ProcessorArchitecture architecture, String executionRuntime, String file) expected,
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

//        }

//    }
//}
