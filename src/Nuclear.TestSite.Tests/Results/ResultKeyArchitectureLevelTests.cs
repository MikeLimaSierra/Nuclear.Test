using System;
using System.Reflection;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class ResultKeyArchitectureLevelTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeIsSubClass<ResultKeyArchitectureLevel, Tuple<String, String, ProcessorArchitecture>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyArchitectureLevel key = null;

            Test.Note("new ResultKeyArchitectureLevel(null, null, ProcessorArchitecture.None)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyArchitectureLevel(null, null, ProcessorArchitecture.None), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, null);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);

            Test.Note("new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);

            Test.Note("new ResultKeyArchitectureLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyArchitectureLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);

        }

        [TestMethod]
        void TestIncrementalConstructor() {

            ResultKeyArchitectureLevel key = null;

            Test.Note("new ResultKeyArchitectureLevel(ResultKeyTargetRuntimeLevel, ProcessorArchitecture.None)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyArchitectureLevel(new ResultKeyTargetRuntimeLevel(String.Empty, null), ProcessorArchitecture.None), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);

            Test.Note("new ResultKeyArchitectureLevel(ResultKeyTargetRuntimeLevel, ProcessorArchitecture.MSIL)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyArchitectureLevel(new ResultKeyTargetRuntimeLevel("ASDF", String.Empty), ProcessorArchitecture.MSIL), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "ASDF");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);

        }

    }
}
