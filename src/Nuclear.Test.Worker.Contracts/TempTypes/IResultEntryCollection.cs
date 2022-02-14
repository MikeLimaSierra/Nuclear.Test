using System;
using System.Collections.Generic;

namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Defines a collection of <see cref="IResultEntry"/>.
    /// </summary>
    public interface IResultEntryCollection : IEnumerable<IResultEntry> {

        #region properties

        /// <summary>
        /// Gets the number of entries.
        /// </summary>
        Int32 Count { get; }

        /// <summary>
        /// Gets the number of result and error entries.
        /// </summary>
        Int32 CountRelevantEntries { get; }

        /// <summary>
        /// Gets the number of results.
        /// </summary>
        Int32 CountResults { get; }

        /// <summary>
        /// Gets the number of positive results.
        /// </summary>
        Int32 CountResultsOk { get; }

        /// <summary>
        /// Gets the number of negative results.
        /// </summary>
        Int32 CountResultsFailed { get; }

        /// <summary>
        /// Gets the number of errors.
        /// </summary>
        Int32 CountErrors { get; }

        /// <summary>
        /// Gets if there are negative result entries or errors.
        /// </summary>
        Boolean IsFailed { get; }

        /// <summary>
        /// Gets if there are no entries in the collection.
        /// </summary>
        Boolean IsEmpty { get; }

        #endregion

        #region methods

        /// <summary>
        /// Adds a new entry to the collection.
        /// </summary>
        /// <param name="entry">The new entry.</param>
        void Add(IResultEntry entry);

        #endregion

    }

}
