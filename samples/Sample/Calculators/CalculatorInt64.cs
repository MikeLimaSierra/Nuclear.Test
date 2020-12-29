using System;

namespace Sample.Calculators {
    public class CalculatorInt64 : Calculator<Int64> {

        #region methods

        public override Int64 Add(Int64 lhs, Int64 rhs) => lhs + rhs;

        public override Int64 Substract(Int64 lhs, Int64 rhs) => lhs - rhs;

        #endregion

    }
}
