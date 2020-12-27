using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using log4net;

using Newtonsoft.Json;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Console.Filters;

namespace Nuclear.Test.Console.Configurations {

    internal class Configuration {

        #region constants

        private const String DEFAULT_FILE_PATH = "%APPDATA%/Nuclear.Test.Console/default.json";

        #endregion

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Configuration));

        #endregion

        #region properties

        internal static Configuration Default => new Configuration() {
            Locator = new LocatorConfig() {
                SearchDirectory = "%USERPROFILE%/source",
                SearchDepth = -1,
                SearchPattern = "*Tests.dll",
                IgnoredDirectoryNames = new List<String>() {
                    "obj",
                    ".vs"
                }
            },
            Executor = new ExecutorConfig() {
                Verbosity = Writer.Console.Verbosity.ExecutionArchitecture,
                WriteReport = false
            },
            Proxy = new ClientConfig() {
                Directory = "%APPDATA%/Nuclear.Test.Proxy/",
                ExecutableName = "Nuclear.Test.Proxy.exe",
                StartClientVisible = false,
                AutoShutdown = true,
                WriteReport = false
            },
            Worker = new ClientConfig() {
                Directory = "%APPDATA%/Nuclear.Test.Worker/",
                ExecutableName = "Nuclear.Test.Worker.exe",
                StartClientVisible = false,
                AutoShutdown = true,
                WriteReport = false
            },
            Execution = new ExecutionConfig() {
                ArchitecturesFilter = new ArchitectureFilterList() {
                    Mode = FilterModes.Blacklist,
                    Values = new List<ProcessorArchitecture>() {
                    ProcessorArchitecture.MSIL,
                    ProcessorArchitecture.IA64,
                    ProcessorArchitecture.Arm,
                    ProcessorArchitecture.None
                }
                },
                RuntimesFilter = new RuntimeInfoFilterList() {
                    Mode = FilterModes.WhiteList,
                    Values = new List<RuntimeInfoItem>() {
                        new RuntimeInfoItem() {
                            Framework = FrameworkIdentifiers.NETCoreApp,
                            Versions = new List<String>() {
                                "2.0",
                                "2.1",
                                "2.2",
                                "3.0",
                                "3.1",
                                "5.0"
                            }
                        },
                        new RuntimeInfoItem() {
                            Framework = FrameworkIdentifiers.NETFramework,
                            Versions = new List<String>() {
                                "4.6.1",
                                "4.6.2",
                                "4.7",
                                "4.7.1",
                                "4.7.2",
                                "4.8"
                            }
                        }
                    }
                },
                AssemblyModeOverride = TestModeOverrides.Auto,
                TestMethodModeOverride = TestModeOverrides.Auto,
                SelectedRuntimes = SelectedExecutionRuntimes.All
            }
        };

        internal static String DefaultFilePath => Environment.ExpandEnvironmentVariables(DEFAULT_FILE_PATH);

        [JsonProperty]
        internal LocatorConfig Locator { get; set; }

        [JsonProperty]
        internal ExecutorConfig Executor { get; set; }

        [JsonProperty]
        internal ClientConfig Proxy { get; set; }

        [JsonProperty]
        internal ClientConfig Worker { get; set; }

        [JsonProperty]
        internal ExecutionConfig Execution { get; set; }

        #endregion

        #region methods

        internal static Boolean TryLoad(out Configuration configuration) => TryLoad(DefaultFilePath, out configuration);

        internal static Boolean TryLoad(String filePath, out Configuration configuration) {
            configuration = null;

            if(File.Exists(filePath)) {
                String json;

                try {
                    json = File.ReadAllText(filePath);

                } catch(Exception ex) {
                    _log.Error($"Failed to load file from {filePath.Format()}.", ex);
                    return false;
                }

                try {
                    configuration = JsonConvert.DeserializeObject<Configuration>(json);

                } catch(Exception ex) {
                    _log.Error($"Failed to deserialize configuration to type {typeof(Configuration).Format()}.", ex);
                    return false;
                }

            } else { _log.Error($"Cannot load configuration. File {filePath.Format()} doesn't exist."); }

            return configuration != null;
        }

        internal Boolean Save() => Save(DefaultFilePath);

        internal Boolean Save(String filePath) {
            String json;

            try {
                json = JsonConvert.SerializeObject(this, Formatting.Indented);

            } catch(Exception ex) {
                _log.Error("Failed to serialize configuration.", ex);
                return false;
            }

            try {
                FileInfo file = new FileInfo(filePath);

                if(!file.Directory.Exists) {
                    Directory.CreateDirectory(file.Directory.FullName);
                }

                File.WriteAllText(filePath, json);

            } catch(Exception ex) {
                _log.Error($"Failed to save file to {filePath.Format()}.", ex);
                return false;
            }

            return true;
        }

        internal IExecutorConfiguration Dump() {

            Factory.Instance.Create(out IWorkerClientConfiguration workerClientConfig);
            workerClientConfig.AutoShutdown = Worker.AutoShutdown;
            workerClientConfig.TestAssembly = null;
            workerClientConfig.TestMethodModeOverride = Execution.TestMethodModeOverride;
            workerClientConfig.WriteReport = Worker.WriteReport;

            Factory.Instance.Create(out IWorkerRemoteConfiguration workerRemoteConfig);
            workerRemoteConfig.ClientConfiguration = workerClientConfig;
            workerRemoteConfig.Executable = null;
            workerRemoteConfig.StartClientVisible = Worker.StartClientVisible;

            Factory.Instance.Create(out IProxyClientConfiguration proxyClientConfiguration);
            proxyClientConfiguration.WorkerRemoteConfiguration = workerRemoteConfig;
            proxyClientConfiguration.AssemblyModeOverride = Execution.AssemblyModeOverride;

            RuntimesHelper.TryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), out IEnumerable<RuntimeInfo> runtimes);
            IEnumerable<RuntimeInfo> filterRuntimes = Execution.RuntimesFilter.Values.SelectMany(ri => ri.Convert());

            proxyClientConfiguration.AvailableRuntimes = runtimes
                .Where(r => Execution.RuntimesFilter.Mode switch {
                    FilterModes.Blacklist => !filterRuntimes.Contains(r),
                    FilterModes.WhiteList => filterRuntimes.Contains(r),
                    _ => false,
                });
            proxyClientConfiguration.AutoShutdown = Proxy.AutoShutdown;
            proxyClientConfiguration.SelectedRuntimes = Execution.SelectedRuntimes;
            proxyClientConfiguration.TestAssembly = null;
            proxyClientConfiguration.WorkerDirectory = new DirectoryInfo(Environment.ExpandEnvironmentVariables(Worker.Directory));
            proxyClientConfiguration.WorkerExecutableName = Worker.ExecutableName;
            proxyClientConfiguration.WriteReport = Proxy.WriteReport;

            Factory.Instance.Create(out IProxyRemoteConfiguration proxyRemoteConfiguration);
            proxyRemoteConfiguration.ClientConfiguration = proxyClientConfiguration;
            proxyRemoteConfiguration.Executable = null;
            proxyRemoteConfiguration.StartClientVisible = Proxy.StartClientVisible;

            Factory.Instance.Create(out IExecutorConfiguration configuration);
            configuration.ProxyRemoteConfiguration = proxyRemoteConfiguration;
            configuration.AvailableArchitectures = Enum.GetValues(typeof(ProcessorArchitecture))
                .Cast<ProcessorArchitecture>()
                .Where(a => Execution.ArchitecturesFilter.Mode switch {
                    FilterModes.Blacklist => !Execution.ArchitecturesFilter.Values.Contains(a),
                    FilterModes.WhiteList => Execution.ArchitecturesFilter.Values.Contains(a),
                    _ => false,
                });
            configuration.ProxyDirectory = new DirectoryInfo(Environment.ExpandEnvironmentVariables(Proxy.Directory));
            configuration.ProxyExecutableName = Proxy.ExecutableName;
            configuration.WriteReport = Executor.WriteReport;

            return configuration;
        }

        #endregion

    }

}
