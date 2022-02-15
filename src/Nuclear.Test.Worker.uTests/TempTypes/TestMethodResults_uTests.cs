using System;
using System.Collections.Generic;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.TempTypes {
    class TestMethodResults_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<TestMethodResults, ITestMethodResults>();

        }

        #region Ctor

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(String in1, (String reason, Boolean isIgnored) expected) {

            ITestMethodResults sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new TestMethodResults(in1), out Exception _);

            TestX.If.Enumerable.IsEmpty(sut.Entries);
            TestX.If.Value.IsEqual(sut.IgnoreReason, expected.reason);
            TestX.If.Value.IsEqual(sut.IsIgnored, expected.isIgnored);

        }

        IEnumerable<Object[]> Ctor_Data() {
            yield return new Object[] { null, ((String) null, false) };
            yield return new Object[] { "", ("", false) };
            yield return new Object[] { " ", (" ", false) };
            yield return new Object[] { "a", ("a", true) };
        }

        #endregion

    }
}
