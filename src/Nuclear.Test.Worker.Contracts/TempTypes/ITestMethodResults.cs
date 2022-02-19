using System;
using System.Diagnostics;

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

        /// <summary>
        /// Gets the total amount of time that was spent executing the test method.
        /// </summary>
        TimeSpan RunTime { get; }

        /// <summary>
        /// Gets the aggregated time that was spent with the creation of test class instances.
        /// </summary>
        TimeSpan ConstructionTime { get; }

        /// <summary>
        /// Gets the aggregated time that was spent with invoking the test method.
        /// </summary>
        TimeSpan InvokationTime { get; }

        /// <summary>
        /// Gets the aggregated time that was spent with destruction and disposition of test class instances.
        /// </summary>
        TimeSpan DestructionTime { get; }

        #endregion

    }

}
