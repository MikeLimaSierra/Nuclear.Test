namespace Nuclear.Test {

    /// <summary>
    /// Implements a factory for internal implementations.
    /// </summary>
    public class Factory {

        #region properties

        /// <summary>
        /// Gets the static factory instance.
        /// </summary>
        public static IFactory Instance { get; } = new InternalFactory();

        #endregion

    }
}
