using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Extensions;
using Nuclear.TestSite;

using TestClass = Nuclear.Test.Worker.Dummies.TestClass;
using TestDataSources = Nuclear.Test.Worker.Dummies.TestDataSources;
using TestResult = Nuclear.Test.Worker.Dummies.TestResult;
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
            yield return new Object[] { new TestMethodInfo(TestClass.MethodInfo_NoA) };
            yield return new Object[] { new TestMethodInfo(TestClass.MethodInfo_OneA) };
            yield return new Object[] { new TestMethodInfo(TestClass.MethodInfo_TwoA) };
            yield return new Object[] { new TestMethodInfo(TestClass.MethodInfo_OneG_NoA) };
            yield return new Object[] { new TestMethodInfo(TestClass.MethodInfo_OneG_OneA) };
            yield return new Object[] { new TestMethodInfo(TestClass.MethodInfo_TwoG_TwoA) };
        }

        #endregion

        #region Invoke

        [TestMethod(TestMode.Sequential)]
        [TestData(nameof(Invoke_Data))]
        void Invoke(TestMethodInfo in1, IEnumerable<GetTestData> in2, String expected) {

            in2.Foreach(_ => in1.AddData(new TestDataSource(_)));
            TestMethodInvoker sut = new TestMethodInvoker(in1);

            TestResult.ActionResult.Clear();
            TestX.IfNot.Action.ThrowsException(() => sut.Invoke(), out Exception _);
            String result = TestResult.ActionResult.ToString();

            TestX.If.Value.IsEqual(result, expected);
        }

        IEnumerable<Object[]> Invoke_Data() {

            #region no repeat / single source

            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_NoA),
                Enumerable.Empty<GetTestData>(),
                $"{nameof(TestClass.Method_NoA)}()"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_OneA),
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneA_Data()) },
                $"{nameof(TestClass.Method_OneA)}('A')\n" +
                $"{nameof(TestClass.Method_OneA)}('B')\n" +
                $"{nameof(TestClass.Method_OneA)}('C')"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_TwoA),
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneA_Data()) },
                $"{nameof(TestClass.Method_TwoA)}('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoA)}('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoA)}('C', '2')"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_OneG_NoA),
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneG_NoA_Data()) },
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int16'>()\n" +
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int32'>()\n" +
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int64'>()"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_OneG_OneA),
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneG_OneA_Data()) },
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int16'>('A')\n" +
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int32'>('B')\n" +
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int64'>('C')"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_TwoG_TwoA),
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_TwoG_TwoA_Data1()) },
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int16', 'System.UInt16'>('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int32', 'System.UInt32'>('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int64', 'System.UInt64'>('C', '2')"
            };

            #endregion

            #region repeat 2 / single source

            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_NoA) { RepeatCount = 2 },
                Enumerable.Empty<GetTestData>(),
                $"{nameof(TestClass.Method_NoA)}()\n" +
                $"{nameof(TestClass.Method_NoA)}()"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_OneA) { RepeatCount = 2 },
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneA_Data()) },
                $"{nameof(TestClass.Method_OneA)}('A')\n" +
                $"{nameof(TestClass.Method_OneA)}('B')\n" +
                $"{nameof(TestClass.Method_OneA)}('C')\n" +
                $"{nameof(TestClass.Method_OneA)}('A')\n" +
                $"{nameof(TestClass.Method_OneA)}('B')\n" +
                $"{nameof(TestClass.Method_OneA)}('C')"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_TwoA) { RepeatCount = 2 },
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneA_Data()) },
                $"{nameof(TestClass.Method_TwoA)}('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoA)}('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoA)}('C', '2')\n" +
                $"{nameof(TestClass.Method_TwoA)}('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoA)}('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoA)}('C', '2')"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_OneG_NoA) { RepeatCount = 2 },
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneG_NoA_Data()) },
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int16'>()\n" +
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int32'>()\n" +
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int64'>()\n" +
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int16'>()\n" +
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int32'>()\n" +
                $"{nameof(TestClass.Method_OneG_NoA)}<'System.Int64'>()"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_OneG_OneA) { RepeatCount = 2 },
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_OneG_OneA_Data()) },
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int16'>('A')\n" +
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int32'>('B')\n" +
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int64'>('C')\n" +
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int16'>('A')\n" +
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int32'>('B')\n" +
                $"{nameof(TestClass.Method_OneG_OneA)}<'System.Int64'>('C')"
            };
            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_TwoG_TwoA) { RepeatCount = 2 },
                new GetTestData[] { new GetTestData(() => new TestDataSources().Method_TwoG_TwoA_Data1()) },
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int16', 'System.UInt16'>('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int32', 'System.UInt32'>('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int64', 'System.UInt64'>('C', '2')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int16', 'System.UInt16'>('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int32', 'System.UInt32'>('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int64', 'System.UInt64'>('C', '2')"
            };

            #endregion

            #region repeat 2 / double source

            yield return new Object[] {
                new TestMethodInfo(TestClass.MethodInfo_TwoG_TwoA) { RepeatCount = 2 },
                new GetTestData[] {
                    new GetTestData(() => new TestDataSources().Method_TwoG_TwoA_Data1()),
                    new GetTestData(() => new TestDataSources().Method_TwoG_TwoA_Data2())
                },
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int16', 'System.UInt16'>('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int32', 'System.UInt32'>('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int64', 'System.UInt64'>('C', '2')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int16', 'System.UInt16'>('A', '0')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int32', 'System.UInt32'>('B', '1')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.Int64', 'System.UInt64'>('C', '2')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.UInt16', 'System.Int16'>('D', '4')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.UInt32', 'System.Int32'>('E', '5')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.UInt64', 'System.Int64'>('F', '6')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.UInt16', 'System.Int16'>('D', '4')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.UInt32', 'System.Int32'>('E', '5')\n" +
                $"{nameof(TestClass.Method_TwoG_TwoA)}<'System.UInt64', 'System.Int64'>('F', '6')"
            };

            #endregion

            #region ignore

            // TODO

            #endregion

        }

        #endregion

    }
}
