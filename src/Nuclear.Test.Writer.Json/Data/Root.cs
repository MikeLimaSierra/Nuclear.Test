using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Results;

namespace Nuclear.Test.Writer.Json.Data {
    internal class Root {

        #region properties

        [JsonProperty]
        internal IList<Assembly> Assemblies { get; set; } = new List<Assembly>();

        #endregion

        #region ctors

        public Root() { }

        internal Root(IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> results) {
            Throw.If.Object.IsNull(results, nameof(results));

            results
                .GroupBy((key) => key.Key.AssemblyName)
                .Foreach(group => Assemblies.Add(new Assembly(group.Key, group)));
        }

        #endregion

    }
}
