using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;
using Nuclear.Test.Results;

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

        #region get bcl type methods

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
        Boolean TryGetData(out FileInfo data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out DirectoryInfo data);

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

        #region get custom type methods

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out IClientConfiguration data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out IWorkerClientConfiguration data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out IProxyClientConfiguration data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out IRemoteConfiguration data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out EntryTypes data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out FrameworkIdentifiers data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out ProcessorArchitecture data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out ITestResultKey data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out ITestEntry data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out ITestMethodResult data);

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        Boolean TryGetData(out IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> data);

        #endregion

        #region append bcl type methods

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Boolean data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Byte data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(SByte data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Char data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Int16 data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(UInt16 data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Int32 data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(UInt32 data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Int64 data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(UInt64 data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Single data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Double data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Decimal data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(String data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(FileInfo data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(DirectoryInfo data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Byte[] data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(Char[] data);

        #endregion

        #region append custom type methods

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(IClientConfiguration data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(IWorkerClientConfiguration data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(IProxyClientConfiguration data);


        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(IRemoteConfiguration data);


        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(EntryTypes data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(FrameworkIdentifiers data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(ProcessorArchitecture data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(SelectedExecutionRuntimes data);


        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(ITestResultKey data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(ITestEntry data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(ITestMethodResult data);

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        IMessage Append(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> data);

        #endregion

    }
}
