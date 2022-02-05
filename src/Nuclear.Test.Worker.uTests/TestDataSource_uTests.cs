using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.TestSite;

using TestDataSources = Nuclear.Test.Worker.Dummies.TestDataSources;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker {
    class TestDataSource_uTests {

        #region construction

        [TestMethod]
        void Ctor_Throws() {

            TestX.If.Action.ThrowsException(() => new TestDataSource(null), out ArgumentNullException ex);

            TestX.If.Value.IsEqual(ex.ParamName, "delegate");

        }

        [TestMethod]
        void Ctor() {

            TestX.IfNot.Action.ThrowsException(() => new TestDataSource(() => new TestDataSources().SingleReturnSingleData()), out ArgumentNullException ex);

        }

        #endregion

        #region GetData

        [TestMethod]
        void GetDataThrows() {

            TestDataSource sut = new TestDataSource(() => new TestDataSources().TripleReturnWithDummyException());
            IEnumerable<TestDataSet> dataSets = null;

            TestX.If.Action.ThrowsException(() => dataSets = sut.GetData().ToArray(), out Dummies.TestException _);

            TestX.If.Object.IsNull(dataSets);

        }

        [TestMethod]
        [TestData(nameof(GetData_Data))]
        void GetData(GetTestData in1, IEnumerable<Object[]> expected) {

            TestDataSource sut = new TestDataSource(in1);
            IEnumerable<TestDataSet> dataSets = null;

            TestX.IfNot.Action.ThrowsException(() => dataSets = sut.GetData().ToArray(), out Exception _);
            IEnumerable<Object[]> dataObjects = dataSets.Select(_ => { _.GetObjects(out Object[] data); return data; });
            IEnumerable<Object[]> expectedObjects = expected.ToArray();

            TestX.If.Value.IsEqual(dataObjects.Count(), expectedObjects.Count());
            TestX.If.Value.IsEqual(dataObjects.Format(), expectedObjects.Format());
            TestX.If.Enumerable.MatchesExactly(
                dataObjects.SelectMany(_ => _.Select(__ => __.Format())),
                expectedObjects.SelectMany(_ => _.Select(__ => __.Format())));
            TestX.If.Enumerable.MatchesExactly(
                dataObjects.SelectMany(_ => _.Select(__ => __ == null ? typeof(Object) : __.GetType())),
                expectedObjects.SelectMany(_ => _.Select(__ => __ == null ? typeof(Object) : __.GetType())));

        }

        IEnumerable<Object[]> GetData_Data() {
            yield return new Object[] { new GetTestData(() => new TestDataSources().SingleReturnSingleData()), new TestDataSources().SingleReturnSingleData() };
            yield return new Object[] { new GetTestData(() => new TestDataSources().SingleReturnTripleData()), new TestDataSources().SingleReturnTripleData() };
            yield return new Object[] { new GetTestData(() => new TestDataSources().TripleReturnSingleData()), new TestDataSources().TripleReturnSingleData() };
            yield return new Object[] { new GetTestData(() => new TestDataSources().TripleReturnTripleData()), new TestDataSources().TripleReturnTripleData() };
            yield return new Object[] { new GetTestData(() => new TestDataSources().TripleReturnMixedData()), new TestDataSources().TripleReturnMixedData() };
        }

        #endregion

    }
}
