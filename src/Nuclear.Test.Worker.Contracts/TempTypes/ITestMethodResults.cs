using System;

namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Represents the results of a number of executed test instructions (e.g. executed test method).
    /// </summary>
    public interface ITestMethodResults {

        #region properties

        /// <summary>
        /// Gets the result entries registered to the test methods.
        /// </summary>
        IResultEntryCollection Entries { get; }

        /// <summary>
        /// Gets the reason why the test method is being ignored.
        /// </summary>
        String IgnoreReason { get; }

        /// <summary>
        /// Gets if the test method was ignored.
        /// </summary>
        Boolean IsIgnored { get; }

        #endregion

    }

}
