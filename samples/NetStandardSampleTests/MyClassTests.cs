using System;
using NetStandardSample;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace NetStandardSampleTests {
    class MyClassTests {

        [TestMethod]
        void TestConstructors() {

            MyClass obj = null;

            Test.If.ThrowsException(() => obj = new MyClass(null), out ArgumentNullException ex);
            Test.If.Null(obj);

            Test.IfNot.ThrowsException(() => obj = new MyClass("asdf"), out ex);
            Test.IfNot.Null(obj);
            Test.If.ValuesEqual(obj.Content, "asdf");

            Test.IfNot.ThrowsException(() => obj = new MyClass("Hello World!"), out ex);
            Test.IfNot.Null(obj);
            Test.If.ValuesEqual(obj.Content, "Hello World!");

        }

        [TestMethod]
        void TestConstructorsAnotherWay() {

            MyClass obj = null;

            Test.If.ThrowsException(() => obj = new MyClass(null), out ArgumentNullException ex);
            Test.If.Null(obj);

            GenericTests.TestCtorGeneric("The quick brown fox");
            GenericTests.TestCtorGeneric("jumped over the lazy dog.");

            GenericTests.TestCtorGeneric("The sun went down in the east.");
            GenericTests.TestCtorGeneric("Holy crap, this is not astronomically correct.");

        }

        [TestMethod]
        void TestUsingCustomTests() {

            Test.If.IsHelloWorld("Hello World!");
            Test.IfNot.IsHelloWorld("Good bye World!");

        }

    }
}
