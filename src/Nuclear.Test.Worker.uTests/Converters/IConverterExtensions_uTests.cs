using System;
using System.Collections.Generic;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.Converters {
    class IConverterExtensions_uTests {

        #region Convert

        [TestMethod]
        [TestData(nameof(Convert_Data))]
        void Convert(Attribute in1, String expected) {

            String result = null;

            TestX.IfNot.Action.ThrowsException(() => result = IConverterExtensions.Convert(in1), out Exception _);

            TestX.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> Convert_Data() {
            yield return new Object[] { new Dummies.DummyAttribute(), "[Dummy]" };
            yield return new Object[] { new Dummies.DummyOnePropAttribute(), "[DummyOneProp(Name = null)]" };
            yield return new Object[] { new Dummies.DummyOnePropAttribute() { Name = "John Doe" }, "[DummyOneProp(Name = 'John Doe')]" };
            yield return new Object[] { new Dummies.DummyTwoPropsAttribute(), "[DummyTwoProps(Name = null, Size = '0')]" };
            yield return new Object[] { new Dummies.DummyTwoPropsAttribute() { Name = "John Doe", Size = 42 }, "[DummyTwoProps(Name = 'John Doe', Size = '42')]" };
            yield return new Object[] { new Dummies.DummyMixedPropsAttribute(), "[DummyMixedProps(Name = null, Size = '0')]" };
            yield return new Object[] { new Dummies.DummyMixedPropsAttribute() { Name = "John Doe", Size = 42 }, "[DummyMixedProps(Name = 'John Doe', Size = '42')]" };
        }

        #endregion

    }
}
