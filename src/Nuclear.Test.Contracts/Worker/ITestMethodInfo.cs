using System;

namespace Nuclear.Test.Worker {

    /// <summary>
    /// Defines a test method object.
    /// </summary>
    public interface ITestMethodInfo {

        #region properties

        /// <summary>
        /// Gets the file name.
        /// </summary>
        String FileName { get; }

        /// <summary>
        /// Gets the test method name.
        /// </summary>
        String MethodName { get; }

        /// <summary>
        /// Gets if the method has parameters.
        /// </summary>
        Boolean HasParameters { get; }

        /// <summary>
        /// Gets if the method has generic parameters.
        /// </summary>
        Boolean IsGeneric { get; }

        /// <summary>
        /// Gets or sets how many times the test method should be invoked.
        /// </summary>
        UInt32 RepeatCount { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invokes the test method.
        /// </summary>
        void Invoke();

        /// <summary>
        /// Adds a data source to the test method object.
        /// </summary>
        /// <param name="dataSource"></param>
        void AddData(ITestMethodDataSource dataSource);

        #endregion

    }
}
