using System;
using System.Linq;

using log4net;

using Nuclear.Exceptions;
using Nuclear.Test.Results;
using Nuclear.Test.Writer.Console.Data.Nodes;

namespace Nuclear.Test.Writer.Console {
    internal class Writer : IConsoleWriter {

        #region fields

        private static readonly ILog _log = LogManager.GetLogger(typeof(Writer));

        private readonly Verbosity _verbosity;

        private RootNode _reportRoot;

        private Int32 _countWorkers;

        private Int32 _countAssemblies;

        private Int32 _countMethods;

        private Int32 _countClasses;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the global <see cref="ColorScheme"/>.
        /// </summary>
        internal static ColorScheme Colors { get; set; }

        #endregion

        #region ctors

        internal Writer(Verbosity verbosity, ColorScheme colors) {
            Throw.IfNot.Enum.IsDefined<Verbosity>(verbosity, nameof(verbosity));
            Throw.If.Object.IsNull(colors, nameof(colors));

            _verbosity = verbosity;
            Colors = colors;
        }

        #endregion

        #region IConsoleWriter methods

        public Boolean Load(ITestResultSource source) {
            _log.Debug(nameof(Load));

            if(source == null) {
                return false;
            }

            try {
                _countWorkers = source.GetKeys().Select(key => (key.AssemblyName, key.TargetRuntime, key.TargetArchitecture, key.ExecutionRuntime, key.ExecutionArchitecture)).Distinct().Count();
                _countAssemblies = source.GetKeys().Select(key => (key.AssemblyName, key.TargetRuntime, key.TargetArchitecture)).Distinct().Count();
                _countMethods = source.GetKeys().Select(key => (key.AssemblyName, key.FileName, key.MethodName)).Distinct().Count();
                _countClasses = source.GetKeys().Select(key => (key.AssemblyName, key.FileName)).Distinct().Count();

                _reportRoot = new RootNode(_verbosity, source.GetKeyedResults());

                return true;

            } catch(Exception ex) { _log.Error("Failed to load results.", ex); }

            return false;
        }

        public void Write() {
            _log.Debug(nameof(Write));

            _reportRoot.Write(0);
            ConsoleAdapter.WriteLine($"=> {_countWorkers} workers running {_countAssemblies} test assemblies with {_countMethods} test methods in {_countClasses} classes.");
        }

        #endregion

    }
}
