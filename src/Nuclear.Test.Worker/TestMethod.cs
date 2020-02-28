using System;
using System.Reflection;
using Nuclear.Exceptions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Worker {
    internal class TestMethod {

        #region fields

        private MethodInfo _method;

        private ITestResultEndPoint _results;

        #endregion

        #region properties

        private Object CallingObject => Activator.CreateInstance(_method.DeclaringType, true);

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestMethod"/>.
        /// </summary>
        /// <param name="results">The test results end point to use.</param>
        /// <param name="method">The method to invoke.</param>
        internal TestMethod(ITestResultEndPoint results, MethodInfo method) {
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Object.IsNull(method, nameof(method));

            _results = results;
            _method = method;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Invokes the associated method.
        /// </summary>
        internal void Invoke() {
            _results.PrepareResults(_method);

            try {
                _method.Invoke(CallingObject, new Object[0]);
            } catch(Exception ex) {
                _results.FailTestMethod(_method, ex);
            }
        }

        #endregion

    }
}
