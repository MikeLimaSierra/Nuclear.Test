using System;
using System.Threading;

namespace Nuclear.TestSite.TestSuites.Proxies {
    internal class MultiEventProxy<TEventArgs>
              where TEventArgs : EventArgs {

        private Int32 _raiseCount = 0;

        internal Int32 RaiseCount => _raiseCount;

        internal Boolean EventRaised => RaiseCount > 0;

        internal EventDataCollection<TEventArgs> EventData { get; private set; } = new EventDataCollection<TEventArgs>();

        internal void OnEventRaised(Object sender, TEventArgs e) {
            Interlocked.Increment(ref _raiseCount);
            EventData.Add(new EventData<TEventArgs>(sender, e));
        }

    }
}
