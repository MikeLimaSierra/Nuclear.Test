using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Nuclear.Test.Writer.Console;

namespace Nuclear.Test.Console.Configurations {

    internal class ExecutorConfig {

        #region properties

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal Verbosity Verbosity { get; set; }

        [JsonProperty]
        internal Boolean WriteReport { get; set; }

        #endregion

    }

}
