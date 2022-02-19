using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Nuclear.Test.Worker.Dummies {
    internal class LongRunningTestClass : IDisposable {

        internal static MethodInfo MethodInfo_Do { get; } = typeof(LongRunningTestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Do));

        #region fields

        private TimeSpan _constructTime = TimeSpan.FromMilliseconds(1000);

        private TimeSpan _invokeTime = TimeSpan.FromMilliseconds(2000);

        private TimeSpan _disposeTime = TimeSpan.FromMilliseconds(3000);

        #endregion

        #region ctor

        internal LongRunningTestClass() {
            Thread.Sleep(_constructTime);
        }

        #endregion

        #region methods

        internal void Do() {
            Thread.Sleep(_invokeTime);
        }

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

        protected virtual void Dispose(Boolean disposing) {
            if(!_disposedValue) {
                if(disposing) {
                    // TODO: dispose managed state (managed objects)
                    Thread.Sleep(_disposeTime);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
