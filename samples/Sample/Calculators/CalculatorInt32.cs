using System;

namespace Sample.Calculators {
    public class CalculatorInt32 : Calculator<Int32> {

        #region methods

        public override Int32 Add(Int32 lhs, Int32 rhs) => lhs + rhs;

        public override Int32 Substract(Int32 lhs, Int32 rhs) => lhs - rhs;

        #endregion

    }
}
