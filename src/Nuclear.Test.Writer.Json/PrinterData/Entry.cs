using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Nuclear.Exceptions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Json.PrinterData {
    internal class Entry {

        #region properties

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal EntryTypes EntryType { get; set; }

        [JsonProperty]
        internal String Instruction { get; set; }

        [JsonProperty]
        internal String Message { get; set; }

        #endregion

        #region ctors

        public Entry() { }

        internal Entry(ITestEntry entry) {
            Throw.If.Object.IsNull(entry, nameof(entry));

            EntryType = entry.EntryType;
            Instruction = entry.Instruction;
            Message = entry.Message;
        }

        #endregion

    }
}
