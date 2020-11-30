using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Test.Configurations;
using Nuclear.Test.Results;

namespace Nuclear.Test.Link {
    internal partial class Message {

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
        public Boolean TryGetData(out IWorkerClientConfiguration data) {
            data = default;

            if(TryGetData(out FileInfo testAssembly)
                && TryGetData(out Boolean autoShutdown)
                && TryGetData(out Boolean testsInSequence)) {

                data = new WorkerClientConfiguration {
                    TestAssembly = testAssembly,
                    AutoShutdown = autoShutdown,
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

            if(TryGetData(out FileInfo testAssembly)
                && TryGetData(out Boolean autoShutdown)
                && TryGetData(out Boolean assembliesInSequence)
                && TryGetData(out SelectedExecutionRuntimes selectedRuntimes)
                && TryGetData(out DirectoryInfo workerDirectory)
                && TryGetData(out String workerExecutableName)
                && TryGetData(out IWorkerRemoteConfiguration remoteConfig)) {

                data = new ProxyClientConfiguration {
                    TestAssembly = testAssembly,
                    AutoShutdown = autoShutdown,
                    AssembliesInSequence = assembliesInSequence,
                    SelectedRuntimes = selectedRuntimes,
                    WorkerDirectory = workerDirectory,
                    WorkerExecutableName = workerExecutableName,
                    WorkerRemoteConfiguration = remoteConfig
                };
            }

            return data != null;
        }


        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IWorkerRemoteConfiguration data) {
            data = default;

            if(TryGetData(out FileInfo executable)
                && TryGetData(out Boolean startClientVisible)
                && TryGetData(out IWorkerClientConfiguration clientConfiguration)) {

                data = new WorkerRemoteConfiguration {
                    Executable = executable,
                    StartClientVisible = startClientVisible,
                    ClientConfiguration = clientConfiguration
                };
            }

            return data != null;
        }

        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IProxyRemoteConfiguration data) {
            data = default;

            if(TryGetData(out FileInfo executable)
                && TryGetData(out Boolean startClientVisible)
                && TryGetData(out IProxyClientConfiguration clientConfiguration)) {

                data = new ProxyRemoteConfiguration {
                    Executable = executable,
                    StartClientVisible = startClientVisible,
                    ClientConfiguration = clientConfiguration
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

    }
}
