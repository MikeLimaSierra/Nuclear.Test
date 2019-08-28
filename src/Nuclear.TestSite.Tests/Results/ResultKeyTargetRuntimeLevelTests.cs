using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class ResultKeyTargetRuntimeLevelTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeIsSubClass<ResultKeyTargetRuntimeLevel, Tuple<String, String>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyTargetRuntimeLevel key = null;

            Test.Note("new ResultKeyTargetRuntimeLevel(null, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel((String) null, null), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, null);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);

            Test.Note("new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);

            Test.Note("new ResultKeyTargetRuntimeLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);

        }

        [TestMethod]
        void TestIncrementalConstructor() {

            ResultKeyTargetRuntimeLevel key = null;

            Test.Note("new ResultKeyTargetRuntimeLevel(ResultKeyTargetRuntimeLevel, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(new ResultKeyAssemblyNameLevel(String.Empty), null), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);

            Test.Note("new ResultKeyTargetRuntimeLevel(ResultKeyTargetRuntimeLevel, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(new ResultKeyAssemblyNameLevel(String.Empty), String.Empty), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);

            Test.Note("new ResultKeyTargetRuntimeLevel(ResultKeyTargetRuntimeLevel(\"SomeAssemblyName\"), \"SomeTargetRuntime\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(new ResultKeyAssemblyNameLevel("SomeAssemblyName"), "SomeTargetRuntime"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);

        }

    }
}
