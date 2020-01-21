using System;
using System.ComponentModel;

namespace Nuclear.TestSite.TestSuites.Proxies {
    class EventProxy_uTests {

        [TestMethod]
        void Ctor() {

            EventProxy<PropertyChangedEventArgs> proxy = null;

            Test.IfNot.Action.ThrowsException(() => proxy = new EventProxy<PropertyChangedEventArgs>(), out Exception ex);
            Test.If.Value.IsFalse(proxy.EventRaised);
            Test.If.Object.IsNull(proxy.EventData);

        }

        [TestMethod]
        void OnEventRaised() {

            EventProxy<PropertyChangedEventArgs> proxy = new EventProxy<PropertyChangedEventArgs>();
            Object sender = new Object();
            PropertyChangedEventArgs e = new PropertyChangedEventArgs("dummy");

            Test.IfNot.Action.ThrowsException(() => proxy.OnEventRaised(null, null), out Exception ex);
            Test.If.Value.IsTrue(proxy.EventRaised);
            Test.IfNot.Object.IsNull(proxy.EventData);
            Test.If.Object.IsNull(proxy.EventData.Sender);
            Test.If.Object.IsNull(proxy.EventData.EventArgs);

            Test.IfNot.Action.ThrowsException(() => proxy.OnEventRaised(sender, e), out ex);
            Test.If.Value.IsTrue(proxy.EventRaised);
            Test.IfNot.Object.IsNull(proxy.EventData);
            Test.If.Reference.IsEqual(proxy.EventData.Sender, sender);
            Test.If.Reference.IsEqual(proxy.EventData.EventArgs, e);

        }

    }
}
