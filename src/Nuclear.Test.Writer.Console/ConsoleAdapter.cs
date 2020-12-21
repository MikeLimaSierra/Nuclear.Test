using System;
using System.Collections.Generic;
using System.Text;

namespace Nuclear.Test.Writer.Console {
    internal static class ConsoleAdapter {

        #region methods

        internal static void WriteLine() => System.Console.WriteLine();

        internal static void WriteLine(String format, params Object[] args) => System.Console.WriteLine(format, args);

        internal static void Write(String format, params Object[] args) => System.Console.Write(format, args);

        internal static void Write(ConsoleColor color, String format, params Object[] args) {
            ConsoleColor defaultColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = color;
            System.Console.Write(format, args);
            System.Console.ForegroundColor = defaultColor;
        }

        #endregion

    }
}
