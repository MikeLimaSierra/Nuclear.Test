using System;

using Newtonsoft.Json;

namespace Nuclear.Test.Console.Configurations {

    internal class ClientConfig {

        #region properties

        [JsonProperty]
        internal String ProxyDirectory { get; set; } = "%APPDATA%/Nuclear.Test.Proxy/";

        [JsonProperty]
        internal String ProxyExecutableName { get; set; } = "Nuclear.Test.Proxy.exe";

        [JsonProperty]
        internal String WorkerDirectory { get; set; } = "%APPDATA%/Nuclear.Test.Worker/";

        [JsonProperty]
        internal String WorkerExecutableName { get; set; } = "Nuclear.Test.Worker.exe";

        [JsonProperty]
        internal Boolean StartClientVisible { get; set; } = false;

        [JsonProperty]
        internal Boolean AutoShutdown { get; set; } = true;

        [JsonProperty]
        internal Boolean ProxyWritesJsonResultFile { get; set; } = false;

        [JsonProperty]
        internal Boolean WorkerWritesJsonResultFile { get; set; } = false;

        #endregion

    }

}
