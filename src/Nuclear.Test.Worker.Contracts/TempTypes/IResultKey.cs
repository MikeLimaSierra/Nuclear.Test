using System;

namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Defines the key structure that identifies test method results.
    /// </summary>
    public interface IResultKey : IEquatable<IResultKey>, IComparable<IResultKey> {

        #region properties

        /// <summary>
        /// Gets the test scenario.
        /// </summary>
        IScenario Scenario { get; }

        /// <summary>
        /// Gets the file name of the test.
        /// </summary>
        String FileName { get; }

        /// <summary>
        /// Gets the calling method name of the test.
        /// </summary>
        String MethodName { get; }

        #endregion

    }

}
