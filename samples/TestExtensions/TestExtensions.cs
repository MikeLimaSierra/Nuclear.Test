using System;
using System.Runtime.CompilerServices;

using Nuclear.TestSite.TestSuites;

namespace TestExtensions {
    public static class TestExtensions {

        public static void IsHelloWorld(this StringTestSuite _this, String value, String customMessage = null, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => _this.InternalTest(value == "Hello World!", "Fancy test message.", customMessage, _file, _method);
    }
}
