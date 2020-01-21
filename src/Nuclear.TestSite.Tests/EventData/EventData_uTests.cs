using System;
using System.ComponentModel;

namespace Nuclear.TestSite {
    class EventData_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<EventData<EventArgs>, Tuple<Object, EventArgs>>();

        }

        [TestMethod]
        void Ctor() {

            EventData<PropertyChangedEventArgs> eventData = null;
            Object sender = new Object();
            PropertyChangedEventArgs e = new PropertyChangedEventArgs("dummy");

            Test.IfNot.Action.ThrowsException(() => eventData = new EventData<PropertyChangedEventArgs>(sender, e), out Exception ex);
            Test.IfNot.Object.IsNull(eventData);
            Test.If.Reference.IsEqual(sender, eventData.Sender);
            Test.If.Reference.IsEqual(e.PropertyName, eventData.EventArgs.PropertyName);

        }

        [TestMethod]
        void Properties() {

            Object sender = new Object();
            PropertyChangedEventArgs e = new PropertyChangedEventArgs("dummy");
            EventData<PropertyChangedEventArgs> eventData = new EventData<PropertyChangedEventArgs>(sender, e);

            Test.If.Reference.IsEqual(eventData.Sender, eventData.Item1);
            Test.If.Reference.IsEqual(eventData.EventArgs, eventData.Item2);

        }

    }
}
