using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Nuclear.Assemblies.Runtimes;

namespace Nuclear.Test.Console.Filters {
    internal class RuntimeInfoItem {

        #region properties

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal FrameworkIdentifiers Framework { get; set; }

        [JsonProperty]
        internal IList<String> Versions { get; set; }

        #endregion

        #region method

        internal IEnumerable<RuntimeInfo> Convert() => Versions
            .Where(v => Version.TryParse(v, out Version _))
            .Select(v => new RuntimeInfo(Framework, Version.Parse(v)));

        #endregion

    }
}
