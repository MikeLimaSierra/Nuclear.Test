using System;
using System.Reflection;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class ResultKeyExecutionRuntimeLevelTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeIsSubClass<ResultKeyExecutionRuntimeLevel, Tuple<String, String, ProcessorArchitecture, String>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyExecutionRuntimeLevel key = null;

            Test.Note("new ResultKeyExecutionRuntimeLevel(null, null, ProcessorArchitecture.None, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(null, null, ProcessorArchitecture.None, null), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, null);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);

            Test.Note("new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, String.Empty);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);

            Test.Note("new ResultKeyExecutionRuntimeLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, "SomeExecutionRuntime");
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);

        }

        [TestMethod]
        void TestIncrementalConstructor() {

            ResultKeyExecutionRuntimeLevel key = null;

            Test.Note("new ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(new ResultKeyArchitectureLevel(String.Empty, null, ProcessorArchitecture.None), null), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);

            Test.Note("new ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL), String.Empty), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, String.Empty);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);

            Test.Note("new ResultKeyExecutionRuntimeLevel(ResultKeyArchitectureLevel, \"SomeExecutionRuntime\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyExecutionRuntimeLevel(new ResultKeyArchitectureLevel("ASDF", String.Empty, ProcessorArchitecture.MSIL), "SomeExecutionRuntime"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "ASDF");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, "SomeExecutionRuntime");
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);

        }

    }
}
