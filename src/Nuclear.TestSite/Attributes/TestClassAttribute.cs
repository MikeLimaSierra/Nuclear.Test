using System;

namespace Nuclear.TestSite {

    /// <summary>
    /// Explicitly marks a class as containing test methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TestClassAttribute : Attribute {

        #region properties

        /// <summary>
        /// Gets the <see cref="TestMode"/> of the corresponding class.
        /// </summary>
        public TestMode TestMode { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestClassAttribute"/>.
        /// </summary>
        /// <param name="testMode">The <see cref="TestMode"/> of the corresponding class. Default is <see cref="TestMode.Parallel"/>.</param>
        public TestClassAttribute(TestMode testMode = TestMode.Parallel) {
            TestMode = testMode;
        }

        #endregion

    }
}
