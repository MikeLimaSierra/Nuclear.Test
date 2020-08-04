using System;
using System.IO;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Defines a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public interface IMessage : IDisposable {

        #region properties

        /// <summary>
        /// Gets the command.
        /// </summary>
        String Command { get; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        MemoryStream Payload { get; }

        #endregion

        #region methods

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Boolean data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Byte data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out SByte data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Char data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Int16 data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out UInt16 data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Int32 data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out UInt32 data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Int64 data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out UInt64 data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Single data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Double data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Decimal data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out String data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Byte[] data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out Char[] data);

        #endregion

    }
}
