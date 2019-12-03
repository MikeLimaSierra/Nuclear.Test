using System;
using System.Collections.Concurrent;

namespace Nuclear.TestSite.EventData {
    class EventDataCollection_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<EventDataCollection<EventArgs>, BlockingCollection<EventData<EventArgs>>>();

        }
    }
}
