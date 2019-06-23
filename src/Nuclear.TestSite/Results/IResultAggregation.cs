using System;

namespace Nuclear.TestSite.Results {
    internal interface IResultAggregation {

        #region properties

        Int32 ResultsTotal { get; }

        Int32 ResultsOk { get; }

        Int32 ResultsFailed { get; }

        Boolean HasFails { get; }

        #endregion

    }
}
