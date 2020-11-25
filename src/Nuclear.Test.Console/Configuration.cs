
using Newtonsoft.Json;

namespace Nuclear.Test.Console {

    internal class Configuration {

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
