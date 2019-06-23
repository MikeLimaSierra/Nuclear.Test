using System;
using System.IO;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Server.Execution {

    public delegate void TestCompletedEventHandler(Object sender, TestCompletedEventArgs e);

    public class TestCompletedEventArgs : EventArgs {

        #region properties

        public TestResultMap Results { get; private set; }

        public FileInfo File { get; private set; }

        #endregion

        #region ctors

        public TestCompletedEventArgs(TestResultMap results, FileInfo file) {
            Results = results;
            File = file;
        }

        #endregion

    }
}
