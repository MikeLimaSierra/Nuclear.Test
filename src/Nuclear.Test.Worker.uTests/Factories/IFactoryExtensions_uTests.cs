using System;
using System.Collections.Generic;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.Factories {
    class IFactoryExtensions_uTests {

        #region Create

        [TestMethod]
        [TestData(nameof(CreateThrows_Data))]
        void CreateThrows(Type in1) {

            Object result = default;

            TestX.If.Action.ThrowsException(() => result = IFactoryExtensions.Create(in1), out Exception _);

            TestX.If.Object.IsNull(result);

        }

        IEnumerable<Object[]> CreateThrows_Data() {
            yield return new Object[] { typeof(Dummies.NotCreatableTestClass) };
        }

        [TestMethod]
        [TestData(nameof(Create_Data))]
        void Create(Type in1) {

            Object result = default;

            TestX.IfNot.Action.ThrowsException(() => result = IFactoryExtensions.Create(in1), out Exception _);

            TestX.IfNot.Object.IsNull(result);
            TestX.If.Object.IsOfExactType(result, in1);

        }

        IEnumerable<Object[]> Create_Data() {
            yield return new Object[] { typeof(Object) };
            yield return new Object[] { typeof(IFactoryExtensions_uTests) };
            yield return new Object[] { typeof(Dummies.TestClass) };
        }

        #endregion

    }
}
