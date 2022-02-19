using System;
using System.Collections.Generic;

using Nuclear.Test.Worker.TempTypes;

namespace Nuclear.Test.Worker {
    public interface IResultCollection : IEnumerable<KeyValuePair<IResultKey, IResultEntry>> {
        void Add(IResultKey key, ITestMethodResults results);
    }
}
