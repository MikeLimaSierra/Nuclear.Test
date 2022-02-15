using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuclear.Test.Worker.TempTypes {
    internal class ResultEntryCollection : List<IResultEntry>, IResultEntryCollection {

        #region properties

        public Int32 CountRelevantEntries => CountResults + CountErrors;

        public Int32 CountResults => CountResultsOk + CountResultsFailed;

        public Int32 CountResultsOk => this.Where(_ => _.EntryType == EntryTypes.ResultOk).Count();

        public Int32 CountResultsFailed => this.Where(_ => _.EntryType == EntryTypes.ResultFail).Count();

        public Int32 CountErrors => this.Where(_ => _.EntryType == EntryTypes.Error).Count();

        public Boolean IsFailed => CountResultsFailed > 0 || CountErrors > 0;

        public Boolean IsEmpty => Count == 0;

        #endregion

        #region ctors

        internal ResultEntryCollection() : base() { }

        internal ResultEntryCollection(IEnumerable<IResultEntry> collection) : base(collection) { }

        #endregion

    }
}
