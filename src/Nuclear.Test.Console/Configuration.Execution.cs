using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Nuclear.Test.Configurations;

namespace Nuclear.Test.Console {

    internal class ExecutionConfig {

        #region properties

        [JsonProperty]
        internal Boolean AssembliesInSequence { get; set; }

        [JsonProperty]
        internal Boolean TestsInSequence { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(StringEnumConverter))]
        internal SelectedExecutionRuntimes SelectedRuntimes { get; set; }

        #endregion

    }

}
