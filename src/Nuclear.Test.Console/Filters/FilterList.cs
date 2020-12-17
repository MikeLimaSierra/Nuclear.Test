using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nuclear.Test.Console.Filters {
    internal class FilterList {

        #region properties

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal FilterModes Mode { get; set; }

        #endregion

    }
}
