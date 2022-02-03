using System;
using System.Linq;
using System.Reflection;

namespace Nuclear.Test.Worker.Dummies {
    internal class TestClassInternal {

        internal static MethodInfo MethodInfo_NoArgs { get; } = typeof(TestClassInternal).GetRuntimeMethods().First(_ => _.Name == nameof(Method_NoArgs));

        internal static MethodInfo MethodInfo_OneArg { get; } = typeof(TestClassInternal).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneArg));

        internal static MethodInfo MethodInfo_TwoArgs { get; } = typeof(TestClassInternal).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoArgs));

        internal static MethodInfo MethodInfo_OneGeneric_NoArgs { get; } = typeof(TestClassInternal).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneGeneric_NoArgs));

        internal static MethodInfo MethodInfo_OneGeneric_OneArg { get; } = typeof(TestClassInternal).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneGeneric_OneArg));

        internal static MethodInfo MethodInfo_TwoGeneric_TwoArgs { get; } = typeof(TestClassInternal).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoGeneric_TwoArgs));

        internal void Method_NoArgs() {
        }

        internal void Method_OneArg(String arg1) {
        }

        internal void Method_TwoArgs(String arg1, Object arg2) {
        }

        internal void Method_OneGeneric_NoArgs<T>() {
        }

        internal void Method_OneGeneric_OneArg<T>(String arg1) {
        }

        internal void Method_TwoGeneric_TwoArgs<T1, T2>(String arg1, Object arg2) {
        }

    }
}
