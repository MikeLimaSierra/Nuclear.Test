//using System;
//using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
//using TestX = Nuclear.TestSite.Test;

//namespace Nuclear.Test {
//    class Temp_uTests {

//        [TestMethodX]
//        void MethodHasFailingTest() {

//            TestX.Note("Note 1");
//            TestX.If.Value.IsTrue(false);
//            TestX.If.Value.IsTrue(true);
//            TestX.Note("Note 2");
//            TestX.If.Value.IsTrue(true);

//        }

//        [TestMethodX]
//        void MethodFailsExceptional() {

//            TestX.Note("Note 1");
//            TestX.If.Value.IsTrue(true);

//            throw new NotImplementedException();
//        }

//        [TestMethodX]
//        void MethodHasNoTests() {
//        }

//    }
//}
