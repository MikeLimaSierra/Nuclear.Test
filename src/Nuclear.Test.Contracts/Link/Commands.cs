using System;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Presents a predefined set of available commands for <see cref="IMessage"/>
    /// </summary>
    public static class Commands {

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
