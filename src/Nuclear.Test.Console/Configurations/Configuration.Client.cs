using System;

using Newtonsoft.Json;

namespace Nuclear.Test.Console.Configurations {

    internal class ClientConfig {

        #region properties

        [JsonProperty]
        internal String Directory { get; set; }

        [JsonProperty]
        internal String ExecutableName { get; set; }

        [JsonProperty]
        internal Boolean StartClientVisible { get; set; }

        [JsonProperty]
        internal Boolean AutoShutdown { get; set; }

        [JsonProperty]
        internal Boolean WriteReport { get; set; }

        #endregion

    }

}
