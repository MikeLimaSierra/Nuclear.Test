using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Nuclear.Test.Console {

    internal class LocatorConfig {

        #region properties

        [JsonProperty]
        internal String SearchDirectory { get; set; } = "%USERPROFILE%/source";

        [JsonProperty]
        internal Int32 SearchDepth { get; set; } = -1;

        [JsonProperty]
        internal String SearchPattern { get; set; } = "*Tests.dll";

        [JsonProperty]
        internal IList<String> IgnoredDirectoryNames { get; set; } = new List<String>() { "obj", ".vs" };

        #endregion

    }

}
