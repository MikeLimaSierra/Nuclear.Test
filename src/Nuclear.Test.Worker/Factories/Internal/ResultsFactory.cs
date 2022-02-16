﻿using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Creation;
using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker.Factories.Internal {
    internal class ResultsFactory : Factories.ResultsFactory {

        #region fields

        private static ICreator<IResultEntry, EntryTypes, String, String> _resultEntry =
            Factory.Instance.Creator.Create<IResultEntry, EntryTypes, String, String>((in1, in2, in3) => new ResultEntry(in1, in2, in3));

        private static ICreator<IResultEntryCollection> _resultEntryCollection =
            Factory.Instance.Creator.Create<IResultEntryCollection>(() => new ResultEntryCollection());

        private static ICreator<IResultEntryCollection, IEnumerable<IResultEntry>> _resultEntryCollectionWithData =
            Factory.Instance.Creator.Create<IResultEntryCollection, IEnumerable<IResultEntry>>((in1) => new ResultEntryCollection(in1));

        private static ICreator<ITestMethodResults, String> _testMethodResults =
            Factory.Instance.Creator.Create<ITestMethodResults, String>((in1) => new TestMethodResults(in1));

        private static ICreator<IScenario, String, RuntimeInfo, ProcessorArchitecture, RuntimeInfo, ProcessorArchitecture> _scenario =
            Factory.Instance.Creator.Create<IScenario, String, RuntimeInfo, ProcessorArchitecture, RuntimeInfo, ProcessorArchitecture>(
                (in1, in2, in3, in4, in5) => new Scenario(in1, in2, in3, in4, in5));

        private static ICreator<IResultKey, IScenario, String, String> _resultKey =
            Factory.Instance.Creator.Create<IResultKey, IScenario, String, String>((in1, in2, in3) => new ResultKey(in1, in2, in3));

        #endregion

        #region IResultEntry

        public override void Create(out IResultEntry obj, EntryTypes in1, String in2, String in3)
            => _resultEntry.Create(out obj, in1, in2, in3);

        public override Boolean TryCreate(out IResultEntry obj, EntryTypes in1, String in2, String in3)
            => _resultEntry.TryCreate(out obj, in1, in2, in3);

        public override Boolean TryCreate(out IResultEntry obj, EntryTypes in1, String in2, String in3, out Exception ex)
            => _resultEntry.TryCreate(out obj, in1, in2, in3, out ex);

        #endregion

        #region IResultEntryCollection

        public override void Create(out IResultEntryCollection obj)
            => _resultEntryCollection.Create(out obj);

        public override Boolean TryCreate(out IResultEntryCollection obj)
            => _resultEntryCollection.TryCreate(out obj);

        public override Boolean TryCreate(out IResultEntryCollection obj, out Exception ex)
            => _resultEntryCollection.TryCreate(out obj, out ex);

        public override void Create(out IResultEntryCollection obj, IEnumerable<IResultEntry> in1)
            => _resultEntryCollectionWithData.Create(out obj, in1);

        public override Boolean TryCreate(out IResultEntryCollection obj, IEnumerable<IResultEntry> in1)
            => _resultEntryCollectionWithData.TryCreate(out obj, in1);

        public override Boolean TryCreate(out IResultEntryCollection obj, IEnumerable<IResultEntry> in1, out Exception ex)
            => _resultEntryCollectionWithData.TryCreate(out obj, in1, out ex);

        #endregion

        #region ITestMethodResults

        public override void Create(out ITestMethodResults obj, String in1)
            => _testMethodResults.Create(out obj, in1);

        public override Boolean TryCreate(out ITestMethodResults obj, String in1)
            => _testMethodResults.TryCreate(out obj, in1);

        public override Boolean TryCreate(out ITestMethodResults obj, String in1, out Exception ex)
            => _testMethodResults.TryCreate(out obj, in1, out ex);

        #endregion

        #region IScenario

        public override void Create(out IScenario obj, String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5)
            => _scenario.Create(out obj, in1, in2, in3, in4, in5);

        public override Boolean TryCreate(out IScenario obj, String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5)
            => _scenario.TryCreate(out obj, in1, in2, in3, in4, in5);

        public override Boolean TryCreate(out IScenario obj, String in1, RuntimeInfo in2, ProcessorArchitecture in3, RuntimeInfo in4, ProcessorArchitecture in5, out Exception ex)
            => _scenario.TryCreate(out obj, in1, in2, in3, in4, in5, out ex);

        #endregion

        #region IResultKey

        public override void Create(out IResultKey obj, IScenario in1, String in2, String in3)
            => _resultKey.Create(out obj, in1, in2, in3);

        public override Boolean TryCreate(out IResultKey obj, IScenario in1, String in2, String in3)
            => _resultKey.TryCreate(out obj, in1, in2, in3);

        public override Boolean TryCreate(out IResultKey obj, IScenario in1, String in2, String in3, out Exception ex)
            => _resultKey.TryCreate(out obj, in1, in2, in3, out ex);

        #endregion

    }
}
