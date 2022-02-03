using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker {
    class TestMethodDataSource_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestMethodDataSource, ITestMethodDataSource>();

        }

        #region construction

        [TestMethod]
        void Ctor_Throws() {

            TestX.If.Action.ThrowsException(() => new TestMethodDataSource(null), out ArgumentNullException ex);

            TestX.If.Value.IsEqual(ex.ParamName, "delegate");

        }

        [TestMethod]
        void Ctor() {

            TestX.IfNot.Action.ThrowsException(() => new TestMethodDataSource(() => new Dummies.TestDataSourcesInternal().SingleReturnSingleData()), out ArgumentNullException ex);

        }

        #endregion

        #region GetData

        [TestMethod]
        void GetDataThrows() {

            ITestMethodDataSource sut = new TestMethodDataSource(() => new Dummies.TestDataSourcesInternal().TripleReturnWithDummyException());
            IEnumerable<ITestDataSet> dataSets = null;

            TestX.If.Action.ThrowsException(() => dataSets = sut.GetData().ToArray(), out Dummies.DummyException _);

            TestX.If.Object.IsNull(dataSets);

        }

        [TestMethod]
        [TestData(nameof(GetData_Data))]
        void GetData(GetTestData in1, IEnumerable<Object[]> expected) {

            ITestMethodDataSource sut = new TestMethodDataSource(in1);
            IEnumerable<ITestDataSet> dataSets = null;

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
            yield return new Object[] { new GetTestData(() => new Dummies.TestDataSourcesInternal().SingleReturnSingleData()), new Dummies.TestDataSourcesInternal().SingleReturnSingleData() };
            yield return new Object[] { new GetTestData(() => new Dummies.TestDataSourcesInternal().SingleReturnTripleData()), new Dummies.TestDataSourcesInternal().SingleReturnTripleData() };
            yield return new Object[] { new GetTestData(() => new Dummies.TestDataSourcesInternal().TripleReturnSingleData()), new Dummies.TestDataSourcesInternal().TripleReturnSingleData() };
            yield return new Object[] { new GetTestData(() => new Dummies.TestDataSourcesInternal().TripleReturnTripleData()), new Dummies.TestDataSourcesInternal().TripleReturnTripleData() };
            yield return new Object[] { new GetTestData(() => new Dummies.TestDataSourcesInternal().TripleReturnMixedData()), new Dummies.TestDataSourcesInternal().TripleReturnMixedData() };
        }

        #endregion

    }
}
