using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.Core.uTests {
    class TestMethodInfo_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestMethodInfo, ITestMethodInfo>();

        }

        #region construction

        [TestMethod]
        void CtorThrows() {

            TestX.If.Action.ThrowsException(() => new TestMethodInfo(null), out ArgumentNullException ex);

            TestX.If.Value.IsEqual(ex.ParamName, "method");

        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(MethodInfo in1, (String file, String method, Boolean hasParams, Int32 @params, Boolean isGeneric, Int32 genParams, Int32 repeat, TestMode mode) expected) {

            ITestMethodInfo sut = null;

            TestX.IfNot.Action.ThrowsException(() => sut = new TestMethodInfo(in1), out Exception _);

            TestX.If.Value.IsEqual(sut.FileName, expected.file);
            TestX.If.Value.IsEqual(sut.MethodName, expected.method);
            TestX.If.Value.IsEqual(sut.HasParameters, expected.hasParams);
            TestX.If.Value.IsEqual(sut.ParameterCount, expected.@params);
            TestX.If.Value.IsEqual(sut.IsGeneric, expected.isGeneric);
            TestX.If.Value.IsEqual(sut.GenericParameterCount, expected.genParams);
            TestX.If.Value.IsEqual(sut.RepeatCount, expected.repeat);
            TestX.If.Value.IsEqual(sut.TestMode, expected.mode);
            TestX.IfNot.Object.IsNull(sut.DataSources);
            TestX.If.Enumerable.IsEmpty(sut.DataSources);

        }

        IEnumerable<Object[]> Ctor_Data() {
            return new List<Object[]>() {
                new Object[] { Dummies.TestClassInternal.MethodInfo_NoArgs,
                    (nameof(Dummies.TestClassInternal), nameof(Dummies.TestClassInternal.Method_NoArgs), false, 0, false, 0, 1, TestSite.TestMode.Parallel) },
                new Object[] { Dummies.TestClassInternal.MethodInfo_OneArg,
                    (nameof(Dummies.TestClassInternal), nameof(Dummies.TestClassInternal.Method_OneArg), true, 1, false, 0, 1, TestSite.TestMode.Parallel) },
                new Object[] { Dummies.TestClassInternal.MethodInfo_TwoArgs,
                    (nameof(Dummies.TestClassInternal), nameof(Dummies.TestClassInternal.Method_TwoArgs), true, 2, false, 0, 1, TestSite.TestMode.Parallel) },
                new Object[] { Dummies.TestClassInternal.MethodInfo_OneGeneric_NoArgs,
                    (nameof(Dummies.TestClassInternal), nameof(Dummies.TestClassInternal.Method_OneGeneric_NoArgs), false, 0, true, 1, 1, TestSite.TestMode.Parallel) },
                new Object[] { Dummies.TestClassInternal.MethodInfo_OneGeneric_OneArg,
                    (nameof(Dummies.TestClassInternal), nameof(Dummies.TestClassInternal.Method_OneGeneric_OneArg), true, 1, true, 1, 1, TestSite.TestMode.Parallel) },
                new Object[] { Dummies.TestClassInternal.MethodInfo_TwoGeneric_TwoArgs,
                    (nameof(Dummies.TestClassInternal), nameof(Dummies.TestClassInternal.Method_TwoGeneric_TwoArgs), true, 2, true, 2, 1, TestSite.TestMode.Parallel) },
            };
        }

        #endregion

        #region properties

        [TestMethod]
        [TestParameters(0, 1)]
        [TestParameters(1, 1)]
        [TestParameters(-1, 1)]
        [TestParameters(Int32.MinValue, 1)]
        [TestParameters(2, 2)]
        [TestParameters(8, 8)]
        [TestParameters(Int32.MaxValue, Int32.MaxValue)]
        void RepeatCount(Int32 in1, Int32 expected) {

            ITestMethodInfo sut = new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_NoArgs);

            TestX.IfNot.Action.ThrowsException(() => sut.RepeatCount = in1, out Exception _);

            TestX.If.Value.IsEqual(sut.RepeatCount, expected);

        }

        [TestMethod]
        [TestParameters(TestSite.TestMode.Parallel, TestSite.TestMode.Parallel)]
        [TestParameters(TestSite.TestMode.Sequential, TestSite.TestMode.Sequential)]
        [TestParameters((TestMode) 42, TestSite.TestMode.Parallel)]
        void TestMode(TestMode in1, TestMode expected) {

            ITestMethodInfo sut = new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_NoArgs);

            TestX.IfNot.Action.ThrowsException(() => sut.TestMode = in1, out Exception _);

            TestX.If.Value.IsEqual(sut.TestMode, expected);

        }

        #endregion

        #region AddData

        [TestMethod]
        [TestData(nameof(AddFirstData_Data))]
        void AddFirstData(ITestDataSource in1, Int32 expected) {

            ITestMethodInfo sut = new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_NoArgs);

            TestX.IfNot.Action.ThrowsException(() => sut.AddData(in1), out Exception _);

            if(in1 != null) {
                TestX.If.Enumerable.Contains(sut.DataSources, in1);
            } else {
                TestX.IfNot.Enumerable.Contains(sut.DataSources, in1);
            }

            TestX.If.Value.IsEqual(sut.DataSources.Count(), expected);

        }

        IEnumerable<Object[]> AddFirstData_Data() {
            return new List<Object[]>() {
                new Object[] { null, 0 },
                new Object[] { new TestDataSource(() => new Dummies.TestDataSourcesInternal().TripleReturnMixedData()), 1 },
            };
        }

        [TestMethod]
        [TestData(nameof(AddSecondData_Data))]
        void AddSecondData(ITestDataSource in1, Int32 expected) {

            ITestMethodInfo sut = new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_NoArgs);
            sut.AddData(new TestDataSource(() => new Dummies.TestDataSourcesInternal().SingleReturnSingleData()));

            TestX.IfNot.Action.ThrowsException(() => sut.AddData(in1), out Exception _);

            if(in1 != null) {
                TestX.If.Enumerable.Contains(sut.DataSources, in1);
                TestX.If.Reference.IsEqual(sut.DataSources.Last(), in1);
            } else {
                TestX.IfNot.Enumerable.Contains(sut.DataSources, in1);
            }

            TestX.If.Value.IsEqual(sut.DataSources.Count(), expected);

        }

        IEnumerable<Object[]> AddSecondData_Data() {
            return new List<Object[]>() {
                new Object[] { null, 1 },
                new Object[] { new TestDataSource(() => new Dummies.TestDataSourcesInternal().TripleReturnMixedData()), 2 },
            };
        }

        #endregion

    }
}
