using System;
using System.Collections;
using System.Collections.Generic;

using TestDataX = Nuclear.TestSite.TestDataAttribute;
using TestMethodX = Nuclear.TestSite.TestMethodAttribute;
using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Temp {
    class MethodHasCorrectData : IEnumerable<Object[]> {

        [TestMethodX]
        [TestDataX(1, "1")]
        [TestDataX(2, "2")]
        [TestDataX(42, "42")]
        [TestDataX(42, "43")]
        [TestDataX(nameof(EmptyProviderField))]
        [TestDataX(nameof(ProviderField))]
        [TestDataX(nameof(EmptyProviderProperty))]
        [TestDataX(nameof(ProviderProperty))]
        [TestDataX(nameof(EmptyProviderMethod))]
        [TestDataX(nameof(ProviderMethod))]
        [TestDataX(typeof(MethodHasCorrectData))]
        [TestDataX(nameof(_EmptyProviderField))]
        [TestDataX(nameof(_ProviderField))]
        [TestDataX(nameof(_EmptyProviderProperty))]
        [TestDataX(nameof(_ProviderProperty))]
        [TestDataX(nameof(_EmptyProviderMethod))]
        [TestDataX(nameof(_ProviderMethod))]
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