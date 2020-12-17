using System.Collections.Generic;

using Newtonsoft.Json;

namespace Nuclear.Test.Console.Filters {
    internal class RuntimeInfoFilterList : FilterList {

        #region properties

        [JsonProperty]
        internal IList<RuntimeInfoItem> Values { get; set; }

        #endregion

    }
}
