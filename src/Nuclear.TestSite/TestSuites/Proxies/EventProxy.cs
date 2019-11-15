using System;

namespace Nuclear.TestSite.TestSuites.Proxies {
    internal class EventProxy<TEventArgs>
             where TEventArgs : EventArgs {

        internal Boolean EventRaised { get; private set; } = false;

        internal EventData<TEventArgs> EventData { get; private set; }

        internal void OnEventRaised(Object sender, TEventArgs e) {
            EventRaised = true;
            EventData = new EventData<TEventArgs>(sender, e);
        }

    }
}
