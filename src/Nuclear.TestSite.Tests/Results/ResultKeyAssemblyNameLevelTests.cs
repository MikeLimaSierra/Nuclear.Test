using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Results {
    class ResultKeyAssemblyNameLevelTests {

        [TestMethod]
        void TestConstructor() {

            ResultKeyAssemblyNameLevel key = null;

            Test.Note("new ResultKeyAssemblyNameLevel(null)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyAssemblyNameLevel(null), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, null);

            Test.Note("new ResultKeyAssemblyNameLevel(String.Empty)");
            Test.IfNot.ThrowsException(() => key = new ResultKeyAssemblyNameLevel(String.Empty), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, String.Empty);

            Test.Note("new ResultKeyAssemblyNameLevel(\"SomeAssemblyName\")");
            Test.IfNot.ThrowsException(() => key = new ResultKeyAssemblyNameLevel("SomeAssemblyName"), out ex);
            Test.If.Null(ex);
            Test.IfNot.Null(key);
            Test.If.ValuesEqual(key.Assembly, "SomeAssemblyName");

        }

    }
}
