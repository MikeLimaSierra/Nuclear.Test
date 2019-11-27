using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Results;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestResults_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestResultEndPoint, ITestResultsSink>();
            TestX.If.Type.Implements<TestResultEndPoint, ITestResultsSource>();

        }

    }
}
