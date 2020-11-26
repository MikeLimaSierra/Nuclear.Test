using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using log4net;

using Nuclear.Extensions;

namespace Nuclear.Test.Console {
    internal class AssemblyLocator {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(AssemblyLocator));

        private DirectoryInfo _searchDirectory = null;

        #endregion

        #region properties

        internal DirectoryInfo SearchDirectory {
            get => _searchDirectory ??= new FileInfo(Assembly.GetEntryAssembly().Location).Directory;
            set => _searchDirectory = value;
        }

        internal Int32 SearchDepth { get; set; }

        internal String SearchPattern { get; set; } = "*Tests.dll";

        internal IEnumerable<String> IgnoredDirectoryNames { get; set; } = Enumerable.Empty<String>();

        #endregion

        #region methods

        internal IEnumerable<FileInfo> DiscoverAssemblies()
            => SearchDirectory != null && SearchDirectory.Exists ? DiscoverAssemblies(SearchDirectory, SearchDepth) : Enumerable.Empty<FileInfo>();

        private IEnumerable<FileInfo> DiscoverAssemblies(DirectoryInfo directory, Int32 depth) {
            List<FileInfo> files = directory.EnumerateFiles(SearchPattern).ToList();

            if(depth != 0) {
                directory
                    .EnumerateDirectories()
                    .Where(d => !IgnoredDirectoryNames.Contains(d.Name))
                    .Foreach(d => files.AddRange(DiscoverAssemblies(d, depth - 1)));
            }

            return files;
        }

        #endregion

    }
}
