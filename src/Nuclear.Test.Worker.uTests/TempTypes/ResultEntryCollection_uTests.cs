using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.TestSite;

using TestX = Nuclear.TestSite.Test;

namespace Nuclear.Test.Worker.TempTypes {
    class ResultEntryCollection_uTests {

        [TestMethod]
        void Implementation() {

            TestX.If.Type.Implements<ResultEntryCollection, IResultEntryCollection>();

        }

        #region Ctor

        [TestMethod]
        void Ctor() {

            IResultEntryCollection sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new ResultEntryCollection(), out Exception _);

            TestX.If.Enumerable.IsEmpty(sut);

        }

        [TestMethod]
        void CtorWithDataThrows() {

            TestX.If.Action.ThrowsException(() => new ResultEntryCollection(null), out ArgumentNullException _);

        }

        [TestMethod]
        [TestData(nameof(CtorWithData_Data))]
        void CtorWithData(IEnumerable<IResultEntry> in1,
            (Int32 count, Int32 countRE, Int32 countR, Int32 countRO, Int32 countRF, Int32 countE, Boolean isFailed, Boolean isEmpty) expected) {

            IResultEntryCollection sut = default;

            TestX.IfNot.Action.ThrowsException(() => sut = new ResultEntryCollection(in1), out Exception _);

            TestX.If.Enumerable.MatchesExactly(sut, in1, Statics.ResultEntryComparer);
            TestX.If.Value.IsEqual(sut.Count, expected.count);
            TestX.If.Value.IsEqual(sut.CountRelevantEntries, expected.countRE);
            TestX.If.Value.IsEqual(sut.CountResults, expected.countR);
            TestX.If.Value.IsEqual(sut.CountResultsOk, expected.countRO);
            TestX.If.Value.IsEqual(sut.CountResultsFailed, expected.countRF);
            TestX.If.Value.IsEqual(sut.CountErrors, expected.countE);
            TestX.If.Value.IsEqual(sut.IsFailed, expected.isFailed);
            TestX.If.Value.IsEqual(sut.IsEmpty, expected.isEmpty);

        }

        IEnumerable<Object[]> CtorWithData_Data() {
            yield return new Object[] {
                    Enumerable.Empty<IResultEntry>(),
                    (0, 0, 0, 0, 0, 0, false, true)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.DataSource, null, "message") },
                    (1, 0, 0, 0, 0, 0, false, false)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.Error, null, "message") },
                    (1, 1, 0, 0, 0, 1, true, false)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.Injection, null, "message") },
                    (1, 0, 0, 0, 0, 0, false, false)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.Note, null, "message") },
                    (1, 0, 0, 0, 0, 0, false, false)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.ResultOk, "instruction", "message") },
                    (1, 1, 1, 1, 0, 0, false, false)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.ResultFail, "instruction", "message") },
                    (1, 1, 1, 0, 1, 0, true, false)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.Note, null, "message"), new ResultEntry(EntryTypes.Error, null, "message") },
                    (2, 1, 0, 0, 0, 1, true, false)
                };
            yield return new Object[] {
                    new IResultEntry[] { new ResultEntry(EntryTypes.Note, null, "message"), new ResultEntry(EntryTypes.Error, null, "message"), new ResultEntry(EntryTypes.Error, null, "message") },
                    (3, 2, 0, 0, 0, 2, true, false)
                };
            yield return new Object[] {
                    new IResultEntry[] {
                        new ResultEntry(EntryTypes.DataSource, null, "message"),
                        new ResultEntry(EntryTypes.Injection, null, "message"),
                        new ResultEntry(EntryTypes.Note, null, "message"),
                        new ResultEntry(EntryTypes.ResultOk, "instruction", "message"),
                        new ResultEntry(EntryTypes.ResultFail, "instruction", "message"),
                        new ResultEntry(EntryTypes.Error, null, "message"),
                        new ResultEntry(EntryTypes.ResultFail, "instruction", "message"),
                        new ResultEntry(EntryTypes.ResultOk, "instruction", "message"),
                        new ResultEntry(EntryTypes.Injection, null, "message"),
                        new ResultEntry(EntryTypes.Error, null, "message"),
                        new ResultEntry(EntryTypes.ResultOk, "instruction", "message"),
                        new ResultEntry(EntryTypes.ResultFail, "instruction", "message"),
                        new ResultEntry(EntryTypes.ResultOk, "instruction", "message"),
                        new ResultEntry(EntryTypes.Note, null, "message"),
                        new ResultEntry(EntryTypes.ResultOk, "instruction", "message")
                    },
                    (15, 10, 8, 5, 3, 2, true, false)
                };
        }

        #endregion

    }
}
