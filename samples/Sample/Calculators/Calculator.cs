namespace Sample.Calculators {
    public abstract class Calculator<T> : ICalculator<T> {

        #region methods

        public abstract T Add(T lhs, T rhs);

        public abstract T Substract(T lhs, T rhs);

        #endregion

    }
}
