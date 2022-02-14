using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker {



    public interface ITestMethodResults : IResultEntryCollection {
        String IgnoreReason { get; }
        void Ignore(String message);
    }

    public interface IResultKey : IEquatable<IResultKey>, IComparable<IResultKey> {
        String AssemblyName { get; }
        RuntimeInfo TargetRuntime { get; }
        ProcessorArchitecture TargetArchitecture { get; }
        RuntimeInfo ExecutionRuntime { get; }
        ProcessorArchitecture ExecutionArchitecture { get; }
        String FileName { get; }
        String MethodName { get; }
    }

    public interface IResultCollection : IEnumerable<KeyValuePair<IResultKey, IResultEntry>> {
        void Add(IResultKey key, ITestMethodResults results);
    }

    public interface IResultsSink {
        void AddNote(String message, String _file, String _method);
        void AddResult(Boolean result, String testInstruction, String message, String _file, String _method);
    }
}
