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
        [TestData(nameof(CtorThrows_Data))]
        void CtorThrows<T>(GetTestData in1, String in2, String expected) where T : ArgumentException {

            TestX.If.Action.ThrowsException(() => new TestDataSource(in1, in2), out T ex);

            TestX.If.Value.IsEqual(ex.ParamName, expected);

        }

        IEnumerable<Object[]> CtorThrows_Data() {
            yield return new Object[] { typeof(ArgumentNullException), null, null, "delegate" };
            yield return new Object[] { typeof(ArgumentNullException), null, "", "delegate" };
            yield return new Object[] { typeof(ArgumentNullException), null, "SomeTestDataSource", "delegate" };
            yield return new Object[] { typeof(ArgumentNullException), new GetTestData(() => Enumerable.Empty<Object[]>()), null, "sourceString" };
            yield return new Object[] { typeof(ArgumentException), new GetTestData(() => Enumerable.Empty<Object[]>()), "", "sourceString" };
            yield return new Object[] { typeof(ArgumentException), new GetTestData(() => Enumerable.Empty<Object[]>()), " ", "sourceString" };
        }

        [TestMethod]
        void Ctor() {

            TestDataSource sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new TestDataSource(() => Enumerable.Empty<Object[]>(), "SomeTestDataSource"), out ArgumentNullException ex);

            TestX.If.Value.IsEqual(sut.SourceString, "SomeTestDataSource");

        }

        #endregion

        #region GetData

        [TestMethod]
        void GetDataThrows() {

            TestDataSource sut = new TestDataSource(() => new TestDataSources().TripleReturnWithDummyException(), "SomeTestDataSource");
            IEnumerable<TestDataSet> dataSets = null;

            TestX.If.Action.ThrowsException(() => dataSets = sut.GetData().ToArray(), out Dummies.TestException _);

            TestX.If.Object.IsNull(dataSets);

        }

        [TestMethod]
        [TestData(nameof(GetData_Data))]
        void GetData(GetTestData in1, IEnumerable<Object[]> expected) {

            TestDataSource sut = new TestDataSource(in1, "SomeTestDataSource");
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
