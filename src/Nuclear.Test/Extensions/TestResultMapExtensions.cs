using System;
using Nuclear.Test.Results;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Extensions {
    internal static class TestResultMapExtensions {

        internal static Int32 GetResultsTotal(this TestResultMap _this, ResultKeyAssemblyNameLevel key) => _this.GetResultsTotal(key);

        internal static Int32 GetResultsTotal(this TestResultMap _this, ResultKeyTargetRuntimeLevel key) => _this.GetResultsTotal(key);

        internal static Int32 GetResultsTotal(this TestResultMap _this, ResultKeyArchitectureLevel key) => _this.GetResultsTotal(key);

        internal static Int32 GetResultsTotal(this TestResultMap _this, ResultKeyExecutionRuntimeLevel key) => _this.GetResultsTotal(key);

        internal static Int32 GetResultsTotal(this TestResultMap _this, ResultKeyFileLevel key) => _this.GetResultsTotal(key);


        internal static Int32 GetResultsOk(this TestResultMap _this, ResultKeyAssemblyNameLevel key) => _this.GetResultsOk(key);

        internal static Int32 GetResultsOk(this TestResultMap _this, ResultKeyTargetRuntimeLevel key) => _this.GetResultsOk(key);

        internal static Int32 GetResultsOk(this TestResultMap _this, ResultKeyArchitectureLevel key) => _this.GetResultsOk(key);

        internal static Int32 GetResultsOk(this TestResultMap _this, ResultKeyExecutionRuntimeLevel key) => _this.GetResultsOk(key);

        internal static Int32 GetResultsOk(this TestResultMap _this, ResultKeyFileLevel key) => _this.GetResultsOk(key);


        internal static Int32 GetResultsFailed(this TestResultMap _this, ResultKeyAssemblyNameLevel key) => _this.GetResultsFailed(key);

        internal static Int32 GetResultsFailed(this TestResultMap _this, ResultKeyTargetRuntimeLevel key) => _this.GetResultsFailed(key);

        internal static Int32 GetResultsFailed(this TestResultMap _this, ResultKeyArchitectureLevel key) => _this.GetResultsFailed(key);

        internal static Int32 GetResultsFailed(this TestResultMap _this, ResultKeyExecutionRuntimeLevel key) => _this.GetResultsFailed(key);

        internal static Int32 GetResultsFailed(this TestResultMap _this, ResultKeyFileLevel key) => _this.GetResultsFailed(key);


        internal static Boolean HasFailedTests(this TestResultMap _this, ResultKeyAssemblyNameLevel key) => _this.HasFailedTests(key);

        internal static Boolean HasFailedTests(this TestResultMap _this, ResultKeyTargetRuntimeLevel key) => _this.HasFailedTests(key);

        internal static Boolean HasFailedTests(this TestResultMap _this, ResultKeyArchitectureLevel key) => _this.HasFailedTests(key);

        internal static Boolean HasFailedTests(this TestResultMap _this, ResultKeyExecutionRuntimeLevel key) => _this.HasFailedTests(key);

        internal static Boolean HasFailedTests(this TestResultMap _this, ResultKeyFileLevel key) => _this.HasFailedTests(key);

    }
}
