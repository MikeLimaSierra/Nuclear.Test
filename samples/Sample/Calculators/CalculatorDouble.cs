using System;

namespace Sample.Calculators {
    public class CalculatorDouble : Calculator<Double> {

        #region methods

        public override Double Add(Double lhs, Double rhs) => lhs + rhs;

        public override Double Substract(Double lhs, Double rhs) => lhs - rhs;

        #endregion

    }
}
