using System;

namespace Nuclear.Test.Writer.Console {

    /// <summary>
    /// Defines a set of task specific colors when writing test results to console.
    /// </summary>
    public class ColorScheme {

        #region properties

        /// <summary>
        /// Gets the default color scheme for <see cref="IConsoleWriter"/>
        /// </summary>
        public static ColorScheme Default => new ColorScheme() {
            ResultsOk = ConsoleColor.Green,
            ResultsFailed = ConsoleColor.Red,
            StateOk = ConsoleColor.Green,
            StateFailed = ConsoleColor.Red,
            StateEmpty = ConsoleColor.Cyan,
            ResultFailMessage = ConsoleColor.Red,
            NoteMessage = ConsoleColor.Yellow,
            InjectionMessage = ConsoleColor.Cyan,
            IgnoreMessage = ConsoleColor.Cyan,
            ErrorDetails = ConsoleColor.Red,
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
        /// Gets or sets the color used to display the message of a test note.
        /// </summary>
        public ConsoleColor InjectionMessage { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the ignore message of test methods.
        /// </summary>
        public ConsoleColor IgnoreMessage { get; set; }

        /// <summary>
        /// Gets or sets the color used to display the error message of test methods.
        /// </summary>
        public ConsoleColor ErrorDetails { get; set; }

        #endregion

    }
}
