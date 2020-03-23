using System;

using TestMethodX = Nuclear.TestSite.TestMethodAttribute;

namespace Nuclear.Test.Temp {
    class MethodHasNoData {

        [TestMethodX]
        void HasNoData(Int32 param1, String param2) { }

    }
}