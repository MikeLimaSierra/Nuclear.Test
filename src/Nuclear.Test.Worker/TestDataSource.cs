using System;
using System.Collections.Generic;

using Nuclear.Exceptions;

namespace Nuclear.Test.Worker {

    /// <summary>
    /// A delegate used to return test data sets.
    /// </summary>
    /// <returns>A collection of test data sets.</returns>
    public delegate IEnumerable<Object[]> GetTestData();

    internal class TestDataSource : ITestDataSource {

        #region fields

        private readonly GetTestData _delegate;

        #endregion

        #region ctors

        internal TestDataSource(GetTestData @delegate) {
            Throw.If.Object.IsNull(@delegate, nameof(@delegate));

            _delegate = @delegate;
        }

        #endregion

        #region methods

        public IEnumerable<ITestDataSet> GetData() {
            IEnumerable<Object[]> dataSets = null;

            try {
                dataSets = _delegate();

            } catch { /* TODO: add logging */ }

            if(dataSets != null) {
                foreach(Object[] data in dataSets) {
                    yield return new TestDataSet(data);
                }
            }
        }

        #endregion

    }
}
