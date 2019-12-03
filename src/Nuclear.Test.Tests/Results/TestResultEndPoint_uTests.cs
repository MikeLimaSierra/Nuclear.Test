using Nuclear.TestSite;
using Nuclear.TestSite.Results;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestResultEndPoint_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<ITestResultEndPoint, ITestResultsSink>();
            TestX.If.Type.Implements<ITestResultEndPoint, ITestResultsSource>();
            TestX.If.Type.Implements<TestResultEndPoint, ITestResultEndPoint>();

        }

    }
}
