using System;
using System.Reflection;

using Nuclear.Creation;
using Nuclear.Test.Results;

namespace Nuclear.Test.Factories.Internal {
    internal class ResultFactory : Factories.ResultFactory {

        #region fields

        private readonly ICreator<ITestEntry, EntryTypes, String, String> _entryFactory =
            Factory.Instance.Creator.Create<ITestEntry, EntryTypes, String, String>(
                (in1, in2, in3) => new TestEntry(in1, in2, in3));

        private readonly ICreator<ITestMethodResult> _methodFactory =
            Factory.Instance.Creator.Create<ITestMethodResult>(
                () => new TestMethodResult());

        private readonly ICreator<ITestResultEndPoint> _endPointFactory =
            Factory.Instance.Creator.Create<ITestResultEndPoint>(
                () => new TestResultEndPoint());

        private readonly ICreator<IResultKey, ITestScenario, String, String> _keyFactory =
            Factory.Instance.Creator.Create<IResultKey, ITestScenario, String, String>(
                (in1, in2, in3) => new ResultKey(in1, in2, in3));

        #endregion

        #region methods

        public override void Create(out ITestEntry obj, EntryTypes in1, String in2, String in3)
            => _entryFactory.Create(out obj, in1, in2, in3);

        public override Boolean TryCreate(out ITestEntry obj, EntryTypes in1, String in2, String in3)
            => _entryFactory.TryCreate(out obj, in1, in2, in3);

        public override Boolean TryCreate(out ITestEntry obj, EntryTypes in1, String in2, String in3, out Exception ex)
            => _entryFactory.TryCreate(out obj, in1, in2, in3, out ex);

        public override void Create(out ITestMethodResult obj)
            => _methodFactory.Create(out obj);

        public override Boolean TryCreate(out ITestMethodResult obj)
            => _methodFactory.TryCreate(out obj);

        public override Boolean TryCreate(out ITestMethodResult obj, out Exception ex)
            => _methodFactory.TryCreate(out obj, out ex);

        public override void Create(out ITestResultEndPoint obj)
            => _endPointFactory.Create(out obj);

        public override Boolean TryCreate(out ITestResultEndPoint obj)
            => _endPointFactory.TryCreate(out obj);

        public override Boolean TryCreate(out ITestResultEndPoint obj, out Exception ex)
            => _endPointFactory.TryCreate(out obj, out ex);

        public override void Create(out IResultKey obj, ITestScenario in1, MethodInfo in2)
            => _keyFactory.Create(out obj, in1, in2.DeclaringType.Name, in2.Name);

        public override Boolean TryCreate(out IResultKey obj, ITestScenario in1, MethodInfo in2)
            => _keyFactory.TryCreate(out obj, in1, in2.DeclaringType.Name, in2.Name);

        public override Boolean TryCreate(out IResultKey obj, ITestScenario in1, MethodInfo in2, out Exception ex)
            => _keyFactory.TryCreate(out obj, in1, in2.DeclaringType.Name, in2.Name, out ex);

        public override void Create(out IResultKey obj, ITestScenario in1, String in2, String in3)
            => _keyFactory.Create(out obj, in1, in2, in3);

        public override Boolean TryCreate(out IResultKey obj, ITestScenario in1, String in2, String in3)
            => _keyFactory.TryCreate(out obj, in1, in2, in3);

        public override Boolean TryCreate(out IResultKey obj, ITestScenario in1, String in2, String in3, out Exception ex)
            => _keyFactory.TryCreate(out obj, in1, in2, in3, out ex);

        #endregion

    }
}
