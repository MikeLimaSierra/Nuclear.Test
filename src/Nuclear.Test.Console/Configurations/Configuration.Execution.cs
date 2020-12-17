using System;
using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Nuclear.Test.Configurations;
using Nuclear.Test.Console.Filters;

namespace Nuclear.Test.Console {

    internal class ExecutionConfig {

        #region properties

        [JsonProperty]
        internal ArchitectureFilterList ArchitecturesFilter { get; set; } = new ArchitectureFilterList() {
            Mode = FilterModes.Blacklist,
            Values = new List<ProcessorArchitecture>() { ProcessorArchitecture.MSIL, ProcessorArchitecture.IA64, ProcessorArchitecture.Arm, ProcessorArchitecture.None }
        };

        [JsonProperty]
        internal RuntimeInfoFilterList RuntimesFilter { get; set; } = new RuntimeInfoFilterList() {
            Mode = FilterModes.WhiteList,
            Values = new List<RuntimeInfoItem>() {
                new RuntimeInfoItem() {
                    Framework = Assemblies.Runtimes.FrameworkIdentifiers.NETCoreApp,
                    Versions = new List<String>() { "2.0", "2.1", "2.2", "3.0", "3.1", "5.0" }
                },
                new RuntimeInfoItem() {
                    Framework = Assemblies.Runtimes.FrameworkIdentifiers.NETFramework,
                    Versions = new List<String>() { "4.6.1", "4.6.2", "4.7", "4.7.1", "4.7.1", "4.8" }
                }
            }
        };

        [JsonProperty]
        internal Boolean AssembliesInSequence { get; set; } = false;

        [JsonProperty]
        internal Boolean TestsInSequence { get; set; } = false;

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal SelectedExecutionRuntimes SelectedRuntimes { get; set; } = SelectedExecutionRuntimes.All;

        #endregion

    }

}
