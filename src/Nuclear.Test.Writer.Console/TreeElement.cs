using System;

namespace Nuclear.Test.Printer {
    internal abstract class TreeElement {

        #region properties

        internal Verbosity Verbosity { get; private set; }

        internal abstract String Title { get; }

        #endregion

        #region ctors

        internal TreeElement(Verbosity verbosity) {
            Verbosity = verbosity;
        }

        #endregion

        #region methods

        internal virtual void Print(Int32 padding) {
            PrintTitle(padding);
            PrintResult();
            PrintDetails();
            WriteEOL();
        }

        protected virtual void PrintTitle(Int32 padding) => Console.Write("{0}{1} => ", String.Empty.PadLeft(padding), Title);

        protected abstract void PrintResult();

        protected abstract void PrintDetails();

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