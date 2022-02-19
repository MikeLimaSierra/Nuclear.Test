using System;

namespace Nuclear.Test.Worker.TempTypes {
    internal class TestMethodResults : ITestMethodResults {

        #region properties

        public IResultEntryCollection Entries { get; } = new ResultEntryCollection();

        public String IgnoreReason { get; internal set; }

        public Boolean IsIgnored => !String.IsNullOrWhiteSpace(IgnoreReason);

        public TimeSpan RunTime { get; internal set; }

        public TimeSpan ConstructionTime { get; internal set; }

        public TimeSpan InvokationTime { get; internal set; }

        public TimeSpan DestructionTime { get; internal set; }

        #endregion

        #region ctors

        internal TestMethodResults(String ignoreReason) {
            IgnoreReason = ignoreReason;
        }

        #endregion

    }
}
