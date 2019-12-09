using Nuclear.TestSite;
using Nuclear.TestSite.Results;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Results {
    class TestResultEndPoint_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<ITestResultEndPoint, ITestResultSink>();
            TestX.If.Type.Implements<ITestResultEndPoint, ITestResultSource>();
            TestX.If.Type.Implements<TestResultEndPoint, ITestResultEndPoint>();

        }

    }
}
