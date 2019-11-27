using System;

namespace Nuclear.Test.ConsolePrinter.Tree {
    internal abstract class TreeElement {

        #region properties

        internal PrintVerbosity Verbosity { get; private set; }

        internal abstract Int32 Padding { get; }

        internal abstract String Title { get; }

        #endregion

        #region ctors

        internal TreeElement(PrintVerbosity verbosity) {
            Verbosity = verbosity;
        }

        #endregion

        #region methods

        protected void PrintTitle() => Console.Write("{0}{1} => ", String.Empty.PadLeft(Padding), Title);

        internal abstract void Print();

        protected void Print(String format, params Object[] args) => Console.Write(format, args);

        protected void Print(ConsoleColor color, String format, params Object[] args) {
            Console.ForegroundColor = color;
            Print(format, args);
            Console.ResetColor();
        }

        protected void PrintResult(Boolean result) {
            ConsoleColor color = result ? ConsoleColor.Green : ConsoleColor.Red;
            String content = result ? "ok" : "failed";

            Print(color, content);
        }

        protected void PrintEOL() => Console.WriteLine();

        #endregion

    }
}
