﻿using System;

using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Temp {
    class MethodHasNoData {

        [TestMethodX]
        void HasNoData(Int32 param1, String param2) {

            String @string = param1.ToString();

            TestX.If.Value.IsEqual(param2, @string);

        }

    }
}