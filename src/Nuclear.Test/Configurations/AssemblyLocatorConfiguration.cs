//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Nuclear.Test.Configurations {

//    /// <summary>
//    /// Holds configuration values for assembly location.
//    /// </summary>
//    public class AssemblyLocatorConfiguration {

//        #region constants

//        /// <summary>
//        /// Gets the command value for SearchDir.
//        /// </summary>
//        public const String COM_SEARCH_DIR = "Locator.SearchDir";

//        /// <summary>
//        /// Gets the command value for SearchDepth.
//        /// </summary>
//        public const String COM_SEARCH_DEPTH = "Locator.SearchDepth";

//        /// <summary>
//        /// Gets the command value for SearchPattern.
//        /// </summary>
//        public const String COM_SEARCH_PATTERN = "Locator.SearchPattern";

//        /// <summary>
//        /// Gets the command value for IgnoredDirNames.
//        /// </summary>
//        public const String COM_IGNORED_DIR_NAMES = "Locator.IgnoredDirNames";

//        #endregion

//        #region properties

//        /// <summary>
//        /// Gets or sets the directory in which to look for assemblies.
//        /// </summary>
//        public DirectoryInfo SearchDir { get; set; }

//        /// <summary>
//        /// Gets or sets the recursive search depth.
//        /// </summary>
//        public Int32 SearchDepth { get; set; }

//        /// <summary>
//        /// Gets or sets the search pattern for valid test assemblies.
//        /// </summary>
//        public String SearchPattern { get; set; }

//        /// <summary>
//        /// Gets or sets a list of directory names that are ignored.
//        /// </summary>
//        public List<String> IgnoredDirNames { get; } = new List<String>();

//        #endregion

//    }
//}
