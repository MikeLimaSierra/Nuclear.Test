using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Nuclear.Exceptions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Json.PrinterData {
    internal class Method {

        #region properties

        [JsonProperty]
        internal String Name { get; set; }

        [JsonProperty]
        internal IList<Entry> Entries { get; set; } = new List<Entry>();

        [JsonProperty]
        internal String IgnoreReason { get; set; }

        #endregion

        #region ctors

        public Method() { }

        internal Method(String name, ITestMethodResult method) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(method, nameof(method));

            Name = name;
            Entries = new List<Entry>(method.TestEntries.Select(e => new Entry(e)));
            IgnoreReason = method.IgnoreReason;
        }

        #endregion

    }
}
