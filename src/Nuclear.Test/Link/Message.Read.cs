using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.Test.Configurations;
using Nuclear.Test.Configurations.Proxy;
using Nuclear.Test.Configurations.Worker;
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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadBoolean();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Boolean).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadByte();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Byte).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadSByte();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(SByte).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadChar();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Char).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadInt16();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Int16).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadUInt16();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(UInt16).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadInt32();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Int32).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadUInt32();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(UInt32).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadInt64();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Int64).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadUInt64();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(UInt64).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadSingle();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Single).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadDouble();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Double).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadDecimal();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Decimal).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = br.ReadString();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(String).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = new FileInfo(br.ReadString());
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(FileInfo).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = new DirectoryInfo(br.ReadString());
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(DirectoryInfo).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    Int32 count = br.ReadInt32();
                    data = br.ReadBytes(count);
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Byte[]).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    Int32 count = br.ReadInt32();
                    data = br.ReadChars(count);
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(Char[]).Format()}", ex);

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
                && TryGetData(out Boolean writeJsonResultFile)
                && TryGetData(out Boolean testsInSequence)) {

                Factory.Instance.Create(out data);
                data.TestAssembly = testAssembly;
                data.AutoShutdown = autoShutdown;
                data.WriteJsonResultFile = writeJsonResultFile;
                data.TestsInSequence = testsInSequence;
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
                && TryGetData(out Boolean writeJsonResultFile)
                && TryGetData(out Boolean assembliesInSequence)
                && TryGetData(out Int32 runtimesCount)) {

                RuntimeInfo[] availableRuntimes = new RuntimeInfo[runtimesCount];

                for(Int32 i = 0; i < runtimesCount; i++) {
                    if(TryGetData(out FrameworkIdentifiers framework)
                        && TryGetData(out String _version)
                        && Version.TryParse(_version, out Version version)) {

                        try {
                            availableRuntimes[i] = new RuntimeInfo(framework, version);

                        } catch(Exception ex) {
                            _log.Error($"Failed to read {typeof(RuntimeInfo).Format()}", ex);

                            return false;
                        }

                    } else { return false; }
                }

                if(TryGetData(out SelectedExecutionRuntimes selectedRuntimes)
                    && TryGetData(out DirectoryInfo workerDirectory)
                    && TryGetData(out String workerExecutableName)
                    && TryGetData(out IWorkerRemoteConfiguration remoteConfig)) {


                    Factory.Instance.Create(out data);
                    data.TestAssembly = testAssembly;
                    data.AutoShutdown = autoShutdown;
                    data.WriteJsonResultFile = writeJsonResultFile;
                    data.AssembliesInSequence = assembliesInSequence;
                    data.AvailableRuntimes = availableRuntimes;
                    data.SelectedRuntimes = selectedRuntimes;
                    data.WorkerDirectory = workerDirectory;
                    data.WorkerExecutableName = workerExecutableName;
                    data.WorkerRemoteConfiguration = remoteConfig;
                }
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

                Factory.Instance.Create(out data);
                data.Executable = executable;
                data.StartClientVisible = startClientVisible;
                data.ClientConfiguration = clientConfiguration;
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

                Factory.Instance.Create(out data);
                data.Executable = executable;
                data.StartClientVisible = startClientVisible;
                data.ClientConfiguration = clientConfiguration;
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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = (EntryTypes) br.ReadInt32();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(EntryTypes).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = (FrameworkIdentifiers) br.ReadInt32();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(FrameworkIdentifiers).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = (ProcessorArchitecture) br.ReadInt32();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(ProcessorArchitecture).Format()}", ex);

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

            using(BinaryReader br = new BinaryReader(Payload, Encoding.Default, true)) {
                try {
                    data = (SelectedExecutionRuntimes) br.ReadInt32();
                    return true;

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(SelectedExecutionRuntimes).Format()}", ex);

                    return false;
                }
            }
        }


        /// <summary>
        /// Tries to read data from the <see cref="Payload"/> <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="data">The data object.</param>
        /// <returns>True if data was found.</returns>
        public Boolean TryGetData(out IResultKey data) {
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


                try {
                    Factory.Instance.Create(out data, asssembly,
                        new RuntimeInfo(tMoniker, tVersion), tArch,
                        new RuntimeInfo(eMoniker, eVersion), eArch,
                        fileName, methodName);

                } catch(Exception ex) {
                    _log.Error($"Failed to read {typeof(IResultKey).Format()}", ex);
                }
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
                Factory.Instance.Create(out data, type, instruction, message);

            } catch(Exception ex) {
                _log.Error($"Failed to read {typeof(ITestEntry).Format()}", ex);
            }

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

            Factory.Instance.Create(out data);
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
        public Boolean TryGetData(out IEnumerable<KeyValuePair<IResultKey, ITestMethodResult>> data) {
            data = default;

            if(!TryGetData(out Int32 count)) {
                return false;
            }

            IList<KeyValuePair<IResultKey, ITestMethodResult>> _data = new List<KeyValuePair<IResultKey, ITestMethodResult>>();

            for(Int32 i = 0; i < count; i++) {
                if(TryGetData(out IResultKey key) && TryGetData(out ITestMethodResult result)) {
                    _data.Add(new KeyValuePair<IResultKey, ITestMethodResult>(key, result));

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
