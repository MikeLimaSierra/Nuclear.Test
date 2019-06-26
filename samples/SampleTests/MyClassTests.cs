using System;
using System.ComponentModel;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;
using Sample;
using TestExtensions;

namespace SampleTests {
    class MyClassTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<MyClass, INotifyPropertyChanged>();
            Test.IfNot.TypeImplements<MyClass, IDisposable>();

        }

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

            GenericTests.TestCtorGeneric("The quick brown fox");
            GenericTests.TestCtorGeneric("jumped over the lazy dog.");

            GenericTests.TestCtorGeneric("The sun went down in the east.");
            GenericTests.TestCtorGeneric("Holy crap, this is not astronomically correct.");

        }

        [TestMethod]
        void TestUsingTestExtensions() {

            Test.If.IsHelloWorld("Hello World!");
            Test.IfNot.IsHelloWorld("Good bye World!");

        }

        [TestMethod]
        void TestContentProperty() {

            MyClass obj = new MyClass("asdf");

            Test.IfNot.ThrowsException(() => obj.Content = "new content", out Exception ex);
            Test.If.Null(ex);
            Test.If.ValuesEqual(obj.Content, "new content");

        }

        [TestMethod]
        void TestPropertyChanged() {

            MyClass obj = new MyClass("asdf");

            Test.If.RaisesPropertyChangedEvent(obj, () => obj.Content = "new content", out Object sender, out PropertyChangedEventArgs e);
            Test.If.ReferencesEqual(obj, sender);
            Test.If.ValuesEqual(e.PropertyName, "Content");

        }

    }
}
