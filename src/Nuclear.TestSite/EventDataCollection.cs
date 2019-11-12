using System;
using System.Collections.Generic;

namespace Nuclear.TestSite {

    /// <summary>
    /// Represents a collection of <see cref="EventData{TEventArgs}"/> objects.
    /// </summary>
    /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
    public class EventDataCollection<TEventArgs> : List<EventData<TEventArgs>>
        where TEventArgs : EventArgs {
    }
}
