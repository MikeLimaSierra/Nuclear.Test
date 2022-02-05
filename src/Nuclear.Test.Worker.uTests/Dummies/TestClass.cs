using System;
using System.Linq;
using System.Reflection;

using Nuclear.Extensions;

namespace Nuclear.Test.Worker.Dummies {
    internal class TestClass {

        internal static MethodInfo MethodInfo_NoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_NoA));

        internal static MethodInfo MethodInfo_OneA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneA));

        internal static MethodInfo MethodInfo_TwoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoA));

        internal static MethodInfo MethodInfo_OneG_NoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneG_NoA));

        internal static MethodInfo MethodInfo_OneG_OneA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneG_OneA));

        internal static MethodInfo MethodInfo_TwoG_TwoA { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoG_TwoA));

        internal void Method_NoA() {
            TestResult.ActionResult.AppendLine($"{nameof(MethodInfo_NoA)}()");
        }

        internal void Method_OneA(String arg1) {
            TestResult.ActionResult.AppendLine($"{nameof(Method_OneA)}({arg1.Format()})");
        }

        internal void Method_TwoA(String arg1, Int32 arg2) {
            TestResult.ActionResult.AppendLine($"{nameof(Method_TwoA)}({arg1.Format()}, {arg2.Format()})");
        }

        internal void Method_OneG_NoA<T>() {
            TestResult.ActionResult.AppendLine($"{nameof(Method_OneG_NoA)}<{typeof(T).Format()}>()");
        }

        internal void Method_OneG_OneA<T>(String arg1) {
            TestResult.ActionResult.AppendLine($"{nameof(Method_OneG_OneA)}<{typeof(T).Format()}>({arg1.Format()})");
        }

        internal void Method_TwoG_TwoA<T1, T2>(String arg1, Int32 arg2) {
            TestResult.ActionResult.AppendLine($"{nameof(Method_TwoG_TwoA)}<{typeof(T1).Format()}, {typeof(T2).Format()}>({arg1.Format()}, {arg2.Format()})");
        }

    }
}
