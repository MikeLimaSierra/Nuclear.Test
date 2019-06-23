using System;
using System.IO;

namespace Nuclear.Test.Configurations {
    public class TestConfiguration {

        #region constants

        public const String FILE_PATH = "Test.FilePath";

        public const String WORKER_BASE_DIR = "Test.WorkerBaseDir";

        public const String FORCE_SEQUENTIAL = "Test.ForceSequential";

        public const String FORCE_ASM_SEQUENTIAL = "Test.ForceAsmSequential";

        #endregion

        #region properties

        public DirectoryInfo WorkerBaseDir { get; set; }

        public Boolean ForceSequential { get; set; }

        public Boolean ForceAsmSequential { get; set; }

        #endregion

    }
}
