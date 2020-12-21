using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Json.Data {
    internal class TargetRuntime {

        #region properties

        [JsonProperty]
        internal String Name { get; set; }

        [JsonProperty]
        internal IList<ExecutionRuntime> ExecutionRuntimes { get; set; } = new List<ExecutionRuntime>();

        #endregion

        #region ctors

        public TargetRuntime() { }

        internal TargetRuntime(String name, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Value.IsFalse(results.Count() > 0, nameof(results));

            Name = name;
            results
                .GroupBy((key) => $"{key.Key.ExecutionRuntime.Framework} v{key.Key.ExecutionRuntime.Version} [{key.Key.ExecutionArchitecture}]")
                .Foreach(group => ExecutionRuntimes.Add(new ExecutionRuntime(group.Key, group)));
        }

        #endregion

    }
}
