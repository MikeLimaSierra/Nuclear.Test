﻿using System;
using System.Collections.Generic;

namespace Nuclear.Test.Worker.Dummies {
    internal class TestDataSources {

        internal IEnumerable<Object[]> SingleReturnSingleData() {
            yield return new Object[] { "A" };
        }

        internal IEnumerable<Object[]> SingleReturnTripleData() {
            yield return new Object[] { "A", 42, "B" };
        }

        internal IEnumerable<Object[]> TripleReturnSingleData() {
            yield return new Object[] { "A" };
            yield return new Object[] { "B" };
            yield return new Object[] { "C" };
        }

        internal IEnumerable<Object[]> TripleReturnTripleData() {
            yield return new Object[] { "A", 42, "B" };
            yield return new Object[] { "C", 43, "D" };
            yield return new Object[] { "E", 44, "F" };
        }

        internal IEnumerable<Object[]> TripleReturnMixedData() {
            yield return new Object[] { "A", 42, "B", new DateTime(2022, 2, 3), null, 'a', new Object[] { "A", "B" }, typeof(Object) };
            yield return new Object[] { "C", 43, "D", new DateTime(2023, 2, 3), null, 'b', new Object[] { "B", "C" }, typeof(String) };
            yield return new Object[] { "E", 44, "F", new DateTime(2024, 2, 3), null, 'c', new Object[] { "C", "D" }, typeof(Int32) };
        }

        internal IEnumerable<Object[]> TripleReturnWithDummyException() {
            yield return new Object[] { "A" };
            yield return new Object[] { "B" };
            yield return new Object[] { "C" };
            throw new TestException();
        }

        internal IEnumerable<Object[]> Method_OneA_Data() {
            yield return new Object[] { "A" };
            yield return new Object[] { "B" };
            yield return new Object[] { "C" };
        }

        internal IEnumerable<Object[]> Method_TwoA_Data() {
            yield return new Object[] { "A", 0 };
            yield return new Object[] { "B", 1 };
            yield return new Object[] { "C", 2 };
        }

        internal IEnumerable<Object[]> Method_OneG_NoA_Data() {
            yield return new Object[] { typeof(Int16) };
            yield return new Object[] { typeof(Int32) };
            yield return new Object[] { typeof(Int64) };
        }

        internal IEnumerable<Object[]> Method_OneG_OneA_Data() {
            yield return new Object[] { typeof(Int16), "A" };
            yield return new Object[] { typeof(Int32), "B" };
            yield return new Object[] { typeof(Int64), "C" };
        }

        internal IEnumerable<Object[]> Method_TwoG_TwoA_Data() {
            yield return new Object[] { typeof(Int16), typeof(UInt16), "A", 0 };
            yield return new Object[] { typeof(Int32), typeof(UInt32), "B", 1 };
            yield return new Object[] { typeof(Int64), typeof(UInt64), "C", 2 };
        }
    }
}
