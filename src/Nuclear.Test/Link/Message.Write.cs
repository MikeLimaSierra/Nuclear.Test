using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;
using Nuclear.Test.Results;

namespace Nuclear.Test.Link {
    internal partial class Message {

        #region append bcl type methods

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Boolean data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Byte data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(SByte data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Char data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Int16 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(UInt16 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Int32 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(UInt32 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Int64 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(UInt64 data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Single data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Double data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Decimal data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(String data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(FileInfo data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data.FullName);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(DirectoryInfo data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data.FullName);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Byte[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Char[] data) {
            Throw.If.Object.IsNull(data, nameof(data));

            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write(data);
            }

            return this;
        }

        #endregion

        #region append custom type methods

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IWorkerClientConfiguration data) {
            Append(data.TestAssembly);
            Append(data.AutoShutdown);

            Append(data.TestsInSequence);

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IProxyClientConfiguration data) {
            Append(data.TestAssembly);
            Append(data.AutoShutdown);

            Append(data.AssembliesInSequence);
            Append(data.AvailableRuntimes.Count());

            foreach(RuntimeInfo runtime in data.AvailableRuntimes) {
                Append(runtime.Framework);
                Append(runtime.Version.ToString());
            }

            Append(data.SelectedRuntimes);
            Append(data.WorkerDirectory);
            Append(data.WorkerExecutableName);
            Append(data.WorkerRemoteConfiguration);

            return this;
        }


        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IWorkerRemoteConfiguration data) {
            Append(data.Executable);
            Append(data.StartClientVisible);

            Append(data.ClientConfiguration);

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IProxyRemoteConfiguration data) {
            Append(data.Executable);
            Append(data.StartClientVisible);

            Append(data.ClientConfiguration);

            return this;
        }


        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(EntryTypes data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write((Int32) data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(FrameworkIdentifiers data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write((Int32) data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(ProcessorArchitecture data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write((Int32) data);
            }

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(SelectedExecutionRuntimes data) {
            using(BinaryWriter bw = new BinaryWriter(Payload, Encoding.Default, true)) {
                bw.Write((Int32) data);
            }

            return this;
        }


        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(ITestResultKey data) {
            Append(data.AssemblyName);
            Append(data.TargetRuntime.Framework);
            Append(data.TargetRuntime.Version.ToString());
            Append(data.TargetArchitecture);
            Append(data.ExecutionRuntime.Framework);
            Append(data.ExecutionRuntime.Version.ToString());
            Append(data.ExecutionArchitecture);
            Append(data.FileName);
            Append(data.MethodName);

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(ITestEntry data) {
            Append(data.EntryType);

            if(data.EntryType == EntryTypes.ResultOk || data.EntryType == EntryTypes.ResultFail) {
                Append(data.Instruction);
            }

            Append(data.Message);

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(ITestMethodResult data) {
            Append(data.IgnoreReason ?? String.Empty);
            Append(data.TestEntries.Count);
            data.TestEntries.Foreach(entry => Append(entry));

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> data) {
            Append(data.Count());

            foreach(KeyValuePair<ITestResultKey, ITestMethodResult> entry in data) {
                Append(entry.Key);
                Append(entry.Value);
            }

            return this;
        }

        #endregion

    }
}
