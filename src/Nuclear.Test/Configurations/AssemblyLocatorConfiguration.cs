using System;
using System.Collections.Generic;
using System.IO;

namespace Nuclear.Test.Configurations {
    public class AssemblyLocatorConfiguration {

        #region constants

        public const String SEARCH_DIR = "Locator.SearchDir";

        public const String SEARCH_DEPTH = "Locator.SearchDepth";

        public const String SEARCH_PATTERN = "Locator.SearchPattern";

        public const String IGNORED_DIR_NAMES = "Locator.IgnoredDirNames";

        #endregion

        #region properties

        public DirectoryInfo SearchDir { get; set; }

        public Int32 SearchDepth { get; set; }

        public String SearchPattern { get; set; }

        public List<String> IgnoredDirNames { get; } = new List<String>();

        #endregion

    }
}
