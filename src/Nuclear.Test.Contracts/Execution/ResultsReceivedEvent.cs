using System;

using Nuclear.Exceptions;

namespace Nuclear.Test.Execution {

    /// <summary>
    /// An event handler delegate to handle <see cref="ResultsReceivedEventArgs"/>.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The arguments.</param>
    public delegate void ResultsReceivedEventHandler(Object sender, ResultsReceivedEventArgs e);

    /// <summary>
    /// An event holding test data in raw format.
    /// </summary>
    public class ResultsReceivedEventArgs : EventArgs {

        #region properties

        /// <summary>
        /// Gets the test data in raw format.
        /// </summary>
        public Byte[] Data { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates an instance of <see cref="ResultsReceivedEventArgs"/>.
        /// </summary>
        /// <param name="data">The raw test data.</param>
        public ResultsReceivedEventArgs(Byte[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            Data = data;
        }

        #endregion

    }
}