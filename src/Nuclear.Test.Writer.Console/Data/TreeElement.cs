using System;

using Nuclear.Exceptions;

namespace Nuclear.Test.Writer.Console.Data {
    internal abstract class TreeElement {

        #region properties

        internal String Name { get; set; }

        #endregion

        #region ctors

        public TreeElement(String name) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }

        #endregion

        #region methods

        internal virtual void Write(Int32 padding) {
            ConsoleAdapter.Write($"{String.Empty.PadLeft(padding)}{Name} => ");

            WriteResult();
            WriteDetails();

            ConsoleAdapter.WriteLine();
        }

        protected virtual void WriteResult() { }

        protected virtual void WriteDetails() { }

        #endregion

    }
}