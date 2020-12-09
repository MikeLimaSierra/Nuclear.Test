using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using Nuclear.TestSite;

using Sample;

using TestExtensions;

namespace SampleTests {
    class MyClassTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<MyClass, INotifyPropertyChanged>();
            Test.IfNot.Type.Implements<MyClass, IDisposable>();

        }

        [TestMethod]
        void TestConstructors() {

            MyClass obj = null;

            Test.Note("new MyClass(null)");
            Test.If.Action.ThrowsException(() => obj = new MyClass(null), out ArgumentNullException ex);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Value.IsEqual(ex.ParamName, "title");

            Test.Note("new MyClass(\"Hello World!\")");
            Test.IfNot.Action.ThrowsException(() => obj = new MyClass("Hello World!"), out ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Object.IsNull(ex);
            Test.If.Value.IsEqual(obj.Title, "Hello World!");

        }

        [TestMethod]
        void TestConstructorsUsingTestExtensions() {

            MyClass obj = new MyClass("Hello World!");
            Test.If.String.IsHelloWorld(obj.Title);

            obj = new MyClass("Good bye World!");
            Test.IfNot.String.IsHelloWorld(obj.Title);

        }

        [TestMethod]
        void TestTitleProperty() {

            MyClass obj = new MyClass("asdf");

            Test.IfNot.Action.ThrowsException(() => obj.Title = "new content", out Exception ex);
            Test.If.Object.IsNull(ex);
            Test.If.Value.IsEqual(obj.Title, "new content");

        }

        [TestMethod]
        void TestTitlePropertyChanged() {

            MyClass obj = new MyClass("asdf");

            Test.If.Action.RaisesPropertyChangedEvent(() => obj.Title = "new content", obj, out EventData<PropertyChangedEventArgs> eventData);

            Test.IfNot.Object.IsNull(eventData.Sender);
            Test.If.Reference.IsEqual(eventData.Sender, obj);

            Test.If.Value.IsEqual(eventData.EventArgs.PropertyName, "Title");

        }

        [TestMethod]
        void TestToXml() {

            MyClass obj = new MyClass("asdf");
            XDocument doc = null;

            Test.IfNot.Action.ThrowsException(() => doc = obj.ToXml(), out Exception ex);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(doc);
            Test.IfNot.Object.IsNull(doc.Root);
            Test.If.Value.IsEqual(doc.Root.Name.LocalName, "myroot");
            Test.If.Value.IsTrue(doc.Root.HasAttributes);
            Test.If.Value.IsEqual(doc.Root.Attributes().Count(), 3);
            Test.IfNot.Object.IsNull(doc.Root.Attribute(XName.Get("mytitle")));
            Test.If.Value.IsEqual(doc.Root.Attribute(XName.Get("mytitle")).Value, "asdf");
            Test.IfNot.Object.IsNull(doc.Root.Attribute(XName.Get("calltimestamp")));
            Test.IfNot.Object.IsNull(doc.Root.Attribute(XName.Get("waketimestamp")));

        }

        [TestMethod]
        void TestTimeStampEvent() {

            MyClass obj = new MyClass("asdf");
            XDocument doc = null;

            Test.If.Action.RaisesEvent(() => doc = obj.ToXml(), obj, "TimeStampEvent", out EventData<MyCustomEventArgs> eventData);

            Test.IfNot.Object.IsNull(eventData.Sender);
            Test.If.Reference.IsEqual(eventData.Sender, obj);

            Test.IfNot.Object.IsNull(eventData);
            Test.IfNot.Object.IsNull(eventData.EventArgs.XmlDoc);
            Test.If.Value.IsEqual(eventData.EventArgs.XmlDoc, doc);
            Test.If.Reference.IsEqual(eventData.EventArgs.XmlDoc, doc);
            Test.IfNot.Object.IsNull(eventData.EventArgs.CallTimeStamp);
            Test.If.Value.IsEqual(eventData.EventArgs.XmlDoc.Root.Attribute(XName.Get("calltimestamp")).Value, eventData.EventArgs.CallTimeStamp.ToString("o"));
            Test.IfNot.Object.IsNull(eventData.EventArgs.WakeTimeStamp);
            Test.If.Value.IsEqual(eventData.EventArgs.XmlDoc.Root.Attribute(XName.Get("waketimestamp")).Value, eventData.EventArgs.WakeTimeStamp.ToString("o"));

        }

    }

    // this is a test class with a bad name. test results in this class will be collected wrongly.
    [TestClass]
    class MyOtherClassTests {

        [TestMethod(ignoreReason: "class name doesn't match file name.")]
        void TestSomething() {
            FileInfo file = null;

            Test.Note("This test result will be registered to MyClassTests.TestSomething");
            Test.If.Value.IsTrue(true);
            Test.Note("This test will cause an exception which will be registered to MyOtherClassTests.TestSomething");
            Test.If.String.StartsWith(file.FullName, "file:///");
        }
    }
}
