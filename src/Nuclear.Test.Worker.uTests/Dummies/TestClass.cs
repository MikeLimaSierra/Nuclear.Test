using System;
using System.Linq;
using System.Reflection;
using System.Text;

using Nuclear.Extensions;

namespace Nuclear.Test.Worker.Dummies {
    internal class TestClass {

        internal StringBuilder ActionResult { get; } = new StringBuilder();

        internal static MethodInfo MethodInfo_NoArgs { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_NoArgs));

        internal static MethodInfo MethodInfo_OneArg { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneArg));

        internal static MethodInfo MethodInfo_TwoArgs { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoArgs));

        internal static MethodInfo MethodInfo_OneGeneric_NoArgs { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneGeneric_NoArgs));

        internal static MethodInfo MethodInfo_OneGeneric_OneArg { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_OneGeneric_OneArg));

        internal static MethodInfo MethodInfo_TwoGeneric_TwoArgs { get; } = typeof(TestClass).GetRuntimeMethods().First(_ => _.Name == nameof(Method_TwoGeneric_TwoArgs));

        internal void Method_NoArgs() {
            ActionResult.AppendLine($"{nameof(MethodInfo_NoArgs)}()");
        }

        internal void Method_OneArg(String arg1) {
            ActionResult.AppendLine($"{nameof(Method_OneArg)}({arg1.Format()})");
        }

        internal void Method_TwoArgs(String arg1, Int32 arg2) {
            ActionResult.AppendLine($"{nameof(Method_TwoArgs)}({arg1.Format()}, {arg2.Format()})");
        }

        internal void Method_OneGeneric_NoArgs<T>() {
            ActionResult.AppendLine($"{nameof(Method_OneGeneric_NoArgs)}<{typeof(T).Format()}>()");
        }

        internal void Method_OneGeneric_OneArg<T>(String arg1) {
            ActionResult.AppendLine($"{nameof(Method_OneGeneric_OneArg)}<{typeof(T).Format()}>({arg1.Format()})");
        }

        internal void Method_TwoGeneric_TwoArgs<T1, T2>(String arg1, Int32 arg2) {
            ActionResult.AppendLine($"{nameof(Method_TwoGeneric_TwoArgs)}<{typeof(T1).Format()}, {typeof(T2).Format()}>({arg1.Format()}, {arg2.Format()})");
        }

    }
}
