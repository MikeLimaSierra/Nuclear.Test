using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json;

namespace Nuclear.Test.Console.Filters {
    internal class ArchitectureFilterList : FilterList {

        #region properties

        [JsonProperty]
        //[JsonConverter(typeof(StringEnumConverter))]
        internal IList<ProcessorArchitecture> Values { get; set; }

        #endregion

    }
}
