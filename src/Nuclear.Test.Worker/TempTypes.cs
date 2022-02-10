using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;

namespace Nuclear.Test.Worker {
    public enum EntryTypes {
        Note,
        DataSource,
        Injection,
        Error,
        ResultOk,
        ResultFail,
    }

    public interface IResultEntry {
        EntryTypes EntryType { get; }
        String Instruction { get; }
        String Message { get; }
    }

    public interface IResultEntryCollection : IEnumerable<IResultEntry> {
        Int32 CountEntries { get; }
        Int32 CountRelevantEntries { get; }
        Int32 CountResults { get; }
        Int32 CountResultsOk { get; }
        Int32 CountResultsFailed { get; }
        Int32 CountErrors { get; }
        Boolean IsFailed { get; }
        Boolean IsIgnored { get; }
        Boolean IsEmpty { get; }
        void Add(IResultEntry entry);
    }

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
