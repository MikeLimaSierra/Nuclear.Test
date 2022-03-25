using System;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker {
    class ResultsSink_uTests {

        #region ctor

        [TestMethod]
        void CtorThrows() {

            TestX.If.Action.ThrowsException(() => new ResultsSink(null), out ArgumentNullException ex);

            TestX.If.Value.IsEqual(ex.ParamName, "scenario");

        }

        [TestMethod]
        void Ctor() {

            ResultsSink sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new ResultsSink(Statics.DefaultScenario), out Exception _);

            TestX.IfNot.Object.IsNull(sut);
            TestX.IfNot.Object.IsNull(sut._results);
            TestX.If.Enumerable.IsEmpty(sut._results);

        }

        #endregion

        #region Prepare

        //[TestMethod]
        //void Prepare(Scenario in1, MethodInfo in2) {

        //    ResultsSink sut = new ResultsSink(in1);

        //    TestX.IfNot.Action.ThrowsException(() => sut.Prepare(in2), out Exception _);

        //}

        #endregion

    }
}
