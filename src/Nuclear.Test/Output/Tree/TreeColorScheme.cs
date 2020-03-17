using System;

namespace Nuclear.Test.ConsolePrinter.Tree {

    /// <summary>
    /// Defines a set of task specific colors when printing a test result tree to console.
    /// </summary>
    public class TreeColorScheme {

        #region properties

        /// <summary>
        /// Gets the default color scheme for <see cref="ResultTree"/>
        /// </summary>
        public static TreeColorScheme Default => new TreeColorScheme() {
            ResultsOk = ConsoleColor.Green,
            ResultsFailed = ConsoleColor.Red,
            StateOk = ConsoleColor.Green,
            StateFailed = ConsoleColor.Red,
            StateEmpty = ConsoleColor.Cyan,
            ResultFailMessage = ConsoleColor.Red,
            NoteMessage = ConsoleColor.Yellow,
            IgnoreMessage = ConsoleColor.Cyan,
            ExceptionDetails = ConsoleColor.Red,
        };

        /// <summary>
        /// Gets or sets the color used to display the count of successful results.
        /// </summary>
        public ConsoleColor ResultsOk { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the count of failed results.
        /// </summary>
        public ConsoleColor ResultsFailed { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the 'ok' state on any level.
        /// </summary>
        public ConsoleColor StateOk { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the 'failed' state on any level.
        /// </summary>
        public ConsoleColor StateFailed { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the state of test methods without results.
        /// </summary>
        public ConsoleColor StateEmpty { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the fail message of test results.
        /// </summary>
        public ConsoleColor ResultFailMessage { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the message of a test note.
        /// </summary>
        public ConsoleColor NoteMessage { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the ignore message of test methods.
        /// </summary>
        public ConsoleColor IgnoreMessage { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the exceptional fail message of test methods.
        /// </summary>
        public ConsoleColor ExceptionDetails { get; set; }

        #endregion

    }
}
