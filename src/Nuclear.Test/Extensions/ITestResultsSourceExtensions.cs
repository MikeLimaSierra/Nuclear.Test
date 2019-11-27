using System.Collections.Generic;
using System.Linq;
using Nuclear.Extensions;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Extensions {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class ITestResultsSourceExtensions {

        private static readonly IEqualityComparer<TestResultKey> _comparer = DynamicEqualityComparer<TestResultKey>.From((x, y) => x.Equals(y), (obj) => obj.GetHashCode());


        public static IEnumerable<TestResultKey> GetKeys(this ITestResultsSource _this, TestResultKey match)
            => _this.Keys.Where(key => key.Matches(match));

        public static IEnumerable<TestResultKey> GetKeys(this ITestResultsSource _this, TestResultKey match, TestResultKeyPrecisions precision) {
            List<TestResultKey> keys = new List<TestResultKey>();

            foreach(TestResultKey key in _this.GetKeys(match)) {
                TestResultKey clippedKey = key.Clip(precision);

                if(!keys.Contains(clippedKey, _comparer)) {
                    keys.Add(clippedKey);
                }
            }

            return keys;
        }

        public static IEnumerable<TestMethodResult> GetResults(this ITestResultsSource _this, TestResultKey match)
            => _this.Values.Where(value => value.Key.Matches(match)).Select(value => value.Value);

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
