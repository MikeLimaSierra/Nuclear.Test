﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Nuclear.Exceptions;
using Nuclear.Test.Configurations;
using Nuclear.Test.NetVersions;
using Nuclear.TestSite.Results;

namespace Nuclear.Test.TestExecution {
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
        protected ITestResultsEndPoint Results { get; set; }

        /// <summary>
        /// Gets or sets the header content as a <see cref="List{String}"/>.
        /// </summary>
        protected List<String> HeaderContent { get; set; } = new List<String>();

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TestExecutor"/>
        /// </summary>
        /// <param name="results">The test results sink to use.</param>
        public TestExecutor(ITestResultsEndPoint results) {
            Throw.If.Null(results, "results");

            Results = results;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Execute tests.
        /// </summary>
        /// <returns>The collective results of all executed tests.</returns>
        public virtual TestResultMap Execute() {
            Assembly entryAsm = Assembly.GetEntryAssembly();
            AssemblyName entryAsmName = entryAsm.GetName();
            (NetPlatforms platform, Version version) entryAsmtargetRuntime = NetVersionTree.GetTargetRuntimeFromAssembly(entryAsm);

            PrintProcessInfo(entryAsmName, entryAsmtargetRuntime);
            Console.Title = String.Format("{0} - {1} - {2}", entryAsmtargetRuntime, entryAsmName.ProcessorArchitecture, entryAsmName.Name);

            return Results.ResultMap;
        }

        #endregion

        #region print methods

        protected void PrintProcessInfo(AssemblyName asmName, (NetPlatforms platform, Version version) targetRuntime) {

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

        protected void PrintAssemblyInfo(AssemblyName asmName, (NetPlatforms platform, Version version) targetRuntime) {
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