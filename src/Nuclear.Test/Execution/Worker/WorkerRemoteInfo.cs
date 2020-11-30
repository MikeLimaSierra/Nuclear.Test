using System;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Execution.Worker {
    internal class WorkerRemoteInfo : IWorkerRemoteInfo {

        #region properties

        public IWorkerRemoteConfiguration Configuration { get; }

        public RuntimeInfo Runtime { get; }

        public Boolean IsSelected { get; set; }

        #endregion

        #region ctors

        internal WorkerRemoteInfo(IProxyClientConfiguration proxyConfig, RuntimeInfo runtime) {
            Throw.If.Object.IsNull(proxyConfig, nameof(proxyConfig));
            Throw.If.Object.IsNull(runtime, nameof(runtime));

            Runtime = runtime;
            ProcessorArchitecture architecture = Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86;
            Factory.Instance.Create(out IWorkerRemoteConfiguration configuration);
            Configuration = configuration;
            Configuration.Executable = new FileInfo(Path.Combine(proxyConfig.WorkerDirectory.FullName, architecture.ToString(), $"{Runtime.Framework}{Runtime.Version}", proxyConfig.WorkerExecutableName));
        }

        #endregion

        #region methods

        public override String ToString() => $"Runtime: {Runtime.Format()}; Executable: {Configuration.Executable.FullName.Format()}; IsSelected: {IsSelected.Format()}";

        #endregion

    }
}
