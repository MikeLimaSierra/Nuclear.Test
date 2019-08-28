using System;

namespace Nuclear.Test {

    /// <summary>
    /// An event handler delegate to handle <see cref="TestDataAvailableEventArgs"/>.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TestDataAvailableEventHandler(Object sender, TestDataAvailableEventArgs e);

    /// <summary>
    /// An event holding test data in raw format.
    /// </summary>
    public class TestDataAvailableEventArgs : EventArgs {

        #region properties

        /// <summary>
        /// Gets the test data in raw format.
        /// </summary>
        public Byte[] Data { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates an instance of <see cref="TestDataAvailableEventArgs"/>.
        /// </summary>
        /// <param name="data">The raw test data.</param>
        public TestDataAvailableEventArgs(Byte[] data) {
            Data = data;
        }

        #endregion

    }
}
