using System;
using System.IO;
using System.Reflection;

namespace Nuclear.Test.Proxy {

    /// <summary>
    /// Contains informations about a specific worker executable and its required runtime properties.
    /// </summary>
    public class WorkerInfo {

        #region properties

        /// <summary>
        /// Gets the runtime platform.
        /// </summary>
        public FrameworkIdentifiers Platform { get; }

        /// <summary>
        /// Gets the runtime version
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Gets the attached worker executable.
        /// </summary>
        public FileInfo Executable { get; } = null;

        /// <summary>
        /// Gets if the attached worker executable <see cref="FileInfo"/> is not null.
        /// </summary>
        public Boolean HasExecutable => Executable != null;

        /// <summary>
        /// Gets if the worker executable is required to be run.
        /// </summary>
        public Boolean ExecutionRequired { get; set; } = false;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="WorkerInfo"/>.
        /// </summary>
        /// <param name="directory">The directory where the executable is located.</param>
        /// <param name="targetRuntime">The target runtime that is associated with this object.</param>
        /// <param name="runtimeArchitecture">The target runtime architecture.</param>
        public WorkerInfo(DirectoryInfo directory, (FrameworkIdentifiers platform, Version version) targetRuntime, ProcessorArchitecture runtimeArchitecture) {
            Platform = targetRuntime.platform;
            Version = targetRuntime.version;
            Executable = new FileInfo(Path.Combine(directory.FullName, runtimeArchitecture.ToString(),
                targetRuntime.platform.ToString() + targetRuntime.version.ToString(), "Nuclear.Test.Worker.exe"));
        }

        #endregion

        #region methods

        /// <summary>
        /// Gets a <see cref="String"/> representation of this object.
        /// </summary>
        /// <returns>The <see cref="String"/> representing this <see cref="WorkerInfo"/> and all its properties.</returns>
        public override String ToString() => String.Format("('{0}', v'{1}') => Required: {2}; Executable: {3}", Platform, Version, ExecutionRequired, HasExecutable ? Executable.FullName : "null");

        #endregion

    }
}
