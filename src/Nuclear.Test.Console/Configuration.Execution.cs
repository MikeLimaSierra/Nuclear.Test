using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Nuclear.Test.Configurations;

namespace Nuclear.Test.Console {

    internal class ExecutionConfig {

        #region properties

        [JsonProperty]
        internal Boolean AssembliesInSequence { get; set; } = false;

        [JsonProperty]
        internal Boolean TestsInSequence { get; set; } = false;

        [JsonProperty()]
        [JsonConverter(typeof(StringEnumConverter))]
        internal SelectedExecutionRuntimes SelectedRuntimes { get; set; } = SelectedExecutionRuntimes.All;

        #endregion

    }

}
