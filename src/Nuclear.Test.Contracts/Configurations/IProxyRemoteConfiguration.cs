using Nuclear.Test.Execution;

namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines configuration values for an <see cref="IProxyRemote"/>.
    /// </summary>
    public interface IProxyRemoteConfiguration : IRemoteConfiguration {

        #region properties

        /// <summary>
        /// Gets or sets the client configuration object.
        /// </summary>
        IProxyClientConfiguration ClientConfiguration { get; set; }

        #endregion

    }
}
