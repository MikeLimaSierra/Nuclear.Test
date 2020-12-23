﻿using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Nuclear.Test.Configurations;
using Nuclear.Test.Console.Filters;

namespace Nuclear.Test.Console.Configurations {

    internal class ExecutionConfig {

        #region properties

        [JsonProperty]
        internal ArchitectureFilterList ArchitecturesFilter { get; set; }

        [JsonProperty]
        internal RuntimeInfoFilterList RuntimesFilter { get; set; }

        [JsonProperty]
        internal Boolean AssembliesInSequence { get; set; }

        [JsonProperty]
        internal Boolean TestsInSequence { get; set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal SelectedExecutionRuntimes SelectedRuntimes { get; set; }

        #endregion

    }

}
