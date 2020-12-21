using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Printer.Json.PrinterData {
    internal class Assembly {

        #region properties

        [JsonProperty]
        internal String Name { get; set; }

        [JsonProperty]
        internal IList<TargetRuntime> TargetRuntimes { get; set; } = new List<TargetRuntime>();

        #endregion

        #region ctors

        public Assembly() { }

        internal Assembly(String name, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Value.IsFalse(results.Count() > 0, nameof(results));

            Name = name;
            results
                .GroupBy((key) => $"{key.Key.TargetRuntime.Framework} v{key.Key.TargetRuntime.Version} [{key.Key.TargetArchitecture}]")
                .Foreach(group => TargetRuntimes.Add(new TargetRuntime(group.Key, group)));
        }

        #endregion

    }
}
