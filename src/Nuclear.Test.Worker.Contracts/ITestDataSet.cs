using System;

namespace Nuclear.Test.Worker {

    /// <summary>
    /// Defines one set of test data objects.
    /// </summary>
    public interface ITestDataSet {

        #region Properties

        /// <summary>
        /// Gets if test data objects are available in the set.
        /// </summary>
        Boolean HasData { get; }

        /// <summary>
        /// Gets the number of objects in the set.
        /// </summary>
        Int32 ObjectCount { get; }

        /// <summary>
        /// Gets the number of leading type objects.
        /// </summary>
        Int32 LeadingTypeCount { get; }

        #endregion

        #region methods

        /// <summary>
        /// Gets the objects of the set.
        /// </summary>
        /// <param name="data">The test data objects.</param>
        /// <returns>True if values can be returned.</returns>
        Boolean GetObjects(out Object[] data);

        /// <summary>
        /// Gets the objects of the test set split into types and data.
        /// </summary>
        /// <param name="typeCount">The number of expected leading types.</param>
        /// <param name="types">The type objects used for generics.</param>
        /// <param name="data">The test data objects.</param>
        /// <returns>True if values can be returned.</returns>
        Boolean GetObjects(UInt32 typeCount, out Type[] types, out Object[] data);

        #endregion

    }
}
