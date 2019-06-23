using System;

namespace Nuclear.TestSite.Attributes {

    /// <summary>
    /// Defines possible test modes.
    /// </summary>
    public enum TestMode : Int32 {
        /// <summary>
        /// Tests will run sequential.
        ///     Default on <see cref="TestClassAttribute"/>.
        /// </summary>
        Sequential,

        /// <summary>
        /// Tests will run in parallel.
        ///     Default on <see cref="TestMethodAttribute"/>.
        /// </summary>
        Parallel
    }
}
