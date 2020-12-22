using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Nuclear.Test.Console.Configurations {

    internal class LocatorConfig {

        #region properties

        [JsonProperty]
        internal String SearchDirectory { get; set; }

        [JsonProperty]
        internal Int32 SearchDepth { get; set; }

        [JsonProperty]
        internal String SearchPattern { get; set; }

        [JsonProperty]
        internal IList<String> IgnoredDirectoryNames { get; set; }

        #endregion

    }

}
