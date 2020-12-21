using System.IO;

namespace Nuclear.Test.Writer.Json {

    /// <summary>
    /// Extends <see cref="IFactory"/> with creation functionality for <see cref="IJsonWriter"/>.
    /// </summary>
    public static class IFactoryExtensions {

        /// <summary>
        /// Creates a new instance of <see cref="IJsonWriter"/>.
        /// </summary>
        /// <param name="this">The <see cref="IFactory"/> instance.</param>
        /// <param name="object">The created <see cref="IJsonWriter"/> instance.</param>
        /// <param name="file">The <see cref="FileInfo"/> where the resulting json file should be stored.</param>
        public static void Create(this IFactory @this, out IJsonWriter @object, FileInfo file) => @object = new Writer(file);

    }
}
