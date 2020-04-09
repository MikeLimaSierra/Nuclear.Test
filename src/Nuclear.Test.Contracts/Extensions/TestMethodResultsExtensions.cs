using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Results;

namespace Nuclear.Test.Extensions {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class TestMethodResultsExtensions {

        public static Int32 CountEntries(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountEntries);

        public static Int32 CountRelevantEntries(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountRelevantEntries);

        public static Int32 CountResults(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountResults);

        public static Int32 CountResultsOk(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountResultsOk);

        public static Int32 CountResultsFailed(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountResultsFailed);

        public static Int32 CountErrors(this IEnumerable<ITestMethodResult> _this)
            => _this.Sum(results => results.CountErrors);

        public static Boolean HasFails(this IEnumerable<ITestMethodResult> _this)
            => _this.Any(results => results.IsFailed);

        public static Boolean HasIgnores(this IEnumerable<ITestMethodResult> _this)
            => _this.Any(results => results.IsIgnored);

        public static Boolean HasBlanks(this IEnumerable<ITestMethodResult> _this)
            => _this.Any(results => results.IsEmpty);

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
