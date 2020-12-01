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

            ProcessorArchitecture architecture = Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86;
            //Executable = new FileInfo(Path.Combine(proxyConfig.Executable.FullName, architecture.ToString(), proxyConfig.WorkerExecutableName));
        }

        #endregion

        #region methods

        public override String ToString() => $"Executable: {Configuration.Executable.FullName.Format()}; " +
            $"Assembly: {Configuration.ClientConfiguration.TestAssembly.FullName.Format()}";

        #endregion

    }
}
