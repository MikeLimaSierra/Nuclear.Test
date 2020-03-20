using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Nuclear.Assemblies;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;
using Nuclear.Test.Results;

namespace Nuclear.Test.TestExecution {

    /// <summary>
    /// Implements the base functionality of any test client.
    /// </summary>
    public class TestExecutor {

        #region properties

        /// <summary>
        /// Configuration values for test execution.
        /// </summary>
        public TestConfiguration TestConfiguration { get; protected set; } = new TestConfiguration();

        /// <summary>
        /// Configuration values for output and logging.
        /// </summary>
        public OutputConfiguration OutputConfiguration { get; protected set; } = new OutputConfiguration();

        /// <summary>
        /// Gets the test results sink that is in use.
        /// </summary>
        protected ITestResultEndPoint Results { get; } = new TestResultEndPoint();

        /// <summary>
        /// Gets or sets the header content as a <see cref="List{String}"/>.
        /// </summary>
        protected List<String> HeaderContent { get; set; } = new List<String>();

        /// <summary>
        /// Gets the entry assembly of the current process.
        /// </summary>
        protected Assembly EntryAssembly { get; private set; }

        /// <summary>
        /// Gets the entry assembly name of the current process.
        /// </summary>
        protected AssemblyName EntryAssemblyName { get; private set; }

        /// <summary>
        /// Gets the runtime of the current process.
        /// </summary>
        protected RuntimeInfo Runtime { get; private set; }

        /// <summary>
        /// Gets the runtime architecture.
        /// </summary>
        protected ProcessorArchitecture RuntimeArchitecure { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestExecutor"/>.
        /// </summary>
        public TestExecutor() {
            EntryAssembly = Assembly.GetEntryAssembly();
            EntryAssemblyName = EntryAssembly.GetName();

            if(RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo current)) {
                Runtime = current;
            }

            RuntimeArchitecure = Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Execute tests.
        /// </summary>
        /// <returns>The collective results of all executed tests.</returns>
        public virtual ITestResultEndPoint Execute() {
            PrintProcessInfo();
            Console.Title = String.Format("{0} - {1} - {2}", Runtime, RuntimeArchitecure, EntryAssemblyName.Name);

            return Results;
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Prints an information panel to console that details the currently running executor instance.
        /// </summary>
        protected void PrintProcessInfo() {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");

            foreach(String line in HeaderContent) {
                sb.AppendFormat("║    {1}    ║{0}", Environment.NewLine, line.PadRight(60, ' '));
            }

            sb.AppendLine(@"╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat(@"║        Platform: {1}    ║{0}", Environment.NewLine, Runtime.Framework.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║         Version: {1}    ║{0}", Environment.NewLine, Runtime.Version.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║    Architecture: {1}    ║{0}", Environment.NewLine, RuntimeArchitecure.ToString().PadRight(48, ' '));
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        /// <summary>
        /// Prints an information panel to console that details the currently loaded test assembly.
        /// </summary>
        /// <param name="asmName"></param>
        /// <param name="targetRuntime"></param>
        protected void PrintAssemblyInfo(AssemblyName asmName, RuntimeInfo targetRuntime) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine(@"║                             Test Assembly                            ║");
            sb.AppendLine(@"╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat(@"║            Name: {1}    ║{0}", Environment.NewLine, asmName.Name.PadRight(48, ' '));
            sb.AppendFormat(@"║        Platform: {1}    ║{0}", Environment.NewLine, targetRuntime.Framework.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║         Version: {1}    ║{0}", Environment.NewLine, targetRuntime.Version.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║    Architecture: {1}    ║{0}", Environment.NewLine, asmName.ProcessorArchitecture.ToString().PadRight(48, ' '));
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        #endregion
    }
}
