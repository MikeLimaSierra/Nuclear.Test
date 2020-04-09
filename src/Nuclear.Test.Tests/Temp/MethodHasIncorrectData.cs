using System;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Temp {
    class MethodHasIncorrectData {

        [TestMethod]
        [TestParameters(1.5, "1")]
        [TestParameters(2.5, "2", '2')]
        [TestParameters(42)]
        void HasIncorrectData(Int32 param1, String param2) {

            String @string = param1.ToString();

            TestX.If.Value.IsEqual(param2, @string);

        }

    }
}