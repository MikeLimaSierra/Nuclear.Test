using System;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Temp {
    class MethodHasNoData {

        [TestMethod]
        void HasNoData(Int32 param1, String param2) {

            String @string = param1.ToString();

            TestX.If.Value.IsEqual(param2, @string);

        }

    }
}