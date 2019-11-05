﻿using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Results {
    class ResultKeyTargetRuntimeLevel_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.IsSubClass<ResultKeyTargetRuntimeLevel, Tuple<String, String>>();

        }

        [TestMethod]
        void TestConstructor() {

            ResultKeyTargetRuntimeLevel key = null;

            Test.Note("new ResultKeyTargetRuntimeLevel(null, null)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel((String) null, null), out Exception ex);

            DDTKey(key, (null, null));

            Test.Note("new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(String.Empty, String.Empty), out ex);

            DDTKey(key, (String.Empty, String.Empty));

            Test.Note("new ResultKeyTargetRuntimeLevel(\"SomeAssemblyName\", \"SomeTargetRuntime\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel("SomeAssemblyName", "SomeTargetRuntime"), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime"));

        }

        [TestMethod]
        void TestIncrementalConstructor() {

            ResultKeyTargetRuntimeLevel key = null;

            Test.Note("new ResultKeyTargetRuntimeLevel(ResultKeyTargetRuntimeLevel, null)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(new ResultKeyAssemblyNameLevel(null), null), out Exception ex);

            DDTKey(key, (null, null));

            Test.Note("new ResultKeyTargetRuntimeLevel(ResultKeyTargetRuntimeLevel, String.Empty)");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(new ResultKeyAssemblyNameLevel(String.Empty), String.Empty), out ex);

            DDTKey(key, (String.Empty, String.Empty));

            Test.Note("new ResultKeyTargetRuntimeLevel(ResultKeyTargetRuntimeLevel(\"SomeAssemblyName\"), \"SomeTargetRuntime\")");
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyTargetRuntimeLevel(new ResultKeyAssemblyNameLevel("SomeAssemblyName"), "SomeTargetRuntime"), out ex);

            DDTKey(key, ("SomeAssemblyName", "SomeTargetRuntime"));

        }

        void DDTKey(ResultKeyTargetRuntimeLevel key, (String assembly, String targetRuntime) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Test.IfNot.Object.IsNull(key, _file, _method);
            Test.If.Value.Equals(key.Assembly, expected.assembly, _file, _method);
            Test.If.Value.Equals(key.Assembly, key.Item1, _file, _method);
            Test.If.Value.Equals(key.TargetRuntime, expected.targetRuntime, _file, _method);
            Test.If.Value.Equals(key.TargetRuntime, key.Item2, _file, _method);

        }

    }
}
