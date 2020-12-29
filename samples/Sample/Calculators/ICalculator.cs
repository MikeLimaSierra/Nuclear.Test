namespace Sample.Calculators {
    public interface ICalculator<T> {

        #region methods

        T Add(T lhs, T rhs);

        T Substract(T lhs, T rhs);

        #endregion

    }
}
