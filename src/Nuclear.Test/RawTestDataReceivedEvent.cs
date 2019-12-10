using System;

namespace Nuclear.Test {

    /// <summary>
    /// An event handler delegate to handle <see cref="RawTestDataReceivedEventArgs"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    public delegate void RawTestDataReceivedEventHandler(Object sender, RawTestDataReceivedEventArgs e);

    /// <summary>
    /// An event holding test data in raw format.
    /// </summary>
    public class RawTestDataReceivedEventArgs : EventArgs {

        #region properties

        /// <summary>
        /// Gets the test data in raw format.
        /// </summary>
        public Byte[] Data { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates an instance of <see cref="RawTestDataReceivedEventArgs"/>.
        /// </summary>
        /// <param name="data">The raw test data.</param>
        public RawTestDataReceivedEventArgs(Byte[] data) {
            Data = data;
        }

        #endregion

    }
}
