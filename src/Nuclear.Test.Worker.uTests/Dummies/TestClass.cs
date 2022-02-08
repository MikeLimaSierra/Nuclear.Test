using System;
using System.Linq;
using System.Reflection;

using Nuclear.Extensions;

namespace Nuclear.Test.Worker.Dummies {
    internal class TestClass : IDisposable {

        internal static MethodInfo MethodInfo_NoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_NoA));

        internal static MethodInfo MethodInfo_OneA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneA));

        internal static MethodInfo MethodInfo_TwoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoA));

        internal static MethodInfo MethodInfo_OneG_NoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneG_NoA));

        internal static MethodInfo MethodInfo_OneG_OneA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneG_OneA));

        internal static MethodInfo MethodInfo_TwoG_TwoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoG_TwoA));

        internal void Method_NoA() {
            TestInvokationResult.ActionResult.Add($"{nameof(Method_NoA)}()");
            TestInvokationResult.InvokationHashCodes.Add(GetHashCode());
        }

        internal void Method_OneA(String arg1) {
            TestInvokationResult.ActionResult.Add($"{nameof(Method_OneA)}({arg1.Format()})");
            TestInvokationResult.InvokationHashCodes.Add(GetHashCode());
        }

        internal void Method_TwoA(String arg1, Int32 arg2) {
            TestInvokationResult.ActionResult.Add($"{nameof(Method_TwoA)}({arg1.Format()}, {arg2.Format()})");
            TestInvokationResult.InvokationHashCodes.Add(GetHashCode());
        }

        internal void Method_OneG_NoA<T>() {
            TestInvokationResult.ActionResult.Add($"{nameof(Method_OneG_NoA)}<{typeof(T).Format()}>()");
            TestInvokationResult.InvokationHashCodes.Add(GetHashCode());
        }

        internal void Method_OneG_OneA<T>(String arg1) {
            TestInvokationResult.ActionResult.Add($"{nameof(Method_OneG_OneA)}<{typeof(T).Format()}>({arg1.Format()})");
            TestInvokationResult.InvokationHashCodes.Add(GetHashCode());
        }

        internal void Method_TwoG_TwoA<T1, T2>(String arg1, Int32 arg2) {
            TestInvokationResult.ActionResult.Add($"{nameof(Method_TwoG_TwoA)}<{typeof(T1).Format()}, {typeof(T2).Format()}>({arg1.Format()}, {arg2.Format()})");
            TestInvokationResult.InvokationHashCodes.Add(GetHashCode());
        }

        #region IDisposable

        private Boolean _disposedValue;

        protected virtual void Dispose(Boolean disposing) {
            if(!_disposedValue) {
                if(disposing) {
                    // TODO: dispose managed state (managed objects)
                    TestInvokationResult.DisposeHashCodes.Add(GetHashCode());
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
