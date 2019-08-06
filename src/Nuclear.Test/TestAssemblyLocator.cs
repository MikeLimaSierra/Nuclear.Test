using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;

namespace Nuclear.Test {

    /// <summary>
    /// Implements functionality to search for files within a directory tree.
    /// </summary>
    public class TestAssemblyLocator {

        #region properties

        private AssemblyLocatorConfiguration Configuration { get; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestAssemblyLocator"/>.
        /// </summary>
        /// <param name="config">The <see cref="AssemblyLocatorConfiguration"/> to use.</param>
        public TestAssemblyLocator(AssemblyLocatorConfiguration config) {
            Throw.If.Null(config, "config");

            Configuration = config;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Get a <see cref="List{FileInfo}"/> by searching for a name pattern in a directory tree.
        /// </summary>
        /// <returns>The <see cref="List{FileInfo}"/> containing the found files.</returns>
        public IEnumerable<FileInfo> GetAssemblies() {
            List<FileInfo> files = new List<FileInfo>();

            if(Configuration.SearchDir.Exists) {
                foreach(FileInfo assembly in DiscoverAssembliesInternal(Configuration.SearchDir, Configuration.SearchDepth)) {
                    files.Add(assembly);
                }
            }

            return files;
        }

        #endregion

        #region private methods

        private IEnumerable<FileInfo> DiscoverAssembliesInternal(DirectoryInfo directory, Int32 depth) {
            List<FileInfo> files = directory.EnumerateFiles(Configuration.SearchPattern).ToList();

            if(depth > 1 || depth <= 0) {
                directory.EnumerateDirectories()
                    .Where(dir => !Configuration.IgnoredDirNames.Contains(dir.Name)).ToList()
                    .ForEach(dir => files.AddRange(DiscoverAssembliesInternal(dir, depth - 1)));
            }

            return files;
        }

        #endregion

    }
}
