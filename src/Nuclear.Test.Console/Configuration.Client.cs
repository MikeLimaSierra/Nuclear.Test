using System;

using Newtonsoft.Json;

namespace Nuclear.Test.Console {

    internal class ClientConfig {

        #region properties

        [JsonProperty]
        internal String ProxyDirectory { get; set; }

        [JsonProperty]
        internal String ProxyExecutableName { get; set; }

        [JsonProperty]
        internal String WorkerDirectory { get; set; }

        [JsonProperty]
        internal String WorkerExecutableName { get; set; }

        [JsonProperty]
        internal Boolean StartClientVisible { get; set; }

        [JsonProperty]
        internal Boolean AutoShutdown { get; set; }

        #endregion

    }

}
