using System;
using System.Collections.Generic;

namespace Nuclear.Test.Worker {

    /// <summary>
    /// Describes a test data source for test methods.
    /// </summary>
    public interface ITestMethodDataSource {

        #region methods

        /// <summary>
        /// Gets the test data from the source object.
        /// </summary>
        /// <returns>A collection of test data sets.</returns>
        IEnumerable<Object[]> GetData();

        #endregion

    }
}
