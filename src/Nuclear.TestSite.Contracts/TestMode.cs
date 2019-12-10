using System;

namespace Nuclear.TestSite {

    /// <summary>
    /// Defines possible test modes.
    /// </summary>
    public enum TestMode : Int32 {
        /// <summary>
        /// Tests will run sequential.
        /// </summary>
        Sequential,

        /// <summary>
        /// Tests will run in parallel.
        /// This value is considered default.
        /// </summary>
        Parallel
    }
}
