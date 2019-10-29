using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Results {
    class ResultKeyArchitectureLevel_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.IsSubClass<ResultKeyArchitectureLevel, Tuple<String, String, ProcessorArchitecture>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyArchitectureLevel key = null;

            Test.Note("new ResultKeyArchitectureLevel(null, null, ProcessorArchitecture.None)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyArchitectureLevel(null, null, ProcessorArchitecture.None), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None));

            Test.Note("new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL));

            Test.Note("new ResultKeyArchitectureLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyArchitectureLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL), out ex);

            DDTestKey(key, ("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL));

        }

        [TestMethod]
        void TestIncrementalConstructor() {

            ResultKeyArchitectureLevel key = null;

            Test.Note("new ResultKeyArchitectureLevel(ResultKeyTargetRuntimeLevel, ProcessorArchitecture.None)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyArchitectureLevel(new ResultKeyTargetRuntimeLevel(null as String, null), ProcessorArchitecture.None), out Exception ex);

            DDTestKey(key, (null, null, ProcessorArchitecture.None));

            Test.Note("new ResultKeyArchitectureLevel(ResultKeyTargetRuntimeLevel, ProcessorArchitecture.None)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyArchitectureLevel(new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty), ProcessorArchitecture.MSIL), out ex);

            DDTestKey(key, (String.Empty, String.Empty, ProcessorArchitecture.MSIL));

            Test.Note("new ResultKeyArchitectureLevel(ResultKeyTargetRuntimeLevel, ProcessorArchitecture.MSIL)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyArchitectureLevel(new ResultKeyTargetRuntimeLevel("ASDF", String.Empty), ProcessorArchitecture.MSIL), out ex);

            DDTestKey(key, ("ASDF", String.Empty, ProcessorArchitecture.MSIL));

        }

        void DDTestKey(ResultKeyArchitectureLevel key, (String assembly, String targetRuntime, ProcessorArchitecture architecture) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.IfNot.Object.IsNull(key, _file, _method);
            Test.If.Values.Equal(key.Assembly, expected.assembly, _file, _method);
            Test.If.Values.Equal(key.Assembly, key.Item1, _file, _method);
            Test.If.Values.Equal(key.TargetRuntime, expected.targetRuntime, _file, _method);
            Test.If.Values.Equal(key.TargetRuntime, key.Item2, _file, _method);
            Test.If.Values.Equal(key.Architecture, expected.architecture, _file, _method);
            Test.If.Values.Equal(key.Architecture, key.Item3, _file, _method);

        }

    }
}
