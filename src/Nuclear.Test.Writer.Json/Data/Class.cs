using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Json.Data {
    internal class Class {

        #region properties

        [JsonProperty]
        internal String Name { get; set; }

        [JsonProperty]
        internal IList<Method> Methods { get; set; } = new List<Method>();

        #endregion

        #region ctors

        public Class() { }

        internal Class(String name, IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(results, nameof(results));
            Throw.If.Value.IsFalse(results.Count() > 0, nameof(results));

            Name = name;
            results
                .Select(result => (result.Key.MethodName, result.Value))
                .Foreach(item => Methods.Add(new Method(item.MethodName, item.Value)));
        }

        #endregion

    }
}
