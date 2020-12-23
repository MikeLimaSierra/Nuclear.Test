using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Json.Data {
    internal class ExecutionRuntime {

        #region properties

        [JsonProperty]
        internal String Name { get; set; }

        [JsonProperty]
        internal IList<Class> Classes { get; set; } = new List<Class>();

        #endregion

        #region ctors

        public ExecutionRuntime() { }

        internal ExecutionRuntime(String name, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Value.IsFalse(results.Count() > 0, nameof(results));

            Name = name;
            results
                .GroupBy((key) => key.Key.FileName)
                .Foreach(group => Classes.Add(new Class(group.Key, group)));
        }

        #endregion

    }
}
