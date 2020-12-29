using System;
using System.Collections.Generic;
using System.Text;

using Nuclear.TestSite;

namespace Sample.Calculators {
    class Calculator_uTests {

        [TestMethod]
        [TestData(nameof(AddData))]
        void Add<T>(ICalculator<T> calculator, T lhs, T rhs, T expected) {

            T result = default;

            Test.IfNot.Action.ThrowsException(() => result = calculator.Add(lhs, rhs), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> AddData() {
            return new List<Object[]>() {
                new Object[] { typeof(Int32), new CalculatorInt32(), 0, 0, 0 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 0, 2, 2 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 1, 0, 1 },
                new Object[] { typeof(Int32), new CalculatorInt32(), -1, 2, 1 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 1, -2, -1 },
                new Object[] { typeof(Int32), new CalculatorInt32(), -1, -2, -3 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 1, 2, 3 },

                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 0, (Int64) 0, (Int64) 0 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 0, (Int64) 2, (Int64) 2 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 1, (Int64) 0, (Int64) 1 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) (-1), (Int64) 2, (Int64) 1 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 1, (Int64) (-2), (Int64) (-1) },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) (-1), (Int64) (-2), (Int64) (-3) },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 1, (Int64) 2, (Int64) 3 },

                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 0, (Single) 0, (Single) 0 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 0, (Single) 2, (Single) 2 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 1, (Single) 0, (Single) 1 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) (-1), (Single) 2, (Single) 1 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 1, (Single) (-2), (Single) (-1) },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) (-1), (Single) (-2), (Single) (-3) },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 1, (Single) 2, (Single) 3 },

                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 0, (Double) 0, (Double) 0 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 0, (Double) 2, (Double) 2 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 1, (Double) 0, (Double) 1 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) (-1), (Double) 2, (Double) 1 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 1, (Double) (-2), (Double) (-1) },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) (-1), (Double) (-2), (Double) (-3) },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 1, (Double) 2, (Double) 3 },

                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 0, (Decimal) 0, (Decimal) 0 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 0, (Decimal) 2, (Decimal) 2 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 1, (Decimal) 0, (Decimal) 1 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) (-1), (Decimal) 2, (Decimal) 1 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 1, (Decimal) (-2), (Decimal) (-1) },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) (-1), (Decimal) (-2), (Decimal) (-3) },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 1, (Decimal) 2, (Decimal) 3 },
            };
        }

        [TestMethod]
        [TestData(nameof(SubstractData))]
        void Substract<T>(ICalculator<T> calculator, T lhs, T rhs, T expected) {

            T result = default;

            Test.IfNot.Action.ThrowsException(() => result = calculator.Substract(lhs, rhs), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> SubstractData() {
            return new List<Object[]>() {
                new Object[] { typeof(Int32), new CalculatorInt32(), 0, 0, 0 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 0, 2, -2 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 1, 0, 1 },
                new Object[] { typeof(Int32), new CalculatorInt32(), -1, 2, -3 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 1, -2, 3 },
                new Object[] { typeof(Int32), new CalculatorInt32(), -1, -2, 1 },
                new Object[] { typeof(Int32), new CalculatorInt32(), 1, 2, -1 },

                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 0, (Int64) 0, (Int64) 0 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 0, (Int64) 2, (Int64) (-2) },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 1, (Int64) 0, (Int64) 1 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) (-1), (Int64) 2, (Int64) (-3) },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 1, (Int64) (-2), (Int64) 3 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) (-1), (Int64) (-2), (Int64) 1 },
                new Object[] { typeof(Int64), new CalculatorInt64(), (Int64) 1, (Int64) 2, (Int64) (-1) },

                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 0, (Single) 0, (Single) 0 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 0, (Single) 2, (Single) (-2) },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 1, (Single) 0, (Single) 1 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) (-1), (Single) 2, (Single) (-3) },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 1, (Single) (-2), (Single) 3 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) (-1), (Single) (-2), (Single) 1 },
                new Object[] { typeof(Single), new CalculatorSingle(), (Single) 1, (Single) 2, (Single) (-1) },

                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 0, (Double) 0, (Double) 0 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 0, (Double) 2, (Double) (-2) },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 1, (Double) 0, (Double) 1 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) (-1), (Double) 2, (Double) (-3) },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 1, (Double) (-2), (Double) 3 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) (-1), (Double) (-2), (Double) 1 },
                new Object[] { typeof(Double), new CalculatorDouble(), (Double) 1, (Double) 2, (Double) (-1) },

                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 0, (Decimal) 0, (Decimal) 0 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 0, (Decimal) 2, (Decimal) (-2) },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 1, (Decimal) 0, (Decimal) 1 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) (-1), (Decimal) 2, (Decimal) (-3) },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 1, (Decimal) (-2), (Decimal) 3 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) (-1), (Decimal) (-2), (Decimal) 1 },
                new Object[] { typeof(Decimal), new CalculatorDecimal(), (Decimal) 1, (Decimal) 2, (Decimal) (-1) },
            };
        }

    }
}
