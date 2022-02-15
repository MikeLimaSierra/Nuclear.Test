using System.Collections.Generic;

using Nuclear.Extensions;
using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker {
    internal static class Statics {

        internal static IEqualityComparer<IResultEntry> ResultEntryComparer { get; }

        static Statics() {
            ResultEntryComparer = DynamicEqualityComparer.FromDelegate<IResultEntry>(
                (x, y) => x.EntryType == y.EntryType && x.Instruction == y.Instruction && x.Message == y.Message,
                (obj) => obj.GetHashCode()
            );
        }

    }
}
