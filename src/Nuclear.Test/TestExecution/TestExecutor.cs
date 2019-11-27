using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Nuclear.Test.Configurations;
using Nuclear.Test.Results;
using Nuclear.TestSite;

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

        #endregion

        #region public methods

        /// <summary>
        /// Execute tests.
        /// </summary>
        /// <returns>The collective results of all executed tests.</returns>
        public virtual ITestResultsSource Execute() {
            Assembly entryAsm = Assembly.GetEntryAssembly();
            AssemblyName entryAsmName = entryAsm.GetName();
            (FrameworkIdentifiers platform, Version version) entryAsmtargetRuntime = NetVersionTree.GetTargetRuntimeFromAssembly(entryAsm);

            PrintProcessInfo(entryAsmName, entryAsmtargetRuntime);
            Console.Title = String.Format("{0} - {1} - {2}", entryAsmtargetRuntime, entryAsmName.ProcessorArchitecture, entryAsmName.Name);

            return Results;
        }

        #endregion

        #region print methods

        /// <summary>
        /// Prints an information panel to console that details the currently running executor instance.
        /// </summary>
        /// <param name="asmName"></param>
        /// <param name="targetRuntime"></param>
        protected void PrintProcessInfo(AssemblyName asmName, (FrameworkIdentifiers platform, Version version) targetRuntime) {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");

            foreach(String line in HeaderContent) {
                sb.AppendFormat("║    {1}    ║{0}", Environment.NewLine, line.PadRight(60, ' '));
            }

            sb.AppendLine(@"╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat(@"║        Platform: {1}    ║{0}", Environment.NewLine, targetRuntime.platform.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║         Version: {1}    ║{0}", Environment.NewLine, targetRuntime.version.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║    Architecture: {1}    ║{0}", Environment.NewLine, asmName.ProcessorArchitecture.ToString().PadRight(48, ' '));
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        /// <summary>
        /// Prints an information panel to console that details the currently loaded test assembly.
        /// </summary>
        /// <param name="asmName"></param>
        /// <param name="targetRuntime"></param>
        protected void PrintAssemblyInfo(AssemblyName asmName, (FrameworkIdentifiers platform, Version version) targetRuntime) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"╔══════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine(@"║                             Test Assembly                            ║");
            sb.AppendLine(@"╠══════════════════════════════════════════════════════════════════════╣");
            sb.AppendFormat(@"║            Name: {1}    ║{0}", Environment.NewLine, asmName.Name.PadRight(48, ' '));
            sb.AppendFormat(@"║        Platform: {1}    ║{0}", Environment.NewLine, targetRuntime.platform.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║         Version: {1}    ║{0}", Environment.NewLine, targetRuntime.version.ToString().PadRight(48, ' '));
            sb.AppendFormat(@"║    Architecture: {1}    ║{0}", Environment.NewLine, asmName.ProcessorArchitecture.ToString().PadRight(48, ' '));
            sb.AppendLine(@"╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write(sb);
        }

        #endregion
    }
}
