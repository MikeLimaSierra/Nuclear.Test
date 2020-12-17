using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nuclear.Test.Console.Filters {
    internal class ArchitectureFilterList : FilterList {

        #region properties

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        internal IList<ProcessorArchitecture> Values { get; set; }

        #endregion

    }
}
