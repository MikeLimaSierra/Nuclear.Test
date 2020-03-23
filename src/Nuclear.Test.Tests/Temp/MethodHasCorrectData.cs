using System;

using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestDataX = Nuclear.TestSite.TestDataAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Temp {
    class MethodHasCorrectData {

        [TestMethodX]
        [TestDataX(1, "1")]
        [TestDataX(2, "2")]
        [TestDataX(42, "42")]
        [TestDataX(42, "43")]
        void HasCorrectData(Int32 param1, String param2) {

            String @string = param1.ToString();

            TestX.If.Value.IsEqual(param2, @string);


        }

    }
}