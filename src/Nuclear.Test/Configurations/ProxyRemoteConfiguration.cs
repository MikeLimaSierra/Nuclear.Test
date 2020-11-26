using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Implements configuration values for an <see cref="IProxyRemote"/>.
    /// </summary>
    internal class ProxyRemoteConfiguration : RemoteConfiguration, IProxyRemoteConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the client configuration object.
        /// </summary>
        public IProxyClientConfiguration ClientConfiguration { get; set; }

        #endregion

    }
}
