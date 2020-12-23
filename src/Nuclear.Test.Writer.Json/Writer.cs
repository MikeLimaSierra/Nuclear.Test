using System;
using System.IO;

using log4net;

using Newtonsoft.Json;

using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Results;
using Nuclear.Test.Writer.Json.Data;

namespace Nuclear.Test.Writer.Json {
    internal class Writer : IJsonWriter {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Writer));

        private readonly FileInfo _file;

        private Root _reportRoot;

        #endregion

        #region ctors

        internal Writer(FileInfo file) {
            Throw.If.Object.IsNull(file, nameof(file));

            _file = file;
        }

        #endregion

        #region IJsonWriter methods

        public Boolean Load(ITestResultSource source) {
            _log.Debug(nameof(Load));

            if(source == null) {
                return false;
            }

            try {
                _reportRoot = new Root(source.GetKeyedResults());

                return true;

            } catch(Exception ex) { _log.Error("Failed to load results.", ex); }

            return false;
        }

        public void Write() {
            _log.Debug(nameof(Write));

            String json;

            try {
                json = JsonConvert.SerializeObject(_reportRoot, Formatting.Indented);

            } catch(Exception ex) {
                _log.Error("Failed to serialize results.", ex);
                return;
            }

            try {
                if(!_file.Directory.Exists) {
                    Directory.CreateDirectory(_file.Directory.FullName);
                }

                _log.Info($"Writing file to {_file.FullName.Format()}.");

                File.WriteAllText(_file.FullName, json);

            } catch(Exception ex) { _log.Error($"Failed to save results file to {_file.FullName.Format()}.", ex); }
        }

        #endregion

    }
}
