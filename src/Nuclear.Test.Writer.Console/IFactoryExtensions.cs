﻿namespace Nuclear.Test.Writer.Console {

    /// <summary>
    /// Extends <see cref="IFactory"/> with creation functionality for <see cref="IConsoleWriter"/>.
    /// </summary>
    public static class IFactoryExtensions {

        /// <summary>
        /// Creates a new instance of <see cref="IConsoleWriter"/>.
        /// </summary>
        /// <param name="this">The <see cref="IFactory"/> instance.</param>
        /// <param name="object">The created <see cref="IConsoleWriter"/> instance.</param>
        /// <param name="verbosity">The <see cref="Verbosity"/> of the console print-out.</param>
        /// <param name="colors">The color scheme to be used for printing.</param>
        public static void Create(this IFactory @this, out IConsoleWriter @object, Verbosity verbosity, ColorScheme colors) => @object = new Writer(verbosity, colors);

    }
}
