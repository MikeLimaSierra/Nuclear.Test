using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;

namespace Nuclear.TestSite.Results {
    class ResultKeyAssemblyNameLevel_uTests {

        [TestMethod]
        void TestConstructor() {

            DDTConstructor(null);
            DDTConstructor(String.Empty);
            DDTConstructor("SomeAssemblyName");

        }

        void DDTConstructor(String input,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ResultKeyAssemblyNameLevel key = null;

            Test.Note(String.Format("new ResultKeyAssemblyNameLevel({0})", input.Print()), _file, _method);
            Test.IfNot.Action.ThrowsException(() => key = new ResultKeyAssemblyNameLevel(input), out Exception ex, _file, _method);
            Test.IfNot.Object.IsNull(key, _file, _method);
            Test.If.Value.Equals(key.Assembly, input, _file, _method);

        }

    }
}
