using System;
using System.Reflection;
using Nuclear.Exceptions;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Client.Execution {
    public class TestMethod {

        #region fields

        private Object _callingObject;

        private MethodInfo _method;

        private ITestResultsEndPoint _results;

        #endregion

        #region properties

        private Object CallingObject {
            get {
                if(_callingObject == null) {
                    _callingObject = Activator.CreateInstance(_method.DeclaringType, true);
                }

                return _callingObject;
            }
        }

        #endregion

        #region ctors

        public TestMethod(ITestResultsEndPoint results, MethodInfo method) {
            Throw.If.Null(results, "results");
            Throw.If.Null(method, "method");

            _results = results;
            _method = method;
        }

        #endregion

        #region public methods

        public void Invoke() {
            try {
                _method.Invoke(CallingObject, new Object[0]);
            } catch(Exception ex) {
                _results.FailTestMethod(_method, ex);
            }
        }

        #endregion

    }
}
