using System;
using System.Collections.Generic;

using Nuclear.Extensions;
using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker {
    class TestMethodInvoker_uTests {

        #region construction

        [TestMethod]
        void CtorThrows() {

            TestX.If.Action.ThrowsException(() => new TestMethodInvoker(null), out ArgumentNullException ex);

            TestX.If.Value.IsEqual(ex.ParamName, "testMethod");

        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(TestMethodInfo in1) {

            TestMethodInvoker sut = null;

            TestX.IfNot.Action.ThrowsException(() => sut = new TestMethodInvoker(in1), out Exception _);

            TestX.If.Value.IsEqual(sut.TestMethod, in1);

        }

        IEnumerable<Object[]> Ctor_Data() {
            yield return new Object[] { new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_NoArgs) };
            yield return new Object[] { new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_OneArg) };
            yield return new Object[] { new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_TwoArgs) };
            yield return new Object[] { new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_OneGeneric_NoArgs) };
            yield return new Object[] { new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_OneGeneric_OneArg) };
            yield return new Object[] { new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_TwoGeneric_TwoArgs) };
        }

        #endregion

        #region Invoke

        [TestMethod]
        [TestData(nameof(Invoke_Data))]
        void Invoke(TestMethodInfo in1, IEnumerable<GetTestData> in2) {

            in2.Foreach(_ => in1.AddData(new TestDataSource(_)));

            TestMethodInvoker sut = new TestMethodInvoker(in1);

        }

        IEnumerable<Object[]> Invoke_Data() {
            yield return new Object[] { new TestMethodInfo(Dummies.TestClassInternal.MethodInfo_NoArgs) };
        }

        #endregion

    }
}
