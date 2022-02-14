namespace Nuclear.Test.Worker.TempTypes {

    /// <summary>
    /// Defines a range of supported entry types.
    /// </summary>
    public enum EntryTypes {

        /// <summary>
        /// The entry is a note.
        /// </summary>
        Note,

        /// <summary>
        /// The entry marks the injection of data from a data source.
        /// </summary>
        DataSource,

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
