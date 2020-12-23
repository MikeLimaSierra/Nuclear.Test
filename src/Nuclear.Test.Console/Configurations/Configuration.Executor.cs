using System;

using Newtonsoft.Json;

using Nuclear.Test.Writer.Console;

namespace Nuclear.Test.Console.Configurations {

    internal class ExecutorConfig {

        #region properties

        [JsonProperty]
        internal Verbosity Verbosity { get; set; }

        [JsonProperty]
        internal Boolean WriteReport { get; set; }

        #endregion

    }

}
