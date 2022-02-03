using System.Collections.Generic;

namespace Nuclear.Test.Worker {

    /// <summary>
    /// Describes a test data source for test methods.
    /// </summary>
    public interface ITestDataSource {

        #region methods

        /// <summary>
        /// Gets all test data sets from the source object.
        /// </summary>
        /// <returns>A collection of test data sets.</returns>
        IEnumerable<ITestDataSet> GetData();

        #endregion

    }

}
