using System;

namespace Sample.Calculators {
    public class CalculatorDecimal : Calculator<Decimal> {

        #region methods

        public override Decimal Add(Decimal lhs, Decimal rhs) => lhs + rhs;

        public override Decimal Substract(Decimal lhs, Decimal rhs) => lhs - rhs;

        #endregion

    }
}
