using System;
using System.Collections.Generic;

using Nuclear.Creation;
using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker.Factories {

    /// <summary>
    /// Defines a factory related to <see cref="IResultEntry"/> types.
    /// </summary>
    public abstract class ResultsFactory :
        ICreator<IResultEntry, EntryTypes, String, String>,
        ICreator<IResultEntryCollection>,
        ICreator<IResultEntryCollection, IEnumerable<IResultEntry>>,
        ICreator<ITestMethodResults, String> {

        #region IResultEntry

        /// <summary>
        /// Creates an instance of <see cref="IResultEntry"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="type">The type of the test entry.</param>
        /// <param name="instruction">The name of the corresponding test instruction.</param>
        /// <param name="message">The message of the corresponding test instruction.</param>
        public abstract void Create(out IResultEntry obj, EntryTypes type, String instruction, String message);

        /// <summary>
        /// Tries to create an instance of <see cref="IResultEntry"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="type">The type of the test entry.</param>
        /// <param name="instruction">The name of the corresponding test instruction.</param>
        /// <param name="message">The message of the corresponding test instruction.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out IResultEntry obj, EntryTypes type, String instruction, String message);

        /// <summary>
        /// Tries to create an instance of <see cref="IResultEntry"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="type">The type of the test entry.</param>
        /// <param name="instruction">The name of the corresponding test instruction.</param>
        /// <param name="message">The message of the corresponding test instruction.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out IResultEntry obj, EntryTypes type, String instruction, String message, out Exception ex);

        #endregion

        #region IResultEntryCollection

        /// <summary>
        /// Creates an instance of <see cref="IResultEntryCollection"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        public abstract void Create(out IResultEntryCollection obj);

        /// <summary>
        /// Tries to create an instance of <see cref="IResultEntryCollection"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out IResultEntryCollection obj);

        /// <summary>
        /// Tries to create an instance of <see cref="IResultEntryCollection"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out IResultEntryCollection obj, out Exception ex);

        /// <summary>
        /// Creates an instance of <see cref="IResultEntryCollection"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public abstract void Create(out IResultEntryCollection obj, IEnumerable<IResultEntry> collection);

        /// <summary>
        /// Tries to create an instance of <see cref="IResultEntryCollection"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out IResultEntryCollection obj, IEnumerable<IResultEntry> collection);

        /// <summary>
        /// Tries to create an instance of <see cref="IResultEntryCollection"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out IResultEntryCollection obj, IEnumerable<IResultEntry> collection, out Exception ex);

        #endregion

        #region ITestMethodResults

        /// <summary>
        /// Creates an instance of <see cref="ITestMethodResults"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="ignoreReason">The reason why the test method is being ignored.</param>
        public abstract void Create(out ITestMethodResults obj, String ignoreReason);

        /// <summary>
        /// Tries to create an instance of <see cref="ITestMethodResults"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="ignoreReason">The reason why the test method is being ignored.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out ITestMethodResults obj, String ignoreReason);

        /// <summary>
        /// Tries to create an instance of <see cref="ITestMethodResults"/> and returns it via the out parameter obj.
        /// </summary>
        /// <param name="obj">The created instance.</param>
        /// <param name="ignoreReason">The reason why the test method is being ignored.</param>
        /// <param name="ex">The caught exception.</param>
        /// <returns>True if the object was created.</returns>
        public abstract Boolean TryCreate(out ITestMethodResults obj, String ignoreReason, out Exception ex);

        #endregion

    }
}
