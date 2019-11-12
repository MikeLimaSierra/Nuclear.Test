using System;

namespace Nuclear.TestSite {

    /// <summary>
    /// Respresents the sender and event arguments of a raised event.
    /// </summary>
    /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
    public class EventData<TEventArgs> : Tuple<Object, TEventArgs>
        where TEventArgs : EventArgs {

        #region properties

        /// <summary>
        /// The sender of the event.
        /// </summary>
        public Object Sender => Item1;

        /// <summary>
        /// The event arguments sent with the event.
        /// </summary>
        public TEventArgs EventArgs => Item2;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="EventData{TEventArgs}"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public EventData(Object sender, TEventArgs e) : base(sender, e) { }

        #endregion

    }
}
