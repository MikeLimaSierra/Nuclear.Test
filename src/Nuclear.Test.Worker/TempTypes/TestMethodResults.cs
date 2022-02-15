using System;

namespace Nuclear.Test.Worker.TempTypes {
    internal class TestMethodResults : ITestMethodResults {

        #region properties

        public IResultEntryCollection Entries { get; } = new ResultEntryCollection();

        public String IgnoreReason { get; internal set; }

        public Boolean IsIgnored => !String.IsNullOrWhiteSpace(IgnoreReason);

        #endregion

        #region ctors

        internal TestMethodResults(String ignoreReason) {
            IgnoreReason = ignoreReason;
        }

        #endregion

    }
}
