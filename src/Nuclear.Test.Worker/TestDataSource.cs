using System;
using System.Collections.Generic;

using Nuclear.Exceptions;

namespace Nuclear.Test.Worker {

    /// <summary>
    /// A delegate used to return test data sets.
    /// </summary>
    /// <returns>A collection of test data sets.</returns>
    public delegate IEnumerable<Object[]> GetTestData();

    internal class TestDataSource {

        #region fields

        private readonly GetTestData _delegate;

        #endregion

        #region properties

        internal String SourceString { get; }

        #endregion

        #region ctors

        internal TestDataSource(GetTestData @delegate, String sourceString) {
            Throw.If.Object.IsNull(@delegate, nameof(@delegate));
            Throw.If.String.IsNullOrWhiteSpace(sourceString, nameof(sourceString));

            _delegate = @delegate;
            SourceString = sourceString;
        }

        #endregion

        #region methods

        public IEnumerable<TestDataSet> GetData() {
            foreach(Object[] data in _delegate()) {
                yield return new TestDataSet(data);
            }
        }

        #endregion

    }
}
