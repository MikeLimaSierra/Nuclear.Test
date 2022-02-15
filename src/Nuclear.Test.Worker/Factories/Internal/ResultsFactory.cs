using System;
using System.Collections.Generic;

using Nuclear.Creation;
using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker.Factories.Internal {
    class ResultsFactory : Factories.ResultsFactory {

        #region fields

        private static ICreator<IResultEntry, EntryTypes, String, String> _resultEntry =
            Factory.Instance.Creator.Create<IResultEntry, EntryTypes, String, String>((in1, in2, in3) => new ResultEntry(in1, in2, in3));

        private static ICreator<IResultEntryCollection> _resultEntryCollection =
            Factory.Instance.Creator.Create<IResultEntryCollection>(() => new ResultEntryCollection());

        private static ICreator<IResultEntryCollection, IEnumerable<IResultEntry>> _resultEntryCollectionWithData =
            Factory.Instance.Creator.Create<IResultEntryCollection, IEnumerable<IResultEntry>>((in1) => new ResultEntryCollection(in1));

        private static ICreator<ITestMethodResults, String> _testMethodResults =
            Factory.Instance.Creator.Create<ITestMethodResults, String>((in1) => new TestMethodResults(in1));

        #endregion

        #region IResultEntry

        public override void Create(out IResultEntry obj, EntryTypes type, String instruction, String message)
            => _resultEntry.Create(out obj, type, instruction, message);

        public override Boolean TryCreate(out IResultEntry obj, EntryTypes type, String instruction, String message)
            => _resultEntry.TryCreate(out obj, type, instruction, message);

        public override Boolean TryCreate(out IResultEntry obj, EntryTypes type, String instruction, String message, out Exception ex)
            => _resultEntry.TryCreate(out obj, type, instruction, message, out ex);

        #endregion

        #region IResultEntryCollection

        public override void Create(out IResultEntryCollection obj)
            => _resultEntryCollection.Create(out obj);

        public override Boolean TryCreate(out IResultEntryCollection obj)
            => _resultEntryCollection.TryCreate(out obj);

        public override Boolean TryCreate(out IResultEntryCollection obj, out Exception ex)
            => _resultEntryCollection.TryCreate(out obj, out ex);

        public override void Create(out IResultEntryCollection obj, IEnumerable<IResultEntry> collection)
            => _resultEntryCollectionWithData.Create(out obj, collection);

        public override Boolean TryCreate(out IResultEntryCollection obj, IEnumerable<IResultEntry> collection)
            => _resultEntryCollectionWithData.TryCreate(out obj, collection);

        public override Boolean TryCreate(out IResultEntryCollection obj, IEnumerable<IResultEntry> collection, out Exception ex)
            => _resultEntryCollectionWithData.TryCreate(out obj, collection, out ex);

        #endregion

        #region ITestMethodResults

        public override void Create(out ITestMethodResults obj, String ignoreReason)
            => _testMethodResults.Create(out obj, ignoreReason);

        public override Boolean TryCreate(out ITestMethodResults obj, String ignoreReason)
            => _testMethodResults.TryCreate(out obj, ignoreReason);

        public override Boolean TryCreate(out ITestMethodResults obj, String ignoreReason, out Exception ex)
            => _testMethodResults.TryCreate(out obj, ignoreReason, out ex);

        #endregion

    }
}
