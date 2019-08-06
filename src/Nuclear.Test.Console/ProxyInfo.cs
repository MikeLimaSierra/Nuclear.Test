using System;
using System.IO;

namespace Nuclear.Test.Console {

    /// <summary>
    /// Contains informations about a specific proxy executable and its required runtime properties.
    /// </summary>
    public class ProxyInfo {

        #region properties

        /// <summary>
        /// Gets the <see cref="FileInfo"/> of the test assembly on disk.
        /// </summary>
        public FileInfo File { get; } = null;

        /// <summary>
        /// Gets if the <see cref="FileInfo"/> of the test assembly on disk is not null.
        /// </summary>
        public Boolean HasFile => File != null;

        /// <summary>
        /// Gets the attached proxy executable.
        /// </summary>
        public FileInfo Executable { get; } = null;

        /// <summary>
        /// Gets if the attached proxy executable <see cref="FileInfo"/> is not null.
        /// </summary>
        public Boolean HasExecutable => Executable != null;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ProxyInfo"/>.
        /// </summary>
        /// <param name="executable">The attached executable.</param>
        /// <param name="file">The <see cref="FileInfo"/> of the test assembly on disk.</param>
        public ProxyInfo(FileInfo executable, FileInfo file) {
            Executable = executable;
            File = file;
        }

        #endregion

        #region methods

        /// <summary>
        /// Gets a <see cref="String"/> representation of this object.
        /// </summary>
        /// <returns>The <see cref="String"/> representing this <see cref="ProxyInfo"/> and all its properties.</returns>
        public override String ToString() => String.Format("Executable: {0}", HasExecutable ? Executable.FullName : "null");

        #endregion

    }
}
