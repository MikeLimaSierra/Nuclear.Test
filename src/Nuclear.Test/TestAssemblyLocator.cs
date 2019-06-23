using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;

namespace Nuclear.Test {
    public class TestAssemblyLocator {

        #region properties

        public AssemblyLocatorConfiguration Configuration { get; private set; }

        #endregion

        #region ctors

        public TestAssemblyLocator(AssemblyLocatorConfiguration config) {
            Throw.If.Null(config, "config");

            Configuration = config;
        }

        #endregion

        #region public methods

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
