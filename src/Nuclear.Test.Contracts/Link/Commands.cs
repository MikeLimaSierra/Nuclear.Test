using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Presents a predefined set of available commands for <see cref="IMessage"/>
    /// </summary>
    public static class Commands {

        /// <summary>
        /// The message payload contains client setup information.
        /// </summary>
        public const String Setup = "Test.Setup";

        /// <summary>
        /// The client is commanded to execute.
        /// </summary>
        public const String Execute = "Test.Execute";

        /// <summary>
        /// The message payload contains serialized test results.
        /// </summary>
        public const String Results = "Test.Results";

        /// <summary>
        /// The client has finished execution and all results have been transmitted.
        /// </summary>
        public const String Finished = "Test.Finished";

    }

}
