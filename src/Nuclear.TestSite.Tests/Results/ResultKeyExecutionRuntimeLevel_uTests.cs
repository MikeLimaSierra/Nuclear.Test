//using System;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using Nuclear.TestSite.Attributes;

//namespace Nuclear.TestSite.Results {
//    class ResultKeyExecutionRuntimeLevel_uTests {

//        [TestMethod]
//        void TestImplementation() {

//            Test.If.Type.IsSubClass<ResultKeyExecutionRuntimeLevel, Tuple<String, String, ProcessorArchitecture, String>>();

//        }

//        [TestMethod]
//        void TestConstructor() {

//            ResultKeyExecutionRuntimeLevel key = null;

//            Test.Note("new ResultKeyExecutionRuntimeLevel(null, null, ProcessorArchitecture.None, null)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(null, null, ProcessorArchitecture.None, null), out Exception ex);

//            DDTKey(key, (null, null, ProcessorArchitecture.None, null));

//            Test.Note("new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty));

//            Test.Note("new ResultKeyExecutionRuntimeLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\")");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), out ex);

//            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"));

//        }

//        [TestMethod]
//        void TestIncrementalConstructor() {

//            ResultKeyExecutionRuntimeLevel key = null;

//            Test.Note("new ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel, null)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(new ResultKeyArchitectureLevel(String.Empty, null, ProcessorArchitecture.None), null), out Exception ex);

//            DDTKey(key, (String.Empty, null, ProcessorArchitecture.None, null));

//            Test.Note("new ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel, String.Empty)");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL), String.Empty), out ex);

//            DDTKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty));

//            Test.Note("new ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel, \"SomeExecutionRuntime\")");
//            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(new ResultKeyArchitectureLevel("ASDF", String.Empty, ProcessorArchitecture.MSIL), "SomeExecutionRuntime"), out ex);

//            DDTKey(key, ("ASDF", String.Empty, ProcessorArchitecture.MSIL, "SomeExecutionRuntime"));

//        }

//        void DDTKey(ResultKeyExecutionRuntimeLevel key, (String assembly, String targetRuntime, ProcessorArchitecture architecture, String executionRuntime) expected,
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

//        }

//    }
//}
