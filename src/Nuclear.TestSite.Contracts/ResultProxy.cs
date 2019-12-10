using System.ComponentModel;

namespace Nuclear.TestSite {

    /// <summary>
    /// A Proxy class that can forward a <see cref="ITestResultSink"/> to other consumers.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ResultProxy {

        #region properties

        /// <summary>
        /// Gets or sets the test result sink to a specific <see cref="ITestResultSink"/>. Should only ever be used by test client implementations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ITestResultSink Results { get; set; }

        #endregion

    }
}
