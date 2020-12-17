using System;
using System.Reflection;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Configurations.Proxy;

namespace Nuclear.Test.Execution.Proxy {
    internal class ProxyRemoteInfo : IProxyRemoteInfo {

        #region properties

        public IProxyRemoteConfiguration Configuration { get; }

        #endregion

        #region ctors

        internal ProxyRemoteInfo(IProxyRemoteConfiguration configuration) {
            Throw.If.Object.IsNull(configuration, nameof(configuration));

            Configuration = configuration;
        }

        #endregion

        #region methods

        public override String ToString() => $"Executable: {Configuration?.Executable?.FullName.Format()}; " +
            $"Assembly: {Configuration?.ClientConfiguration?.TestAssembly?.FullName.Format()}";

        #endregion

    }
}
