namespace Nuclear.Test.Configurations {

    /// <summary>
    /// Defines possible test mode overrides.
    /// </summary>
    public enum TestModeOverrides {

        /// <summary>
        /// Test execution is done the way it is configured in the tests.
        /// </summary>
        Auto,

        /// <summary>
        /// Test execution is forced to be sequential.
        /// </summary>
        Sequential,
    }
}
