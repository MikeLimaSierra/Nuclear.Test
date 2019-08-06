using System;
using System.Globalization;
using Nuclear.Test.Configurations;

namespace Nuclear.Test.Output {

    /// <summary>
    /// Quick'n'dirty implementation for console type logging. Will be replaced.
    /// </summary>
    public static class DiagnosticOutput {

        #region fields

        private static readonly Object _lock = new Object();

        #endregion

        #region methods

        /// <summary>
        /// Logs a message to console if configured.
        /// </summary>
        /// <param name="config">The configuration to use.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The parameters.</param>
        public static void Log(OutputConfiguration config, String format, params Object[] args) {
            lock(_lock) {
                if(config.DiagnosticOutput) {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("[*] ");
                    Console.ResetColor();
                    Console.WriteLine(String.Format(CultureInfo.CurrentCulture, format, args));
                }
            }
        }

        /// <summary>
        /// Logs an error to console.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The parameters.</param>
        public static void LogError(String format, params Object[] args) {
            lock(_lock) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[!] ");
                Console.ResetColor();
                Console.WriteLine(String.Format(CultureInfo.CurrentCulture, format, args));
            }
        }

        #endregion

    }
}
