using System;
using System.Globalization;
using Nuclear.Test.Configurations;

namespace Nuclear.Test.Output {
    public static class DiagnosticOutput {

        #region fields

        private static readonly Object _lock = new Object();

        #endregion

        #region methods

        public static void Log(Configuration config, String format, params Object[] args) {
            lock(_lock) {
                if(config.OutputConfiguration.DiagnosticOutput) {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("[*] ");
                    Console.ResetColor();
                    Console.WriteLine(String.Format(CultureInfo.CurrentCulture, format, args));
                }
            }
        }

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
