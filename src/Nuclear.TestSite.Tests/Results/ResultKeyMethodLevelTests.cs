using System;
using System.Reflection;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class ResultKeyMethodLevelTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeIsSubClass<ResultKeyMethodLevel, Tuple<String, String, ProcessorArchitecture, String, String, String>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(null, null, ProcessorArchitecture.None, null, null, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(null, null, ProcessorArchitecture.None, null, null, null), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty, String.Empty), out ex);
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
            Test.If.ValuesEqual(key.Method, String.Empty);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\", \"SomeMethod\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile", "SomeMethod"), out ex);
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
            Test.If.ValuesEqual(key.Method, "SomeMethod");
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

        [TestMethod]
        void TestConstructorDefaultValues() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\", \"SomeFile\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL, \"SomeExecutionRuntime\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime"), out ex);
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
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\", ProcessorArchitecture.MSIL)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName", "SomeTargetRuntime"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(\"SomeAssemblyName\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel("SomeAssemblyName"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

        [TestMethod]
        void TestIncrementalFileConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null), null), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty), String.Empty), out ex);
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
            Test.If.ValuesEqual(key.Method, String.Empty);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel, \"SomeMethod\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile"), "SomeMethod"), out ex);
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
            Test.If.ValuesEqual(key.Method, "SomeMethod");
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

        [TestMethod]
        void TestFileConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(null, null, ProcessorArchitecture.None, null, null)), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty, String.Empty)), out ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyFileLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyFileLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime", "SomeFile")), out ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

        [TestMethod]
        void TestExecutionRuntimeConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyExecutionRuntimeLevel(null, null, ProcessorArchitecture.None, null)), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyExecutionRuntimeLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL, String.Empty)), out ex);
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
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyExecutionRuntimeLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyExecutionRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL, "SomeExecutionRuntime")), out ex);
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
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

        [TestMethod]
        void TestArchitectureConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyArchitectureLevel(null, null, ProcessorArchitecture.None)), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyArchitectureLevel(String.Empty, String.Empty, ProcessorArchitecture.MSIL)), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyArchitectureLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyArchitectureLevel("SomeAssemblyName", "SomeTargetRuntime", ProcessorArchitecture.MSIL)), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.MSIL);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

        [TestMethod]
        void TestTargetRuntimeConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyTargetRuntimeLevel((String) null, null)), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty)), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, String.Empty);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyTargetRuntimeLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyTargetRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime")), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, "SomeTargetRuntime");
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

        [TestMethod]
        void TestAssemblyNameConstructor() {

            ResultKeyMethodLevel key = null;

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyAssemblyNameLevel(null)), out Exception ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyAssemblyNameLevel(String.Empty)), out ex);
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
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

            Test.Note("new ResultKeyMethodLevel(ResultKeyAssemblyNameLevel)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyMethodLevel(new ResultKeyAssemblyNameLevel("SomeAssemblyName")), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");
            Test.If.ValuesEqual(key.Assembly, key.Item1);
            Test.If.ValuesEqual(key.TargetRuntime, null);
            Test.If.ValuesEqual(key.TargetRuntime, key.Item2);
            Test.If.ValuesEqual(key.Architecture, ProcessorArchitecture.None);
            Test.If.ValuesEqual(key.Architecture, key.Item3);
            Test.If.ValuesEqual(key.ExecutionRuntime, null);
            Test.If.ValuesEqual(key.ExecutionRuntime, key.Item4);
            Test.If.ValuesEqual(key.File, null);
            Test.If.ValuesEqual(key.File, key.Item5);
            Test.If.ValuesEqual(key.Method, null);
            Test.If.ValuesEqual(key.Method, key.Item6);

        }

    }
}
