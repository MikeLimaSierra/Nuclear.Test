using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Test.Execution;
using Nuclear.Test.Results;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test {
    class ResultsAvailableEventArgs_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.IsSubClass<ResultsAvailableEventArgs, EventArgs>();

        }

        [TestMethod]
        void Ctor() {

            ResultsAvailableEventArgs e = null;

            TestX.If.Action.ThrowsException(() => e = new ResultsAvailableEventArgs(null), out ArgumentException ex);
            TestX.If.Value.IsEqual(ex.ParamName, "results");

            TestX.IfNot.Action.ThrowsException(() => e = new ResultsAvailableEventArgs(Enumerable.Empty<KeyValuePair<IResultKey, ITestMethodResult>>()), out Exception ex1);
            TestX.If.Enumerable.IsEmpty(e.Results);

        }

    }
}
