using System.Collections.Generic;
using System.Linq;
using Nuclear.Test.Results;

namespace Nuclear.Test.Extensions {
    internal static class ITestResultsSourceExtensions {

        private static readonly IEqualityComparer<ITestResultKey> _comparer = new TestResultKeyEqualityComparer();


        public static IEnumerable<ITestResultKey> GetKeys(this ITestResultSource _this, ITestResultKey match)
            => _this.Keys.Where(key => key.Matches(match));

        public static IEnumerable<ITestResultKey> GetKeys(this ITestResultSource _this, ITestResultKey match, TestResultKeyPrecisions precision) {
            List<ITestResultKey> keys = new List<ITestResultKey>();

            foreach(ITestResultKey key in _this.GetKeys(match)) {
                ITestResultKey clippedKey = key.Clip(precision);

                if(!keys.Contains(clippedKey, _comparer)) {
                    keys.Add(clippedKey);
                }
            }

            return keys;
        }

        public static IEnumerable<ITestMethodResult> GetResults(this ITestResultSource _this, ITestResultKey match)
            => _this.Values.Where(value => value.Key.Matches(match)).Select(value => value.Value);

    }
}
