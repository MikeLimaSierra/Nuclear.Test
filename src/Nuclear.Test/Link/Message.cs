using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Results;

namespace Nuclear.Test.Link {

    /// <summary>
    /// Implements a message that can be transmitted between <see cref="ILink"/> instances.
    /// </summary>
    public class Message : IMessage {

        #region properties

        /// <summary>
        /// Gets the command.
        /// </summary>
        public String Command { get; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        public MemoryStream Payload { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new empty instance of <see cref="Message"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="command"/> is null or empty.</exception>
        /// <param name="command">The message command.</param>
        public Message(String command) {
            Throw.If.String.IsNullOrWhiteSpace(command, nameof(command));

            Command = command;
            Payload = new MemoryStream();
        }

        #endregion

        #region get bcl type methods

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Boolean data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadBoolean();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Byte data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadByte();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out SByte data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadSByte();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Char data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadChar();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Int16 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadInt16();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out UInt16 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadUInt16();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Int32 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out UInt32 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadUInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Int64 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadInt64();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out UInt64 data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadUInt64();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Single data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadSingle();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Double data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadDouble();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Decimal data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadDecimal();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out String data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = br.ReadString();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out FileInfo data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = new FileInfo(br.ReadString());
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out DirectoryInfo data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = new DirectoryInfo(br.ReadString());
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Byte[] data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    Int32 count = br.ReadInt32();
                    data = br.ReadBytes(count);
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out Char[] data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    Int32 count = br.ReadInt32();
                    data = br.ReadChars(count);
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        #endregion

        #region get custom type methods

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IClientConfiguration data) {
            data = default;

            if(TryGetData(out String identifier) && identifier == ClientConfiguration.FILE && TryGetData(out FileInfo file)
                && TryGetData(out identifier) && identifier == ClientConfiguration.AUTO_SHUTDOWN && TryGetData(out Boolean autoShutdown)) {
                data = new ClientConfiguration {
                    File = file,
                    AutoShutdown = autoShutdown
                };
            }

            return data != null;
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IWorkerClientConfiguration data) {
            data = default;

            if(TryGetData(out String identifier) && identifier == WorkerClientConfiguration.TESTS_IN_SEQUENCE && TryGetData(out Boolean testsInSequence)) {
                data = new WorkerClientConfiguration {
                    TestsInSequence = testsInSequence
                };
            }

            return data != null;
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IProxyClientConfiguration data) {
            data = default;

            if(TryGetData(out String identifier) && identifier == ProxyClientConfiguration.ASSEMBLIES_IN_SEQUENCE && TryGetData(out Boolean assembliesInSequence)
                && TryGetData(out identifier) && identifier == ProxyClientConfiguration.SELECTED_RUNTIMES && TryGetData(out SelectedExecutionRuntimes selectedRuntimes)
                && TryGetData(out identifier) && identifier == ProxyClientConfiguration.WORKER_DIRECTORY && TryGetData(out DirectoryInfo workerDirectory)
                && TryGetData(out identifier) && identifier == ProxyClientConfiguration.WORKER_EXECUTABLE_NAME && TryGetData(out String workerExecutableName)) {
                data = new ProxyClientConfiguration {
                    AssembliesInSequence = assembliesInSequence,
                    SelectedRuntimes = selectedRuntimes,
                    WorkerDirectory = workerDirectory,
                    WorkerExecutableName = workerExecutableName
                };
            }

            return data != null;
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IRemoteConfiguration data) {
            data = default;

            if(TryGetData(out String identifier) && identifier == RemoteConfiguration.START_CLIENT_VISIBLE && TryGetData(out Boolean startClientVisible)) {
                data = new RemoteConfiguration {
                    StartClientVisible = startClientVisible
                };
            }

            return data != null;
        }


        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out EntryTypes data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = (EntryTypes) br.ReadInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out FrameworkIdentifiers data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = (FrameworkIdentifiers) br.ReadInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out ProcessorArchitecture data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = (ProcessorArchitecture) br.ReadInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out SelectedExecutionRuntimes data) {
            data = default;

            using(BinaryReader br = new BinaryReader(Payload)) {
                try {
                    data = (SelectedExecutionRuntimes) br.ReadInt32();
                    return true;

                } catch(Exception) {
                    return false;
                }
            }
        }


        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out ITestResultKey data) {
            data = default;

            if(TryGetData(out String asssembly)
                && TryGetData(out FrameworkIdentifiers tMoniker)
                && TryGetData(out String _tVersion)
                && Version.TryParse(_tVersion, out Version tVersion)
                && TryGetData(out ProcessorArchitecture tArch)
                && TryGetData(out FrameworkIdentifiers eMoniker)
                && TryGetData(out String _eVersion)
                && Version.TryParse(_eVersion, out Version eVersion)
                && TryGetData(out ProcessorArchitecture eArch)
                && TryGetData(out String fileName)
                && TryGetData(out String methodName)) {

                data = new TestResultKey(asssembly,
                    new RuntimeInfo(tMoniker, tVersion), tArch,
                    new RuntimeInfo(eMoniker, eVersion), eArch,
                    fileName, methodName);
            }

            return data != null;
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out ITestEntry data) {
            data = default;

            if(!TryGetData(out EntryTypes type)) {
                return false;
            }

            String instruction = null;
            if((type == EntryTypes.ResultOk || type == EntryTypes.ResultFail) && !TryGetData(out instruction)) {
                return false;
            }

            if(!TryGetData(out String message)) {
                return false;
            }

            try {
                data = new TestEntry(type, instruction, message);

            } catch { }

            return data != null;
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out ITestMethodResult data) {
            data = default;

            if(!TryGetData(out String ignore) || !TryGetData(out Int32 count)) {
                return false;
            }

            data = new TestMethodResult();
            data.Ignore(ignore);

            for(Int32 i = 0; i < count; i++) {
                if(TryGetData(out ITestEntry entry)) {
                    data.TestEntries.Add(entry);

                } else {
                    return false;
                }
            }

            return data != null;
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IEnumerable<KeyValuePair<ITestResultKey, ITestMethodResult>> data) {
            data = default;

            if(!TryGetData(out Int32 count)) {
                return false;
            }

            IList<KeyValuePair<ITestResultKey, ITestMethodResult>> _data = new List<KeyValuePair<ITestResultKey, ITestMethodResult>>();

            for(Int32 i = 0; i < count; i++) {
                if(TryGetData(out ITestResultKey key) && TryGetData(out ITestMethodResult result)) {
                    _data.Add(new KeyValuePair<ITestResultKey, ITestMethodResult>(key, result));

                } else {
                    return false;
                }
            }

            data = _data;
            return true;
        }

        #endregion

        #region append bcl type methods

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(Boolean data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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

            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
        public IMessage Append(IClientConfiguration data) {
            Append(ClientConfiguration.FILE);
            Append(data.File);
            Append(ClientConfiguration.AUTO_SHUTDOWN);
            Append(data.AutoShutdown);

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IWorkerClientConfiguration data) {
            Append(WorkerClientConfiguration.TESTS_IN_SEQUENCE);
            Append(data.TestsInSequence);

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IProxyClientConfiguration data) {
            Append(ProxyClientConfiguration.ASSEMBLIES_IN_SEQUENCE);
            Append(data.AssembliesInSequence);
            Append(ProxyClientConfiguration.SELECTED_RUNTIMES);
            Append(data.SelectedRuntimes);
            Append(ProxyClientConfiguration.WORKER_DIRECTORY);
            Append(data.WorkerDirectory);
            Append(ProxyClientConfiguration.WORKER_EXECUTABLE_NAME);
            Append(data.WorkerExecutableName);

            return this;
        }

        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(IRemoteConfiguration data) {
            Append(RemoteConfiguration.START_CLIENT_VISIBLE);
            Append(data.StartClientVisible);

            return this;
        }


        /// <summary>
        /// Appends <paramref name="data"/> to the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>The current <see cref="IMessage"/>.</returns>
        public IMessage Append(EntryTypes data) {
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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
            using(BinaryWriter bw = new BinaryWriter(Payload)) {
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

            Append(data.EntryType);

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

        #region methods

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override String ToString() => $"{typeof(Message).Format()} ({Command.Format()} => {Payload.Length.Format()} Bytes)";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        #region IDisposable

        private Boolean _disposedValue;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected virtual void Dispose(Boolean disposing) {
            if(!_disposedValue) {
                if(disposing) {
                    Payload?.Dispose();
                    Payload = null;
                }

                _disposedValue = true;
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        #region static creation methods

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command) => new Message(command);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Boolean data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Byte data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, SByte data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Char data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int16 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt16 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int32 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt32 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Int64 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, UInt64 data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Single data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Double data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Decimal data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, String data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Byte[] data) => new Message(command).Append(data);

        /// <summary>
        /// Creates a new instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="command">The message command.</param>
        /// <param name="data">The message payload.</param>
        /// <exception cref="ArgumentNullException">Is thrown when <paramref name="data"/> is null.</exception>
        /// <returns>The new message object.</returns>
        public static IMessage From(String command, Char[] data) => new Message(command).Append(data);

        #endregion

    }
}
