using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Results;

namespace Nuclear.Test.Extensions {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class TestMethodResultsExtensions {

        public static Int32 CountResults(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountResults);

        public static Int32 CountSuccesses(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountSuccesses);

        public static Int32 CountFails(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountFails);

        public static Boolean HasFails(this IEnumerable<ITestMethodResult> _this)
            => _this.Any(results => results.HasFails);

        public static Boolean Failed(this IEnumerable<ITestMethodResult> _this)
            => _this.Any(results => results.Failed);

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
