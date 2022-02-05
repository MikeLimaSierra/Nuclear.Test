using Nuclear.Exceptions;

namespace Nuclear.Test.Worker {
    internal class TestMethodInvoker {

        #region properties

        internal TestMethodInfo TestMethod { get; }

        #endregion

        #region ctors

        internal TestMethodInvoker(TestMethodInfo testMethod) {
            Throw.If.Object.IsNull(testMethod, nameof(testMethod));

            TestMethod = testMethod;
        }

        #endregion

        #region method

        internal void Invoke() { }

        #endregion

    }
}
