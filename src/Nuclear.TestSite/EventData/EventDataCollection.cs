using System;
using System.Collections.Concurrent;

namespace Nuclear.TestSite {

    /// <summary>
    /// Represents a collection of <see cref="EventData{TEventArgs}"/> objects.
    /// </summary>
    /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
    public class EventDataCollection<TEventArgs> : BlockingCollection<EventData<TEventArgs>>
        where TEventArgs : EventArgs {
    }
}
