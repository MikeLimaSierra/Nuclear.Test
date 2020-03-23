using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuclear.Test.Results {
    internal class TestMethodResult : ITestMethodResult {

        #region properties

        public IList<ITestInstructionResult> InstructionResults { get; } = new List<ITestInstructionResult>();

        public Int32 CountResults => InstructionResults.Where(result => result.Result.HasValue).Count();

        public Int32 CountResultsOk => InstructionResults.Where(result => result.Result.HasValue && result.Result.Value).Count();

        public Int32 CountResultsFailed => InstructionResults.Where(result => result.Result.HasValue && !result.Result.Value).Count();

        public String IgnoreReason { get; private set; }


        public Boolean IsFailed => CountResultsFailed > 0;

        public Boolean IsIgnored => !String.IsNullOrWhiteSpace(IgnoreReason);

        public Boolean IsEmpty => CountResults == 0;

        #endregion

        #region methods

        public void Ignore(String reason) => IgnoreReason = reason;

        #endregion

    }
}
