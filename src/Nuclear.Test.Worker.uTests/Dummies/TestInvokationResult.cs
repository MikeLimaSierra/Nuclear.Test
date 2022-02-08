using System;
using System.Collections.Generic;

namespace Nuclear.Test.Worker.Dummies {
    internal static class TestInvokationResult {

        internal static List<String> ActionResult { get; } = new List<String>();

        internal static List<Int32> InvokationHashCodes { get; } = new List<Int32>();

        internal static List<Int32> DisposeHashCodes { get; } = new List<Int32>();

    }
}
