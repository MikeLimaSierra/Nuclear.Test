using System;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations.Worker;

namespace Nuclear.Test.Execution.Worker {

    /// <summary>
    /// Defines the information required to create an <see cref="IWorkerRemote"/>.
    /// </summary>
    public interface IWorkerRemoteInfo {

        #region properties

        /// <summary>
        /// Gets the configuration object.
        /// </summary>
        IWorkerRemoteConfiguration Configuration { get; }

        /// <summary>
        /// Gets the runtime information.
        /// </summary>
        RuntimeInfo Runtime { get; }

        /// <summary>
        /// Gets or sets if the remote will be executed.
        /// </summary>
        Boolean IsSelected { get; set; }

        #endregion

    }
}
