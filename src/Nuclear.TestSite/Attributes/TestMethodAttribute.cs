using System;

namespace Nuclear.TestSite {

    /// <summary>
    /// Marks a method as test method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TestMethodAttribute : Attribute {

        #region properties

        /// <summary>
        /// Gets the <see cref="TestMode"/> of the corresponding test method.
        /// </summary>
        public TestMode TestMode { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestMethodAttribute"/>.
        /// </summary>
        /// <param name="testMode">The <see cref="TestMode"/> of the corresponding test method. Default is <see cref="TestMode.Parallel"/>.</param>
        public TestMethodAttribute(TestMode testMode = TestMode.Parallel) {
            TestMode = testMode;
        }

        #endregion

    }
}
