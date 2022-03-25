using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker {
    internal static class Statics {

        internal static IEqualityComparer<IResultEntry> ResultEntryComparer { get; }

        internal static Scenario DefaultScenario { get; } = new Scenario(
            "SomeAssembly",
            new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            ProcessorArchitecture.MSIL,
            new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            ProcessorArchitecture.Amd64);

        static Statics() {
            ResultEntryComparer = DynamicEqualityComparer.FromDelegate<IResultEntry>(
                (x, y) => x.EntryType == y.EntryType && x.Instruction == y.Instruction && x.Message == y.Message,
                (obj) => obj.GetHashCode()
            );
        }

    }
}
