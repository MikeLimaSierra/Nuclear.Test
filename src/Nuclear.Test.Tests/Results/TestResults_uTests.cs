using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Results;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestResults_uTests {

        [TestMethod]
        void TestImplementation() {

            TestX.If.Type.Implements<TestResults, ITestResultsSink>();
            TestX.If.Type.Implements<TestResults, ITestResultsSource>();

        }

    }
}
