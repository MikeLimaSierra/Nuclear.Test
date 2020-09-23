//using System;
//using System.IO;

//namespace Nuclear.Test.Configurations {

//    /// <summary>
//    /// Holds configuration values for test execution.
//    /// </summary>
//    public class TestConfiguration {

//        #region constants

//        /// <summary>
//        /// Gets the command value for test assembly path.
//        /// </summary>
//        public const String FILE_PATH = "Test.FilePath";

//        /// <summary>
//        /// Gets the command value for test results.
//        /// </summary>
//        public const String TEST_RESULTS = "Test.Results";

//        /// <summary>
//        /// Gets the command value for test finished.
//        /// </summary>
//        public const String TEST_FINISHED = "Test.Finished";

//        /// <summary>
//        /// Gets the command value for WorkerBaseDir.
//        /// </summary>
//        public const String WORKER_BASE_DIR = "Test.WorkerBaseDir";

//        /// <summary>
//        /// Gets the command value for ProxyBaseDir.
//        /// </summary>
//        public const String PROXY_BASE_DIR = "Test.ProxyBaseDir";

//        /// <summary>
//        /// Gets the command value for ForceSequential.
//        /// </summary>
//        public const String FORCE_SEQUENTIAL = "Test.ForceSequential";

//        /// <summary>
//        /// Gets the command value for ForceAsmSequential.
//        /// </summary>
//        public const String FORCE_ASM_SEQUENTIAL = "Test.ForceAsmSequential";

//        /// <summary>
//        /// Gets the command value for TestAllVersions.
//        /// </summary>
//        public const String TEST_ALL_VERSIONS = "Test.TestAllVersions";

//        #endregion

//        #region properties

//        /// <summary>
//        /// Gets or sets the directory in which to look for workers.
//        /// </summary>
//        public DirectoryInfo WorkerBaseDir { get; set; }

//        /// <summary>
//        /// Gets or sets the directory in which to look for proxies.
//        /// </summary>
//        public DirectoryInfo ProxyBaseDir { get; set; }

//        /// <summary>
//        /// Gets or sets if sequential test execution within each assembly should be enforced.
//        ///      Will result in one test method being invoked at a time within each test assembly if set to true.
//        /// </summary>
//        public Boolean ForceSequential { get; set; }

//        /// <summary>
//        /// Gets or sets if sequential processing of test assemblies should be enforced.
//        ///     Will result in processing one assembly at a time if set to true.
//        /// </summary>
//        public Boolean ForceAsmSequential { get; set; }

//        /// <summary>
//        /// Gets or sets if all tests are executed on all valid platform versions or just the lowest possible.
//        ///     Will execute all tests on all platform versions if set to true.
//        /// </summary>
//        public Boolean TestAllVersions { get; set; }

//        #endregion

//    }
//}
