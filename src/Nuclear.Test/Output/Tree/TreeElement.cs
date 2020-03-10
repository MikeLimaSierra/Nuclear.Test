using System;

namespace Nuclear.Test.ConsolePrinter.Tree {
    internal abstract class TreeElement {

        #region properties

        internal abstract Int32 Padding { get; }

        internal abstract String Title { get; }

        #endregion

        #region methods

        protected void PrintTitle() => Console.Write("{0}{1} => ", String.Empty.PadLeft(Padding), Title);

        protected void PrintResult(Boolean result) => Write(result ? ConsoleColor.Green : ConsoleColor.Red, result ? "ok" : "failed");

        internal abstract void PrintResults();

        protected internal static void Write(String format, params Object[] args) => Console.Write(format, args);

        protected internal static void Write(ConsoleColor color, String format, params Object[] args) {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Write(format, args);
            Console.ForegroundColor = defaultColor;
        }

        protected internal static void WriteEOL() => Console.WriteLine();

        #endregion

    }
}
