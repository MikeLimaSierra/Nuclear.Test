using System;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;

namespace Nuclear.Test.Proxy {
    internal class RemoteInfo {

        #region properties

        internal RuntimeInfo Runtime { get; }

        internal FileInfo Executable { get; }

        internal Boolean HasExecutable => Executable != null && Executable.Exists;

        internal Boolean IsSelected { get; set; }

        #endregion

        #region ctors

        public RemoteInfo(IProxyConfiguration proxyConfig, RuntimeInfo runtime) {
            Throw.If.Object.IsNull(proxyConfig, nameof(proxyConfig));
            Throw.If.Object.IsNull(runtime, nameof(runtime));

            Runtime = runtime;
            ProcessorArchitecture architecture = Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86;
            Executable = new FileInfo(Path.Combine(proxyConfig.WorkerDirectory.FullName, architecture.ToString(), $"{Runtime.Framework}{Runtime.Version}", proxyConfig.WorkerExecutableName));
        }

        #endregion

    }
}
