using System;
using System.Collections.Generic;

namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Defines a collection of <see cref="ValueTuple{IResultKey, ITestMethodResults}"/>.
    /// </summary>
    interface IResultCollection : IEnumerable<(IResultKey, ITestMethodResults)> {

        #region properties

        /// <summary>
        /// Gets the number of keys.
        /// </summary>
        Int32 Count { get; }

        /// <summary>
        /// Gets if there are no keys in the collection.
        /// </summary>
        Boolean IsEmpty { get; }

        #endregion

        #region methods

        /// <summary>
        /// Adds a new entry to the collection.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="results">The new results.</param>
        void Add(IResultKey key, ITestMethodResults results);

        /// <summary>
        /// Adds a range of entries to the collection.
        /// </summary>
        /// <param name="collection">The collection to add.</param>
        void AddRange(IEnumerable<(IResultKey, ITestMethodResults)> collection);

        #endregion

    }
}
