using System;
using System.Collections.Generic;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker {
    class TestDataSet_uTests {

        #region construction

        [TestMethod]
        void CtorThrows() {

            TestX.If.Action.ThrowsException(() => new TestDataSet(null), out ArgumentNullException ex);

            TestX.If.Value.IsEqual(ex.ParamName, "data");

        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(Object[] in1, (Boolean hasData, Int32 count, Int32 tCount) expected) {

            TestDataSet sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new TestDataSet(in1), out Exception _);

            TestX.If.Value.IsEqual(sut.HasData, expected.hasData);
            TestX.If.Value.IsEqual(sut.ObjectCount, expected.count);
            TestX.If.Value.IsEqual(sut.LeadingTypeCount, expected.tCount);

        }

        IEnumerable<Object[]> Ctor_Data() {
            yield return new Object[] { new Object[] { }, (false, 0, 0) };
            yield return new Object[] { new Object[] { null }, (true, 1, 0) };
            yield return new Object[] { new Object[] { null, null }, (true, 2, 0) };
            yield return new Object[] { new Object[] { true }, (true, 1, 0) };
            yield return new Object[] { new Object[] { true, true }, (true, 2, 0) };
            yield return new Object[] { new Object[] { typeof(String), null }, (true, 2, 1) };
            yield return new Object[] { new Object[] { typeof(String), null, null }, (true, 3, 1) };
            yield return new Object[] { new Object[] { typeof(String), true }, (true, 2, 1) };
            yield return new Object[] { new Object[] { typeof(String), true, true }, (true, 3, 1) };
            yield return new Object[] { new Object[] { typeof(String), null, typeof(String) }, (true, 3, 1) };
            yield return new Object[] { new Object[] { typeof(String), null, typeof(String), null }, (true, 4, 1) };
            yield return new Object[] { new Object[] { typeof(String), true, typeof(String) }, (true, 3, 1) };
            yield return new Object[] { new Object[] { typeof(String), true, typeof(String), true }, (true, 4, 1) };
            yield return new Object[] { new Object[] { typeof(String), typeof(String), null }, (true, 3, 2) };
            yield return new Object[] { new Object[] { typeof(String), typeof(String), null, null }, (true, 4, 2) };
            yield return new Object[] { new Object[] { typeof(String), typeof(String), true }, (true, 3, 2) };
            yield return new Object[] { new Object[] { typeof(String), typeof(String), true, true }, (true, 4, 2) };
            yield return new Object[] { new Object[] { typeof(String) }, (true, 1, 1) };
            yield return new Object[] { new Object[] { typeof(String), typeof(String) }, (true, 2, 2) };
        }

        #endregion

        #region GetObjects

        [TestMethod]
        [TestData(nameof(GetObjects_Data))]
        void GetObjects(Object[] in1, (Boolean result, Object[] data) expected) {

            TestDataSet sut = new TestDataSet(in1);
            Boolean result = default;
            Object[] data = default;

            TestX.IfNot.Action.ThrowsException(() => result = sut.GetObjects(out data), out Exception _);

            TestX.If.Value.IsEqual(result, expected.result);
            TestX.If.Enumerable.MatchesExactly(data, expected.data);

        }

        IEnumerable<Object[]> GetObjects_Data() {
            return new List<Object[]>() {
                new Object[] { new Object[] { },                                            (false, new Object[] { }) },
                new Object[] { new Object[] { null },                                       (true, new Object[] { null }) },
                new Object[] { new Object[] { null, null },                                 (true, new Object[] { null, null }) },
                new Object[] { new Object[] { true },                                       (true, new Object[] { true }) },
                new Object[] { new Object[] { true, true },                                 (true, new Object[] { true, true }) },
                new Object[] { new Object[] { typeof(String), null },                       (true, new Object[] { typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), null, null },                 (true, new Object[] { typeof(String), null, null }) },
                new Object[] { new Object[] { typeof(String), true },                       (true, new Object[] { typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), true, true },                 (true, new Object[] { typeof(String), true, true }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String) },       (true, new Object[] { typeof(String), null, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String), null }, (true, new Object[] { typeof(String), null, typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String) },       (true, new Object[] { typeof(String), true, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String), true }, (true, new Object[] { typeof(String), true, typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null },       (true, new Object[] { typeof(String), typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null, null }, (true, new Object[] { typeof(String), typeof(String), null, null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true },       (true, new Object[] { typeof(String), typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true, true }, (true, new Object[] { typeof(String), typeof(String), true, true }) },
                new Object[] { new Object[] { typeof(String) },                             (true, new Object[] { typeof(String) }) },
                new Object[] { new Object[] { typeof(String), typeof(String) },             (true, new Object[] { typeof(String), typeof(String) }) },
            };
        }

        [TestMethod]
        [TestData(nameof(GetSplitObjects_Data))]
        void GetSplitObjects(Object[] in1, UInt32 in2, (Boolean result, Type[] types, Object[] data) expected) {

            TestDataSet sut = new TestDataSet(in1);
            Boolean result = default;
            Type[] types = default;
            Object[] data = default;

            TestX.IfNot.Action.ThrowsException(() => result = sut.GetObjects(in2, out types, out data), out Exception _);

            TestX.If.Value.IsEqual(result, expected.result);
            TestX.If.Enumerable.MatchesExactly(types, expected.types);
            TestX.If.Enumerable.MatchesExactly(data, expected.data);

        }

        IEnumerable<Object[]> GetSplitObjects_Data() {
            return new List<Object[]>() {
                new Object[] { new Object[] { }                                           , 0u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { null }                                      , 0u, (true, new Type[] { }, new Object[] { null }) },
                new Object[] { new Object[] { null, null }                                , 0u, (true, new Type[] { }, new Object[] { null, null }) },
                new Object[] { new Object[] { true }                                      , 0u, (true, new Type[] { }, new Object[] { true }) },
                new Object[] { new Object[] { true, true }                                , 0u, (true, new Type[] { }, new Object[] { true, true }) },
                new Object[] { new Object[] { typeof(String), null }                      , 0u, (true, new Type[] { }, new Object[] { typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), null, null }                , 0u, (true, new Type[] { }, new Object[] { typeof(String), null, null }) },
                new Object[] { new Object[] { typeof(String), true }                      , 0u, (true, new Type[] { }, new Object[] { typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), true, true }                , 0u, (true, new Type[] { }, new Object[] { typeof(String), true, true }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String) }      , 0u, (true, new Type[] { }, new Object[] { typeof(String), null, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String), null }, 0u, (true, new Type[] { }, new Object[] { typeof(String), null, typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String) }      , 0u, (true, new Type[] { }, new Object[] { typeof(String), true, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String), true }, 0u, (true, new Type[] { }, new Object[] { typeof(String), true, typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null }      , 0u, (true, new Type[] { }, new Object[] { typeof(String), typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null, null }, 0u, (true, new Type[] { }, new Object[] { typeof(String), typeof(String), null, null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true }      , 0u, (true, new Type[] { }, new Object[] { typeof(String), typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true, true }, 0u, (true, new Type[] { }, new Object[] { typeof(String), typeof(String), true, true }) },
                new Object[] { new Object[] { typeof(String) }                            , 0u, (true, new Type[] { }, new Object[] { typeof(String) }) },
                new Object[] { new Object[] { typeof(String), typeof(String) }            , 0u, (true, new Type[] { }, new Object[] { typeof(String), typeof(String) }) },

                new Object[] { new Object[] { typeof(String), null }                      , 1u, (true, new Type[] { typeof(String) }, new Object[] { null }) },
                new Object[] { new Object[] { typeof(String), null, null }                , 1u, (true, new Type[] { typeof(String) }, new Object[] { null, null }) },
                new Object[] { new Object[] { typeof(String), true }                      , 1u, (true, new Type[] { typeof(String) }, new Object[] { true }) },
                new Object[] { new Object[] { typeof(String), true, true }                , 1u, (true, new Type[] { typeof(String) }, new Object[] { true, true }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String) }      , 1u, (true, new Type[] { typeof(String) }, new Object[] { null, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String), null }, 1u, (true, new Type[] { typeof(String) }, new Object[] { null, typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String) }      , 1u, (true, new Type[] { typeof(String) }, new Object[] { true, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String), true }, 1u, (true, new Type[] { typeof(String) }, new Object[] { true, typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null }      , 2u, (true, new Type[] { typeof(String), typeof(String) }, new Object[] { null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null, null }, 2u, (true, new Type[] { typeof(String), typeof(String) }, new Object[] { null, null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true }      , 2u, (true, new Type[] { typeof(String), typeof(String) }, new Object[] { true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true, true }, 2u, (true, new Type[] { typeof(String), typeof(String) }, new Object[] { true, true }) },
                new Object[] { new Object[] { typeof(String) }                            , 1u, (true, new Type[] { typeof(String) }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), typeof(String) }            , 2u, (true, new Type[] { typeof(String), typeof(String) }, new Object[] { }) },

                new Object[] { new Object[] { typeof(String), null }                      , 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), null, null }                , 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), null, null }) },
                new Object[] { new Object[] { typeof(String), true }                      , 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), true, true }                , 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), true, true }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String) }      , 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), null, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String), null }, 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), null, typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String) }      , 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), true, typeof(String) }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String), true }, 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String), true, typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null }      , 2u - 1u, (true, new Type[] { typeof(String) }, new Object[] { typeof(String), null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null, null }, 2u - 1u, (true, new Type[] { typeof(String) }, new Object[] { typeof(String), null, null }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true }      , 2u - 1u, (true, new Type[] { typeof(String) }, new Object[] { typeof(String), true }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true, true }, 2u - 1u, (true, new Type[] { typeof(String) }, new Object[] { typeof(String), true, true }) },
                new Object[] { new Object[] { typeof(String) }                            , 1u - 1u, (true, new Type[] { }, new Object[] { typeof(String) }) },
                new Object[] { new Object[] { typeof(String), typeof(String) }            , 2u - 1u, (true, new Type[] { typeof(String) }, new Object[] { typeof(String) }) },

                new Object[] { new Object[] { }                                           , 0u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { null }                                      , 0u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { null, null }                                , 0u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { true }                                      , 0u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { true, true }                                , 0u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), null }                      , 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), null, null }                , 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), true }                      , 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), true, true }                , 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String) }      , 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), null, typeof(String), null }, 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String) }      , 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), true, typeof(String), true }, 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null }      , 2u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), typeof(String), null, null }, 2u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true }      , 2u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), typeof(String), true, true }, 2u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String) }                            , 1u + 1u, (false, new Type[] { }, new Object[] { }) },
                new Object[] { new Object[] { typeof(String), typeof(String) }            , 2u + 1u, (false, new Type[] { }, new Object[] { }) },
            };
        }

        #endregion

    }
}
