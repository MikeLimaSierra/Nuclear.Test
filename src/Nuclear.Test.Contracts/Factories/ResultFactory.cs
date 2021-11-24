using System;
using System.Reflection;

using Nuclear.Creation;
using Nuclear.Test.Results;

namespace Nuclear.Test.Factories {

    /// <summary>
    /// Defines a factory for internal implementations.
    /// </summary>
    public abstract class ResultFactory :
        ICreator<ITestEntry, EntryTypes, String, String>,
        ICreator<ITestMethodResult>,
        ICreator<ITestResultEndPoint>,
        ICreator<IResultKey, ITestScenario, MethodInfo>,
        ICreator<IResultKey, ITestScenario, String, String> {

        public abstract void Create(out ITestEntry obj, EntryTypes type, String instruction, String message);

        public abstract Boolean TryCreate(out ITestEntry obj, EntryTypes type, String instruction, String message);

        public abstract Boolean TryCreate(out ITestEntry obj, EntryTypes type, String instruction, String message, out Exception ex);

        public abstract void Create(out ITestMethodResult obj);

        public abstract Boolean TryCreate(out ITestMethodResult obj);

        public abstract Boolean TryCreate(out ITestMethodResult obj, out Exception ex);

        public abstract void Create(out ITestResultEndPoint obj);

        public abstract Boolean TryCreate(out ITestResultEndPoint obj);

        public abstract Boolean TryCreate(out ITestResultEndPoint obj, out Exception ex);

        public abstract void Create(out IResultKey obj, ITestScenario scenario, MethodInfo methodInfo);

        public abstract Boolean TryCreate(out IResultKey obj, ITestScenario scenario, MethodInfo methodInfo);

        public abstract Boolean TryCreate(out IResultKey obj, ITestScenario scenario, MethodInfo methodInfo, out Exception ex);

        public abstract void Create(out IResultKey obj, ITestScenario scenario, String fileName, String methodInfo);

        public abstract Boolean TryCreate(out IResultKey obj, ITestScenario scenario, String fileName, String methodInfo);

        public abstract Boolean TryCreate(out IResultKey obj, ITestScenario scenario, String fileName, String methodInfo, out Exception ex);

    }

}
