using System;
using NetFrameworkSample;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;


namespace NetFrameworkSampleTests {
    class MyClassTests {

        [TestMethod]
        void TestConstructors() {

            MyClass obj = null;

            Test.If.ThrowsException(() => obj = new MyClass(null), out ArgumentNullException ex);
            Test.If.Null(obj);

            Test.IfNot.ThrowsException(() => obj = new MyClass("asdf"), out ex);
            Test.IfNot.Null(obj);
            Test.If.ValuesEqual(obj.Content, "asdf");

        }

    }
}
