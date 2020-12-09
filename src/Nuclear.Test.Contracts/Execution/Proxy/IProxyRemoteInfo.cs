using System;

using Nuclear.Test.Configurations.Proxy;

namespace Nuclear.Test.Execution.Proxy {

    /// <summary>
    /// Defines the information required to create an <see cref="IProxyRemote"/>.
    /// </summary>
    public interface IProxyRemoteInfo {

        #region properties

        /// <summary>
        /// Gets the configuration object.
        /// </summary>
        IProxyRemoteConfiguration Configuration { get; }

        #endregion

    }
}
