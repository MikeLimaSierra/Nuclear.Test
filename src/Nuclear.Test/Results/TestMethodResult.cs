using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuclear.Test.Results {
    internal class TestMethodResult : ITestMethodResult {

        #region properties

        public IList<ITestInstructionResult> InstructionResults { get; } = new List<ITestInstructionResult>();

        public Int32 CountResults => InstructionResults.Where(result => result.Result.HasValue).Count();

        public Int32 CountSuccesses => InstructionResults.Where(result => result.Result.HasValue && result.Result.Value).Count();

        public Int32 CountFails => InstructionResults.Where(result => result.Result.HasValue && !result.Result.Value).Count();

        public String FailMessage { get; private set; }

        public String IgnoreReason { get; private set; }


        public Boolean HasFails => CountFails > 0;

        public Boolean HasFailMessage => !String.IsNullOrWhiteSpace(FailMessage);

        public Boolean Failed => HasFails || HasFailMessage;

        public Boolean IsIgnored => !String.IsNullOrWhiteSpace(IgnoreReason);

        #endregion

        #region methods

        public void Fail(String message) => FailMessage = message;

        public void Ignore(String reason) => IgnoreReason = reason;

        #endregion

    }
}
