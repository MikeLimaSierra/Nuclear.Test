using System;

using TestDataX = Nuclear.TestSite.TestDataAttribute;
using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Temp {
    class MethodHasIncorrectData {

        [TestMethodX]
        [TestDataX(1.5, "1")]
        [TestDataX(2.5, "2", '2')]
        [TestDataX(42)]
        void HasIncorrectData(Int32 param1, String param2) {

            String @string = param1.ToString();

            TestX.If.Value.IsEqual(param2, @string);

        }

    }
}