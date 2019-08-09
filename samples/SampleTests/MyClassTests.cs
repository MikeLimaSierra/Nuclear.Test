using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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

            Test.Note("new MyClass(null)");
            Test.If.ThrowsException(() => obj = new MyClass(null), out ArgumentNullException ex);
            Test.If.Null(obj);
            Test.IfNot.Null(ex);
            Test.If.ValuesEqual(ex.ParamName, "title");

            Test.Note("new MyClass(\"Hello World!\")");
            Test.IfNot.ThrowsException(() => obj = new MyClass("Hello World!"), out ex);
            Test.IfNot.Null(obj);
            Test.If.Null(ex);
            Test.If.ValuesEqual(obj.Title, "Hello World!");

        }

        [TestMethod]
        void TestConstructorsAnotherWay() {

            Test.Note("Test constructor with 'The quick brown fox'");
            GenericTests.TestCtorGeneric("The quick brown fox");
            Test.Note("Test constructor with 'jumped over the lazy dog.'");
            GenericTests.TestCtorGeneric("jumped over the lazy dog.");

            Test.Note("Test constructor with 'The sun went down in the east.'");
            GenericTests.TestCtorGeneric("The sun went down in the east.");
            Test.Note("Test constructor with 'Holy crap, this is not astronomically correct.'");
            GenericTests.TestCtorGeneric("Holy crap, this is not astronomically correct.");

        }

        [TestMethod]
        void TestConstructorsUsingTestExtensions() {

            MyClass obj = new MyClass("Hello World!");
            Test.If.IsHelloWorld(obj.Title);

            obj = new MyClass("Good bye World!");
            Test.IfNot.IsHelloWorld(obj.Title);

        }

        [TestMethod]
        void TestTitleProperty() {

            MyClass obj = new MyClass("asdf");

            Test.IfNot.ThrowsException(() => obj.Title = "new content", out Exception ex);
            Test.If.Null(ex);
            Test.If.ValuesEqual(obj.Title, "new content");

        }

        [TestMethod]
        void TestTitlePropertyChanged() {

            MyClass obj = new MyClass("asdf");

            Test.If.RaisesPropertyChangedEvent(obj, () => obj.Title = "new content", out Object sender, out PropertyChangedEventArgs e);
            Test.If.ReferencesEqual(obj, sender);
            Test.If.ValuesEqual(e.PropertyName, "Title");

        }

        [TestMethod]
        void TestToXml() {

            MyClass obj = new MyClass("asdf");
            XDocument doc = null;

            Test.IfNot.ThrowsException(() => doc = obj.ToXml(), out Exception ex);
            Test.If.Null(ex);
            Test.IfNot.Null(doc);
            Test.IfNot.Null(doc.Root);
            Test.If.ValuesEqual(doc.Root.Name.LocalName, "myroot");
            Test.If.True(doc.Root.HasAttributes);
            Test.If.ValuesEqual(doc.Root.Attributes().Count(), 3);
            Test.IfNot.Null(doc.Root.Attribute(XName.Get("mytitle")));
            Test.If.ValuesEqual(doc.Root.Attribute(XName.Get("mytitle")).Value, "asdf");
            Test.IfNot.Null(doc.Root.Attribute(XName.Get("calltimestamp")));
            Test.IfNot.Null(doc.Root.Attribute(XName.Get("waketimestamp")));

        }

        [TestMethod]
        void TestTimeStampEvent() {

            MyClass obj = new MyClass("asdf");
            XDocument doc = null;

            Test.If.RaisesEvent(obj, "TimeStampEvent", () => doc = obj.ToXml(), out Object sender, out MyCustomEventArgs e);
            Test.IfNot.Null(sender);
            Test.If.ReferencesEqual(sender, obj);
            Test.IfNot.Null(e);
            Test.IfNot.Null(e.XmlDoc);
            Test.IfNot.Null(e.WakeTimeStamp);
            Test.If.ValuesEqual(e.XmlDoc, doc);
            Test.If.ReferencesEqual(e.XmlDoc, doc);
            Test.IfNot.Null(e.CallTimeStamp);
            Test.If.ValuesEqual(e.XmlDoc.Root.Attribute(XName.Get("calltimestamp")).Value, e.CallTimeStamp.ToString("o"));
            Test.IfNot.Null(e.CallTimeStamp);
            Test.If.ValuesEqual(e.XmlDoc.Root.Attribute(XName.Get("waketimestamp")).Value, e.WakeTimeStamp.ToString("o"));

        }

    }

    // this is a test class with a bad name. test results in this class will be collected wrongly.
    //[TestClass]
    class MyOtherClassTests {

        //[TestMethod]
        void TestSomething() {
            FileInfo file = null;

            Test.Note("This test result will be registered to MyClassTests.TestSomething");
            Test.If.True(true);
            Test.Note("This test will cause an exception which will be registered to MyOtherClassTests.TestSomething");
            Test.If.StringStartsWith(file.FullName, "file:///");
        }
    }
}
