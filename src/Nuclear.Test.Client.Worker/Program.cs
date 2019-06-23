using System;
using Nuclear.Test.Client.Clients;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.Client.Worker {
    public static class Program {

        #region public methods

        public static void Main(String[] args) {
            PipedTestClient client = new PipedTestClient(TestResults.Instance, args[0]);
            client.RunTests();
        }

        #endregion

    }
}
