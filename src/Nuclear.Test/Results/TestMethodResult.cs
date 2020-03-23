using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuclear.Test.Results {
    internal class TestMethodResult : ITestMethodResult {

        #region properties

        public IList<ITestEntry> TestEntries { get; } = new List<ITestEntry>();

        public Int32 CountEntries
            => TestEntries.Where(result => result.EntryType == EntryTypes.ResultOk || result.EntryType == EntryTypes.ResultFail).Count();

        public Int32 CountResultsOk
            => TestEntries.Where(result => result.EntryType == EntryTypes.ResultOk).Count();

        public Int32 CountResultsFailed
            => TestEntries.Where(result => result.EntryType == EntryTypes.ResultFail).Count();

        public String IgnoreReason { get; private set; }


        public Boolean IsFailed => CountResultsFailed > 0;

        public Boolean IsIgnored => !String.IsNullOrWhiteSpace(IgnoreReason);

        public Boolean IsEmpty => CountEntries == 0;

        #endregion

        #region methods

        public void Ignore(String reason) => IgnoreReason = reason;

        #endregion

    }
}
