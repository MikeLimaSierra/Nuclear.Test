using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Tests;
using Sample;

namespace SampleTests {
    internal static class GenericTests {

        internal static void TestCtorGeneric(String title, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            MyClass obj = null;

            Test.IfNot.ThrowsException(() => obj = new MyClass(title), out ArgumentNullException ex, _file, _method);
            Test.IfNot.Null(obj, _file, _method);
            Test.If.Null(ex, _file, _method);
            Test.If.ValuesEqual(obj.Title, title, _file, _method);

        }

    }
}
