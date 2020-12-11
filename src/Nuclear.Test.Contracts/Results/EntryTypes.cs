namespace Nuclear.Test.Results {

    /// <summary>
    /// Defines a range of supported entry types.
    /// </summary>
    public enum EntryTypes {

        /// <summary>
        /// The entry is a note.
        /// </summary>
        Note,

        /// <summary>
        /// The entry is a test method data injection.
        /// </summary>
        Injection,

        /// <summary>
        /// The entry is an error.
        /// </summary>
        Error,

        /// <summary>
        /// The entry is a positive test result.
        /// </summary>
        ResultOk,

        /// <summary>
        /// The entry is a negative test result.
        /// </summary>
        ResultFail,

    }
}
