using System;
using System.Reflection;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class ResultKeyFileLevelTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeIsSubClass<ResultKeyFileLevel, Tuple<String, String, ProcessorArchitecture, String, String>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyFileLevel key = null;

            Test.Note("new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null), out Exception ex);
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
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);

            Test.Note("new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty), out ex);
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
            Test.If.ValuesEqual(key.File, String.Empty);
            Test.If.ValuesEqual(key.File, key.Item5);

            Test.Note("new ResultKeyFileLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), out ex);
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
            Test.If.ValuesEqual(key.File, "SomeFile");
            Test.If.ValuesEqual(key.File, key.Item5);

        }

        [TestMethod]
        void TestIncrementalConstructor() {

            ResultKeyFileLevel key = null;

            Test.Note("new ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyFileLevel(new ResultKeyExecutionRuntimeLevel(String.Empty, null, ProcessorArchitecture.None, null), null), out Exception ex);
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
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);

            Test.Note("new ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyFileLevel(new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty), String.Empty), out ex);
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
            Test.If.ValuesEqual(key.File, String.Empty);
            Test.If.ValuesEqual(key.File, key.Item5);

            Test.Note("new ResultKeyFileLevel(ResultKeyExecutionRuntimeLevel, \"SomeFile\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyFileLevel(new ResultKeyExecutionRuntimeLevel("ASDF", String.Empty, ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), "SomeFile"), out ex);
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
            Test.If.ValuesEqual(key.File, "SomeFile");
            Test.If.ValuesEqual(key.File, key.Item5);

        }

    }
}
