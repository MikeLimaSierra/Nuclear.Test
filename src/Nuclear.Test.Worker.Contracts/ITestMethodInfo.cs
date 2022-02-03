using System;
using System.Collections.Generic;

using Nuclear.TestSite;

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
        /// Gets the number of required parameters.
        /// </summary>
        Int32 ParameterCount { get; }

        /// <summary>
        /// Gets if the method has generic parameters.
        /// </summary>
        Boolean IsGeneric { get; }

        /// <summary>
        /// Gets the number of required generic parameters.
        /// </summary>
        Int32 GenericParameterCount { get; }

        /// <summary>
        /// Gets or sets how many times the test method should be invoked.
        /// </summary>
        Int32 RepeatCount { get; set; }

        /// <summary>
        /// Gets or sets the test mode.
        /// </summary>
        TestMode TestMode { get; set; }

        /// <summary>
        /// Gets a collection of data sources for the test method object.
        /// </summary>
        IEnumerable<ITestMethodDataSource> DataSources { get; }

        #endregion

        #region methods

        /// <summary>
        /// Invokes the test method using a test method invoker.
        /// </summary>
        /// <param name="creator">The test object creator.</param>
        /// <param name="invoker">The test method invoker.</param>
        void Invoke(ITestObjectCreator creator, ITestMethodInvoker invoker);

        /// <summary>
        /// Adds a data source to the test method object.
        /// </summary>
        /// <param name="dataSource">The data source to add.</param>
        void AddData(ITestMethodDataSource dataSource);

        #endregion

    }

}
