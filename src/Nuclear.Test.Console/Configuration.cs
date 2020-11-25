
using System;

using Newtonsoft.Json;

namespace Nuclear.Test.Console {

    internal class Configuration {

        #region constants

        internal const String DEFAULT_FILE_PATH = "%APPDATA%/Nuclear.Test.Console/default.json";

        #endregion

        #region properties

        [JsonProperty]
        internal LocatorConfig Locator { get; set; } = new LocatorConfig();

        [JsonProperty]
        internal ClientConfig Clients { get; set; } = new ClientConfig();

        [JsonProperty]
        internal ExecutionConfig Execution { get; set; } = new ExecutionConfig();

        #endregion

    }

}
