using System;

namespace Sample.Calculators {
    public class CalculatorSingle : Calculator<Single> {

        #region methods

        public override Single Add(Single lhs, Single rhs) => lhs + rhs;

        public override Single Substract(Single lhs, Single rhs) => lhs - rhs;

        #endregion

    }
}
