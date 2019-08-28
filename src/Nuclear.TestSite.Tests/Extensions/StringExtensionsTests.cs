using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.TestSite.Extensions {
    class StringExtensionsTests {

        [TestMethod]
        void TestStartsWith() {

            Boolean result = false;

            Test.IfNot.ThrowsException(() => result = "Test".StartsWith('T'), out Exception ex);
            Test.If.True(result);

            Test.IfNot.ThrowsException(() => result = "Test".StartsWith('t'), out ex);
            Test.If.False(result);

            Test.IfNot.ThrowsException(() => result = "_Test".StartsWith('T'), out ex);
            Test.If.False(result);

        }

        [TestMethod]
        void TestEndsWith() {

            Boolean result = false;

            Test.IfNot.ThrowsException(() => result = "Test".EndsWith('t'), out Exception ex);
            Test.If.True(result);

            Test.IfNot.ThrowsException(() => result = "Test".EndsWith('T'), out ex);
            Test.If.False(result);

            Test.IfNot.ThrowsException(() => result = "Test_".EndsWith('t'), out ex);
            Test.If.False(result);

        }

    }
}
