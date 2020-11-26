using System;
using System.IO;

using log4net;

using Newtonsoft.Json;

using Nuclear.Extensions;

namespace Nuclear.Test.Console {

    internal class Configuration {

        #region constants

        private const String DEFAULT_FILE_PATH = "%APPDATA%/Nuclear.Test.Console/default.json";

        #endregion

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Configuration));

        #endregion

        #region properties

        internal static String DefaultFilePath => Environment.ExpandEnvironmentVariables(DEFAULT_FILE_PATH);

        [JsonProperty]
        internal LocatorConfig Locator { get; set; } = new LocatorConfig();

        [JsonProperty]
        internal ClientConfig Clients { get; set; } = new ClientConfig();

        [JsonProperty]
        internal ExecutionConfig Execution { get; set; } = new ExecutionConfig();

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

        #endregion

    }

}
