using System;
using System.Collections;
using System.Collections.Generic;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Temp {
    class MethodHasCorrectData : IEnumerable<Object[]> {

        [TestMethod]
        [TestParameters(1, "1")]
        [TestParameters(2, "2")]
        [TestParameters(42, "42")]
        [TestParameters(42, "43")]
        [TestData(nameof(EmptyProviderField))]
        [TestData(nameof(ProviderField))]
        [TestData(nameof(EmptyProviderProperty))]
        [TestData(nameof(ProviderProperty))]
        [TestData(nameof(EmptyProviderMethod))]
        [TestData(nameof(ProviderMethod))]
        [TestData(typeof(MethodHasCorrectData))]
        [TestData(nameof(_EmptyProviderField))]
        [TestData(nameof(_ProviderField))]
        [TestData(nameof(_EmptyProviderProperty))]
        [TestData(nameof(_ProviderProperty))]
        [TestData(nameof(_EmptyProviderMethod))]
        [TestData(nameof(_ProviderMethod))]
        void HasCorrectData(Int32 param1, String param2) {

            String @string = param1.ToString();

            TestX.If.Value.IsEqual(param2, @string);

        }

        #region instance providers

        IEnumerable<Object[]> EmptyProviderField = new List<Object[]>();

        IEnumerable<Object[]> ProviderField = new List<Object[]>() { new Object[] { 11, "11" }, new Object[] { 12, "12" }, new Object[] { 142, "142" }, new Object[] { 142, "143" } };

        IEnumerable<Object[]> EmptyProviderProperty => new List<Object[]>();

        IEnumerable<Object[]> ProviderProperty => new List<Object[]>() { new Object[] { 21, "21" }, new Object[] { 22, "22" }, new Object[] { 242, "242" }, new Object[] { 242, "243" } };

        IEnumerable<Object[]> EmptyProviderMethod() => new List<Object[]>();

        IEnumerable<Object[]> ProviderMethod() => new List<Object[]>() { new Object[] { 31, "31" }, new Object[] { 32, "32" }, new Object[] { 342, "342" }, new Object[] { 342, "343" } };

        public IEnumerator<Object[]> GetEnumerator() {
            yield return new Object[] { 41, "41" };
            yield return new Object[] { 42, "42" };
            yield return new Object[] { 442, "442" };
            yield return new Object[] { 442, "443" };
        }

        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

        #endregion

        #region static providers

        static IEnumerable<Object[]> _EmptyProviderField = new List<Object[]>();

        static IEnumerable<Object[]> _ProviderField = new List<Object[]>() { new Object[] { 11, "11" }, new Object[] { 12, "12" }, new Object[] { 142, "142" }, new Object[] { 142, "143" } };

        static IEnumerable<Object[]> _EmptyProviderProperty => new List<Object[]>();

        static IEnumerable<Object[]> _ProviderProperty => new List<Object[]>() { new Object[] { 21, "21" }, new Object[] { 22, "22" }, new Object[] { 242, "242" }, new Object[] { 242, "243" } };

        static IEnumerable<Object[]> _EmptyProviderMethod() => new List<Object[]>();

        static IEnumerable<Object[]> _ProviderMethod() => new List<Object[]>() { new Object[] { 31, "31" }, new Object[] { 32, "32" }, new Object[] { 342, "342" }, new Object[] { 342, "343" } };

        #endregion

    }
}