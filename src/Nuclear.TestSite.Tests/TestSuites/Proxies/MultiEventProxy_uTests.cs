using System;
using System.ComponentModel;

namespace Nuclear.TestSite.TestSuites.Proxies {
    class MultiEventProxy_uTests {

        [TestMethod]
        void Ctor() {

            MultiEventProxy<PropertyChangedEventArgs> proxy = null;

            Test.IfNot.Action.ThrowsException(() => proxy = new MultiEventProxy<PropertyChangedEventArgs>(), out Exception ex);
            Test.If.Value.IsEqual(proxy.RaiseCount, 0);
            Test.If.Value.IsFalse(proxy.EventRaised);
            Test.IfNot.Object.IsNull(proxy.EventData);
            Test.If.Enumerable.IsEmpty(proxy.EventData);

        }

        [TestMethod]
        void OnEventRaised() {

            MultiEventProxy<PropertyChangedEventArgs> proxy = new MultiEventProxy<PropertyChangedEventArgs>();
            Object sender = new Object();
            PropertyChangedEventArgs e = new PropertyChangedEventArgs("dummy");
            EventDataCollection<PropertyChangedEventArgs> first = new EventDataCollection<PropertyChangedEventArgs>() {
                new EventData<PropertyChangedEventArgs>(null, null)
            };
            EventDataCollection<PropertyChangedEventArgs> second = new EventDataCollection<PropertyChangedEventArgs>() {
                new EventData<PropertyChangedEventArgs>(null, null),
                new EventData<PropertyChangedEventArgs>(sender, e)
            };

            Test.IfNot.Action.ThrowsException(() => proxy.OnEventRaised(null, null), out Exception ex);
            Test.If.Value.IsEqual(proxy.RaiseCount, 1);
            Test.If.Value.IsTrue(proxy.EventRaised);
            Test.If.Enumerable.MatchesExactly(proxy.EventData, first);

            Test.IfNot.Action.ThrowsException(() => proxy.OnEventRaised(sender, e), out ex);
            Test.If.Value.IsEqual(proxy.RaiseCount, 2);
            Test.If.Value.IsTrue(proxy.EventRaised);
            Test.If.Enumerable.MatchesExactly(proxy.EventData, second);

        }

    }
}
