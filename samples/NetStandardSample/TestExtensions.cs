using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Tests;

namespace NetStandardSample {
    public static class TestExtensions {

        public static void IsHelloWorld(this ConditionalTest _this, String value, [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            => _this.InternalTest(value == "Hello World!", "Fancy test message.", _file, _method);

    }
}
