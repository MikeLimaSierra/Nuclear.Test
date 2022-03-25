using System;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker {
    class ResultsSink_uTests {

        #region ctor

        [TestMethod]
        void Ctor() {

            ResultsSink sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new ResultsSink(), out Exception _);

            TestX.IfNot.Object.IsNull(sut);
            TestX.IfNot.Object.IsNull(sut._results);
            TestX.If.Enumerable.IsEmpty(sut._results);

        }

        #endregion

    }
}
